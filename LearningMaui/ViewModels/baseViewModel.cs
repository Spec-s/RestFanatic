using CommunityToolkit.Mvvm.ComponentModel;

namespace LearningMaui.ViewModels;

public partial class BaseViewModel : ObservableObject
{
	[ObservableProperty]
	public bool isBusy;

	[ObservableProperty]
	public string title;
}