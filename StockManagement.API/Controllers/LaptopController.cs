using log4net;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;
using System.Reflection;

namespace StockManagement.API.Controllers
{
    [ApiController]
    [Route("API/Laptop")]
    public class LaptopController : ControllerBase, IItemsController<Laptop>
    {
        private readonly ILog _log;
        private readonly IItemsRepository<Laptop> _csvLaptopRepository;

        public LaptopController(IItemsRepository<Laptop> csvLaptopRepository)
        {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
            _csvLaptopRepository = csvLaptopRepository;
        }

        [HttpPost("AddItem")]
        public IActionResult AddItem(Laptop item)
        {
            Laptop check = _csvLaptopRepository.AddItem(item);
            if (check == item)
            {
                _log.Info($"Item {item} was added to LaptopData.csv");
                return StatusCode(StatusCodes.Status201Created, item);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteItem")]
        public IActionResult DeleteItem(int itemID)
        {
            bool deleted = _csvLaptopRepository.DeleteItem(itemID);
            if (deleted)
            {
                _log.Info($"Item with ID {itemID} was deleted from LaptopData.csv");
                return StatusCode(StatusCodes.Status204NoContent, deleted);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Item ID {itemID} does not exist"); ;
            }
        }

        [HttpPut("EditItem")]
        public IActionResult EditItem(Laptop exampleItem, int itemID)
        {
            var editedItem = _csvLaptopRepository.EditItem(exampleItem, itemID);
            if (editedItem != null)
            {
                _log.Info($"Item with ID {itemID} was edited within LaptopData.csv");
                return StatusCode(StatusCodes.Status201Created, editedItem); ;
            }
            return StatusCode(StatusCodes.Status404NotFound, $"Item ID {itemID} does not exist");
        }

        [HttpGet("GetAllItems")]
        public IActionResult GetAllItems()
        {
            _log.Info($"All items retrieved from LaptopData.csv");
            return Ok(_csvLaptopRepository.GetAllItems());
        }

        [HttpGet("GetItemById")]
        public IActionResult GetItem(int itemID)
        {
            var item = _csvLaptopRepository.GetItem(itemID);
            if (item == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Item ID {itemID} does not exist");
            }
            _log.Info($"{item} was retrieved from LaptopData.csv");
            return Ok(item);
        }
    }
}