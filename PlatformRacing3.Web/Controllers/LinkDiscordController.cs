﻿using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using PlatformRacing3.Common.User;
using PlatformRacing3.Web.Extensions;

namespace PlatformRacing3.Web.Controllers;

[ApiController]
[Route("linkdiscord")]
public class LinkDiscordController : ControllerBase
{
	private const string DISCORD_API_TOKEN = "https://discord.com/api/v6/oauth2/token";
	private const string DISCORD_API_ME = "https://discord.com/api/v6/users/@me";

	[HttpGet]
	[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)] //Dynamic get
	public async Task<ContentResult> GetAsync([FromQuery] string code)
	{
		uint userId = this.HttpContext.IsAuthenicatedPr3User();
		if (userId <= 0)
		{
			return this.Content(@"Please login to the client in the browser! Or <a href=""https://pr3hub.com/login"">click here</a> to do so without the Flash client.", "text/html");
		}

		if (string.IsNullOrWhiteSpace(code))
		{
			PlayerUserData playerUserData = await UserManager.TryGetUserDataByIdAsync(userId);

			return this.Content($@"Are you sure that you want to link your {playerUserData.Username} account to your Discord account?

<a href=""https://discordapp.com/api/oauth2/authorize?response_type=code&client_id={Program.Config.DiscordClientId}&scope=identify"">Click here to proceed</a>", "text/html");
		}

		DiscordTokenResponse tokenResponse = await RequestTokenAsync(code);
		if (!string.IsNullOrWhiteSpace(tokenResponse.Error))
		{
			return this.Content($"Requesting discord token returned the following error: {tokenResponse.ErrorReason}");
		}

		DiscordUserResponse user = await GetUser(tokenResponse);
		if (user.Code != null)
		{
			return this.Content($"Requesting discord profile resulted to the following error: {user.Message}");
		}

		uint linkedToAccount = await UserManager.HasDiscordLinkage(userId, user.Id);
		if (linkedToAccount == 0)
		{
			if (!await UserManager.TryInsertDiscordLinkage(userId, user.Id))
			{
				return this.Content("Oops, something went wrong!");
			}

			return this.Content("All ok! :sunglasses:");
		}
		else
		{
			if (linkedToAccount == userId)
			{
				return this.Content("This account has already been linked to Discord account!");
			}
			else
			{
				return this.Content("This Discord account has already been linked to different account!");
			}
		}

		static async Task<DiscordTokenResponse> RequestTokenAsync(string code)
		{
			Dictionary<string, string> values = new()
			{
				{ "client_id", Program.Config.DiscordClientId },
				{ "client_secret", Program.Config.DiscordClientSecret },

				{ "grant_type", "authorization_code" },
				{ "scope", "identify" },

				{ "code", code },
			};

			using (HttpClient httpClient = new())
			{
				using (FormUrlEncodedContent content = new(values))
				{
					using (HttpResponseMessage message = await httpClient.PostAsync(LinkDiscordController.DISCORD_API_TOKEN, content))
					{
						return JsonSerializer.Deserialize<DiscordTokenResponse>(await message.Content.ReadAsStringAsync());
					}
				}
			}
		}

		static async Task<DiscordUserResponse> GetUser(DiscordTokenResponse tokenResponse)
		{
			using (HttpClient httpClient = new())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenResponse.TokenType, tokenResponse.AccessToken);

				return await httpClient.GetFromJsonAsync<DiscordUserResponse>(LinkDiscordController.DISCORD_API_ME);
			}
		}
	}

	private class DiscordTokenResponse
	{
		[JsonPropertyName("token_type")]
		public string TokenType { get; set; }
		[JsonPropertyName("access_token")]
		public string AccessToken { get; set; }

		[JsonPropertyName("error")]
		public string Error { get; set; }
		[JsonPropertyName("error_description")]
		public string ErrorReason { get; set; }
	}

	private class DiscordUserResponse
	{
		[JsonPropertyName("id")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public ulong Id { get; set; }

		[JsonPropertyName("code")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public uint? Code { get; set; }
		[JsonPropertyName("message")]
		public string Message { get; set; }
	}
}