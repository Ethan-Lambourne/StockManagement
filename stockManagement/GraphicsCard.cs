using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace stockManagement
{
    public class GraphicsCard : Items
    {
        public GraphicsCard(string itemName, string itemType, int itemStock, double itemPrice, int itemVRAMamount, int itemCudaCores)
            : base(itemName, itemType, itemStock, itemPrice)
        {
            VRAM = itemVRAMamount;
            CudaCores = itemCudaCores;
        }

        public int VRAM { get; set; }

        public int CudaCores { get; set; }

        public override string ToString()
        {
            return $"\nItem name: \t\t\t{Name}" +
                $"\nItem type: \t\t\t{Type}" +
                $"\nItem stock: \t\t\t{Stock}" +
                $"\nItem price: \t\t\t£{Price}" +
                $"\nItem VRAM (in GB): \t\t{VRAM}" +
                $"\nItem cuda cores: \t\t{CudaCores}";
        }
    }
}