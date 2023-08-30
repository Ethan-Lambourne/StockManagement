using System.Runtime.Intrinsics.Arm;

namespace stockManagement
{
    internal class GraphicsCard : Items
    {
        private int vram;
        private int cudaCores;

        public GraphicsCard(string itemName, string itemType, int itemStock, double itemPrice, int itemVRAMamount, int itemCudaCores) : base(itemName, itemType, itemStock, itemPrice)
        {
            vram = itemVRAMamount;
            cudaCores = itemCudaCores;
        }

        public int VRAM
        {
            get { return vram; }
            set { vram = value; }
        }

        public int CudaCores
        {
            get { return cudaCores; }
            set { cudaCores = value; }
        }

        public override void DisplayItemDetails()
        {
            Console.WriteLine($"\nItem name: \t\t\t{name}" +
                $"\nItem type: \t\t\t{type}" +
                $"\nItem stock: \t\t\t{stock}" +
                $"\nItem price: \t\t\t£{price}" +
                $"\nItem VRAM (in GB): \t\t{vram}" +
                $"\nItem cuda cores: \t\t{cudaCores}");
        }

        public override void EditItemDetails(List<Items> ItemList)
        {
            string newName = "";
            string newType = "";
            int newStock = 0;
            double newPrice = 0;
            int newVRAMamount = 0;
            int newCudaCores = 0;
            var getDetail = new GetDetail();
            var loop = true;
            while (loop == true)
            {
                Console.WriteLine($"\nWhat would you like to edit about \"{name}\"?" +
                "\n1. Name. " +
                "\n2. Stock. " +
                "\n3. Price. " +
                "\n4. VRAM. " +
                "\n5. Cuda cores. " +
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
                        Console.WriteLine("\nEnter new VRAM amount:");
                        newVRAMamount = getDetail.AddInt();
                        break;

                    case 5:
                        Console.WriteLine("\nEnter new cuda core amount:");
                        newCudaCores = getDetail.AddInt();
                        break;

                    case 9:
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid input (1, 2, 3, 4, 5, 6, or 9).");
                        break;
                }
            }
            if (newName == "") { newName = name; }
            if (newType == "") { newType = type; }
            if (newStock == 0) { newStock = stock; }
            if (newPrice == 0) { newPrice = price; }
            if (newVRAMamount == 0) { newVRAMamount = vram; }
            if (newCudaCores == 0) { newCudaCores = cudaCores; }
            Items NewItem = new GraphicsCard(newName, newType, newStock, newPrice, newVRAMamount, newCudaCores);
            ItemList.Add(NewItem);
        }
    }
}