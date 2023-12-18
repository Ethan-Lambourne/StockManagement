using Microsoft.AspNetCore.Mvc;
using StockManagement.MVC.Models;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace StockManagement.MVC.Controllers
{
    public class LaptopController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemsRepository<Laptop> _csvLaptopRepository;

        public LaptopController(ILogger<HomeController> logger, IItemsRepository<Laptop> csvLaptopRepository)
        {
            _logger = logger;
            _csvLaptopRepository = csvLaptopRepository;
        }

        [Route("/LaptopDetails/{laptopId}")]
        public IActionResult LaptopView(int laptopId)
        {
            Laptop? laptop = _csvLaptopRepository.GetItem(laptopId);
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