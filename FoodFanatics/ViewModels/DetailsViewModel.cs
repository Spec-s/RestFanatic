using CommunityToolkit.Mvvm.ComponentModel;
using FoodFanatics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FoodFanatics.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class DetailsViewModel : BaseViewModels, IQueryAttributable
    {
        [ObservableProperty]
        Restaurant restaurant;

        [ObservableProperty]
        int id;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query[nameof(Id)].ToString()));
           // Restaurant = App.RestaurantService.GetRestaurant(Id);
        }
    }

}
