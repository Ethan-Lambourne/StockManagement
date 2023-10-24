using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using StockManagement.API.Models;
using System.Globalization;

namespace StockManagement.API.Controllers
{
    [ApiController]
    [Route("API/Laptop")]
    public class LaptopController : ControllerBase, IItemsController<Laptop>
    {
        private readonly string laptopFilePath = "C:\\dev\\stockManagement\\stockManagement.Shared\\ItemStorage\\LaptopData.csv";
        private readonly CsvConfiguration csvConfiguration = new(CultureInfo.InvariantCulture);

        [HttpPost("AddItem")]
        public ActionResult<Laptop> AddItem(Laptop item)
        {
            List<Laptop> allLaptops = GetAllItemsInListForm();
            using StreamWriter laptopWriter = new(laptopFilePath);
            using CsvWriter csvLaptopWriter = new(laptopWriter, csvConfiguration);

            allLaptops.Add(item);
            csvLaptopWriter.WriteHeader<Laptop>();
            csvLaptopWriter.NextRecord();
            csvLaptopWriter.WriteRecords(allLaptops);
            return Ok(item);
        }

        [HttpDelete("DeleteItem")]
        public ActionResult<bool> DeleteItem(int itemID)
        {
            List<Laptop> allLaptops = GetAllItemsInListForm();
            Laptop? item = allLaptops.FirstOrDefault(item => item.ID == itemID);

            if (item != null)
            {
                using StreamWriter laptopWriter = new(laptopFilePath);
                using CsvWriter csvLaptopWriter = new(laptopWriter, csvConfiguration);
                for (int i = 0; i < allLaptops.Count; i++)
                {
                    if (itemID == allLaptops[i].ID)
                    {
                        allLaptops.Remove(allLaptops[i]);
                        csvLaptopWriter.WriteHeader<Laptop>();
                        csvLaptopWriter.NextRecord();
                        csvLaptopWriter.WriteRecords(allLaptops);
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
        public ActionResult<Laptop>? EditItem(Laptop ExampleItem, int itemID)
        {
            List<Laptop> allLaptops = GetAllItemsInListForm();
            Laptop? item = allLaptops.FirstOrDefault(item => item.ID == itemID);
            if (item != null)
            {
                if (ExampleItem.Name != "") { item.Name = ExampleItem.Name; }
                if (ExampleItem.Stock != null) { item.Stock = ExampleItem.Stock; }
                if (ExampleItem.Price != null) { item.Price = (double)ExampleItem.Price; }
                if (ExampleItem.ScreenSize != 0) { item.ScreenSize = ExampleItem.ScreenSize; }
                if (ExampleItem.RAM != 0) { item.RAM = ExampleItem.RAM; }
                if (ExampleItem.Storage != 0) { item.Storage = ExampleItem.Storage; }
                DeleteItem(itemID);
                AddItem(item);
                return Ok(item);
            }
            return BadRequest(item);
        }

        [HttpGet("GetAllItems")]
        public ActionResult<Laptop> GetAllItems()
        {
            using StreamReader laptopReader = new(laptopFilePath);
            using CsvReader csvLaptopReader = new(laptopReader, csvConfiguration);
            List<Laptop> allLaptops = csvLaptopReader.GetRecords<Laptop>().ToList();
            return Ok(allLaptops);
        }

        [HttpGet("GetItemById")]
        public ActionResult<Laptop> GetItem(int itemID)
        {
            List<Laptop> allLaptops = GetAllItemsInListForm();
            Laptop? item = allLaptops.FirstOrDefault(item => item.ID == itemID);
            if (item == null)
            {
                return NotFound(item);
            }
            return Ok(item);
        }

        [HttpGet("GetAllItemsInListForm")]
        public List<Laptop> GetAllItemsInListForm()
        {
            using StreamReader laptopReader = new(laptopFilePath);
            using CsvReader csvLaptopReader = new(laptopReader, csvConfiguration);
            List<Laptop> allLaptops = csvLaptopReader.GetRecords<Laptop>().ToList();
            return allLaptops;
        }
    }
}