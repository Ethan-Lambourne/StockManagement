namespace stockManagement.Models
{
    public abstract class Items
    {
        public Items(int itemID, string itemName, string itemType, int? itemStock, double? itemPrice)
        {
            ID = itemID;
            Name = itemName;
            Type = itemType;
            Stock = itemStock;
            Price = itemPrice;
        }

        public int ID { get; }

        public string Name { get; set; }

        public string Type { get; }

        public int? Stock { get; set; }

        public double? Price { get; set; }
    }
}