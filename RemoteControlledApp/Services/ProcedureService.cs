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
            //proc1.UseShellExecute = true;
            //proc1.WorkingDirectory = @"C:\Windows\System32";
            //proc1.FileName = @"C:\Windows\System32\cmd.exe";
            //proc1.Arguments = "/c " + anyCommand;
            //proc1.WindowStyle = ProcessWindowStyle.Hidden;
            //Process.Start(proc1);


            //ManagementClass processClass = new ManagementClass(@"\\<10.101.210.27>\root\cimv2:Win32_Process");
            //ManagementBaseObject inParams = processClass.GetMethodParameters("Create");

            //inParams["CommandLine"] = anyCommand;
            //inParams["CurrentDirectory"] = @"c:\windows\system32";

            //ManagementBaseObject outParams = processClass.InvokeMethod("Create", inParams, null);

            var hostname = "192.168.1.4"; //hostname or a IpAddress
            var username = @"BAMIJI\BAMIJI"; //hostname or a IpAddress
            var password = "qwerty"; //hostname or a IpAddress

            //var connection = new ConnectionOptions();
            ////The '.\' is for a local user on the remote machine
            ////Or 'mydomain\user' for a domain user
            //connection.Username = "BAMIJI";
            //connection.Password = "qwerty";
            //connection.EnablePrivileges = true;
            //connection.Impersonation = ImpersonationLevel.Impersonate;
            //connection.Authority = "ntlmdomain:" + "BAMIJI";
            //connection.Authentication = AuthenticationLevel.Packet;

            //object[] theProcessToRun = { anyCommand };


            //var wmiScope = new ManagementScope($@"\\{hostname}\root\cimv2", connection);
            //wmiScope.Connect();
            //using (var managementClass = new ManagementClass(wmiScope, new ManagementPath("Win32_Process"), new ObjectGetOptions()))
            //{
            //    managementClass.InvokeMethod("Create", theProcessToRun);
            //}





            var processToRun = new[] { "notepad.exe" };
            var connection = new ConnectionOptions();
            connection.Username = username;
            connection.Password = password;
            connection.EnablePrivileges = true;
            connection.Impersonation = ImpersonationLevel.Impersonate;
            var wmiScope = new ManagementScope(string.Format("\\\\{0}\\root\\cimv2", hostname), connection);
            var wmiProcess = new ManagementClass(wmiScope, new ManagementPath("Win32_Process"), new ObjectGetOptions());
            wmiProcess.InvokeMethod("Create", processToRun);

            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "/C psexec \\192.168.1.4 -u VICTOR -p qwerty net localgroup Administrators testuser /add";
            //process.StartInfo = startInfo;
            //process.Start();
            //process.WaitForExit();

            // Replace these values with the actual IP address, username, and password of the remote machine
            string ipAddress = "192.168.1.4";
            string username = "oyetu";
            string password = "1962";

            // Create a secure string for the password
            var securePassword = new System.Security.SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }

            // Create a PSCredential object with the username and secure password
            var credential = new PSCredential(username, securePassword);

            // Create a PowerShell runspace
            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                // Open the runspace
                runspace.Open();

                // Create a pipeline and associate it with the runspace
                using (var pipeline = runspace.CreatePipeline())
                {
                    // Create a command to execute on the remote machine
                    var command = new Command("Invoke-Command");

                    // Add parameters to the command
                    command.Parameters.Add("ComputerName", ipAddress);
                    command.Parameters.Add("Credential", credential);
                    command.Parameters.Add("ScriptBlock", ScriptBlock.Create("Get-Process"));

                    // Add the command to the pipeline
                    pipeline.Commands.Add(command);

                    // Execute the pipeline (PowerShell command) and collect the results
                    var results = pipeline.Invoke();

                    // Display the results
                    foreach (var result in results)
                    {
                        Console.WriteLine(result.ToString());
                    }


                }

            }
        }
    }
}
