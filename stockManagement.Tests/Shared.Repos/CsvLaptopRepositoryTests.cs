using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using StockManagement.API.Models;

namespace StockManagement.Repos
{
    public class CsvLaptopRepositoryTests
    {
        private readonly Laptop item = new(999, "test laptop", "laptop", 11, 22.22, 33.33, 44, 55);

        [Test]
        public void GetIndividualLaptopUsingLaptopCsvRepository()
        {
            var csvLaptopRepository = new CsvLaptopRepository();
            csvLaptopRepository.AddItem(item);

            var check = csvLaptopRepository.GetItem(item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.ScreenSize, Is.EqualTo(item.ScreenSize));
                Assert.That(check.RAM, Is.EqualTo(item.RAM));
                Assert.That(check.Storage, Is.EqualTo(item.Storage));
            });
            csvLaptopRepository.DeleteItem(item.ID);
        }

        [Test]
        public void GetAllLaptopsUsingCsvLaptopRepository()
        {
            var csvLaptopRepository = new CsvLaptopRepository();

            List<Laptop> check = csvLaptopRepository.GetAllItems();
            for (int i = 0; i < check.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(check[i].Name, Is.EqualTo(csvLaptopRepository.GetAllItems()[i].Name));
                    Assert.That(check[i].Stock, Is.EqualTo(csvLaptopRepository.GetAllItems()[i].Stock));
                    Assert.That(check[i].Price, Is.EqualTo(csvLaptopRepository.GetAllItems()[i].Price));
                    Assert.That(check[i].ScreenSize, Is.EqualTo(csvLaptopRepository.GetAllItems()[i].ScreenSize));
                    Assert.That(check[i].RAM, Is.EqualTo(csvLaptopRepository.GetAllItems()[i].RAM));
                    Assert.That(check[i].Storage, Is.EqualTo(csvLaptopRepository.GetAllItems()[i].Storage));
                });
            }
        }

        [Test]
        public void AddLaptopUsingLaptopCsvRepository()
        {
            var csvLaptopRepository = new CsvLaptopRepository();

            var check = csvLaptopRepository.AddItem(item);

            Assert.Multiple(() =>
            {
                Assert.That(check.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.ScreenSize, Is.EqualTo(item.ScreenSize));
                Assert.That(check.RAM, Is.EqualTo(item.RAM));
                Assert.That(check.Storage, Is.EqualTo(item.Storage));
            });
            csvLaptopRepository.DeleteItem(item.ID);
        }

        [TestCase("test name", 50, 100, 20, 16, 500)]
        [TestCase("TEST NAME", 0, 50.5, 18.5, 8, 1000)]
        [TestCase("Test Name123", 10000, 999.99, 25.25, 64, 3000)]
        [TestCase("test name!&*^%4", 1, 0, 8, 128, 10)]
        public void EditLaptopUsingLaptopCsvRepository(string testName, int testStock, double testPrice, double testScreenSize, int testRAM, int testStorage)
        {
            var csvLaptopRepository = new CsvLaptopRepository();
            Laptop ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testScreenSize, testRAM, testStorage);
            csvLaptopRepository.AddItem(item);

            var check = csvLaptopRepository.EditItem(ExampleItem, item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(testName));
                Assert.That(check.Stock, Is.EqualTo(testStock));
                Assert.That(check.Price, Is.EqualTo(testPrice));
                Assert.That(check.ScreenSize, Is.EqualTo(testScreenSize));
                Assert.That(check.RAM, Is.EqualTo(testRAM));
                Assert.That(check.Storage, Is.EqualTo(testStorage));
            });
            csvLaptopRepository.DeleteItem(item.ID);
        }

        [Test]
        public void DeleteLaptopUsingLaptopCsvRepository()
        {
            var csvLaptopRepository = new CsvLaptopRepository();
            csvLaptopRepository.AddItem(item);

            bool check = csvLaptopRepository.DeleteItem(item.ID);

            Assert.That(check, Is.EqualTo(true));
        }
    }
}