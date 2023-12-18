using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace StockManagement.Details
{
    public class GenerateItemID
    {
        private readonly IItemsRepository<Laptop> _laptopRepository;
        private readonly IItemsRepository<GraphicsCard> _graphicsCardRepository;

        public GenerateItemID(IItemsRepository<Laptop> laptopRepository,
            IItemsRepository<GraphicsCard> graphicsCardRepository)
        {
            _laptopRepository = laptopRepository;
            _graphicsCardRepository = graphicsCardRepository;
        }

        public int GenerateID()
        {
            List<int> existingIDs = new();
            foreach (Laptop laptop in _laptopRepository.GetAllItems())
            {
                existingIDs.Add(laptop.ID);
            }
            foreach (GraphicsCard graphicsCard in _graphicsCardRepository.GetAllItems())
            {
                existingIDs.Add(graphicsCard.ID);
            }
            int ID = 1;
            var isInList = existingIDs.IndexOf(ID) != -1;
            while (isInList == true)
            {
                ID++;
                isInList = existingIDs.IndexOf(ID) != -1;
            }
            return ID;
        }
    }
}