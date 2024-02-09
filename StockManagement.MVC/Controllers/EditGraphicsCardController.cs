using Microsoft.AspNetCore.Mvc;
using StockManagement.MVC.Models;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace StockManagement.MVC.Controllers
{
    public class EditGraphicsCardController : Controller
    {
        private readonly IItemsRepository<GraphicsCard> _csvGraphicsCardRepository;

        public EditGraphicsCardController(IItemsRepository<GraphicsCard> csvGraphicsCardRepository)
        {
            _csvGraphicsCardRepository = csvGraphicsCardRepository;
        }

        [Route("/EditGraphicsCard/{graphicsCardId}")]
        public IActionResult EditGraphicsCardView(int graphicsCardId)
        {
            GraphicsCard? graphicsCard = _csvGraphicsCardRepository.GetItem(graphicsCardId);
            if (graphicsCard != null)
            {
                EditGraphicsCardViewModel editGraphicsCardViewModel = new(graphicsCard.ID, graphicsCard.Name, graphicsCard.Type, graphicsCard.Stock,
                    graphicsCard.Price, graphicsCard.VRAM, graphicsCard.CudaCores);
                return View(editGraphicsCardViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult EditGraphicsCard(int ID, string Name, string Type, int? Stock, double? Price, int VRAM, int CudaCores)
        {
            GraphicsCard exampleItem = new(ID, Name, Type, Stock, Price, VRAM, CudaCores);
            GraphicsCard? editedItem = _csvGraphicsCardRepository.EditItem(exampleItem, ID);
            if (editedItem != null && editedItem.Name == Name && editedItem.Stock == Stock && editedItem.Price == Price && editedItem.VRAM == VRAM && editedItem.CudaCores == CudaCores)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyAdded = false, itemRecentlyEdited = true, itemRecentlyDeleted = false });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}