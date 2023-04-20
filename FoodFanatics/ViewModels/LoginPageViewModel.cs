using CommunityToolkit.Mvvm.Input;
using FoodFanatics.Views;

namespace FoodFanatics.ViewModels;

public partial class LoginPageViewModel : BaseViewModels
{
    public Command LoginBtn { get; }
    private readonly INavigation _navigation;

    [RelayCommand]
    public async void EnterBtnTappedAsync(object obj)
    {
        await this._navigation.PushAsync(new HomePage());
    }
    public LoginPageViewModel(INavigation navigation)
    {
        this._navigation = navigation;
        

    }

}