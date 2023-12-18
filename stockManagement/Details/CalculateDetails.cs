using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace StockManagement.Details
{
    public class CalculateDetails
    {
        private int? laptopStock;
        private int? graphicsCardStock;
        private double? totalLaptopValue;
        private double? totalGraphicsCardValue;

        private readonly IItemsRepository<Laptop> _laptopRepository;
        private readonly IItemsRepository<GraphicsCard> _graphicsCardRepository;

        public CalculateDetails(IItemsRepository<Laptop> laptopRepository,
            IItemsRepository<GraphicsCard> graphicsCardRepository)
        {
            _laptopRepository = laptopRepository;
            _graphicsCardRepository = graphicsCardRepository;
        }

        public void CalculateItemValues()
        {
            totalLaptopValue = 0;
            totalGraphicsCardValue = 0;
            foreach (Laptop item in _laptopRepository.GetAllItems())
            {
                totalLaptopValue += item.Price;
            }
            foreach (GraphicsCard item in _graphicsCardRepository.GetAllItems())
            {
                totalGraphicsCardValue += item.Price;
            }
        }

        public void CalculateItemStocks()
        {
            laptopStock = 0;
            graphicsCardStock = 0;
            foreach (Laptop item in _laptopRepository.GetAllItems())
            {
                laptopStock += item.Stock;
            }
            foreach (GraphicsCard item in _graphicsCardRepository.GetAllItems())
            {
                graphicsCardStock += item.Stock;
            }
        }

        public int? GetLaptopStock()
        {
            CalculateItemStocks();
            return laptopStock;
        }

        public int? GetGraphicsCardStock()
        {
            CalculateItemStocks();
            return graphicsCardStock;
        }

        public double? GetTotalLaptopValue()
        {
            CalculateItemValues();
            return totalLaptopValue;
        }

        public double? GetTotalGraphicsCardValue()
        {
            CalculateItemValues();
            return totalGraphicsCardValue;
        }
    }
}