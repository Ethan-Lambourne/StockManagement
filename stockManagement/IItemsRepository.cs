namespace stockManagement
{
    public interface IItemsRepository<T>
    {
        T? GetItem(string itemName);

        void AddItem(T item);

        void DeleteItem(string itemName);

        void EditItem(string itemName);
    }
}