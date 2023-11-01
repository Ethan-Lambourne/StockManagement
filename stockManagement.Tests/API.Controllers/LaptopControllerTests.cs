using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StockManagement.API.Controllers;
using StockManagement.API.Models;
using StockManagement.Repos;

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

            var check = laptopController.GetItem(item.ID);

            var checkResult = (ObjectResult)check!.Result!;
            Laptop checkValue = (Laptop)checkResult!.Value!;
            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check.Result, Is.InstanceOf(typeof(OkObjectResult)));
                Assert.That(checkValue.Name, Is.EqualTo(item.Name));
                Assert.That(checkValue.Stock, Is.EqualTo(item.Stock));
                Assert.That(checkValue.Price, Is.EqualTo(item.Price));
                Assert.That(checkValue.ScreenSize, Is.EqualTo(item.ScreenSize));
                Assert.That(checkValue.RAM, Is.EqualTo(item.RAM));
                Assert.That(checkValue.Storage, Is.EqualTo(item.Storage));
            });
        }

        [Test]
        public void GetAllLaptopsUsingLaptopController()
        {
            var mockCsvLaptopRepository = new Mock<IItemsRepository<Laptop>>();
            var laptopController = new LaptopController(mockCsvLaptopRepository.Object);

            var check = laptopController.GetAllItems();

            Assert.That(check.Result, Is.InstanceOf(typeof(OkObjectResult)));
        }

        [Test]
        public void AddLaptopUsingLaptopController()
        {
            var mockCsvLaptopRepository = new Mock<IItemsRepository<Laptop>>();
            var laptopController = new LaptopController(mockCsvLaptopRepository.Object);
            mockCsvLaptopRepository.Setup(x => x.AddItem(item)).Returns(item);

            var check = laptopController.AddItem(item);

            var checkResult = (ObjectResult)check!.Result!;
            Laptop checkValue = (Laptop)checkResult!.Value!;
            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check.Result, Is.InstanceOf(typeof(OkObjectResult)));
                Assert.That(checkValue.Name, Is.EqualTo(item.Name));
                Assert.That(checkValue.Stock, Is.EqualTo(item.Stock));
                Assert.That(checkValue.Price, Is.EqualTo(item.Price));
                Assert.That(checkValue.ScreenSize, Is.EqualTo(item.ScreenSize));
                Assert.That(checkValue.RAM, Is.EqualTo(item.RAM));
                Assert.That(checkValue.Storage, Is.EqualTo(item.Storage));
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

            var check = laptopController.EditItem(ExampleItem, item.ID);

            var checkResult = (ObjectResult)check!.Result!;
            Laptop checkValue = (Laptop)checkResult!.Value!;
            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Result, Is.InstanceOf(typeof(OkObjectResult)));
                Assert.That(checkValue.Name, Is.EqualTo(testName));
                Assert.That(checkValue.Stock, Is.EqualTo(testStock));
                Assert.That(checkValue.Price, Is.EqualTo(testPrice));
                Assert.That(checkValue.ScreenSize, Is.EqualTo(testScreenSize));
                Assert.That(checkValue.RAM, Is.EqualTo(testRAM));
                Assert.That(checkValue.Storage, Is.EqualTo(testStorage));
            });
        }

        [Test]
        public void DeleteLaptopUsingLaptopController()
        {
            var mockCsvLaptopRepository = new Mock<IItemsRepository<Laptop>>();
            var laptopController = new LaptopController(mockCsvLaptopRepository.Object);
            mockCsvLaptopRepository.Setup(x => x.DeleteItem(item.ID)).Returns(true);

            var check = laptopController.DeleteItem(item.ID);

            Assert.That(check.Result, Is.InstanceOf(typeof(OkObjectResult)));
        }
    }
}