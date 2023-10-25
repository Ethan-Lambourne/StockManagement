namespace StockManagement.Repos
{
    public interface IItemsRepository<T>
    {
        T? GetItem(int itemID);

        List<T> GetAllItems();

        T AddItem(T item);

        bool DeleteItem(int itemID);

        T? EditItem(T ExampleItem, int itemID);
    }
}