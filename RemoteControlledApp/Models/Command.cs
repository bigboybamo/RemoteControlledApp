using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlledApp.Models
{
    public class computerCommand

    {
        public int ID { get; set; }
        public string CommandName { get; set; }
        public string CommandDescription { get; set; }
        public string CommandFunc { get; set; }
    }
}
