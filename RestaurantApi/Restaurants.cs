using SQLite;
using System.ComponentModel.DataAnnotations;

namespace RestaurantApi
{
    public class Restaurants
    {
        [Key]
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string Details { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
    }
}