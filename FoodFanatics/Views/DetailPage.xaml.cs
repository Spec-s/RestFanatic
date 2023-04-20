using FoodFanatics.ViewModels;

namespace FoodFanatics.Views;

public partial class DetailPage : ContentPage
{
    public DetailPage()
    {
    }

    public DetailPage(DetailsViewModel detailsViewModel)
	{
        InitializeComponent();
        BindingContext = detailsViewModel;
	}

  
}