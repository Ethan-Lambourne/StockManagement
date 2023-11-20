using Microsoft.AspNetCore.Mvc;
using Moq;
using StockManagement.API.Controllers;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

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

            var gottenGraphicsCard = graphicsCardController.GetItem(item.ID);

            var gottenGraphicsCardResult = gottenGraphicsCard as ObjectResult;
            GraphicsCard gottenGraphicsCardValue = (GraphicsCard)gottenGraphicsCardResult!.Value!;
            Assert.Multiple(() =>
            {
                Assert.That(gottenGraphicsCard, Is.Not.EqualTo(null));
                Assert.That(gottenGraphicsCardValue.Name, Is.EqualTo(item.Name));
                Assert.That(gottenGraphicsCardValue.Stock, Is.EqualTo(item.Stock));
                Assert.That(gottenGraphicsCardValue.Price, Is.EqualTo(item.Price));
                Assert.That(gottenGraphicsCardValue.VRAM, Is.EqualTo(item.VRAM));
                Assert.That(gottenGraphicsCardValue.CudaCores, Is.EqualTo(item.CudaCores));
            });
        }

        [Test]
        public void GetAllGraphicsCardsUsingGraphicsCardController()
        {
            var mockCsvGraphicsCardRepository = new Mock<IItemsRepository<GraphicsCard>>();
            var graphicsCardController = new GraphicsCardController(mockCsvGraphicsCardRepository.Object);

            var allGraphicsCards = graphicsCardController.GetAllItems();

            Assert.That(allGraphicsCards, Is.InstanceOf(typeof(OkObjectResult)));
        }

        [Test]
        public void AddGraphicsCardUsingGraphicsCardController()
        {
            var mockCsvGraphicsCardRepository = new Mock<IItemsRepository<GraphicsCard>>();
            var graphicsCardController = new GraphicsCardController(mockCsvGraphicsCardRepository.Object);
            mockCsvGraphicsCardRepository.Setup(x => x.AddItem(item)).Returns(item);

            var addedGraphicsCard = graphicsCardController.AddItem(item);

            var addedGraphicsCardResult = addedGraphicsCard as ObjectResult;
            GraphicsCard addedGraphicsCardValue = (GraphicsCard)addedGraphicsCardResult!.Value!;
            Assert.Multiple(() =>
            {
                Assert.That(addedGraphicsCard, Is.Not.EqualTo(null));
                Assert.That(addedGraphicsCardValue.Name, Is.EqualTo(item.Name));
                Assert.That(addedGraphicsCardValue.Stock, Is.EqualTo(item.Stock));
                Assert.That(addedGraphicsCardValue.Price, Is.EqualTo(item.Price));
                Assert.That(addedGraphicsCardValue.VRAM, Is.EqualTo(item.VRAM));
                Assert.That(addedGraphicsCardValue.CudaCores, Is.EqualTo(item.CudaCores));
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

            var editedGraphicsCard = graphicsCardController.EditItem(ExampleItem, item.ID);

            var editedGraphicsCardResult = editedGraphicsCard as ObjectResult;
            GraphicsCard editedGraphicsCardValue = (GraphicsCard)editedGraphicsCardResult!.Value!;
            Assert.Multiple(() =>
            {
                Assert.That(editedGraphicsCard, Is.Not.EqualTo(null));
                Assert.That(editedGraphicsCardValue.Name, Is.EqualTo(testName));
                Assert.That(editedGraphicsCardValue.Stock, Is.EqualTo(testStock));
                Assert.That(editedGraphicsCardValue.Price, Is.EqualTo(testPrice));
                Assert.That(editedGraphicsCardValue.VRAM, Is.EqualTo(testVRAM));
                Assert.That(editedGraphicsCardValue.CudaCores, Is.EqualTo(testCudaCores));
            });
        }

        [Test]
        public void DeleteLaptopUsingLaptopController()
        {
            var mockCsvGraphicsCardRepository = new Mock<IItemsRepository<GraphicsCard>>();
            var graphicsCardController = new GraphicsCardController(mockCsvGraphicsCardRepository.Object);
            mockCsvGraphicsCardRepository.Setup(x => x.DeleteItem(item.ID)).Returns(true);

            var deletedGraphicsCard = graphicsCardController.DeleteItem(item.ID);

            var deletedGraphicsCardResult = deletedGraphicsCard as ObjectResult;
            bool deletedGraphicsCardValue = (bool)deletedGraphicsCardResult!.Value!;
            Assert.That(deletedGraphicsCardValue, Is.EqualTo(true));
        }
    }
}