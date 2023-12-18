using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.MVC.Models
{
    public class EditGraphicsCardViewModel
    {
        public EditGraphicsCardViewModel(int ID, string Name, string Type, int? Stock, double? Price, int VRAM, int CudaCores)
        {
            this.ID = ID;
            this.Name = Name;
            this.Type = Type;
            this.Stock = Stock;
            this.Price = Price;
            this.VRAM = VRAM;
            this.CudaCores = CudaCores;
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int? Stock { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.##}")]
        public double? Price { get; set; }

        public int VRAM { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int CudaCores { get; set; }
    }
}