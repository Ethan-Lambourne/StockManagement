using Microsoft.AspNetCore.Mvc;
using StockManagement.MVC.Models;
using System.Diagnostics;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace StockManagement.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemsRepository<Laptop> _laptopRepository;
        private readonly IItemsRepository<GraphicsCard> _graphicsCardRepository;

        public HomeController(ILogger<HomeController> logger, IItemsRepository<Laptop> laptopRepository, IItemsRepository<GraphicsCard> graphicsCardRepository)
        {
            _logger = logger;
            _laptopRepository = laptopRepository;
            _graphicsCardRepository = graphicsCardRepository;
        }

        public IActionResult Index(bool itemRecentlyAdded, bool itemRecentlyEdited, bool itemRecentlyDeleted)
        {
            HomeViewModel homeViewModel = new(_laptopRepository.GetAllItems(), _graphicsCardRepository.GetAllItems(),
                itemRecentlyAdded, itemRecentlyEdited, itemRecentlyDeleted);
            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}