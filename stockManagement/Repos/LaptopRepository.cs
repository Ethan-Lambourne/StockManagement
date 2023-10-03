using StockManagement.Models;

namespace StockManagement.Repos
{
    public class LaptopRepository : IItemsRepository<Laptop>
    {
        private List<Laptop> LaptopList = new()
        {
            new Laptop(1, "cool laptop", "laptop", 34, 899.99, 14, 32, 1000),
            new Laptop(2, "less cool laptop", "laptop", 8, 399.99, 12, 16, 800),
        };

        public Laptop AddItem(Laptop item)
        {
            LaptopList.Add(item);
            return item;
        }

        public bool DeleteItem(int itemID)
        {
            var item = GetItem(itemID);
            if (item != null)
            {
                LaptopList.Remove(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Laptop? EditItem(Laptop ExampleItem, int itemID)
        {
            var item = GetItem(itemID);
            if (item != null)
            {
                if (ExampleItem.Name != "") { item.Name = ExampleItem.Name; }
                if (ExampleItem.Stock != null) { item.Stock = ExampleItem.Stock; }
                if (ExampleItem.Price != null) { item.Price = (double)ExampleItem.Price; }
                if (ExampleItem.ScreenSize != 0) { item.ScreenSize = ExampleItem.ScreenSize; }
                if (ExampleItem.RAM != 0) { item.RAM = ExampleItem.RAM; }
                if (ExampleItem.Storage != 0) { item.Storage = ExampleItem.Storage; }
            }
            return item;
        }

        public Laptop? GetItem(int itemID)
        {
            return LaptopList.FirstOrDefault(item => item.ID == itemID);
        }

        public List<Laptop> GetAllItems()
        {
            return LaptopList;
        }
    }
}