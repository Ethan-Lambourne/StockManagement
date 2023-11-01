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
            var mockCsvGraphicsCardRepository = new Mock<IItemsRepository<GraphicsCard>>();
            var graphicsCardController = new GraphicsCardController(mockCsvGraphicsCardRepository.Object);
            mockCsvGraphicsCardRepository.Setup(x => x.GetItem(item.ID)).Returns(item);

            var check = graphicsCardController.GetItem(item.ID);

            var checkResult = (ObjectResult)check!.Result!;
            GraphicsCard checkValue = (GraphicsCard)checkResult!.Value!;
            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Result, Is.InstanceOf(typeof(OkObjectResult)));
                Assert.That(checkValue.Name, Is.EqualTo(item.Name));
                Assert.That(checkValue.Stock, Is.EqualTo(item.Stock));
                Assert.That(checkValue.Price, Is.EqualTo(item.Price));
                Assert.That(checkValue.VRAM, Is.EqualTo(item.VRAM));
                Assert.That(checkValue.CudaCores, Is.EqualTo(item.CudaCores));
            });
        }

        [Test]
        public void GetAllGraphicsCardsUsingGraphicsCardController()
        {
            var mockCsvGraphicsCardRepository = new Mock<IItemsRepository<GraphicsCard>>();
            var graphicsCardController = new GraphicsCardController(mockCsvGraphicsCardRepository.Object);

            var check = graphicsCardController.GetAllItems();

            Assert.That(check.Result, Is.InstanceOf(typeof(OkObjectResult)));
        }

        [Test]
        public void AddGraphicsCardUsingGraphicsCardController()
        {
            var mockCsvGraphicsCardRepository = new Mock<IItemsRepository<GraphicsCard>>();
            var graphicsCardController = new GraphicsCardController(mockCsvGraphicsCardRepository.Object);
            mockCsvGraphicsCardRepository.Setup(x => x.AddItem(item)).Returns(item);

            var check = graphicsCardController.AddItem(item);

            var checkResult = (ObjectResult)check!.Result!;
            GraphicsCard checkValue = (GraphicsCard)checkResult!.Value!;
            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Result, Is.InstanceOf(typeof(OkObjectResult)));
                Assert.That(checkValue.Name, Is.EqualTo(item.Name));
                Assert.That(checkValue.Stock, Is.EqualTo(item.Stock));
                Assert.That(checkValue.Price, Is.EqualTo(item.Price));
                Assert.That(checkValue.VRAM, Is.EqualTo(item.VRAM));
                Assert.That(checkValue.CudaCores, Is.EqualTo(item.CudaCores));
            });
        }

        [TestCase("test name", 50, 100, 8, 4)]
        [TestCase("TEST NAME", 0, 50.5, 10, 6)]
        [TestCase("Test Name123", 10000, 999.99, 6, 2)]
        [TestCase("test name!&*^%4", 1, 0, 20, 12)]
        public void EditGraphicsCardUsingGraphicsCardController(string testName, int testStock, double testPrice, int testVRAM, int testCudaCores)
        {
            var mockCsvGraphicsCardRepository = new Mock<IItemsRepository<GraphicsCard>>();
            var graphicsCardController = new GraphicsCardController(mockCsvGraphicsCardRepository.Object);
            GraphicsCard ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testVRAM, testCudaCores);
            mockCsvGraphicsCardRepository.Setup(x => x.EditItem(ExampleItem, item.ID)).Returns(ExampleItem);

            var check = graphicsCardController.EditItem(ExampleItem, item.ID);

            var checkResult = (ObjectResult)check!.Result!;
            GraphicsCard checkValue = (GraphicsCard)checkResult!.Value!;
            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Result, Is.InstanceOf(typeof(OkObjectResult)));
                Assert.That(checkValue.Name, Is.EqualTo(testName));
                Assert.That(checkValue.Stock, Is.EqualTo(testStock));
                Assert.That(checkValue.Price, Is.EqualTo(testPrice));
                Assert.That(checkValue.VRAM, Is.EqualTo(testVRAM));
                Assert.That(checkValue.CudaCores, Is.EqualTo(testCudaCores));
            });
        }

        [Test]
        public void DeleteLaptopUsingLaptopController()
        {
            var mockCsvGraphicsCardRepository = new Mock<IItemsRepository<GraphicsCard>>();
            var graphicsCardController = new GraphicsCardController(mockCsvGraphicsCardRepository.Object);
            mockCsvGraphicsCardRepository.Setup(x => x.DeleteItem(item.ID)).Returns(true);

            var check = graphicsCardController.DeleteItem(item.ID);

            Assert.That(check.Result, Is.InstanceOf(typeof(OkObjectResult)));
        }
    }
}