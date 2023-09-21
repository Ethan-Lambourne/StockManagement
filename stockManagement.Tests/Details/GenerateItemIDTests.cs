using Moq;
using StockManagement.Models;
using StockManagement.Repos;

namespace StockManagement.Details
{
    public class GenerateItemIDTests
    {
        [Test]
        public void CheckForValidItemID()
        {
            var laptop = new Mock<LaptopRepository>();
            var graphicsCard = new Mock<GraphicsCardRepository>();
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