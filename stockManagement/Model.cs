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

        public int AddStock()                                              // inputs stock for a new object
        {
            bool loop = true;
            int stock = 0;
            while (loop == true)
            {
                if (int.TryParse(Console.ReadLine(), out stock))
                {
                    Convert.ToInt32(stock);
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer");
                }
            }
            return stock;
        }

        public double AddPrice()                                           // inputs a price for a new object
        {
            bool loop = true;
            double price = 0.00;
            while (loop == true)
            {
                if (double.TryParse(Console.ReadLine(), out price))
                {
                    Convert.ToDouble(price);
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid double integer");
                }
            }
            return price;
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
        public string name;                                               // setting the 'blueprint' for a new object / Item
        public string type;
        public int stock;
        public double price;

        public Item(string itemName, string itemType, int itemStock, double itemPrice)
        {
            name = itemName;
            type = itemType;
            stock = itemStock;
            price = itemPrice;
        }

        public void DisplayItemDetails()                                  // displays the details of an individual item
        {
            Console.WriteLine("\nItem name: " + name);
            Console.WriteLine("Item type: " + type);
            Console.WriteLine("Item stock: " + stock);
            Console.WriteLine("Item price: £" + price);
        }
    }
}