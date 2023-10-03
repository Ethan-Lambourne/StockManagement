using StockManagement.Models;
using StockManagement.Repos;

namespace StockManagement.Details
{
    public class DisplayDetails
    {
        private readonly IItemsRepository<Laptop> _laptopRepository;
        private readonly IItemsRepository<GraphicsCard> _graphicsCardRepository;

        public DisplayDetails(IItemsRepository<Laptop> laptopRepository,
            IItemsRepository<GraphicsCard> graphicsCardRepository)
        {
            _laptopRepository = laptopRepository;
            _graphicsCardRepository = graphicsCardRepository;
        }

        public void DisplayAllItemsInStock()
        {
            foreach (Laptop item in _laptopRepository.GetAllItems())
            {
                Console.WriteLine(item.ToString());
            }
            foreach (GraphicsCard item in _graphicsCardRepository.GetAllItems())
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}