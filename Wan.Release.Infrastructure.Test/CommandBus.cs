using System;
using Wan.Release.Infrastructure.Base;

namespace Wan.Release.Infrastructure.Test
{
   public class CommandBus
   {
       public static void SendCommand(BaseCommand command)
       {
            
            Console.WriteLine(command.CommandId);
       }
   }
}
