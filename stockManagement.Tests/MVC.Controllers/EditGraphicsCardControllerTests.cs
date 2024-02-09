using Microsoft.AspNetCore.Mvc;
using Moq;
using StockManagement.MVC.Controllers;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace stockManagement.MVC.Controllers
{
    public class EditGraphicsCardControllerTests
    {
        private readonly GraphicsCard testGraphicsCard = new(999, "test graphics card", "graphics card", 11, 22.22, 33, 44);

        private Mock<IItemsRepository<GraphicsCard>> mockCsvGraphicsCardRepository;
        private EditGraphicsCardController editGraphicsCardController;

        [SetUp]
        public void SetUp()
        {
            mockCsvGraphicsCardRepository = new Mock<IItemsRepository<GraphicsCard>>();
            editGraphicsCardController = new EditGraphicsCardController(mockCsvGraphicsCardRepository.Object);
        }

        [Test]
        public void RedirectToEditGraphicsCardView()
        {
            mockCsvGraphicsCardRepository.Setup(x => x.GetItem(testGraphicsCard.ID)).Returns(testGraphicsCard);

            var editGraphicsCardForm = (ViewResult)editGraphicsCardController.EditGraphicsCardView(testGraphicsCard.ID);

            Assert.That(editGraphicsCardForm.ViewName, Is.Null);
            Mock.VerifyAll();
        }

        [TestCase("test name", 50, 100, 8, 4)]
        [TestCase("TEST NAME", 0, 50.5, 10, 6)]
        [TestCase("Test Name123", 10000, 999.99, 6, 2)]
        [TestCase("test name!&*^%4", 1, 0, 20, 12)]
        public void EditGraphicsCardUsingEditGraphicsCardController(string testName, int testStock, double testPrice, int testVRAM, int testCudaCores)
        {
            GraphicsCard exampleGraphicsCard = new(testGraphicsCard.ID, testName, testGraphicsCard.Type, testStock, testPrice, testVRAM, testCudaCores);
            mockCsvGraphicsCardRepository.Setup(x => x.EditItem(It.IsAny<GraphicsCard>(), testGraphicsCard.ID)).Returns(exampleGraphicsCard);

            var editedGraphicsCard = (RedirectToActionResult)editGraphicsCardController.EditGraphicsCard(testGraphicsCard.ID, testName,
                testGraphicsCard.Type, testStock, testPrice, testVRAM, testCudaCores);

            Assert.Multiple(() =>
            {
                Assert.That(editedGraphicsCard.ActionName, Is.EqualTo("Index"));
                Assert.That(editedGraphicsCard.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }
    }
}