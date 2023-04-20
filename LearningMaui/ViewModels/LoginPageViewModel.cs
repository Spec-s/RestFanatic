using CommunityToolkit.Mvvm.ComponentModel;

namespace LearningMaui.ViewModels;

public partial class LoginPageViewModel : BaseViewModel
{
	[ObservableProperty]
	public string userName;

	[ObservableProperty] 
	public string password;
	
}