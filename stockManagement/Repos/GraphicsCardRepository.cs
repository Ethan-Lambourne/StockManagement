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

        public GraphicsCard? EditItem(GraphicsCard ExampleItem, int itemID)
        {
            var item = GetItem(itemID);
            if (item != null)
            {
                if (ExampleItem.Name != "") { item.Name = ExampleItem.Name; }
                if (ExampleItem.Stock != null) { item.Stock = ExampleItem.Stock; }
                if (ExampleItem.Price != null) { item.Price = (double)ExampleItem.Price; }
                if (ExampleItem.VRAM != 0) { item.VRAM = ExampleItem.VRAM; }
                if (ExampleItem.CudaCores != 0) { item.CudaCores = ExampleItem.CudaCores; }
            }
            return item;
        }

        public GraphicsCard? GetItem(int itemID)
        {
            return GraphicsCardList.FirstOrDefault(item => item.ID == itemID);
        }

        public List<GraphicsCard> GetAllItems()
        {
            return GraphicsCardList;
        }
    }
}