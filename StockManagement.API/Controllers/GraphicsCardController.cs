using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using StockManagement.API.Models;
using System.Globalization;

namespace StockManagement.API.Controllers
{
    [ApiController]
    [Route("API/GraphicsCard")]
    public class GraphicsCardController : ControllerBase, IItemsController<GraphicsCard>
    {
        private readonly string graphicsCardFilePath = "C:\\dev\\stockManagement\\stockManagement.Shared\\ItemStorage\\GraphicsCardData.csv";
        private readonly CsvConfiguration csvConfiguration = new(CultureInfo.InvariantCulture);

        [HttpPost("AddItem")]
        public ActionResult<GraphicsCard> AddItem(GraphicsCard item)
        {
            List<GraphicsCard> allGraphicsCards = GetAllItemsInListForm();
            using StreamWriter graphicsCardWriter = new(graphicsCardFilePath);
            using CsvWriter csvGraphicsCardWriter = new(graphicsCardWriter, csvConfiguration);

            allGraphicsCards.Add(item);
            csvGraphicsCardWriter.WriteHeader<GraphicsCard>();
            csvGraphicsCardWriter.NextRecord();
            csvGraphicsCardWriter.WriteRecords(allGraphicsCards);
            return Ok(item);
        }

        [HttpDelete("DeleteItem")]
        public ActionResult<bool> DeleteItem(int itemID)
        {
            List<GraphicsCard> allGraphicsCards = GetAllItemsInListForm();
            GraphicsCard? item = allGraphicsCards.FirstOrDefault(item => item.ID == itemID);

            if (item != null)
            {
                using StreamWriter graphicsCardWriter = new(graphicsCardFilePath);
                using CsvWriter csvGraphicsCardWriter = new(graphicsCardWriter, csvConfiguration);
                for (int i = 0; i < allGraphicsCards.Count; i++)
                {
                    if (itemID == allGraphicsCards[i].ID)
                    {
                        allGraphicsCards.Remove(allGraphicsCards[i]);
                        csvGraphicsCardWriter.WriteHeader<GraphicsCard>();
                        csvGraphicsCardWriter.NextRecord();
                        csvGraphicsCardWriter.WriteRecords(allGraphicsCards);
                        return Ok(true);
                    }
                }
                return NotFound(false);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpPut("EditItem")]
        public ActionResult<GraphicsCard>? EditItem(GraphicsCard ExampleItem, int itemID)
        {
            List<GraphicsCard> allGraphicsCards = GetAllItemsInListForm();
            GraphicsCard? item = allGraphicsCards.FirstOrDefault(item => item.ID == itemID);
            if (item != null)
            {
                if (ExampleItem.Name != "") { item.Name = ExampleItem.Name; }
                if (ExampleItem.Stock != null) { item.Stock = ExampleItem.Stock; }
                if (ExampleItem.Price != null) { item.Price = (double)ExampleItem.Price; }
                if (ExampleItem.VRAM != 0) { item.VRAM = ExampleItem.VRAM; }
                if (ExampleItem.CudaCores != 0) { item.CudaCores = ExampleItem.CudaCores; }
                DeleteItem(itemID);
                AddItem(item);
                return Ok(item);
            }
            return BadRequest(item);
        }

        [HttpGet("GetAllItems")]
        public ActionResult<GraphicsCard> GetAllItems()
        {
            using StreamReader graphicsCardReader = new(graphicsCardFilePath);
            using CsvReader csvGraphicsCardReader = new(graphicsCardReader, csvConfiguration);
            List<GraphicsCard> allGraphicsCards = csvGraphicsCardReader.GetRecords<GraphicsCard>().ToList();
            return Ok(allGraphicsCards);
        }

        [HttpGet("GetItemById")]
        public ActionResult<GraphicsCard>? GetItem(int itemID)
        {
            List<GraphicsCard> allGraphicsCards = GetAllItemsInListForm();
            GraphicsCard? item = allGraphicsCards.FirstOrDefault(item => item.ID == itemID);
            if (item == null)
            {
                return NotFound(item);
            }
            return Ok(item);
        }

        [HttpGet("GetAllItemsInListForm")]
        public List<GraphicsCard> GetAllItemsInListForm()
        {
            using StreamReader graphicsCardReader = new(graphicsCardFilePath);
            using CsvReader csvGraphicsCardReader = new(graphicsCardReader, csvConfiguration);
            List<GraphicsCard> allGraphicsCards = csvGraphicsCardReader.GetRecords<GraphicsCard>().ToList();
            return allGraphicsCards;
        }
    }
}