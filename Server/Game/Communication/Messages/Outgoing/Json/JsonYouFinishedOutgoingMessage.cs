﻿using System.Text.Json.Serialization;
using Platform_Racing_3_Server.Game.Communication.Messages.Incoming.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platform_Racing_3_Server.Game.Communication.Messages.Outgoing.Json
{
    internal sealed class JsonYouFinishedOutgoingMessage : JsonPacket
    {
        public override string Type => "youFinished";

        [JsonPropertyName("rank")]
        public ulong Rank { get; set; }

        [JsonPropertyName("curExp")]
        public ulong CurExp { get; set; }

        [JsonPropertyName("maxExp")]
        public ulong MaxExp { get; set; }

        [JsonPropertyName("totExpGain")]
        public ulong TotExpGain { get; set; }

        [JsonPropertyName("expArray")]
        public IReadOnlyCollection<object[]> ExpArray { get; set; }

        [JsonPropertyName("place")]
        public int Place { get; set; }

        internal JsonYouFinishedOutgoingMessage(uint rank, ulong curExp, ulong maxExp, ulong totExpGain, IReadOnlyCollection<object[]> expArray, int place)
        {
            this.Rank = rank;
            this.CurExp = curExp;
            this.MaxExp = maxExp;
            this.TotExpGain = totExpGain;
            this.ExpArray = expArray;
            this.Place = place;
        }
    }
}
