using log4net;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;
using System.Reflection;

namespace StockManagement.API.Controllers
{
    [ApiController]
    [Route("API/GraphicsCard")]
    public class GraphicsCardController : ControllerBase, IItemsController<GraphicsCard>
    {
        private readonly ILog _log;
        private readonly IItemsRepository<GraphicsCard> _csvGraphicsCardRepository;

        public GraphicsCardController(IItemsRepository<GraphicsCard> csvGraphicsCardRepository)
        {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
            _csvGraphicsCardRepository = csvGraphicsCardRepository;
        }

        [HttpPost("AddItem")]
        public IActionResult AddItem(GraphicsCard item)
        {
            GraphicsCard check = _csvGraphicsCardRepository.AddItem(item);
            if (check == item)
            {
                _log.Info($"Item {item} was added to GraphicsCardData.csv");
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
            bool deleted = _csvGraphicsCardRepository.DeleteItem(itemID);
            if (deleted)
            {
                _log.Info($"Item with ID {itemID} was deleted from GraphicsCardData.csv");
                return StatusCode(StatusCodes.Status204NoContent, deleted);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Item ID {itemID} does not exist");
            }
        }

        [HttpPut("EditItem")]
        public IActionResult EditItem(GraphicsCard ExampleItem, int itemID)
        {
            var item = _csvGraphicsCardRepository.EditItem(ExampleItem, itemID);
            if (item != null)
            {
                _log.Info($"Item with ID {itemID} was edited within GraphicsCardData.csv");
                return StatusCode(StatusCodes.Status201Created, item);
            }
            return StatusCode(StatusCodes.Status404NotFound, $"Item ID {itemID} does not exist");
        }

        [HttpGet("GetAllItems")]
        public IActionResult GetAllItems()
        {
            _log.Info($"All items retrieved from GraphicsCardData.csv");
            return Ok(_csvGraphicsCardRepository.GetAllItems());
        }

        [HttpGet("GetItemById")]
        public IActionResult GetItem(int itemID)
        {
            var item = _csvGraphicsCardRepository.GetItem(itemID);
            if (item == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Item ID {itemID} does not exist");
            }
            _log.Info($"{item} was retrieved from GraphicsCardData.csv");
            return Ok(item);
        }
    }
}