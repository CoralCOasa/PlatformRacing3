﻿using System.Text.Json.Serialization;

namespace PlatformRacing3.Server.Game.Communication.Messages.Incoming.Json;

internal sealed class JsonTokenLoginIncomingMessage : JsonPacket
{
	[JsonPropertyName("login_token")]
	public string LoginToken { get; set; }
}