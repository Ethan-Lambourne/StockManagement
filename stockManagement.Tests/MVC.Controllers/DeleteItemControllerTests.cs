using Microsoft.AspNetCore.Mvc;
using Moq;
using StockManagement.MVC.Controllers;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace stockManagement.MVC.Controllers
{
    public class DeleteItemControllerTests
    {
        private readonly Laptop testLaptop = new(999, "test laptop", "laptop", 11, 22.22, 33.33, 44, 55);
        private readonly GraphicsCard testGraphicsCard = new(999, "test graphics card", "graphics card", 11, 22.22, 33, 44);

        private Mock<IItemsRepository<Laptop>> mockCsvLaptopRepository;
        private Mock<IItemsRepository<GraphicsCard>> mockCsvGraphicsCardRepository;
        private DeleteItemController deleteItemController;

        [SetUp]
        public void SetUp()
        {
            mockCsvLaptopRepository = new Mock<IItemsRepository<Laptop>>();
            mockCsvGraphicsCardRepository = new Mock<IItemsRepository<GraphicsCard>>();
            deleteItemController = new DeleteItemController(mockCsvLaptopRepository.Object, mockCsvGraphicsCardRepository.Object);
        }

        [Test]
        public void RedirectToDeleteItemConfirmationWithLaptop()
        {
            mockCsvLaptopRepository.Setup(x => x.GetItem(testLaptop.ID)).Returns(testLaptop);

            var laptopDeleteConfirmation = (ViewResult)deleteItemController.DeleteItemView(testLaptop.ID);

            Assert.That(laptopDeleteConfirmation.ViewName, Is.Null);
            Mock.VerifyAll();
        }

        [Test]
        public void RedirectToDeleteItemConfirmationWithGraphicsCard()
        {
            mockCsvGraphicsCardRepository.Setup(x => x.GetItem(testGraphicsCard.ID)).Returns(testGraphicsCard);

            var graphicsCardDeleteConfirmation = (ViewResult)deleteItemController.DeleteItemView(testGraphicsCard.ID);

            Assert.That(graphicsCardDeleteConfirmation.ViewName, Is.Null);
            Mock.VerifyAll();
        }

        [Test]
        public void DeleteLaptopUsingDeleteItemController()
        {
            mockCsvLaptopRepository.Setup(x => x.DeleteItem(testLaptop.ID)).Returns(true);
            mockCsvLaptopRepository.Setup(x => x.GetItem(testLaptop.ID)).Returns(testLaptop);

            var deletedLaptop = (RedirectToActionResult)deleteItemController.DeleteItem(testLaptop.ID);

            Assert.Multiple(() =>
            {
                Assert.That(deletedLaptop.ActionName, Is.EqualTo("Index"));
                Assert.That(deletedLaptop.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }

        [Test]
        public void DeleteGraphicsCardUsingDeleteItemController()
        {
            mockCsvGraphicsCardRepository.Setup(x => x.DeleteItem(testGraphicsCard.ID)).Returns(true);
            mockCsvGraphicsCardRepository.Setup(x => x.GetItem(testGraphicsCard.ID)).Returns(testGraphicsCard);

            var deletedGraphicsCard = (RedirectToActionResult)deleteItemController.DeleteItem(testGraphicsCard.ID);

            Assert.Multiple(() =>
            {
                Assert.That(deletedGraphicsCard.ActionName, Is.EqualTo("Index"));
                Assert.That(deletedGraphicsCard.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }
    }
}