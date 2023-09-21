using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace StockManagement.Models
{
    public class GraphicsCard : Items
    {
        public GraphicsCard(int itemID, string itemName, string itemType, int? itemStock, double? itemPrice, int itemVRAMamount, int itemCudaCores)
            : base(itemID, itemName, itemType, itemStock, itemPrice)
        {
            VRAM = itemVRAMamount;
            CudaCores = itemCudaCores;
        }

        public int VRAM { get; set; }

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