﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Platform_Racing_3_Server_API.Net
{
    public interface INetworkConnection : IDisposable
    {
        bool Disconnected { get; }

        uint SocketId { get; }
        IPAddress RemoteAddress { get; }

        TimeSpan LastRead { get; }

        event NetworkEvents.OnDisconnect OnDisconnect;

        void StartListening();
        void Send(byte[] data, int offset = 0, int? length = default);
        void Disconnect(string reason = default);
    }
}
