using System.ComponentModel.DataAnnotations;

namespace StockManagement.MVC.Models
{
    public class AddItemViewModel
    {
        public int? ID { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; }

        public int? Stock { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.##}")]
        public double? Price { get; set; }

        public double? ScreenSize { get; set; }

        public int? RAM { get; set; }

        public int? Storage { get; set; }

        public int? VRAM { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int? CudaCores { get; set; }
    }
}