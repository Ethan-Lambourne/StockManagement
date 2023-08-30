namespace stockManagement
{
    internal class Laptop : Items
    {
        private double screenSize;
        private int ram;
        private int storage;

        public Laptop(string itemName, string itemType, int itemStock, double itemPrice, double itemScreenSize, int itemRAMamount, int itemStorageAmount) : base(itemName, itemType, itemStock, itemPrice)
        {
            screenSize = itemScreenSize;
            ram = itemRAMamount;
            storage = itemStorageAmount;
        }

        public double ScreenSize
        {
            get { return screenSize; }
            set { screenSize = value; }
        }

        public int RAM
        {
            get { return ram; }
            set { ram = value; }
        }

        public int Storage
        {
            get { return storage; }
            set { storage = value; }
        }

        public override void DisplayItemDetails()
        {
            Console.WriteLine($"\nItem name: \t\t\t{name}" +
                $"\nItem type: \t\t\t{type}" +
                $"\nItem stock: \t\t\t{stock}" +
                $"\nItem price: \t\t\t£{price}" +
                $"\nItem screen size (inches): \t{screenSize}" +
                $"\nItem RAM (in GB): \t\t{ram}" +
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
            var getDetail = new GetDetail();
            var loop = true;
            while (loop == true)
            {
                Console.WriteLine($"\nWhat would you like to edit about \"{name}\"?" +
                "\n1. Name. " +
                "\n2. Stock. " +
                "\n3. Price. " +
                "\n4. Screen size. " +
                "\n5. RAM. " +
                "\n6. Storage." +
                "\n9. Finish editing.");
                int choice = getDetail.AddInt();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nEnter new name:");
                        newName = getDetail.AddName();
                        break;

                    case 2:
                        Console.WriteLine("\nEnter new stock amount:");
                        newStock = getDetail.AddInt();
                        break;

                    case 3:
                        Console.WriteLine("\nEnter new price:");
                        newPrice = getDetail.AddDouble();
                        break;

                    case 4:
                        Console.WriteLine("\nEnter new screen size:");
                        newScreenSize = getDetail.AddDouble();
                        break;

                    case 5:
                        Console.WriteLine("\nEnter new RAM amount:");
                        newRAMamount = getDetail.AddInt();
                        break;

                    case 6:
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
            if (newName == "") { newName = name; }
            if (newType == "") { newType = type; }
            if (newStock == 0) { newStock = stock; }
            if (newPrice == 0) { newPrice = price; }
            if (newScreenSize == 0) { newScreenSize = screenSize; }
            if (newRAMamount == 0) { newRAMamount = ram; }
            if (newStorageAmount == 0) { newStorageAmount = storage; }
            Items NewItem = new Laptop(newName, newType, newStock, newPrice, newScreenSize, newRAMamount, newStorageAmount);
            ItemList.Add(NewItem);
        }
    }
}