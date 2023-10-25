using Microsoft.AspNetCore.Mvc;
using StockManagement.API.Models;
using StockManagement.Repos;

namespace StockManagement.API.Controllers
{
    [ApiController]
    [Route("API/GraphicsCard")]
    public class GraphicsCardController : ControllerBase, IItemsController<GraphicsCard>
    {
        public CsvGraphicsCardRepository _csvGraphicsCardRepository = new();

        [HttpPost("AddItem")]
        public ActionResult<GraphicsCard> AddItem(GraphicsCard item)
        {
            _csvGraphicsCardRepository.AddItem(item);
            return Ok(item);
        }

        [HttpDelete("DeleteItem")]
        public ActionResult<bool> DeleteItem(int itemID)
        {
            bool check = _csvGraphicsCardRepository.DeleteItem(itemID);
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
        public ActionResult<GraphicsCard>? EditItem(GraphicsCard ExampleItem, int itemID)
        {
            var item = _csvGraphicsCardRepository.EditItem(ExampleItem, itemID);
            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest(item);
        }

        [HttpGet("GetAllItems")]
        public ActionResult<GraphicsCard> GetAllItems()
        {
            return Ok(_csvGraphicsCardRepository.GetAllItems());
        }

        [HttpGet("GetItemById")]
        public ActionResult<GraphicsCard>? GetItem(int itemID)
        {
            var item = _csvGraphicsCardRepository.GetItem(itemID);
            if (item == null)
            {
                return NotFound(item);
            }
            return Ok(item);
        }
    }
}