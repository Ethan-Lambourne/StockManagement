using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace stockManagement
{
    internal class GraphicsCard : Items
    {
        public GraphicsCard(string itemName, string itemType, int itemStock, double itemPrice, int itemVRAMamount, int itemCudaCores) : base(itemName, itemType, itemStock, itemPrice)
        {
            VRAM = itemVRAMamount;
            CudaCores = itemCudaCores;
        }

        public int VRAM { get; set; }

        public int CudaCores { get; set; }

        public override string ToString()
        {
            return $"\nItem name: \t\t\t{Name}" +
                $"\nItem type: \t\t\t{Type}" +
                $"\nItem stock: \t\t\t{Stock}" +
                $"\nItem price: \t\t\t£{Price}" +
                $"\nItem VRAM (in GB): \t\t{VRAM}" +
                $"\nItem cuda cores: \t\t{CudaCores}";
        }

        public override void EditItemDetails(List<Items> ItemList)
        {
            string newName = "";
            string newType = "";
            int newStock = 0;
            double newPrice = 0;
            int newVRAMamount = 0;
            int newCudaCores = 0;
            var addDetail = new AddDetail();
            var loop = true;
            while (loop == true)
            {
                Console.WriteLine($"\nWhat would you like to edit about \"{Name}\"?" +
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
            if (newName == "") { newName = Name; }
            if (newType == "") { newType = Type; }
            if (newStock == 0) { newStock = Stock; }
            if (newPrice == 0) { newPrice = Price; }
            if (newVRAMamount == 0) { newVRAMamount = VRAM; }
            if (newCudaCores == 0) { newCudaCores = CudaCores; }
            Items NewItem = new GraphicsCard(newName, newType, newStock, newPrice, newVRAMamount, newCudaCores);
            ItemList.Add(NewItem);
        }
    }
}