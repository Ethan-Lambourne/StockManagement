using Microsoft.AspNetCore.Mvc;
using StockManagement.API.Models;
using StockManagement.Repos;

namespace StockManagement.API.Controllers
{
    [ApiController]
    [Route("API/Laptop")]
    public class LaptopController : ControllerBase, IItemsController<Laptop>
    {
        public CsvLaptopRepository _csvLaptopRepository = new();

        [HttpPost("AddItem")]
        public ActionResult<Laptop> AddItem(Laptop item)
        {
            _csvLaptopRepository.AddItem(item);
            return Ok(item);
        }

        [HttpDelete("DeleteItem")]
        public ActionResult<bool> DeleteItem(int itemID)
        {
            bool check = _csvLaptopRepository.DeleteItem(itemID);
            if (check)
            {
                return Ok(check);
            }
            else
            {
                return BadRequest(check);
            }
        }

        [HttpPut("EditItem")]
        public ActionResult<Laptop>? EditItem(Laptop ExampleItem, int itemID)
        {
            var check = _csvLaptopRepository.EditItem(ExampleItem, itemID);
            if (check != null)
            {
                return Ok(check);
            }
            return BadRequest(check);
        }

        [HttpGet("GetAllItems")]
        public ActionResult<Laptop> GetAllItems()
        {
            return Ok(_csvLaptopRepository.GetAllItems());
        }

        [HttpGet("GetItemById")]
        public ActionResult<Laptop>? GetItem(int itemID)
        {
            var item = _csvLaptopRepository.GetItem(itemID);
            if (item == null)
            {
                return NotFound(item);
            }
            return Ok(item);
        }
    }
}