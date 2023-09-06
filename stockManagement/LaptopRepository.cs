namespace stockManagement
{
    public class LaptopRepository : IItemsRepository<Laptop>
    {
        public List<Laptop> LaptopList = new()
        {
            new Laptop("cool laptop", "laptop", 34, 899.99, 14, 32, 1000),
            new Laptop("less cool laptop", "laptop", 8, 399.99, 12, 16, 800),
        };

        public void AddItem(Laptop item)
        {
            LaptopList.Add(item);
        }

        public void DeleteItem(string itemName)
        {
            var item = GetItem(itemName);
            if (item != null)
            {
                LaptopList.Remove(item);
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
            double newScreenSize = 0;
            int newRAMamount = 0;
            int newStorageAmount = 0;
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
                        "\n4. Screen size. " +
                        "\n5. RAM. " +
                        "\n6. Storage." +
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
                            Console.WriteLine("\nEnter new screen size:");
                            newScreenSize = addDetail.AddDouble();
                            break;

                        case 5:
                            Console.WriteLine("\nEnter new RAM amount:");
                            newRAMamount = addDetail.AddInt();
                            break;

                        case 6:
                            Console.WriteLine("\nEnter new storage amount:");
                            newStorageAmount = addDetail.AddInt();
                            break;

                        case 9:
                            loop = false;
                            break;

                        default:
                            Console.WriteLine("Please enter a valid input (1, 2, 3, 4, 5, 6, 7, or 9).");
                            break;
                    }
                }
                if (newName == "") { newName = item.Name; }
                if (newType == "") { newType = item.Type; }
                if (newStock == 0) { newStock = item.Stock; }
                if (newPrice == 0) { newPrice = item.Price; }
                if (newScreenSize == 0) { newScreenSize = item.ScreenSize; }
                if (newRAMamount == 0) { newRAMamount = item.RAM; }
                if (newStorageAmount == 0) { newStorageAmount = item.Storage; }
                Laptop NewItem = new Laptop(newName, newType, newStock, newPrice, newScreenSize, newRAMamount, newStorageAmount);
                LaptopList.Add(NewItem);
                LaptopList.Remove(item);
            }
            else
            {
                Console.WriteLine("\nNo items in stock match that name.");
            }
        }

        public Laptop? GetItem(string itemName)
        {
            var obj = LaptopList.FirstOrDefault(item => item.Name == itemName);
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