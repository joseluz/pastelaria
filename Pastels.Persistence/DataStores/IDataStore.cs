using Pastels.Persistence.Docs;

namespace Pastels.Persistence.DataStores
{
    public interface IDataStore<T> where T: IDocument
    {
        Task<IList<T>> FindAll();

        Task<T> Create(T item);

        Task<T?> Update(T item);

        Task Delete(T item);
    }
}
