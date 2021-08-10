﻿using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Platform_Racing_3_Common.Campaign;
using Platform_Racing_3_Common.Server;
using Platform_Racing_3_Server.Config;
using Platform_Racing_3_Server.Core;
using Platform_Racing_3_Server.Game.Chat;
using Platform_Racing_3_Server.Game.Client;
using Platform_Racing_3_Server.Game.Commands;
using Platform_Racing_3_Server.Game.Communication.Messages;
using Platform_Racing_3_Server.Game.Lobby;
using Platform_Racing_3_Server.Game.Match;
using Platform_Racing_3_Server.Host;
using Platform_Racing_3_Server.Host.Implementation;

namespace Platform_Racing_3_Server.Extensions
{
	public static class HostBuilderExtensions
	{
		public static IHostBuilder ConfigurePlatformRacingServerDefaults(this IHostBuilder builder)
		{
			return builder.ConfigurePlatformRacingServerDefaults(_ => { });
		}

		public static IHostBuilder ConfigurePlatformRacingServerDefaults(this IHostBuilder builder, Action<IServerHostBuilder> configure)
		{
			return builder.ConfigurePlatformRacingServer(hostBuilder =>
			{
				hostBuilder.ConfigureServices((configure, services) =>
				{
					services.AddSingleton<PlatformRacing3Server>();
					services.AddSingleton<CommandManager>();
					services.AddSingleton<MatchManager>();
					services.AddSingleton<PacketManager>();
					services.AddSingleton<ChatRoomManager>();
					services.AddSingleton<MatchListingManager>();
					services.AddSingleton<PacketManager>();
					services.AddSingleton<ServerManager>();
					services.AddSingleton<CampaignManager>();
					services.AddSingleton<ClientManager>();

					services.Configure<ServerConfig>(configure);
				});

				configure(hostBuilder);
			});
		}

		public static IHostBuilder ConfigurePlatformRacingServer(this IHostBuilder builder, Action<IServerHostBuilder> configure)
		{
			builder.ConfigureHostConfiguration(config =>
			{
				config.AddJsonFile("settings.json");
			});

			ServerHostBuilder hostBuilder = new(builder);
			configure(hostBuilder);

			builder.ConfigureServices((context, services) =>
			{
				services.AddHostedService<ServerHostService>();
			});

			return builder;
		}
	}
}
