using RemoteControlledApp.ViewModels;

namespace RemoteControlledApp.View;

public partial class DropDownDetailPage : ContentPage
{
	public DropDownDetailPage(DropDownDetailPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}