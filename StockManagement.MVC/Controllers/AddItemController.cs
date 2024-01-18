using Microsoft.AspNetCore.Mvc;
using StockManagement.MVC.Models;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;
using StockManagement.Shared.GenerateID;

namespace StockManagement.MVC.Controllers
{
    public class AddItemController : Controller
    {
        private readonly IItemsRepository<Laptop> _laptopRepository;
        private readonly IItemsRepository<GraphicsCard> _graphicsCardRepository;
        private readonly IGenerateID _generateItemID;

        public AddItemController(IItemsRepository<Laptop> laptopRepository,
            IItemsRepository<GraphicsCard> graphicsCardRepository, IGenerateID generateItemID)
        {
            _laptopRepository = laptopRepository;
            _graphicsCardRepository = graphicsCardRepository;
            _generateItemID = generateItemID;
        }

        [Route("/AddItemForm")]
        public IActionResult AddItemView()
        {
            AddItemViewModel addItemViewModel = new()
            {
                ID = _generateItemID.GenerateID()
            };
            return View(addItemViewModel);
        }

        public IActionResult AddLaptop(int ID, string Name, string Type, int? Stock, double? Price, double ScreenSize, int RAM, int Storage)
        {
            Laptop laptop = new(ID, Name, Type, Stock, Price, ScreenSize, RAM, Storage);
            var addedLaptop = _laptopRepository.AddItem(laptop);
            if (addedLaptop.ID == laptop.ID)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyAdded = true, itemRecentlyEdited = false, itemRecentlyDeleted = false });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult AddGraphicsCard(int ID, string Name, string Type, int? Stock, double? Price, int VRAM, int CudaCores)
        {
            GraphicsCard graphicsCard = new(ID, Name, Type, Stock, Price, VRAM, CudaCores);
            var addedGraphicsCard = _graphicsCardRepository.AddItem(graphicsCard);
            if (addedGraphicsCard.ID == graphicsCard.ID)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyAdded = true, itemRecentlyEdited = false, itemRecentlyDeleted = false });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}