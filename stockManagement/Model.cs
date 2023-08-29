namespace stockManagement
{
    public class GetDetail
    {
        public int laptopStock;
        public int graphicsCardStock;
        public double totalLaptopValue;
        public double totalGraphicsCardValue;

        public string AddType()
        {
            int typeChoice;
            if (int.TryParse(Console.ReadLine(), out typeChoice))
            {
                switch (typeChoice)
                {
                    case 1:
                        return "laptop";

                    case 2:
                        return "graphics card";

                    default:
                        Console.WriteLine("Please enter a valid input (1 or 2).");
                        return AddType();
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid integer.");
                return AddType();
            }
        }

        public string AddName()
        {
            string? name = string.Empty;
            while (string.IsNullOrEmpty(name))
            {
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name cannot be null, try again.");
                }
            }
            return name;
        }

        public int AddInt()
        {
            bool loop = true;
            int x = 0;
            while (loop == true)
            {
                if (int.TryParse(Console.ReadLine(), out x))
                {
                    Convert.ToInt32(x);
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer.");
                }
            }
            return x;
        }

        public double AddDouble()
        {
            bool loop = true;
            double x = 0.00;
            while (loop == true)
            {
                if (double.TryParse(Console.ReadLine(), out x))
                {
                    Convert.ToDouble(x);
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid double integer.");
                }
            }
            return x;
        }

        public bool ProceedOrNot(List<Items> ItemList)
        {
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateNewItem(ItemList);
                        return true;

                    case 2:
                        return false;

                    default:
                        Console.WriteLine("Please enter a valid input (1 or 2).");
                        return ProceedOrNot(ItemList);
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid integer.");
                return ProceedOrNot(ItemList);
            }
        }

        public void ResetStocksAndValues()
        {
            laptopStock = 0;
            graphicsCardStock = 0;
            totalLaptopValue = 0;
            totalGraphicsCardValue = 0;
        }

        public void DisplayReportSummary()
        {
            Console.WriteLine($"\nLaptop stock: \t\t\t{laptopStock}" +
                $"\nGraphics card stock: \t\t{graphicsCardStock}" +
                $"\nTotal stock: \t\t\t{laptopStock + graphicsCardStock}" +
                $"\n\nTotal laptop value: \t\t£{totalLaptopValue}" +
                $"\nTotal graphics card value: \t£{totalGraphicsCardValue}" +
                $"\nTotal value of all items: \t£{totalLaptopValue + totalGraphicsCardValue}");
        }

        public virtual void CreateNewItem(List<Items> ItemList)
        {
            var getDetail = new GetDetail();
            Console.WriteLine("\nWhich item type would you like to add?" +
                   "\n1. Laptop." +
                   "\n2. Graphics Card.");
            string itemType = getDetail.AddType();

            Console.WriteLine("\nWhat is the item called?");
            string itemName = getDetail.AddName();

            Console.WriteLine("\nHow much stock is being added?");
            int itemStock = getDetail.AddInt();

            Console.WriteLine("\nWhat is the price of the item?");
            double itemPrice = getDetail.AddDouble();

            if (itemType == "laptop")
            {
                Console.WriteLine("\nWhat is the screen size? (in inches)");
                double itemScreenSize = getDetail.AddDouble();

                Console.WriteLine("\nWhat is the amount of RAM? (in GB)");
                int itemRAMamount = getDetail.AddInt();

                Console.WriteLine("\nHow much storage does it have? (in GB)");
                int itemStorageAmount = getDetail.AddInt();

                Items NewItem = new Laptop(itemName, itemType, itemStock, itemPrice, itemScreenSize, itemRAMamount, itemStorageAmount);
                ItemList.Add(NewItem);
            }
            if (itemType == "graphics card")
            {
                Console.WriteLine("\nHow much VRAM does it have? (in GB)");
                int itemVRAMamount = getDetail.AddInt();

                Console.WriteLine("\nHow many cuda cores does it have?");
                int itemCudaCores = getDetail.AddInt();

                Items NewItem = new GraphicsCard(itemName, itemType, itemStock, itemPrice, itemVRAMamount, itemCudaCores);
                ItemList.Add(NewItem);
            }
        }
    }
}