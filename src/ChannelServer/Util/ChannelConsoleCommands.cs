﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System.Collections.Generic;
using System.Linq;
using Aura.Shared.Util;
using Aura.Shared.Util.Commands;

namespace Aura.Channel.Util
{
    public class ChannelConsoleCommands : ConsoleCommands
    {
        protected override CommandResult HandleStatus(string command, IList<string> args)
        {
            var result = base.HandleStatus(command, args);
            if (result != CommandResult.Okay)
                return result;

            var creatures = ChannelServer.Instance.World.GetAllCreatures();

            Log.Status("Creatures in world: {0}", creatures.Count);
            Log.Status("Players in world: {0}", creatures.Count(a => a.IsPlayer));

            return CommandResult.Okay;
        }
    }
}