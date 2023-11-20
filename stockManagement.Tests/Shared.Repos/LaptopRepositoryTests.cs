using StockManagement.Shared.Models;
using Moq;

namespace StockManagement.Shared.Repos
{
    public class LaptopRepositoryTests
    {
        private readonly Laptop item = new(999, "test laptop", "laptop", 11, 22.22, 33.33, 44, 55);

        [Test]
        public void AddLaptopItemToLaptopList()
        {
            var laptopRepository = new LaptopRepository();

            var check = laptopRepository.AddItem(item);

            Assert.That(check, Is.EqualTo(item));
        }

        [Test]
        public void GetIndividualItemFromLaptopList()
        {
            var laptopRepository = new LaptopRepository();
            laptopRepository.AddItem(item);

            var check = laptopRepository.GetItem(999);

            Assert.That(check, Is.EqualTo(item));
        }

        [Test]
        public void DeleteItemFromLaptopList()
        {
            var laptopRepository = new LaptopRepository();
            laptopRepository.AddItem(item);

            var check = laptopRepository.DeleteItem(999);

            Assert.That(check, Is.EqualTo(true));
        }

        [TestCase("test name", 50, 100, 20, 16, 500)]
        [TestCase("TEST NAME", 0, 50.5, 18.5, 8, 1000)]
        [TestCase("Test Name123", 10000, 999.99, 25.25, 64, 3000)]
        [TestCase("test name!&*^%4", 1, 0, 8, 128, 10)]
        public void EditItemFromLaptopList(string testName, int testStock, double testPrice, double testScreenSize, int testRAM, int testStorage)
        {
            var laptopRepository = new LaptopRepository();
            laptopRepository.AddItem(item);
            Laptop ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testScreenSize, testRAM, testStorage);

            var check = laptopRepository.EditItem(ExampleItem, item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check!.Name, Is.EqualTo(testName));
                Assert.That(check.Stock, Is.EqualTo(testStock));
                Assert.That(check.Price, Is.EqualTo(testPrice));
                Assert.That(check.ScreenSize, Is.EqualTo(testScreenSize));
                Assert.That(check.RAM, Is.EqualTo(testRAM));
                Assert.That(check.Storage, Is.EqualTo(testStorage));
            });
        }

        [Test]
        public void GetAllItemsFromLaptopList()
        {
            var laptopRepository = new LaptopRepository();

            List<Laptop> check = laptopRepository.GetAllItems();

            Assert.That(check, Is.EqualTo(laptopRepository.GetAllItems()));
        }
    }
}