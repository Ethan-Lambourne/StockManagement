using Microsoft.AspNetCore.Mvc;
using StockManagement.MVC.Models;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace StockManagement.MVC.Controllers
{
    public class GraphicsCardController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemsRepository<GraphicsCard> _csvGraphicsCardRepository;

        public GraphicsCardController(ILogger<HomeController> logger, IItemsRepository<GraphicsCard> csvGraphicsCardRepository)
        {
            _logger = logger;
            _csvGraphicsCardRepository = csvGraphicsCardRepository;
        }

        [Route("/GraphicsCardDetails/{graphicsCardId}")]
        public IActionResult GraphicsCardView(int graphicsCardId)
        {
            GraphicsCard? graphicsCard = _csvGraphicsCardRepository.GetItem(graphicsCardId);
            if (graphicsCard != null)
            {
                GraphicsCardViewModel graphicsCardViewModel = new(graphicsCard.ID, graphicsCard.Name, graphicsCard.Type, graphicsCard.Stock,
                    graphicsCard.Price, graphicsCard.VRAM, graphicsCard.CudaCores);
                return View(graphicsCardViewModel);
            }
            else
            {
                return NotFound();
            }
        }
    }
}