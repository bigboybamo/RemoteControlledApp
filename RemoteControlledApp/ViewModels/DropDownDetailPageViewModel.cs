using CommunityToolkit.Mvvm.ComponentModel;
using RemoteControlledApp.Interfaces;
using RemoteControlledApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlledApp.ViewModels
{

    public class DropDownDetailPageViewModel: ObservableObject
    {
        public  ObservableCollection<computerCommand> CommandList { get; set; } = new ObservableCollection<computerCommand>();
        private readonly ICommandService _commandService;
        public DropDownDetailPageViewModel(ICommandService commandService)
        {
            _commandService = commandService;
            GetCommandList();
        }
        private  async void GetCommandList()
        {
            var response =  await _commandService.GetCommand();
            if(response?.Count > 0)
            {
                foreach(var command in response)
                {
                    CommandList.Add(command);
                }
            }
        }
    }
}
