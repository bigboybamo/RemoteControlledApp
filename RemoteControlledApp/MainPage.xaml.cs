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
        string Iptext = "";
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
                CommandFunc = "tbd"
            });

            this.BindingContext = this;

            Entry entry = new Entry { Placeholder = "Enter text" };
            entry.TextChanged += OnEntryTextChanged;
            entry.Completed += OnEntryCompleted;

        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
            Iptext = entry.Text;
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            Iptext = ((Entry)sender).Text;
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

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            CommandLabelIP.Text = Iptext;
            CommandLabelName.Text = checkCommand.CommandDescription;
            ProcedureService.RunCommand(checkCommand.CommandFunc);


        }
    }
}