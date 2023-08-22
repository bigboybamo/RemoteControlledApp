﻿using RemoteControlledApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlledApp.Services
{
    public interface ICommandService

    {
        Task<List<computerCommand>> GetCommand();
    }
}
