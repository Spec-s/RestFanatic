using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FoodFanatics.Models;
using FoodFanatics.Services;
using FoodFanatics.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FoodFanatics.ViewModels;

public partial class RestaurantViewModel : BaseViewModels
{
	public ObservableCollection<Restaurant> Restaurants { get; private set; } = new();
	private readonly RestaurantApiService RestaurantApiService;
	//NetworkAccess accessType = Connectivity.Current.NetworkAccess;

    public RestaurantViewModel(RestaurantApiService restaurantApiService)
	{
		title = "Restaurants List";
		restaurantApiService.GetRestaurants().Wait();
        RestaurantApiService = restaurantApiService;
    }

	[ObservableProperty]
	bool isRefreshing;

	[ObservableProperty]
	string restaurantname;
	[ObservableProperty]
	string details;
    [ObservableProperty]
    string image;
    [ObservableProperty]
    string location;

    [RelayCommand]
	async Task GetRestaurantList()
	{
		if (isLoading) return;
		try
		{
			isLoading = true;
			if(Restaurants.Any()) Restaurants.Clear();
			var restaurants = new List<Restaurant>();
			//calling from the restaurant model
			restaurants = await RestaurantApiService.GetRestaurants();

			foreach (var restaurant in Restaurants)
			{
				Restaurants.Add(restaurant);
			}
		}
		catch (Exception )
		{
			await Shell.Current.DisplayAlert("Error", "The list of restaurants were not populated", "Ok");
		}
		finally 
		{ 
			isLoading = false;
			isRefreshing = false;	
		}


	}

	[RelayCommand]
	async Task RestaurantDetails(int id)
	{
		if(id == 0) return;
		await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Id={id}", true);
	}

	[RelayCommand]
	async Task AddRestaurant() {
		if (string.IsNullOrEmpty(Restaurantname) || string.IsNullOrEmpty(Details) || string.IsNullOrEmpty(Image) || string.IsNullOrEmpty(Location))
		{
			await Shell.Current.DisplayAlert("Missing Record", "Please fill out all of the required fields with correct data", "OK");
			return;
		}
		var restaurant = new Restaurant()
		{
			RestaurantName = Restaurantname,
			Details = Details,
			Image = Image,
			Location = Location
		};

		await RestaurantApiService.AddRestaurant(restaurant);
		await Shell.Current.DisplayAlert("Success!!", "Data was added successfully", "OK");
		await RestaurantApiService.GetRestaurants();
	}
	[RelayCommand]
	async Task DeleteRestaurant(int id) 
	{
		if(id == 0)
		{
			await Shell.Current.DisplayAlert("oops!", "Unable to delete record, try again", "OK");
			return;
		}
		
		else
		{
            await RestaurantApiService.DeleteRestaurant(id);
            await Shell.Current.DisplayAlert("SUCCESS!", "Recod was removed", "OK");
            await RestaurantApiService.GetRestaurants();
        }
	}

	async Task UpdateRestaurant( int id)
	{
		Restaurant restaurant;

		restaurant = await RestaurantApiService.GetRestaurant(id);
		if (restaurant != null) 
		{
			restaurant.Location = Location;
			restaurant.RestaurantName = Restaurantname;
			restaurant.Details = Details;
			restaurant.Image = Image;

			await RestaurantApiService.EditRestaurant(id, restaurant);
		}
		else
		{
            await Shell.Current.DisplayAlert("Failed!", "Failed to update record", "OK");
        }
	}
}