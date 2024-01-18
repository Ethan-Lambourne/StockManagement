using Microsoft.AspNetCore.Mvc;
using StockManagement.MVC.Models;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace StockManagement.MVC.Controllers
{
    public class LaptopController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemsRepository<Laptop> _laptopRepository;

        public LaptopController(ILogger<HomeController> logger, IItemsRepository<Laptop> laptopRepository)
        {
            _logger = logger;
            _laptopRepository = laptopRepository;
        }

        [Route("/LaptopDetails/{laptopId}")]
        public IActionResult LaptopView(int laptopId)
        {
            Laptop? laptop = _laptopRepository.GetItem(laptopId);
            if (laptop != null)
            {
                LaptopViewModel laptopViewModel = new(laptop.ID, laptop.Name, laptop.Type, laptop.Stock,
                    laptop.Price, laptop.ScreenSize, laptop.RAM, laptop.Storage);
                return View(laptopViewModel);
            }
            else
            {
                return NotFound();
            }
        }
    }
}