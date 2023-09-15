namespace stockManagement.Repos
{
    public interface IItemsRepository<T>
    {
        T? GetItem(int itemID);

        List<T> GetAllItems();

        T AddItem(T item);

        bool DeleteItem(int itemID);

        T EditItem(T item, string newName, int newStock, double newPrice, double newScreenSize, int newRAMamount,
            int newStorageAmount, int newVRAMamount, int newCudaCores);
    }
}