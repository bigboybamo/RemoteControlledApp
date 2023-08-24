using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlledApp.Services
{
    public class ProcedureService
    {
        public static void RunCommand(string anyCommand )
        {
            var proc1 = new ProcessStartInfo();
            proc1.UseShellExecute = true;
            proc1.WorkingDirectory = @"C:\Windows\System32";
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Arguments = "/c " + anyCommand;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);
        }
    }
}
