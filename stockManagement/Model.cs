using System.Diagnostics;

namespace stockManagement
{
    public class GetDetail
    {
        public int laptopStock;
        public int graphicsCardStock;
        public double totalLaptopValue;
        public double totalGraphicsCardValue;

        public string AddType()                                             // choose which type of hardware
        {
            while (true)
            {
                int typeChoice = Convert.ToInt32(Console.ReadLine());
                switch (typeChoice)
                {
                    case 1:
                        return "laptop";

                    case 2:
                        return "graphics card";

                    default:
                        Console.WriteLine("Please enter a valid input (1 or 2)");
                        break;
                }
            }
        }

        public string AddName()                                             // creates a name for a new object
        {
            bool loop = true;
            string name = "";
            while (loop == true)
            {
                name = Console.ReadLine(); // I couldn't figure out how to get rid of the warning on this line and line 48, but the code works correctly
                if (name == "")
                {
                    Console.WriteLine("Name cannot be null, try again");
                }
                else
                {
                    loop = false;
                }
            }
            return name;
        }

        public int AddInt()                                              // inputs an integer for a new object
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
                    Console.WriteLine("Please enter a valid integer");
                }
            }
            return x;
        }

        public double AddDouble()                                           // inputs a double for a new object
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
                    Console.WriteLine("Please enter a valid double integer");
                }
            }
            return x;
        }

        public void ResetStocksAndValues()                                // sets stocks and values back to 0
        {
            laptopStock = 0;
            graphicsCardStock = 0;
            totalLaptopValue = 0;
            totalGraphicsCardValue = 0;
        }

        public void DisplayReportSummary()                               // displays final report summary of stocks and values
        {
            Console.WriteLine("\nLaptop stock: " + laptopStock);
            Console.WriteLine("Graphics card stock: " + graphicsCardStock);
            Console.WriteLine("Total stock: " + (laptopStock + graphicsCardStock));
            Console.WriteLine("\nTotal laptop value: " + totalLaptopValue);
            Console.WriteLine("Total graphics card value: " + totalGraphicsCardValue);
            Console.WriteLine("Total value of all items: " + (totalLaptopValue + totalGraphicsCardValue));
        }
    }

    public class Item
    {
        public string name;                                               // setting the 'blueprint' for a new objects / Items
        public string type;
        public int stock;
        public double price;
        public double screenSize;
        public int RAM;
        public int storage;
        public int VRAM;
        public int cudaCores;

        public Item(string itemName, string itemType, int itemStock, double itemPrice, double itemScreenSize, int itemRAMamount, int itemStorageAmount)
        {
            name = itemName;
            type = itemType;
            stock = itemStock;
            price = itemPrice;
            screenSize = itemScreenSize;
            RAM = itemRAMamount;
            storage = itemStorageAmount;
        }

        public Item(string itemName, string itemType, int itemStock, double itemPrice, int itemVRAMamount, int itemCudaCores)
        {
            name = itemName;
            type = itemType;
            stock = itemStock;
            price = itemPrice;
            VRAM = itemVRAMamount;
            cudaCores = itemCudaCores;
        }

        public void DisplayItemDetails()                                  // displays the details of an individual item
        {
            Console.WriteLine("\nItem name: " + name);
            Console.WriteLine("Item type: " + type);
            Console.WriteLine("Item stock: " + stock);
            Console.WriteLine("Item price: £" + price);
            if (type == "laptop")
            {
                Console.WriteLine("Item screen size (inches): " + screenSize);
                Console.WriteLine("Item RAM (in GB): " + RAM);
                Console.WriteLine("Item storage (in GB): " + storage);
            }
            if (type == "graphics card")
            {
                Console.WriteLine("Item VRAM (in GB): " + VRAM);
                Console.WriteLine("Item cuda cores: " + cudaCores);
            }
        }
    }
}