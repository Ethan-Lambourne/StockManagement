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
                DeleteItemViewModel deleteItemViewModel = new(null, graphicsCard);
                return View(deleteItemViewModel);
            }
            else if (laptop != null)
            {
                DeleteItemViewModel deleteItemViewModel = new(laptop, null);
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
                var isGraphicsCardDeleted = _csvGraphicsCardRepository.DeleteItem(itemId);
                if (isGraphicsCardDeleted)
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
                var isLaptopDeleted = _csvLaptopRepository.DeleteItem(itemId);
                if (isLaptopDeleted)
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