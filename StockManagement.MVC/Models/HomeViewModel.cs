using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace StockManagement.MVC.Models
{
    public class HomeViewModel
    {
        public HomeViewModel(List<Laptop> LaptopList, List<GraphicsCard> GraphicsCardList, bool itemRecentlyAdded, bool itemRecentlyEdited, bool itemRecentlyDeleted)
        {
            this.LaptopList = LaptopList;
            this.GraphicsCardList = GraphicsCardList;
            this.itemRecentlyAdded = itemRecentlyAdded;
            this.itemRecentlyEdited = itemRecentlyEdited;
            this.itemRecentlyDeleted = itemRecentlyDeleted;
        }

        public List<Laptop> LaptopList { get; set; }

        public List<GraphicsCard> GraphicsCardList { get; set; }

        public bool itemRecentlyAdded { get; set; }

        public bool itemRecentlyEdited { get; set; }

        public bool itemRecentlyDeleted { get; set; }
    }
}