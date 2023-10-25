using CsvHelper;
using CsvHelper.Configuration;
using StockManagement.API.Models;
using System.Globalization;

namespace StockManagement.Repos
{
    public class CsvLaptopRepository : IItemsRepository<Laptop>
    {
        private readonly string laptopFilePath = "C:\\dev\\stockManagement\\stockManagement.Shared\\ItemStorage\\LaptopData.csv";
        private readonly CsvConfiguration csvConfiguration = new(CultureInfo.InvariantCulture);

        public Laptop AddItem(Laptop item)
        {
            List<Laptop> allLaptops = GetAllItems();
            using StreamWriter laptopWriter = new(laptopFilePath);
            using CsvWriter csvLaptopWriter = new(laptopWriter, csvConfiguration);

            allLaptops.Add(item);
            csvLaptopWriter.WriteHeader<Laptop>();
            csvLaptopWriter.NextRecord();
            csvLaptopWriter.WriteRecords(allLaptops);
            return item;
        }

        public bool DeleteItem(int itemID)
        {
            List<Laptop> allLaptops = GetAllItems();
            var item = GetItem(itemID);

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
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public Laptop? EditItem(Laptop ExampleItem, int itemID)
        {
            Laptop? item = GetItem(itemID);
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
            }
            return item;
        }

        public List<Laptop> GetAllItems()
        {
            using StreamReader laptopReader = new(laptopFilePath);
            using CsvReader csvLaptopReader = new(laptopReader, csvConfiguration);
            List<Laptop> allLaptops = csvLaptopReader.GetRecords<Laptop>().ToList();
            return allLaptops;
        }

        public Laptop? GetItem(int itemID)
        {
            List<Laptop> allLaptops = GetAllItems();
            return allLaptops.FirstOrDefault(item => item.ID == itemID);
        }
    }
}