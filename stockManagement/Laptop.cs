using System.Runtime.Intrinsics.Arm;

namespace stockManagement
{
    internal class Laptop : Items
    {
        public Laptop(string itemName, string itemType, int itemStock, double itemPrice, double itemScreenSize, int itemRAMamount, int itemStorageAmount) : base(itemName, itemType, itemStock, itemPrice)
        {
            ScreenSize = itemScreenSize;
            RAM = itemRAMamount;
            Storage = itemStorageAmount;
        }

        public double ScreenSize { get; set; }

        public int RAM { get; set; }

        public int Storage { get; set; }

        public override string ToString()
        {
            return $"\nItem name: \t\t\t{Name}" +
                $"\nItem type: \t\t\t{Type}" +
                $"\nItem stock: \t\t\t{Stock}" +
                $"\nItem price: \t\t\t£{Price}" +
                $"\nItem screen size (inches): \t{ScreenSize}" +
                $"\nItem RAM (in GB): \t\t{RAM}" +
                $"\nItem storage (in GB): \t\t{Storage}";
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
            var addDetail = new AddDetail();
            var loop = true;
            while (loop == true)
            {
                Console.WriteLine($"\nWhat would you like to edit about \"{Name}\"?" +
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
            if (newName == "") { newName = Name; }
            if (newType == "") { newType = Type; }
            if (newStock == 0) { newStock = Stock; }
            if (newPrice == 0) { newPrice = Price; }
            if (newScreenSize == 0) { newScreenSize = ScreenSize; }
            if (newRAMamount == 0) { newRAMamount = RAM; }
            if (newStorageAmount == 0) { newStorageAmount = Storage; }
            Items NewItem = new Laptop(newName, newType, newStock, newPrice, newScreenSize, newRAMamount, newStorageAmount);
            ItemList.Add(NewItem);
        }
    }
}