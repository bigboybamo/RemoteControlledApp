using RemoteControlledApp.Interfaces;
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
                ID = 1,
                CommandName = "Restart Computer",
                CommandDescription = "Restarts the Computer",
                CommandFunc = "tbd"
            },
             new computerCommand()
            {
                 ID = 2,
                CommandName = "Lock Computer",
                CommandDescription = "Locks the Computer",
                CommandFunc = "rundll32.exe user32.dll,LockWorkStation"
            },
             new computerCommand()
             {
                 ID = 3,
                 CommandName = "ShutDown",
                 CommandDescription= "Shut downs the Computer",
                 CommandFunc = "shutdown /s"
             }

        };
        public Task<List<computerCommand>> GetCommand()
        {
            return Task.FromResult(commands);
        }
    }
}
