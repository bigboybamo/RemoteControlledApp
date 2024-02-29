using RemoteControlledApp.Models;
using RemoteControlledApp.Services;
using RemoteControlledApp.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace RemoteControlledApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        computerCommand checkCommand = new computerCommand();
        public ObservableCollection<computerCommand> CommandList { get; set; } = new ObservableCollection<computerCommand>();
        public MainPage()
        {
            InitializeComponent();

            CommandList.Add(new computerCommand()
            {
                ID = 1,
                CommandName = "Restart Computer",
                CommandDescription = "Restarts the Computer",
                CommandFunc = "tbd"
            });

            CommandList.Add(new computerCommand()
            {
                ID = 2,
                CommandName = "Lock Computer",
                CommandDescription = "Locks the Computer",
                CommandFunc = "rundll32.exe user32.dll,LockWorkStation"
            });

            CommandList.Add(new computerCommand()
            {
                ID = 3,
                CommandName = "ShutDown",
                CommandDescription = "Shut downs the Computer",
                CommandFunc = "shutdown /s"
            });

            this.BindingContext = this;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
               checkCommand = CommandList.Where(X => X.ID == selectedIndex+1).FirstOrDefault();
            }
        }

        private void ExecuteClicked(object sender, EventArgs e)
        {
            var userCommand = new UserExcecute
            {
                UserName = username.Text,
                Password = password.Text,
                ComputerName = computername.Text,
                Command = checkCommand.CommandFunc
            };
            ProcedureService.RunCommand(userCommand);
        }
    }
}