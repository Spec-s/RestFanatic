using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFanatics.Models
{
    public abstract class BaseModels
    {
        [PrimaryKey, AutoIncrement]
        public int RestaurantId { get; set; }
    }
}
