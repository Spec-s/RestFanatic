using SQLite;

namespace FoodFanatics.Models;
[Table("RestaurantTable")]
public class Restaurant : BaseModels
{
    [Unique]
    public string RestaurantName { get; set; }
    public string Details { get; set; }
    public string Image { get; set; }
    public string Location { get; set; }    
}