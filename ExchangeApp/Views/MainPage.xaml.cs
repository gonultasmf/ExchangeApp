using ExchangeApp.ViewModels;

namespace ExchangeApp;

public partial class MainPage : ContentPage
{
    public MainPage(ExchangesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
