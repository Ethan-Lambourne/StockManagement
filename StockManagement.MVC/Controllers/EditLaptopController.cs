using Microsoft.AspNetCore.Mvc;
using StockManagement.MVC.Models;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace StockManagement.MVC.Controllers
{
    public class EditLaptopController : Controller
    {
        private readonly IItemsRepository<Laptop> _laptopRepository;

        public EditLaptopController(IItemsRepository<Laptop> laptopRepository)
        {
            _laptopRepository = laptopRepository;
        }

        [Route("/EditLaptop/{laptopId}")]
        public IActionResult EditLaptopView(int laptopId)
        {
            Laptop? laptop = _laptopRepository.GetItem(laptopId);
            if (laptop != null)
            {
                EditLaptopViewModel editLaptopViewModel = new(laptop.ID, laptop.Name, laptop.Type, laptop.Stock,
                    laptop.Price, laptop.ScreenSize, laptop.RAM, laptop.Storage);
                return View(editLaptopViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult EditLaptop(int ID, string Name, string Type, int? Stock, double? Price, double ScreenSize, int RAM, int Storage)
        {
            Laptop exampleItem = new(ID, Name, Type, Stock, Price, ScreenSize, RAM, Storage);
            Laptop? editedItem = _laptopRepository.EditItem(exampleItem, ID);
            if (editedItem != null && editedItem.Name == Name && editedItem.Stock == Stock && editedItem.Price == Price
                && editedItem.ScreenSize == ScreenSize && editedItem.RAM == RAM && editedItem.Storage == Storage)
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