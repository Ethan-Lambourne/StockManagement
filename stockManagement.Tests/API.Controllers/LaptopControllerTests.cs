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
            var mockCsvLaptopRepository = new Mock<CsvLaptopRepository>();
            var laptopController = new LaptopController();
            mockCsvLaptopRepository.Object.AddItem(item);

            var check = laptopController.GetItem(item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Result, Is.InstanceOf(typeof(OkObjectResult)));
            });
            mockCsvLaptopRepository.Object.DeleteItem(item.ID);
        }

        [Test]
        public void GetAllLaptopsUsingLaptopController()
        {
            var laptopController = new LaptopController();

            var check = laptopController.GetAllItems();

            Assert.That(check.Result, Is.InstanceOf(typeof(OkObjectResult)));
        }

        [Test]
        public void AddLaptopUsingLaptopController()
        {
            var mockCsvLaptopRepository = new Mock<CsvLaptopRepository>();
            var laptopController = new LaptopController();

            var check = laptopController.AddItem(item);

            Assert.That(check.Result, Is.InstanceOf(typeof(OkObjectResult)));
            mockCsvLaptopRepository.Object.DeleteItem(item.ID);
        }

        [TestCase("test name", 50, 100, 20, 16, 500)]
        [TestCase("TEST NAME", 0, 50.5, 18.5, 8, 1000)]
        [TestCase("Test Name123", 10000, 999.99, 25.25, 64, 3000)]
        [TestCase("test name!&*^%4", 1, 0, 8, 128, 10)]
        public void EditLaptopUsingLaptopController(string testName, int testStock, double testPrice, double testScreenSize, int testRAM, int testStorage)
        {
            var mockCsvLaptopRepository = new Mock<CsvLaptopRepository>();
            var laptopController = new LaptopController();
            Laptop ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testScreenSize, testRAM, testStorage);
            mockCsvLaptopRepository.Object.AddItem(item);

            var check = laptopController.EditItem(ExampleItem, item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Result, Is.InstanceOf(typeof(OkObjectResult)));
            });
            mockCsvLaptopRepository.Object.DeleteItem(item.ID);
        }

        [Test]
        public void DeleteLaptopUsingLaptopController()
        {
            var mockCsvLaptopRepository = new Mock<CsvLaptopRepository>();
            var laptopController = new LaptopController();
            mockCsvLaptopRepository.Object.AddItem(item);

            var check = laptopController.DeleteItem(item.ID);

            Assert.That(check.Result, Is.InstanceOf(typeof(OkObjectResult)));
        }
    }
}