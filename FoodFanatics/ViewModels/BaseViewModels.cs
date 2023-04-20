using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Globalization;

namespace FoodFanatics.ViewModels;

public partial class BaseViewModels : ObservableObject
{
    [ObservableProperty]
    public string title;

    [ObservableProperty]
	[NotifyPropertyChangedFor(nameof(IsNotLoading))]
	public bool isLoading;
	public bool IsNotLoading => !isLoading;
	
}