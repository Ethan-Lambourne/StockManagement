using Microsoft.AspNetCore.Mvc;
using Moq;
using StockManagement.API.Controllers;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace stockManagement.API.Controllers
{
    public class LaptopControllerTests
    {
        private readonly Laptop item = new(999, "test laptop", "laptop", 11, 22.22, 33.33, 44, 55);

        [Test]
        public void GetIndividualLaptopUsingLaptopController()
        {
            var mockCsvLaptopRepository = new Mock<IItemsRepository<Laptop>>();
            var laptopController = new LaptopController(mockCsvLaptopRepository.Object);
            mockCsvLaptopRepository.Setup(x => x.GetItem(item.ID)).Returns(item);

            var gottenLaptop = laptopController.GetItem(item.ID);

            var gottenLaptopResult = gottenLaptop as ObjectResult;
            Laptop gottenLaptopValue = (Laptop)gottenLaptopResult!.Value!;
            Assert.Multiple(() =>
            {
                Assert.That(gottenLaptop, Is.Not.EqualTo(null));
                Assert.That(gottenLaptopResult, Is.InstanceOf(typeof(OkObjectResult)));
                Assert.That(gottenLaptopValue.Name, Is.EqualTo(item.Name));
                Assert.That(gottenLaptopValue.Stock, Is.EqualTo(item.Stock));
                Assert.That(gottenLaptopValue.Price, Is.EqualTo(item.Price));
                Assert.That(gottenLaptopValue.ScreenSize, Is.EqualTo(item.ScreenSize));
                Assert.That(gottenLaptopValue.RAM, Is.EqualTo(item.RAM));
                Assert.That(gottenLaptopValue.Storage, Is.EqualTo(item.Storage));
            });
        }

        [Test]
        public void GetAllLaptopsUsingLaptopController()
        {
            var mockCsvLaptopRepository = new Mock<IItemsRepository<Laptop>>();
            var laptopController = new LaptopController(mockCsvLaptopRepository.Object);

            var allLaptops = laptopController.GetAllItems();

            Assert.That(allLaptops, Is.InstanceOf(typeof(OkObjectResult)));
        }

        [Test]
        public void AddLaptopUsingLaptopController()
        {
            var mockCsvLaptopRepository = new Mock<IItemsRepository<Laptop>>();
            var laptopController = new LaptopController(mockCsvLaptopRepository.Object);
            mockCsvLaptopRepository.Setup(x => x.AddItem(item)).Returns(item);

            var addedLaptop = laptopController.AddItem(item);

            var addedLaptopResult = addedLaptop as ObjectResult;
            Laptop addedLaptopValue = (Laptop)addedLaptopResult!.Value!;
            Assert.Multiple(() =>
            {
                Assert.That(addedLaptop, Is.Not.EqualTo(null));
                Assert.That(addedLaptopValue.Name, Is.EqualTo(item.Name));
                Assert.That(addedLaptopValue.Stock, Is.EqualTo(item.Stock));
                Assert.That(addedLaptopValue.Price, Is.EqualTo(item.Price));
                Assert.That(addedLaptopValue.ScreenSize, Is.EqualTo(item.ScreenSize));
                Assert.That(addedLaptopValue.RAM, Is.EqualTo(item.RAM));
                Assert.That(addedLaptopValue.Storage, Is.EqualTo(item.Storage));
            });
        }

        [TestCase("test name", 50, 100, 20, 16, 500)]
        [TestCase("TEST NAME", 0, 50.5, 18.5, 8, 1000)]
        [TestCase("Test Name123", 10000, 999.99, 25.25, 64, 3000)]
        [TestCase("test name!&*^%4", 1, 0, 8, 128, 10)]
        public void EditLaptopUsingLaptopController(string testName, int testStock, double testPrice, double testScreenSize, int testRAM, int testStorage)
        {
            var mockCsvLaptopRepository = new Mock<IItemsRepository<Laptop>>();
            var laptopController = new LaptopController(mockCsvLaptopRepository.Object);
            Laptop ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testScreenSize, testRAM, testStorage);
            mockCsvLaptopRepository.Setup(x => x.EditItem(ExampleItem, item.ID)).Returns(ExampleItem);

            var editedLaptop = laptopController.EditItem(ExampleItem, item.ID);

            var editedLaptopResult = editedLaptop as ObjectResult;
            Laptop editedLaptopValue = (Laptop)editedLaptopResult!.Value!;
            Assert.Multiple(() =>
            {
                Assert.That(editedLaptop, Is.Not.EqualTo(null));
                Assert.That(editedLaptopValue.Name, Is.EqualTo(testName));
                Assert.That(editedLaptopValue.Stock, Is.EqualTo(testStock));
                Assert.That(editedLaptopValue.Price, Is.EqualTo(testPrice));
                Assert.That(editedLaptopValue.ScreenSize, Is.EqualTo(testScreenSize));
                Assert.That(editedLaptopValue.RAM, Is.EqualTo(testRAM));
                Assert.That(editedLaptopValue.Storage, Is.EqualTo(testStorage));
            });
        }

        [Test]
        public void DeleteLaptopUsingLaptopController()
        {
            var mockCsvLaptopRepository = new Mock<IItemsRepository<Laptop>>();
            var laptopController = new LaptopController(mockCsvLaptopRepository.Object);
            mockCsvLaptopRepository.Setup(x => x.DeleteItem(item.ID)).Returns(true);

            var deletedLaptop = laptopController.DeleteItem(item.ID);

            var deletedLaptopResult = deletedLaptop as ObjectResult;
            bool deletedLaptopValue = (bool)deletedLaptopResult!.Value!;
            Assert.That(deletedLaptopValue, Is.EqualTo(true));
        }
    }
}