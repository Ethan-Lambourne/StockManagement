using stockManagement.Models;

namespace stockManagement.Repos
{
    public class GraphicsCardRepositoryTests
    {
        private GraphicsCard item = new GraphicsCard(999, "test graphics card", "graphics card", 11, 22.22, 33, 44);

        [Test]
        public void AddLaptopItemToGraphicsCardList()
        {
            var graphicsCardRepository = new GraphicsCardRepository();

            var check = graphicsCardRepository.AddItem(item);

            Assert.That(check, Is.EqualTo(item));
        }

        [Test]
        public void GetIndividualItemFromGraphicsCardList()
        {
            var graphicsCardRepository = new GraphicsCardRepository();
            graphicsCardRepository.AddItem(item);

            var check = graphicsCardRepository.GetItem(999);

            Assert.That(check, Is.EqualTo(item));
        }

        [Test]
        public void DeleteItemFromGraphicsCardList()
        {
            var graphicsCardRepository = new GraphicsCardRepository();
            graphicsCardRepository.AddItem(item);

            var check = graphicsCardRepository.DeleteItem(999);

            Assert.That(check, Is.EqualTo(true));
        }

        [TestCase("test name", 50, 100, 8, 4)]
        [TestCase("TEST NAME", 0, 50.5, 10, 6)]
        [TestCase("Test Name123", 10000, 999.99, 6, 2)]
        [TestCase("test name!&*^%4", 1, 0, 20, 12)]
        public void EditItemFromGraphicsCardList(string testName, int testStock, double testPrice, int testVRAM, int testCudaCores)
        {
            var graphicsCardRepository = new GraphicsCardRepository();
            graphicsCardRepository.AddItem(item);
            GraphicsCard ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testVRAM, testCudaCores);

            var check = graphicsCardRepository.EditItem(ExampleItem, item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check.Name, Is.EqualTo(testName));
                Assert.That(check.Stock, Is.EqualTo(testStock));
                Assert.That(check.Price, Is.EqualTo(testPrice));
                Assert.That(check.VRAM, Is.EqualTo(testVRAM));
                Assert.That(check.CudaCores, Is.EqualTo(testCudaCores));
            });
        }

        [Test]
        public void GetAllItemsFromGraphicsCardList()
        {
            var graphicsCardRepository = new GraphicsCardRepository();

            List<GraphicsCard> check = graphicsCardRepository.GetAllItems();

            Assert.That(check, Is.EqualTo(graphicsCardRepository.GetAllItems()));
        }
    }
}