using FoodFanatics.ViewModels;

namespace FoodFanatics.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
    }

    public HomePage(RestaurantViewModel restaurantViewModel)
	{
        InitializeComponent();
        BindingContext = restaurantViewModel;
    }
}