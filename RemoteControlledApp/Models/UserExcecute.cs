using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlledApp.Models
{
    public class UserExcecute
    {
        public string ComputerName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Command { get; set; }
    }
}
