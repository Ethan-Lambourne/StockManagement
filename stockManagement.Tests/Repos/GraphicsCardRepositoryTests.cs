using Moq;
using stockManagement.Models;

namespace stockManagement.Repos
{
    public class GraphicsCardRepositoryTests
    {
        [Test]
        public void AddLaptopItemToGraphicsCardList()
        {
            var graphicsCardRepository = new Mock<GraphicsCardRepository>();
            var item = new GraphicsCard(999, "test graphics card", "graphics card", 11, 22.22, 33, 44);

            var check = graphicsCardRepository.Object.AddItem(item);

            Assert.That(check, Is.EqualTo(item));
        }

        [Test]
        public void GetIndividualItemFromGraphicsCardList()
        {
            var graphicsCardRepository = new Mock<GraphicsCardRepository>();
            var item = new GraphicsCard(999, "test graphics card", "graphics card", 11, 22.22, 33, 44);
            graphicsCardRepository.Object.AddItem(item);

            var check = graphicsCardRepository.Object.GetItem(999);

            Assert.That(check, Is.EqualTo(item));
        }

        [Test]
        public void DeleteItemFromGraphicsCardList()
        {
            var graphicsCardRepository = new Mock<GraphicsCardRepository>();
            var item = new GraphicsCard(999, "test graphics card", "graphics card", 11, 22.22, 33, 44);
            graphicsCardRepository.Object.AddItem(item);

            bool check = graphicsCardRepository.Object.DeleteItem(999);

            Assert.That(check, Is.EqualTo(true));
        }

        [Test]
        public void EditItemFromGraphicsCardList()
        {
            var graphicsCardRepository = new Mock<GraphicsCardRepository>();
            var item = new GraphicsCard(999, "test graphics card", "graphics card", 11, 22.22, 33, 44);
            graphicsCardRepository.Object.AddItem(item);

            var check = graphicsCardRepository.Object.EditItem(item, "edited test graphics card", 123, 45.6, 0, 0, 0, 7, 8);

            Assert.Multiple(() =>
            {
                Assert.That(check.Name, Is.EqualTo("edited test graphics card"));
                Assert.That(check.Stock, Is.EqualTo(123));
                Assert.That(check.Price, Is.EqualTo(45.6));
                Assert.That(check.VRAM, Is.EqualTo(7));
                Assert.That(check.CudaCores, Is.EqualTo(8));
            });
        }

        [Test]
        public void GetAllItemsFromGraphicsCardList()
        {
            var graphicsCardRepository = new Mock<GraphicsCardRepository>();

            List<GraphicsCard> check = graphicsCardRepository.Object.GetAllItems();

            Assert.That(check, Is.EqualTo(graphicsCardRepository.Object.GetAllItems()));
        }
    }
}