﻿using System;
using System.Collections.Generic;
using System.Text;
using Platform_Racing_3_Server.Game.Communication.Messages.Incoming.Json;
using Platform_Racing_3_Server.Game.Communication.Messages.Outgoing.Json;
using Platform_Racing_3_Server.Game.Match;

namespace Platform_Racing_3_Server.Game.Communication.Messages.Outgoing
{
    internal class CoinsOutgoingMessage : JsonOutgoingMessage<JsonCoinsOutgoingMessage>
    {
        internal CoinsOutgoingMessage(IReadOnlyCollection<MatchPlayer> matchPlayer) : base(new JsonCoinsOutgoingMessage(matchPlayer))
        {
        }
    }
}
