namespace stockManagement
{
    internal abstract class Items
    {
        public Items(string itemName, string itemType, int itemStock, double itemPrice)
        {
            Name = itemName;
            Type = itemType;
            Stock = itemStock;
            Price = itemPrice;
        }

        public string Name { get; protected set; }

        public string Type { get; }

        public int Stock { get; protected set; }

        public double Price { get; protected set; }

        public abstract void EditItemDetails(List<Items> ItemList);
    }
}