using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RemoteControlledApp.Services
{
    public class ProcedureService
    {
        public static void RunCommand(string anyCommand)
        {
            var proc1 = new ProcessStartInfo();
            proc1.UseShellExecute = true;
            proc1.WorkingDirectory = @"C:\Windows\System32";
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Arguments = "/c " + anyCommand;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);

            ManagementClass processClass = new ManagementClass(@"\\<10.101.210.27>\root\cimv2:Win32_Process");
            ManagementBaseObject inParams = processClass.GetMethodParameters("Create");

            inParams["CommandLine"] = anyCommand;
            inParams["CurrentDirectory"] = @"c:\windows\system32";

            ManagementBaseObject outParams = processClass.InvokeMethod("Create", inParams, null);

        }
    }
}
