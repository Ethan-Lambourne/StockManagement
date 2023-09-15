using stockManagement.Models;
using Moq;

namespace stockManagement.Repos
{
    public class LaptopRepositoryTests
    {
        [Test]
        public void AddLaptopItemToLaptopList()
        {
            var laptopRepository = new Mock<LaptopRepository>();
            var item = new Laptop(999, "test laptop", "laptop", 11, 22.22, 33.33, 44, 55);

            var check = laptopRepository.Object.AddItem(item);

            Assert.That(check, Is.EqualTo(item));
        }

        [Test]
        public void GetIndividualItemFromLaptopList()
        {
            var laptopRepository = new Mock<LaptopRepository>();
            var item = new Laptop(999, "test laptop", "laptop", 11, 22.22, 33.33, 44, 55);
            laptopRepository.Object.AddItem(item);

            var check = laptopRepository.Object.GetItem(999);

            Assert.That(check, Is.EqualTo(item));
        }

        [Test]
        public void DeleteItemFromLaptopList()
        {
            var laptopRepository = new Mock<LaptopRepository>();
            var item = new Laptop(999, "test laptop", "laptop", 11, 22.22, 33.33, 44, 55);
            laptopRepository.Object.AddItem(item);

            bool check = laptopRepository.Object.DeleteItem(999);

            Assert.That(check, Is.EqualTo(true));
        }

        [Test]
        public void EditItemFromLaptopList()
        {
            var laptopRepository = new Mock<LaptopRepository>();
            var item = new Laptop(999, "test laptop", "laptop", 11, 22.22, 33.33, 44, 55);
            laptopRepository.Object.AddItem(item);

            var check = laptopRepository.Object.EditItem(item, "edited test laptop", 123, 45.6, 78.9, 10, 11, 0, 0);

            Assert.Multiple(() =>
            {
                Assert.That(check.Name, Is.EqualTo("edited test laptop"));
                Assert.That(check.Stock, Is.EqualTo(123));
                Assert.That(check.Price, Is.EqualTo(45.6));
                Assert.That(check.ScreenSize, Is.EqualTo(78.9));
                Assert.That(check.RAM, Is.EqualTo(10));
                Assert.That(check.Storage, Is.EqualTo(11));
            });
        }

        [Test]
        public void GetAllItemsFromLaptopList()
        {
            var laptopRepository = new Mock<LaptopRepository>();

            List<Laptop> check = laptopRepository.Object.GetAllItems();

            Assert.That(check, Is.EqualTo(laptopRepository.Object.GetAllItems()));
        }
    }
}