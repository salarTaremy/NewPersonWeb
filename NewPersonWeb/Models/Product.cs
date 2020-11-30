using System.Collections.Generic;

namespace NewPersonWeb.Models
{
    public class Product : BaseEntity<long>
    {
        public Product()
        {
            this.RelatedProducts = new List<Product>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string GroupName { get; set; }
        public double Weight { get; set; }

        public long Price { get; set; }
        public long ConsumerPrices { get; set; }

        public int MaxPerDayCount { get; set; } //recommended : 10
        public int DayCount { get; set; }  //Default Is 1

        public int CountInBox { get; set; }
        public bool IsFavorite { get; set; }

        public int CountInBasket { get; set; }
        public bool HaveTax { get; set; }
        public bool ExistInBasket { get; set; }

        public int? BuyHistoryCount { get; set; }
        public int? FavoriteCount { get; set; }

        public byte? Rate { get; set; }
        public string AnbarName { get; set; }

        public long? @Inventory { get; set; }

        public List<Product> RelatedProducts { get; set; }
    }
}