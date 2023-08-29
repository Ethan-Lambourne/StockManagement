namespace stockManagement
{
    internal class Laptop : Items
    {
        private double screenSize;
        private int RAM;
        private int storage;

        public Laptop(string itemName, string itemType, int itemStock, double itemPrice, double itemScreenSize, int itemRAMamount, int itemStorageAmount) : base(itemName, itemType, itemStock, itemPrice)
        {
            screenSize = itemScreenSize;
            RAM = itemRAMamount;
            storage = itemStorageAmount;
        }

        public override void DisplayItemDetails()
        {
            Console.WriteLine($"\nItem name: \t\t\t{name}" +
                $"\nItem type: \t\t\t{type}" +
                $"\nItem stock: \t\t\t{stock}" +
                $"\nItem price: \t\t\t£{price}" +
                $"\nItem screen size (inches): \t{screenSize}" +
                $"\nItem RAM (in GB): \t\t{RAM}" +
                $"\nItem storage (in GB): \t\t{storage}");
        }

        public override void EditItemDetails(List<Items> ItemList)
        {
            string newName = "";
            string newType = "";
            int newStock = 0;
            double newPrice = 0;
            double newScreenSize = 0;
            int newRAMamount = 0;
            int newStorageAmount = 0;
            bool check = false;
            var getDetail = new GetDetail();
            var loop = true;
            while (loop == true)
            {
                Console.WriteLine($"\nWhat would you like to edit about \"{name}\"?" +
                "\n1. Name. " +
                "\n2. Type. " +
                "\n3. Stock. " +
                "\n4. Price. " +
                "\n5. Screen size. " +
                "\n6. RAM. " +
                "\n7. Storage." +
                "\n9. Finish editing.");
                int choice = getDetail.AddInt();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nEnter new name:");
                        newName = getDetail.AddName();
                        break;

                    case 2:
                        Console.WriteLine("\nWARNING: EDITING THE TYPE CHANGES THE SPECIFICATION CATEGORIES OF THIS ITEM," +
                            "\nYOU WILL NEED TO EDIT ALL CATEGORIES WITHIN THIS ITEM." +
                            "\n1. Continue." +
                            "\n2. Go back.");
                        check = getDetail.ProceedOrNot(ItemList);
                        if (check == true)
                        {
                            loop = false;
                        }
                        break;

                    case 3:
                        Console.WriteLine("\nEnter new stock amount:");
                        newStock = getDetail.AddInt();
                        break;

                    case 4:
                        Console.WriteLine("\nEnter new price:");
                        newPrice = getDetail.AddDouble();
                        break;

                    case 5:
                        Console.WriteLine("\nEnter new screen size:");
                        newScreenSize = getDetail.AddDouble();
                        break;

                    case 6:
                        Console.WriteLine("\nEnter new RAM amount:");
                        newRAMamount = getDetail.AddInt();
                        break;

                    case 7:
                        Console.WriteLine("\nEnter new storage amount:");
                        newStorageAmount = getDetail.AddInt();
                        break;

                    case 9:
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid input (1, 2, 3, 4, 5, 6, 7, or 9).");
                        break;
                }
            }
            if (check == false)
            {
                if (newName == "") { newName = name; }
                if (newType == "") { newType = type; }
                if (newStock == 0) { newStock = stock; }
                if (newPrice == 0) { newPrice = price; }
                if (newScreenSize == 0) { newScreenSize = screenSize; }
                if (newRAMamount == 0) { newRAMamount = RAM; }
                if (newStorageAmount == 0) { newStorageAmount = storage; }
                Items NewItem = new Laptop(newName, newType, newStock, newPrice, newScreenSize, newRAMamount, newStorageAmount);
                ItemList.Add(NewItem);
            }
        }
    }
}