using Microsoft.AspNetCore.Mvc;
using Moq;
using StockManagement.MVC.Controllers;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace stockManagement.MVC.Controllers
{
    public class EditLaptopControllerTests
    {
        private readonly Laptop testLaptop = new(999, "test laptop", "laptop", 11, 22.22, 33.33, 44, 55);

        private Mock<IItemsRepository<Laptop>> mockCsvLaptopRepository;
        private EditLaptopController editLaptopController;

        [SetUp]
        public void SetUp()
        {
            mockCsvLaptopRepository = new Mock<IItemsRepository<Laptop>>();
            editLaptopController = new EditLaptopController(mockCsvLaptopRepository.Object);
        }

        [Test]
        public void RedirectToEditLaptopView()
        {
            mockCsvLaptopRepository.Setup(x => x.GetItem(testLaptop.ID)).Returns(testLaptop);

            var editLaptopForm = (ViewResult)editLaptopController.EditLaptopView(testLaptop.ID);

            Assert.That(editLaptopForm.ViewName, Is.Null);
            Mock.VerifyAll();
        }

        [TestCase("test name", 50, 100, 20, 16, 500)]
        [TestCase("TEST NAME", 0, 50.5, 18.5, 8, 1000)]
        [TestCase("Test Name123", 10000, 999.99, 25.25, 64, 3000)]
        [TestCase("test name!&*^%4", 1, 0, 8, 128, 10)]
        public void EditLaptopUsingEditLaptopController(string testName, int testStock, double testPrice, double testScreenSize, int testRAM, int testStorage)
        {
            Laptop exampleLaptop = new(testLaptop.ID, testName, testLaptop.Type, testStock, testPrice, testScreenSize, testRAM, testStorage);
            mockCsvLaptopRepository.Setup(x => x.EditItem(It.IsAny<Laptop>(), testLaptop.ID)).Returns(exampleLaptop);

            var editedLaptop = (RedirectToActionResult)editLaptopController.EditLaptop(testLaptop.ID, testName, testLaptop.Type, testStock,
                testPrice, testScreenSize, testRAM, testStorage);

            Assert.Multiple(() =>
            {
                Assert.That(editedLaptop.ActionName, Is.EqualTo("Index"));
                Assert.That(editedLaptop.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }
    }
}