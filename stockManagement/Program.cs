using StockManagement.Details;
using StockManagement.Shared.Repos;
using StockManagement.Shared.Models;
using StockManagement.Shared.GenerateID;

var laptop = new CsvLaptopRepository();
var graphicsCard = new CsvGraphicsCardRepository();
var calculateDetail = new CalculateDetails(laptop, graphicsCard);
var displayDetail = new DisplayDetails(laptop, graphicsCard);
var addDetail = new AddDetail();
var generateItemID = new GenerateItemID(laptop, graphicsCard);

var loop = true;
while (loop)
{
    Console.WriteLine("\n====================================================" +
        "\nWhat would you like to do?" +
        "\n1. Add a new item to stock." +
        "\n2. Remove an item from stock." +
        "\n3. Edit an item in stock." +
        "\n4. Track the stock level of a sepecific item type." +
        "\n5. Generate a total value report." +
        "\n9. End program." +
        "\n====================================================");

    int choice = addDetail.AddInt();

    switch (choice)
    {
        case 1:
            CreateNewItem();
            break;

        case 2:
            TryToRemoveItem();
            break;

        case 3:
            TryToEditItem();
            break;

        case 4:
            TrackStockByType();
            break;

        case 5:
            GenerateTotalStockAndValueReport();
            break;

        case 9:
            Console.WriteLine("Goodbye.");
            loop = false;
            break;

        default:
            Console.WriteLine("Please enter a valid input (1, 2, 3, or 9).");
            break;
    }
}

void CreateNewItem()
{
    Console.Clear();
    Console.WriteLine("\nWhich item type would you like to add?" +
           "\n1. Laptop." +
           "\n2. Graphics Card.");
    string itemType = addDetail.AddType();

    int itemID = generateItemID.GenerateID();

    Console.WriteLine("\nWhat is the item called?");
    string itemName = addDetail.AddName();

    Console.WriteLine("\nHow much stock is being added?");
    int itemStock = addDetail.AddInt();

    Console.WriteLine("\nWhat is the price of the item?");
    double itemPrice = addDetail.AddDouble();

    if (itemType == "laptop")
    {
        Console.WriteLine("\nWhat is the screen size? (in inches)");
        double itemScreenSize = addDetail.AddDouble();

        Console.WriteLine("\nWhat is the amount of RAM? (in GB)");
        int itemRAMamount = addDetail.AddInt();

        Console.WriteLine("\nHow much storage does it have? (in GB)");
        int itemStorageAmount = addDetail.AddInt();

        Laptop NewItem = new Laptop(itemID, itemName, itemType, itemStock, itemPrice, itemScreenSize, itemRAMamount, itemStorageAmount);
        laptop.AddItem(NewItem);
    }
    if (itemType == "graphics card")
    {
        Console.WriteLine("\nHow much VRAM does it have? (in GB)");
        int itemVRAMamount = addDetail.AddInt();

        Console.WriteLine("\nHow many cuda cores does it have?");
        int itemCudaCores = addDetail.AddInt();

        GraphicsCard NewItem = new GraphicsCard(itemID, itemName, itemType, itemStock, itemPrice, itemVRAMamount, itemCudaCores);
        graphicsCard.AddItem(NewItem);
    }
}

void TryToRemoveItem()
{
    Console.Clear();
    Console.WriteLine("\nWhat is the type of the item you wish to remove?" +
           "\n1. Laptop." +
           "\n2. Graphics Card.");
    string itemType = addDetail.AddType();
    Console.WriteLine("\nEnter the ID of the item you would like to remove.");
    int itemToRemove = addDetail.AddInt();
    if (itemType == "laptop")
    {
        if (laptop.DeleteItem(itemToRemove) == true)
        {
            Console.WriteLine("\nItem removed.");
        }
        else
        {
            Console.WriteLine("\nNo items in stock match that ID.");
        }
    }
    if (itemType == "graphics card")
    {
        if (graphicsCard.DeleteItem(itemToRemove) == true)
        {
            Console.WriteLine("\nItem removed.");
        }
        else
        {
            Console.WriteLine("\nNo items in stock match that ID.");
        }
    }
}

void TryToEditItem()
{
    Console.Clear();
    Console.WriteLine("\nWhat is the type of the item you wish to edit?" +
           "\n1. Laptop." +
           "\n2. Graphics Card.");
    string itemType = addDetail.AddType();
    Console.WriteLine("\nEnter the ID of the item you would like to edit.");
    int itemToEdit = addDetail.AddInt();
    string newName = "";
    int? newStock = null;
    double? newPrice = null;
    int newVRAMamount = 0;
    int newCudaCores = 0;
    double newScreenSize = 0;
    int newRAMamount = 0;
    int newStorageAmount = 0;
    var loop = true;
    if (itemType == "laptop")
    {
        var item = laptop.GetItem(itemToEdit);
        if (item != null)
        {
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
            Laptop ExampleItem = new(item.ID, newName, item.Type, newStock, newPrice, newScreenSize, newRAMamount, newStorageAmount);
            laptop.EditItem(ExampleItem, item.ID);
        }
        else
        {
            Console.WriteLine("\nNo items in stock match that ID.");
        }
    }
    if (itemType == "graphics card")
    {
        var item = graphicsCard.GetItem(itemToEdit);
        if (item != null)
        {
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
            GraphicsCard ExampleItem = new(item.ID, newName, item.Type, newStock, newPrice, newVRAMamount, newCudaCores);
            graphicsCard.EditItem(ExampleItem, item.ID);
        }
        else
        {
            Console.WriteLine("\nNo items in stock match that ID.");
        }
    }
}

void TrackStockByType()
{
    Console.Clear();
    Console.WriteLine("\nWhich type of item stock do you want to check?" +
            "\n1. Laptops." +
            "\n2. Graphics Cards.");
    string trackType = addDetail.AddType();
    if (trackType == "laptop")
    {
        Console.WriteLine($"\nTotal laptop stock: {calculateDetail.GetLaptopStock()}");
    }
    if (trackType == "graphics card")
    {
        Console.WriteLine($"\nTotal graphics card stock: {calculateDetail.GetGraphicsCardStock()}");
    }
}

void GenerateTotalStockAndValueReport()
{
    Console.Clear();
    displayDetail.DisplayAllItemsInStock();
    DisplayReportSummary();
}

void DisplayReportSummary()
{
    Console.WriteLine($"\nLaptop stock: \t\t\t{calculateDetail.GetLaptopStock()}" +
        $"\nGraphics card stock: \t\t{calculateDetail.GetGraphicsCardStock()}" +
        $"\nTotal stock: \t\t\t{calculateDetail.GetLaptopStock() + calculateDetail.GetGraphicsCardStock()}" +
        $"\n\nTotal laptop value: \t\t£{calculateDetail.GetTotalLaptopValue()}" +
        $"\nTotal graphics card value: \t£{calculateDetail.GetTotalGraphicsCardValue()}" +
        $"\nTotal value of all items: \t£{calculateDetail.GetTotalLaptopValue() + calculateDetail.GetTotalGraphicsCardValue()}");
}