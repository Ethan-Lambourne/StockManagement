using StockManagement.Shared.DataManagement;
using StockManagement.Shared.Models;

namespace StockManagement.Shared.Repos
{
    public class GraphicsCardDbRepository : IItemsRepository<GraphicsCard>
    {
        private readonly ItemContext _context = new();

        public GraphicsCardDbRepository(ItemContext context)
        {
            _context = context;
        }

        public GraphicsCard AddItem(GraphicsCard item)
        {
            _context.GraphicsCards.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool DeleteItem(int itemID)
        {
            var graphicsCard = GetItem(itemID);
            if (graphicsCard != null)
            {
                _context.GraphicsCards.Remove(graphicsCard);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public GraphicsCard? EditItem(GraphicsCard ExampleItem, int itemID)
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
                    if (ExampleItem.VRAM != 0) { item.VRAM = ExampleItem.VRAM; }
                    if (ExampleItem.CudaCores != 0) { item.CudaCores = ExampleItem.CudaCores; }
                    AddItem(item);
                }
            }
            return item;
        }

        public List<GraphicsCard> GetAllItems()
        {
            return _context.GraphicsCards.ToList();
        }

        public GraphicsCard? GetItem(int itemID)
        {
            List<GraphicsCard> allGraphicsCards = GetAllItems();
            return allGraphicsCards.FirstOrDefault(x => x.ID == itemID);
        }
    }
}