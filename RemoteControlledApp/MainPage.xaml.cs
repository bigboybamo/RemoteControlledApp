using RemoteControlledApp.Models;
using RemoteControlledApp.ViewModels;
using System.Collections.ObjectModel;

namespace RemoteControlledApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

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
                CommandFunc = "tbd"
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
            string myText = entry.Text;
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}