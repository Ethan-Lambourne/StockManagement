using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using StockManagement.Shared.Models;

namespace StockManagement.Shared.Repos
{
    public class CsvGraphicsCardRepository : IItemsRepository<GraphicsCard>
    {
        private readonly string graphicsCardFilePath = "C:\\dev\\stockManagement\\stockManagement.Shared\\ItemStorage\\GraphicsCardData.csv";
        private readonly CsvConfiguration csvConfiguration = new(CultureInfo.InvariantCulture);

        public GraphicsCard AddItem(GraphicsCard item)
        {
            List<GraphicsCard> allGraphicsCards = GetAllItems();
            using StreamWriter graphicsCardWriter = new(graphicsCardFilePath);
            using CsvWriter csvGraphicsCardWriter = new(graphicsCardWriter, csvConfiguration);

            allGraphicsCards.Add(item);
            csvGraphicsCardWriter.WriteHeader<GraphicsCard>();
            csvGraphicsCardWriter.NextRecord();
            csvGraphicsCardWriter.WriteRecords(allGraphicsCards);
            return item;
        }

        public bool DeleteItem(int itemID)
        {
            List<GraphicsCard> allGraphicsCards = GetAllItems();
            var item = GetItem(itemID);

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

        public GraphicsCard? EditItem(GraphicsCard ExampleItem, int itemID)
        {
            GraphicsCard? item = GetItem(itemID);
            if (item != null)
            {
                if (ExampleItem.Name != "") { item.Name = ExampleItem.Name; }
                if (ExampleItem.Stock != null) { item.Stock = ExampleItem.Stock; }
                if (ExampleItem.Price != null) { item.Price = (double)ExampleItem.Price; }
                if (ExampleItem.VRAM != 0) { item.VRAM = ExampleItem.VRAM; }
                if (ExampleItem.CudaCores != 0) { item.CudaCores = ExampleItem.CudaCores; }
                DeleteItem(itemID);
                AddItem(item);
            }
            return item;
        }

        public List<GraphicsCard> GetAllItems()
        {
            using StreamReader graphicsCardReader = new(graphicsCardFilePath);
            using CsvReader csvGraphicsCardReader = new(graphicsCardReader, csvConfiguration);

            List<GraphicsCard> allGraphicsCards = csvGraphicsCardReader.GetRecords<GraphicsCard>().ToList();
            return allGraphicsCards;
        }

        public GraphicsCard? GetItem(int itemID)
        {
            List<GraphicsCard> allGraphicsCards = GetAllItems();
            return allGraphicsCards.FirstOrDefault(item => item.ID == itemID); ;
        }
    }
}