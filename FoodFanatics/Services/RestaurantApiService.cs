using FoodFanatics.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FoodFanatics.Services
{
    public class RestaurantApiService
    {
        HttpClient _httpClient;
        public string ErrorMessage;
        public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:8010" :
            "http://localhost:8010";

        public RestaurantApiService()
        {
            _httpClient = new HttpClient() { BaseAddress = new Uri (BaseAddress) };
        }

        public async Task<List<Restaurant>> GetRestaurants()
        {
            try
            {
                //initializing the connection to the database
                //if successful, load the database allocated information
                var response = await _httpClient.GetStringAsync("/Restaurants");
                return JsonConvert.DeserializeObject<List<Restaurant>>(response);
            }
            catch (Exception)
            {
                ErrorMessage = "Connection to database was unsuccessful, no data was allocated";
            }

            //if not successful, display an empty list

            return new List<Restaurant>();

        }

        public async Task<Restaurant> GetRestaurant(int id)
        {
            try
            {
                //initializing the connection to the database
                //if successful, load the database allocated information
                var response = await _httpClient.GetStringAsync("/Restaurants/" + id);
                //return JsonConvert.DeserializeObject<List<Restaurant>>(response);
            }
            catch (Exception)
            {
                ErrorMessage = "no data was allocated";
            }

            //if not successful, display an empty list

            return new Restaurant();
        }

        public async Task AddRestaurant( Restaurant restaurant)
        {
            try
            {
                //initializing the connection to the database
                //if successful, load the database allocated information
                var response = await _httpClient.PostAsJsonAsync("/Restaurants/", restaurant);
                response.EnsureSuccessStatusCode();
                ErrorMessage = "Restaurant was successfully added to the datatbase";
            }
            catch (Exception)
            {
                ErrorMessage = "Failed to add data";
            }
        }

        public async Task<List<Restaurant>> DeleteRestaurant(int id)
        {
            try
            {
                //initializing the connection to the database
                //if successful, load the database allocated information
                var response = await _httpClient.DeleteAsync("/Restaurants/" + id);
                response.EnsureSuccessStatusCode();
                ErrorMessage = "Restaurant was deleted from the datatbase";
            }
            catch (Exception)
            {
                ErrorMessage = "no data was allocated with that ID";
            }

            return null;
        }

        public async Task EditRestaurant(int id, Restaurant restaurant)
        {
            try
            {
                //initializing the connection to the database
                //if successful, load the database allocated information
                var response = await _httpClient.PutAsJsonAsync("/Restaurants/" + id, restaurant);
                response.EnsureSuccessStatusCode();
                ErrorMessage = "Restaurant was updated";
            }
            catch (Exception)
            {
                ErrorMessage = "no data was allocated with that ID";
            }
        }
    }
}
