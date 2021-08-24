﻿using System.Text.Json.Serialization;
using Platform_Racing_3_Server.Game.Communication.Messages.Incoming.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platform_Racing_3_Server.Game.Communication.Messages.Outgoing.Json
{
    internal sealed class JsonFinishDrawingOutgoingMessage : JsonPacket
    {
        private protected override string InternalType => "finishDrawing";

        [JsonPropertyName("socketID")]
        public uint SocketId { get; set; }

        internal JsonFinishDrawingOutgoingMessage(uint socketId)
        {
            this.SocketId = socketId;
        }
    }
}
