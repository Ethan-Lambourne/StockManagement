using StockManagement.Models;

namespace StockManagement.Repos
{
    public class CsvGraphicsCardRepositoryTests
    {
        private readonly GraphicsCard item = new(999, "test graphics card", "graphics card", 11, 22.22, 33, 44);

        [Test]
        public void GetIndividualGraphicsCardUsingGraphicsCardCsvRepository()
        {
            var csvGraphicsCardRepository = new CsvGraphicsCardRepository();
            csvGraphicsCardRepository.AddItem(item);

            var check = csvGraphicsCardRepository.GetItem(item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.VRAM, Is.EqualTo(item.VRAM));
                Assert.That(check.CudaCores, Is.EqualTo(item.CudaCores));
            });
            csvGraphicsCardRepository.DeleteItem(item.ID);
        }

        [Test]
        public void GetAllGraphicsCardsUsingCsvGraphicsCardRepository()
        {
            var csvGraphicsCardRepository = new CsvGraphicsCardRepository();

            List<GraphicsCard> check = csvGraphicsCardRepository.GetAllItems();
            for (int i = 0; i < check.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(check[i].Name, Is.EqualTo(csvGraphicsCardRepository.GetAllItems()[i].Name));
                    Assert.That(check[i].Stock, Is.EqualTo(csvGraphicsCardRepository.GetAllItems()[i].Stock));
                    Assert.That(check[i].Price, Is.EqualTo(csvGraphicsCardRepository.GetAllItems()[i].Price));
                    Assert.That(check[i].VRAM, Is.EqualTo(csvGraphicsCardRepository.GetAllItems()[i].VRAM));
                    Assert.That(check[i].CudaCores, Is.EqualTo(csvGraphicsCardRepository.GetAllItems()[i].CudaCores));
                });
            }
        }

        [Test]
        public void AddGraphicsCardUsingGraphicsCardCsvRepository()
        {
            var csvGraphicsCardRepository = new CsvGraphicsCardRepository();

            var check = csvGraphicsCardRepository.AddItem(item);

            Assert.Multiple(() =>
            {
                Assert.That(check.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.VRAM, Is.EqualTo(item.VRAM));
                Assert.That(check.CudaCores, Is.EqualTo(item.CudaCores));
            });
            csvGraphicsCardRepository.DeleteItem(item.ID);
        }

        [TestCase("test name", 50, 100, 8, 4)]
        [TestCase("TEST NAME", 0, 50.5, 10, 6)]
        [TestCase("Test Name123", 10000, 999.99, 6, 2)]
        [TestCase("test name!&*^%4", 1, 0, 20, 12)]
        public void EditGraphicsCardUsingGraphicsCardCsvRepository(string testName, int testStock, double testPrice, int testVRAM, int testCudaCores)
        {
            var csvGraphicsCardRepository = new CsvGraphicsCardRepository();
            GraphicsCard ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testVRAM, testCudaCores);
            csvGraphicsCardRepository.AddItem(item);

            var check = csvGraphicsCardRepository.EditItem(ExampleItem, item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(testName));
                Assert.That(check.Stock, Is.EqualTo(testStock));
                Assert.That(check.Price, Is.EqualTo(testPrice));
                Assert.That(check.VRAM, Is.EqualTo(testVRAM));
                Assert.That(check.CudaCores, Is.EqualTo(testCudaCores));
            });
            csvGraphicsCardRepository.DeleteItem(item.ID);
        }

        [Test]
        public void DeleteGraphicsCardUsingGraphicsCardCsvRepository()
        {
            var csvGraphicsCardRepository = new CsvGraphicsCardRepository();
            csvGraphicsCardRepository.AddItem(item);

            bool check = csvGraphicsCardRepository.DeleteItem(item.ID);

            Assert.That(check, Is.EqualTo(true));
        }
    }
}