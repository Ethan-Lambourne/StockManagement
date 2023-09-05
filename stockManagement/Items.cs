namespace stockManagement
{
    public abstract class Items
    {
        public Items(string itemName, string itemType, int itemStock, double itemPrice)
        {
            Name = itemName;
            Type = itemType;
            Stock = itemStock;
            Price = itemPrice;
        }

        public string Name { get; set; }

        public string Type { get; }

        public int Stock { get; set; }

        public double Price { get; set; }
    }
}