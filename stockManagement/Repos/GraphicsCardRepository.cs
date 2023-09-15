using stockManagement.Models;

namespace stockManagement.Repos
{
    public class GraphicsCardRepository : IItemsRepository<GraphicsCard>
    {
        private List<GraphicsCard> GraphicsCardList = new()
        {
            new GraphicsCard(3, "cool graphics card", "graphics card", 12, 699.99, 16, 8),
            new GraphicsCard(4, "less cool graphics card", "graphics card", 3, 299.99, 8, 4)
        };

        public GraphicsCard AddItem(GraphicsCard item)
        {
            GraphicsCardList.Add(item);
            return item;
        }

        public bool DeleteItem(int itemID)
        {
            var item = GetItem(itemID);
            if (item != null)
            {
                GraphicsCardList.Remove(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public GraphicsCard EditItem(GraphicsCard item, string newName, int newStock, double newPrice, double newScreenSize,
            int newRAMamount, int newStorageAmount, int newVRAMamount, int newCudaCores)
        {
            if (newName != "") { item.Name = newName; }
            if (newStock != 0) { item.Stock = newStock; }
            if (newPrice != 0) { item.Price = newPrice; }
            if (newVRAMamount != 0) { item.VRAM = newVRAMamount; }
            if (newCudaCores != 0) { item.CudaCores = newCudaCores; }
            return item;
        }

        public GraphicsCard? GetItem(int itemID)
        {
            var graphicsCard = GraphicsCardList.FirstOrDefault(item => item.ID == itemID);
            if (graphicsCard != null)
            {
                return graphicsCard;
            }
            else
            {
                return null;
            }
        }

        public List<GraphicsCard> GetAllItems()
        {
            return GraphicsCardList;
        }
    }
}