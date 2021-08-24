﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Platform_Racing_3_Server.Game.User.Identifiers
{
    internal class GuestIdentifier : IUserIdentifier
    {
        internal uint SocketId { get; set; }
        internal IPAddress IPAddress { get; set; }

        internal GuestIdentifier(uint socketId, IPAddress ipAddress)
        {
            this.SocketId = socketId;
            this.IPAddress = ipAddress;
        }

        public bool Matches(uint userId, uint socketId, IPAddress ipAddress) => this.SocketId == socketId || this.IPAddress.Equals(ipAddress);
    }
}
