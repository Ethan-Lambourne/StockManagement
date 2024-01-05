using System.ComponentModel.DataAnnotations;

namespace StockManagement.Shared.Models
{
    public class GraphicsCard : Items
    {
        public GraphicsCard(int ID, string Name, string Type, int? Stock, double? Price, int VRAM, int CudaCores)
            : base(ID, Name, Type, Stock, Price)
        {
            this.VRAM = VRAM;
            this.CudaCores = CudaCores;
        }

        public int VRAM { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int CudaCores { get; set; }

        public override string ToString()
        {
            return $"\nItem ID: \t\t\t{ID}" +
                $"\nItem name: \t\t\t{Name}" +
                $"\nItem type: \t\t\t{Type}" +
                $"\nItem stock: \t\t\t{Stock}" +
                $"\nItem price: \t\t\t£{Price}" +
                $"\nItem VRAM (in GB): \t\t{VRAM}" +
                $"\nItem cuda cores: \t\t{CudaCores}";
        }
    }
}