using MauiKeypad.Converters;
using MauiKeypad.ViewModels;

namespace MauiKeypad;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        BindingContext = new ViewModel();

    }
}

