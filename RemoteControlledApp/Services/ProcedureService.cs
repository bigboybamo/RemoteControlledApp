using RemoteControlledApp.Models;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RemoteControlledApp.Services
{
    public class ProcedureService
    {
        public static void RunCommand(UserExcecute userExcecute)
        {
            // Convert the password to a secure string
            SecureString securePassword = new SecureString();
            foreach (char c in userExcecute.Password)
            {
                securePassword.AppendChar(c);
            }

            PSCredential credential = new PSCredential(userExcecute.UserName, securePassword);

            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();

            Pipeline pipeline = runspace.CreatePipeline();

            pipeline.Commands.AddScript(userExcecute.Command);

            pipeline.Commands[0].Parameters.Add("Credential", credential);

            pipeline.Commands[0].Parameters.Add("ComputerName", userExcecute.ComputerName);

            pipeline.Invoke();

            runspace.Close();
        }
    }
}
