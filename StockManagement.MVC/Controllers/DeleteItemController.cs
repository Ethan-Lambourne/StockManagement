using Microsoft.AspNetCore.Mvc;
using StockManagement.MVC.Models;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace StockManagement.MVC.Controllers
{
    public class DeleteItemController : Controller
    {
        private readonly IItemsRepository<Laptop> _csvLaptopRepository;
        private readonly IItemsRepository<GraphicsCard> _csvGraphicsCardRepository;

        public DeleteItemController(IItemsRepository<Laptop> csvLaptopRepository, IItemsRepository<GraphicsCard> csvGraphicsCardRepository)
        {
            _csvLaptopRepository = csvLaptopRepository;
            _csvGraphicsCardRepository = csvGraphicsCardRepository;
        }

        [Route("/DeleteItemConfirmation/{itemId}")]
        public IActionResult DeleteItemView(int itemId)
        {
            GraphicsCard? graphicsCard = _csvGraphicsCardRepository.GetItem(itemId);
            Laptop? laptop = _csvLaptopRepository.GetItem(itemId);
            if (graphicsCard != null)
            {
                DeleteItemViewModel deleteItemViewModel = new(graphicsCard.ID, graphicsCard.Name, graphicsCard.Type, graphicsCard.Stock, graphicsCard.Price,
                    0, 0, 0, graphicsCard.VRAM, graphicsCard.CudaCores);
                return View(deleteItemViewModel);
            }
            else if (laptop != null)
            {
                DeleteItemViewModel deleteItemViewModel = new(laptop.ID, laptop.Name, laptop.Type, laptop.Stock, laptop.Price, laptop.ScreenSize,
                    laptop.RAM, laptop.Storage, 0, 0);
                return View(deleteItemViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult DeleteItem(int itemId)
        {
            GraphicsCard? graphicsCard = _csvGraphicsCardRepository.GetItem(itemId);
            Laptop? laptop = _csvLaptopRepository.GetItem(itemId);
            if (graphicsCard != null)
            {
                bool graphicsCardDeleted = _csvGraphicsCardRepository.DeleteItem(itemId);
                if (graphicsCardDeleted)
                {
                    return RedirectToAction("Index", "Home", new { itemRecentlyAdded = false, itemRecentlyEdited = false, itemRecentlyDeleted = true });
                }
                else
                {
                    return BadRequest();
                }
            }
            else if (laptop != null)
            {
                bool laptopDeleted = _csvLaptopRepository.DeleteItem(itemId);
                if (laptopDeleted)
                {
                    return RedirectToAction("Index", "Home", new { itemRecentlyAdded = false, itemRecentlyEdited = false, itemRecentlyDeleted = true });
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}