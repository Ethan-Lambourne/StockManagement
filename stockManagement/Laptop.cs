namespace stockManagement
{
    public class Laptop : Items
    {
        public Laptop(string itemName, string itemType, int itemStock, double itemPrice, double itemScreenSize, int itemRAMamount, int itemStorageAmount)
            : base(itemName, itemType, itemStock, itemPrice)
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
    }
}