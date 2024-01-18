using System.ComponentModel.DataAnnotations;

namespace StockManagement.Shared.Models
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

        [Key]
        public int PK { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int? Stock { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.##}")]
        public double? Price { get; set; }
    }
}