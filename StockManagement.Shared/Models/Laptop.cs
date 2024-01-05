using System.ComponentModel.DataAnnotations;

namespace StockManagement.Shared.Models
{
    public class Laptop : Items
    {
        public Laptop(int ID, string Name, string Type, int? Stock, double? Price, double ScreenSize, int RAM, int Storage)
            : base(ID, Name, Type, Stock, Price)
        {
            this.ScreenSize = ScreenSize;
            this.RAM = RAM;
            this.Storage = Storage;
        }

        public double ScreenSize { get; set; }

        public int RAM { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int Storage { get; set; }

        public override string ToString()
        {
            return $"\nItem ID: \t\t\t{ID}" +
                $"\nItem name: \t\t\t{Name}" +
                $"\nItem type: \t\t\t{Type}" +
                $"\nItem stock: \t\t\t{Stock}" +
                $"\nItem price: \t\t\t£{Price}" +
                $"\nItem screen size (inches): \t{ScreenSize}" +
                $"\nItem RAM (in GB): \t\t{RAM}" +
                $"\nItem storage (in GB): \t\t{Storage}";
        }
    }
}