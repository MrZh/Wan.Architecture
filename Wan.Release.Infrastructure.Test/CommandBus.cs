using System;
using System.Collections.Generic;
using Wan.Release.Infrastructure.Base;

namespace Wan.Release.Infrastructure.Test
{
    public static class CommandBus
    {
        public static void SendCommand(BaseCommand command)
        {
            BaseContext.BaseCommand(command);
            Console.WriteLine(command.CommandId);
        }

        public static void SendCommands(List<BaseCommand> commands)
        {
            BaseContext.BaseTransaction(commands);
        }
    }
}
