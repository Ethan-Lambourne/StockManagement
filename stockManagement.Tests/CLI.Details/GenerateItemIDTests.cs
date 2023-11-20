using Moq;
using StockManagement.Shared.Models;
using StockManagement.Shared.Repos;

namespace StockManagement.Details
{
    public class GenerateItemIDTests
    {
        [Test]
        public void CheckForValidItemID()
        {
            var laptop = new Mock<CsvLaptopRepository>();
            var graphicsCard = new Mock<CsvGraphicsCardRepository>();
            var generateItemID = new GenerateItemID(laptop.Object, graphicsCard.Object);

            int idToTest = generateItemID.GenerateID();

            Assert.That(idToTest, Is.Not.Negative);
            foreach (Laptop item in laptop.Object.GetAllItems())
            {
                Assert.That(item.ID, Is.Not.EqualTo(idToTest));
            }
            foreach (GraphicsCard item in graphicsCard.Object.GetAllItems())
            {
                Assert.That(item.ID, Is.Not.EqualTo(idToTest));
            }
        }
    }
}