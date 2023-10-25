using Microsoft.AspNetCore.Mvc;
using Moq;
using StockManagement.API.Controllers;
using StockManagement.API.Models;
using StockManagement.Repos;

namespace stockManagement.API.Controllers
{
    public class GraphicsCardControllerTests
    {
        private readonly GraphicsCard item = new(999, "test graphics card", "graphics card", 11, 22.22, 33, 44);

        [Test]
        public void GetIndividualGraphicsCardUsingGraphicsCardController()
        {
            var mockCsvGraphicsCardRepository = new Mock<CsvGraphicsCardRepository>();
            var graphicsCardController = new GraphicsCardController();
            mockCsvGraphicsCardRepository.Object.AddItem(item);

            var check = graphicsCardController.GetItem(item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Result, Is.InstanceOf(typeof(OkObjectResult)));
            });
            mockCsvGraphicsCardRepository.Object.DeleteItem(item.ID);
        }

        [Test]
        public void GetAllGraphicsCardsUsingGraphicsCardController()
        {
            var graphicsCardController = new GraphicsCardController();

            var check = graphicsCardController.GetAllItems();

            Assert.That(check.Result, Is.InstanceOf(typeof(OkObjectResult)));
        }

        [Test]
        public void AddGraphicsCardUsingGraphicsCardController()
        {
            var mockCsvGraphicsCardRepository = new Mock<CsvGraphicsCardRepository>();
            var graphicsCardController = new GraphicsCardController();

            var check = graphicsCardController.AddItem(item);

            Assert.That(check.Result, Is.InstanceOf(typeof(OkObjectResult)));
            mockCsvGraphicsCardRepository.Object.DeleteItem(item.ID);
        }

        [TestCase("test name", 50, 100, 8, 4)]
        [TestCase("TEST NAME", 0, 50.5, 10, 6)]
        [TestCase("Test Name123", 10000, 999.99, 6, 2)]
        [TestCase("test name!&*^%4", 1, 0, 20, 12)]
        public void EditGraphicsCardUsingGraphicsCardController(string testName, int testStock, double testPrice, int testVRAM, int testCudaCores)
        {
            var mockCsvGraphicsCardRepository = new Mock<CsvGraphicsCardRepository>();
            var graphicsCardController = new GraphicsCardController();
            GraphicsCard ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testVRAM, testCudaCores);
            mockCsvGraphicsCardRepository.Object.AddItem(item);

            var check = graphicsCardController.EditItem(ExampleItem, item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Result, Is.InstanceOf(typeof(OkObjectResult)));
            });
            mockCsvGraphicsCardRepository.Object.DeleteItem(item.ID);
        }

        [Test]
        public void DeleteLaptopUsingLaptopController()
        {
            var mockCsvGraphicsCardRepository = new Mock<CsvGraphicsCardRepository>();
            var graphicsCardController = new GraphicsCardController();
            mockCsvGraphicsCardRepository.Object.AddItem(item);

            var check = graphicsCardController.DeleteItem(item.ID);

            Assert.That(check.Result, Is.InstanceOf(typeof(OkObjectResult)));
        }
    }
}