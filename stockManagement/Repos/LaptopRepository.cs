using stockManagement.Models;

namespace stockManagement.Repos
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

        public Laptop EditItem(Laptop item, string newName, int newStock, double newPrice, double newScreenSize,
            int newRAMamount, int newStorageAmount, int newVRAMamount, int newCudaCores)
        {
            if (newName != "") { item.Name = newName; }
            if (newStock != 0) { item.Stock = newStock; }
            if (newPrice != 0) { item.Price = newPrice; }
            if (newScreenSize != 0) { item.ScreenSize = newScreenSize; }
            if (newRAMamount != 0) { item.RAM = newRAMamount; }
            if (newStorageAmount != 0) { item.Storage = newStorageAmount; }
            return item;
        }

        public Laptop? GetItem(int itemID)
        {
            var laptop = LaptopList.FirstOrDefault(item => item.ID == itemID);
            if (laptop != null)
            {
                return laptop;
            }
            else
            {
                return null;
            }
        }

        public List<Laptop> GetAllItems()
        {
            return LaptopList;
        }
    }
}