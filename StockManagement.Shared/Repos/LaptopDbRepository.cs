using StockManagement.Shared.DataManagement;
using StockManagement.Shared.Models;

namespace StockManagement.Shared.Repos
{
    public class LaptopDbRepository : IItemsRepository<Laptop>
    {
        private readonly ItemContext _context = new();

        public LaptopDbRepository(ItemContext context)
        {
            _context = context;
        }

        public Laptop AddItem(Laptop item)
        {
            _context.Laptops.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool DeleteItem(int itemID)
        {
            var laptop = GetItem(itemID);
            if (laptop != null)
            {
                _context.Laptops.Remove(laptop);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Laptop? EditItem(Laptop ExampleItem, int itemID)
        {
            var item = GetItem(itemID);
            if (item != null)
            {
                var isDeleted = DeleteItem(itemID);
                if (isDeleted)
                {
                    if (item.PK != 0) { item.PK = 0; }
                    if (ExampleItem.Name != "") { item.Name = ExampleItem.Name; }
                    if (ExampleItem.Stock != null) { item.Stock = ExampleItem.Stock; }
                    if (ExampleItem.Price != null) { item.Price = (double)ExampleItem.Price; }
                    if (ExampleItem.ScreenSize != 0) { item.ScreenSize = ExampleItem.ScreenSize; }
                    if (ExampleItem.RAM != 0) { item.RAM = ExampleItem.RAM; }
                    if (ExampleItem.Storage != 0) { item.Storage = ExampleItem.Storage; }
                    AddItem(item);
                }
            }
            return item;
        }

        public List<Laptop> GetAllItems()
        {
            return _context.Laptops.ToList();
        }

        public Laptop? GetItem(int itemID)
        {
            List<Laptop> allLaptops = GetAllItems();
            return allLaptops.FirstOrDefault(x => x.ID == itemID);
        }
    }
}