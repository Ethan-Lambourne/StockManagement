namespace StockManagement.Models
{
    public abstract class Items
    {
        public Items(int ID, string Name, string Type, int? Stock, double? Price)
        {
            this.ID = ID;
            this.Name = Name;
            this.Type = Type;
            this.Stock = Stock;
            this.Price = Price;
        }

        public int ID { get; }

        public string Name { get; set; }

        public string Type { get; }

        public int? Stock { get; set; }

        public double? Price { get; set; }
    }
}