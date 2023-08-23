using stockManagement;

Item TestItem1 = new("cool laptop", "laptop", 34, 899.99);                            // items for testing purposes
Item TestItem2 = new("cool graphics card", "graphics card", 12, 699.99);
Item TestItem3 = new("less cool laptop", "laptop", 8, 399.99);
Item TestItem4 = new("less cool graphics card", "graphics card", 3, 299.99);
List<Item> ItemList = new List<Item>();                                               // creates list of objects and put the test objects inside
ItemList.AddRange(new List<Item>() { TestItem1, TestItem2, TestItem3, TestItem4 });

bool loop = true;
while (loop == true)
{
    var getDetail = new GetDetail();

    getDetail.ResetStocksAndValues();                                                  // clears total stock and total value variables
    foreach (Item item in ItemList)                                                    // works out total stock and total value variables
    {
        if (item.type == "laptop")
        {
            getDetail.laptopStock = getDetail.laptopStock + item.stock;
            getDetail.totalLaptopValue = getDetail.totalLaptopValue + item.price;
        }
        if (item.type == "graphics card")
        {
            getDetail.graphicsCardStock = getDetail.graphicsCardStock + item.stock;
            getDetail.totalGraphicsCardValue = getDetail.totalGraphicsCardValue + item.price;
        }
    }

    Console.WriteLine("\nWhat would you like to do?" +
    "\n1. Add a new item to stock." +
    "\n2. Track the stock level of a sepecific item type." +
    "\n3. Generate a total value report." +
    "\n9. End program.");

    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.WriteLine("\nWhich item type would you like to add?" +
                "\n1. Laptop." +
                "\n2. Graphics Card.");
            string itemType = getDetail.AddType();

            Console.WriteLine("\nWhat is the item called?");
            string itemName = getDetail.AddName();

            Console.WriteLine("\nHow much stock is being added?");
            int itemStock = getDetail.AddStock();

            Console.WriteLine("\nWhat is the price of the item?");
            double itemPrice = getDetail.AddPrice();

            Item NewItem = new(itemName, itemType, itemStock, itemPrice);                    // creates new object with user defined parameters
            ItemList.Add(NewItem);                                                           // adds object to list of objects
            break;

        case 2:
            Console.WriteLine("\nWhich type of item stock do you want to check?" +
                "\n1. Laptops." +
                "\n2. Graphics Cards.");
            string trackType = getDetail.AddType();
            if (trackType == "laptop")                                                       // checks the stock levels of each type of hardware
            {
                Console.WriteLine("\nTotal laptop stock: " + getDetail.laptopStock);
            }
            if (trackType == "graphics card")
            {
                Console.WriteLine("\nTotal graphics card stock: " + getDetail.graphicsCardStock);
            }
            break;

        case 3:
            foreach (Item item in ItemList)                                                  // displays details of every item in stock
            {
                item.DisplayItemDetails();
            }
            getDetail.DisplayReportSummary();                                                // displays overall report of stock and values
            break;

        case 9:
            Console.WriteLine("Goodbye.");
            loop = false;                                                                    // exits program
            break;

        default:
            Console.WriteLine("Please enter a valid input (1, 2, 3, or 9)");                 // input validation
            break;
    }
}