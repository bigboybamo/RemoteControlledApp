using RemoteControlledApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlledApp.Services
{
    public class CommandService : ICommandService
    {
        private static List<computerCommand> commands = new List<computerCommand>()
        {
            new computerCommand()
            {
                commandName = "Restart Computer",
                commandDescription = "Restarts the Computer",
                commandFunc = "tbd"
            },
             new computerCommand()
            {
                commandName = "Lock Computer",
                commandDescription = "Locks the Computer",
                commandFunc = "tbd"
            }

        };
        public Task<List<computerCommand>> GetCommand()
        {
            return Task.FromResult(commands);
        }
    }
}
