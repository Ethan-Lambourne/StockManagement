using stockManagement;

var addDetail = new AddDetail();
var laptop = new LaptopRepository();
var graphicsCard = new GraphicsCardRepository();
var displayDetail = new DisplayDetails(laptop, graphicsCard);

var loop = true;
while (loop == true)
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
    Console.WriteLine("\nWhich item type would you like to add?" +
           "\n1. Laptop." +
           "\n2. Graphics Card.");
    string itemType = addDetail.AddType();

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

        Laptop NewItem = new Laptop(itemName, itemType, itemStock, itemPrice, itemScreenSize, itemRAMamount, itemStorageAmount);
        laptop.AddItem(NewItem);
    }
    if (itemType == "graphics card")
    {
        Console.WriteLine("\nHow much VRAM does it have? (in GB)");
        int itemVRAMamount = addDetail.AddInt();

        Console.WriteLine("\nHow many cuda cores does it have?");
        int itemCudaCores = addDetail.AddInt();

        GraphicsCard NewItem = new GraphicsCard(itemName, itemType, itemStock, itemPrice, itemVRAMamount, itemCudaCores);
        graphicsCard.AddItem(NewItem);
    }
}

void TryToRemoveItem()
{
    Console.WriteLine("\nWhat is the type of the item you wish to remove?" +
           "\n1. Laptop." +
           "\n2. Graphics Card.");
    string itemType = addDetail.AddType();
    Console.WriteLine("\nEnter the name of the item you would like to remove.");
    string itemToRemove = addDetail.AddName();
    if (itemType == "laptop")
    {
        laptop.DeleteItem(itemToRemove);
    }
    if (itemType == "graphics card")
    {
        graphicsCard.DeleteItem(itemToRemove);
    }
}

void TryToEditItem()
{
    Console.WriteLine("\nWhat is the type of the item you wish to edit?" +
           "\n1. Laptop." +
           "\n2. Graphics Card.");
    string itemType = addDetail.AddType();
    Console.WriteLine("\nEnter the name of the item you would like to edit.");
    string itemToEdit = addDetail.AddName();
    if (itemType == "laptop")
    {
        laptop.EditItem(itemToEdit);
    }
    if (itemType == "graphics card")
    {
        graphicsCard.EditItem(itemToEdit);
    }
}

void TrackStockByType()
{
    displayDetail.CalculateStocksAndValues();

    Console.WriteLine("\nWhich type of item stock do you want to check?" +
            "\n1. Laptops." +
            "\n2. Graphics Cards.");
    string trackType = addDetail.AddType();
    if (trackType == "laptop")
    {
        Console.WriteLine($"\nTotal laptop stock: {displayDetail.laptopStock}");
    }
    if (trackType == "graphics card")
    {
        Console.WriteLine($"\nTotal graphics card stock: {displayDetail.graphicsCardStock}");
    }
}

void GenerateTotalStockAndValueReport()
{
    displayDetail.DisplayAllItemsInStock();
    displayDetail.CalculateStocksAndValues();
    displayDetail.DisplayReportSummary();
}