using CommunityToolkit.Mvvm.Input;

namespace FoodFanatics.Views;

public partial class LoginPage : ContentPage
{
    private readonly INavigation _navigation;

    public LoginPage()
	{
		InitializeComponent();
	}


    [RelayCommand]
    private async void EnterBtnTappedAsync(object obj)
    {
        await this._navigation.PushAsync(new HomePage());
    }
}