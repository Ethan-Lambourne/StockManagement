namespace stockManagement
{
    internal abstract class Items
    {
        protected string name;
        protected string type;
        protected int stock;
        protected double price;

        public Items(string itemName, string itemType, int itemStock, double itemPrice)
        {
            name = itemName;
            type = itemType;
            stock = itemStock;
            price = itemPrice;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Type
        {
            get { return type; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public abstract void DisplayItemDetails();

        public abstract void EditItemDetails(List<Items> ItemList);
    }
}