using stockManagement;

var ItemList = new List<Items>()
{
    new Laptop("cool laptop", "laptop", 34, 899.99, 14, 32, 1000),
    new GraphicsCard("cool graphics card", "graphics card", 12, 699.99, 16, 8),
    new Laptop("less cool laptop", "laptop", 8, 399.99, 12, 16, 800),
    new GraphicsCard("less cool graphics card", "graphics card", 3, 299.99, 8, 4)
};

var getDetail = new GetDetail();

var loop = true;
while (loop == true)
{
    getDetail.ResetStocksAndValues();
    foreach (Items item in ItemList)
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
    "\n2. Remove an item from stock." +
    "\n3. Edit an item in stock." +
    "\n4. Track the stock level of a sepecific item type." +
    "\n5. Generate a total value report." +
    "\n9. End program.");

    int choice = getDetail.AddInt();

    switch (choice)
    {
        case 1:
            getDetail.CreateNewItem(ItemList);
            break;

        case 2:
            RemoveItem();
            break;

        case 3:
            EditItem();
            break;

        case 4:
            TrackStockByType();
            break;

        case 5:
            foreach (Items item in ItemList)
            {
                item.DisplayItemDetails();
            }
            getDetail.DisplayReportSummary();
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

void RemoveItem()
{
    Console.WriteLine("\nEnter the name of the item you would like to remove.");
    string itemToRemove = getDetail.AddName();
    bool check = false;
    foreach (Items item in ItemList)
    {
        if (itemToRemove == item.name)
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

void EditItem()
{
    Console.WriteLine("\nEnter the name of the item you would like to edit.");
    string itemToEdit = getDetail.AddName();
    bool check = false;
    foreach (Items item in ItemList)
    {
        if (itemToEdit == item.name)
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
        Console.WriteLine($"\nTotal laptop stock: {getDetail.laptopStock}");
    }
    if (trackType == "graphics card")
    {
        Console.WriteLine($"\nTotal graphics card stock: {getDetail.graphicsCardStock}");
    }
}