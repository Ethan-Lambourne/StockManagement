using Microsoft.AspNetCore.Mvc;

namespace StockManagement.API.Controllers
{
    public interface IItemsController<T>
    {
        ActionResult<T>? GetItem(int itemID);

        ActionResult<T> GetAllItems();

        ActionResult<T> AddItem(T item);

        ActionResult<bool> DeleteItem(int itemID);

        ActionResult<T>? EditItem(T ExampleItem, int itemID);
    }
}