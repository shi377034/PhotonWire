﻿#pragma warning disable CS1998
// disable Task warning.

using PhotonWire.Sample.ServerApp.GameServer.ReceiveServerHubs;
using PhotonWire.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotonWire.Sample.ServerApp.MasterServer.ServerHubs
{
    // 1. Inherit ServerHub
    // 2. Add HubAttribute
    [Hub(54)]
    public class MasterTutorial : PhotonWire.Server.ServerToServer.ServerHub
    {
        // 3. Create virtual, async method
        // 4. Add OperationAttribute
        [Operation(0)]
        public virtual async Task<int> Multiply(int x, int y)
        {
            return x * y;
        }

        [Operation(1)]
        public virtual async Task Broadcast(string group, string message)
        {
            // Invoke all receive server hubs
            await GetReceiveServerHubProxy<TestReceive>().All.Invoke(x => x.Broadcast(group, message));
        }
    }
}

#pragma warning restore CS1998