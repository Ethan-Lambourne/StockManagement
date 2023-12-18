using Microsoft.AspNetCore.Mvc;

namespace StockManagement.API.Controllers
{
    public interface IItemsController<T>
    {
        IActionResult GetItem(int itemID);

        IActionResult GetAllItems();

        IActionResult AddItem(T item);

        IActionResult DeleteItem(int itemID);

        IActionResult EditItem(T ExampleItem, int itemID);
    }
}