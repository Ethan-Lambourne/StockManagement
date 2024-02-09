using StockManagement.Shared.Models;

namespace StockManagement.MVC.Models
{
    public class DeleteItemViewModel
    {
        public Laptop? Laptop { get; set; }

        public GraphicsCard? GraphicsCard { get; set; }

        public DeleteItemViewModel(Laptop? laptop, GraphicsCard? graphicsCard)
        {
            Laptop = laptop;
            GraphicsCard = graphicsCard;
        }
    }
}