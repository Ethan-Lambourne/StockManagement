using Microsoft.AspNetCore.Mvc;
using Moq;
using StockManagement.MVC.Controllers;
using StockManagement.Shared.GenerateID;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace stockManagement.MVC.Controllers
{
    public class AddItemControllerTests
    {
        private readonly Laptop testLaptop = new(999, "test laptop", "laptop", 11, 22.22, 33.33, 44, 55);
        private readonly GraphicsCard testGraphicsCard = new(999, "test graphics card", "graphics card", 11, 22.22, 33, 44);

        private Mock<IItemsRepository<Laptop>> mockCsvLaptopRepository;
        private Mock<IItemsRepository<GraphicsCard>> mockCsvGraphicsCardRepository;
        private Mock<IGenerateID> generateID;
        private AddItemController addItemController;

        [SetUp]
        public void SetUp()
        {
            mockCsvLaptopRepository = new Mock<IItemsRepository<Laptop>>();
            mockCsvGraphicsCardRepository = new Mock<IItemsRepository<GraphicsCard>>();
            generateID = new Mock<IGenerateID>();
            addItemController = new AddItemController(mockCsvLaptopRepository.Object, mockCsvGraphicsCardRepository.Object, generateID.Object);
        }

        [Test]
        public void RedirectToAddItemForm()
        {
            generateID.Setup(x => x.GenerateID()).Returns(999);

            var addItemForm = (ViewResult)addItemController.AddItemView();

            Assert.That(addItemForm.ViewName, Is.Null);
            Mock.VerifyAll();
        }

        [Test]
        public void AddLaptopUsingAddItemController()
        {
            mockCsvLaptopRepository.Setup(x => x.AddItem(It.IsAny<Laptop>())).Returns(testLaptop);

            var addedLaptop = (RedirectToActionResult)addItemController.AddLaptop(testLaptop.ID, testLaptop.Name, testLaptop.Type, testLaptop.Stock,
                testLaptop.Price, testLaptop.ScreenSize, testLaptop.RAM, testLaptop.Storage);

            Assert.Multiple(() =>
            {
                Assert.That(addedLaptop.ActionName, Is.EqualTo("Index"));
                Assert.That(addedLaptop.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }

        [Test]
        public void AddGraphicsCardUsingAddItemController()
        {
            mockCsvGraphicsCardRepository.Setup(x => x.AddItem(It.IsAny<GraphicsCard>())).Returns(testGraphicsCard);

            var addedGraphicsCard = (RedirectToActionResult)addItemController.AddGraphicsCard(testGraphicsCard.ID, testGraphicsCard.Name, testGraphicsCard.Type,
                testGraphicsCard.Stock, testGraphicsCard.Price, testGraphicsCard.VRAM, testGraphicsCard.CudaCores);

            Assert.Multiple(() =>
            {
                Assert.That(addedGraphicsCard.ActionName, Is.EqualTo("Index"));
                Assert.That(addedGraphicsCard.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }
    }
}