using stockManagement;

var ItemList = new List<Items>()
{
    new Laptop("cool laptop", "laptop", 34, 899.99, 14, 32, 1000),
    new GraphicsCard("cool graphics card", "graphics card", 12, 699.99, 16, 8),
    new Laptop("less cool laptop", "laptop", 8, 399.99, 12, 16, 800),
    new GraphicsCard("less cool graphics card", "graphics card", 3, 299.99, 8, 4)
};

var getDetail = new GetDetail();
var displayDetail = new DisplayDetails();

var loop = true;
while (loop == true)
{
    displayDetail.ResetStocksAndValues();
    foreach (Items item in ItemList)
    {
        if (item.Type == "laptop")
        {
            displayDetail.laptopStock = displayDetail.laptopStock + item.Stock;
            displayDetail.totalLaptopValue = displayDetail.totalLaptopValue + item.Price;
        }
        if (item.Type == "graphics card")
        {
            displayDetail.graphicsCardStock = displayDetail.graphicsCardStock + item.Stock;
            displayDetail.totalGraphicsCardValue = displayDetail.totalGraphicsCardValue + item.Price;
        }
    }

    Console.WriteLine("\nWhat would you like to do?" +
    "\n1. Add a new item to stock." +
    "\n2. Remove an item from stock." +
    "\n3. Edit an item in stock." +
    "\n4. Track the stock level of a sepecific item type." +
    "\n5. Generate a total value report." +
    "\n9. End program.");

    int choice = getDetail.AddInt();

    switch (choice)
    {
        case 1:
            CreateNewItem(ItemList);
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
            foreach (Items item in ItemList)
            {
                item.DisplayItemDetails();
            }
            displayDetail.DisplayReportSummary();
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

void CreateNewItem(List<Items> ItemList)
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

void TryToRemoveItem()
{
    Console.WriteLine("\nEnter the name of the item you would like to remove.");
    string itemToRemove = getDetail.AddName();
    bool check = false;
    foreach (Items item in ItemList)
    {
        if (itemToRemove == item.Name)
        {
            ItemList.Remove(item);
            Console.WriteLine("\nItem removed.");
            check = true;
            break;
        }
    }
    if (check == false)
    {
        Console.WriteLine("\nNo items in stock match that name.");
    }
}

void TryToEditItem()
{
    Console.WriteLine("\nEnter the name of the item you would like to edit.");
    string itemToEdit = getDetail.AddName();
    bool check = false;
    foreach (Items item in ItemList)
    {
        if (itemToEdit == item.Name)
        {
            item.DisplayItemDetails();
            item.EditItemDetails(ItemList);
            ItemList.Remove(item);
            check = true;
            Console.WriteLine("\nItem details changed.");
            break;
        }
    }
    if (check == false)
    {
        Console.WriteLine("\nNo items in stock match that name.");
    }
}

void TrackStockByType()
{
    Console.WriteLine("\nWhich type of item stock do you want to check?" +
            "\n1. Laptops." +
            "\n2. Graphics Cards.");
    string trackType = getDetail.AddType();
    if (trackType == "laptop")
    {
        Console.WriteLine($"\nTotal laptop stock: {displayDetail.laptopStock}");
    }
    if (trackType == "graphics card")
    {
        Console.WriteLine($"\nTotal graphics card stock: {displayDetail.graphicsCardStock}");
    }
}