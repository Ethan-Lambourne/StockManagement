namespace stockManagement
{
    public class GraphicsCardRepository : IItemsRepository<GraphicsCard>
    {
        public List<GraphicsCard> GraphicsCardList = new()
        {
            new GraphicsCard("cool graphics card", "graphics card", 12, 699.99, 16, 8),
            new GraphicsCard("less cool graphics card", "graphics card", 3, 299.99, 8, 4)
        };

        public void AddItem(GraphicsCard item)
        {
            GraphicsCardList.Add(item);
        }

        public void DeleteItem(string itemName)
        {
            var item = GetItem(itemName);
            if (item != null)
            {
                GraphicsCardList.Remove(item);
                Console.WriteLine("\nItem removed.");
            }
            else
            {
                Console.WriteLine("\nNo items in stock match that name.");
            }
        }

        public void EditItem(string itemName)
        {
            string newName = "";
            string newType = "";
            int newStock = 0;
            double newPrice = 0;
            int newVRAMamount = 0;
            int newCudaCores = 0;
            var addDetail = new AddDetail();
            var item = GetItem(itemName);
            if (item != null)
            {
                var loop = true;
                while (loop)
                {
                    Console.WriteLine($"\nWhat would you like to edit about \"{item.Name}\"?" +
                        "\n1. Name. " +
                        "\n2. Stock. " +
                        "\n3. Price. " +
                        "\n4. VRAM. " +
                        "\n5. Cuda cores. " +
                        "\n9. Finish editing.");
                    int choice = addDetail.AddInt();
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\nEnter new name:");
                            newName = addDetail.AddName();
                            break;

                        case 2:
                            Console.WriteLine("\nEnter new stock amount:");
                            newStock = addDetail.AddInt();
                            break;

                        case 3:
                            Console.WriteLine("\nEnter new price:");
                            newPrice = addDetail.AddDouble();
                            break;

                        case 4:
                            Console.WriteLine("\nEnter new VRAM amount:");
                            newVRAMamount = addDetail.AddInt();
                            break;

                        case 5:
                            Console.WriteLine("\nEnter new cuda core amount:");
                            newCudaCores = addDetail.AddInt();
                            break;

                        case 9:
                            loop = false;
                            break;

                        default:
                            Console.WriteLine("Please enter a valid input (1, 2, 3, 4, 5, 6, or 9).");
                            break;
                    }
                }
                if (newName == "") { newName = item.Name; }
                if (newType == "") { newType = item.Type; }
                if (newStock == 0) { newStock = item.Stock; }
                if (newPrice == 0) { newPrice = item.Price; }
                if (newVRAMamount == 0) { newVRAMamount = item.VRAM; }
                if (newCudaCores == 0) { newCudaCores = item.CudaCores; }
                GraphicsCard NewItem = new GraphicsCard(newName, newType, newStock, newPrice, newVRAMamount, newCudaCores);
                AddItem(NewItem);
                GraphicsCardList.Remove(item);
            }
            else
            {
                Console.WriteLine("\nNo items in stock match that name.");
            }
        }

        public GraphicsCard? GetItem(string itemName)
        {
            var obj = GraphicsCardList.FirstOrDefault(item => item.Name == itemName);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                Console.WriteLine("Null Value Gotten");
                return null;
            }
        }
    }
}