using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.MVC.Models
{
    public class EditLaptopViewModel
    {
        public EditLaptopViewModel(int ID, string Name, string Type, int? Stock, double? Price, double ScreenSize, int RAM, int Storage)
        {
            this.ID = ID;
            this.Name = Name;
            this.Type = Type;
            this.Stock = Stock;
            this.Price = Price;
            this.ScreenSize = ScreenSize;
            this.RAM = RAM;
            this.Storage = Storage;
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int? Stock { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.##}")]
        public double? Price { get; set; }

        public double ScreenSize { get; set; }

        public int RAM { get; set; }

        public int Storage { get; set; }
    }
}