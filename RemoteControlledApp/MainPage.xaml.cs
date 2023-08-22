namespace RemoteControlledApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;


        public MainPage()
        {
            InitializeComponent();
            Entry entry = new Entry { Placeholder = "Enter text" };
            entry.TextChanged += OnEntryTextChanged;
            entry.Completed += OnEntryCompleted;

            var monkeyList = new List<string>();
            monkeyList.Add("Shutdown");
            monkeyList.Add("Lock Computer");

            Picker picker = new Picker { Title = "Select a Command" };
            picker.ItemsSource = monkeyList;
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