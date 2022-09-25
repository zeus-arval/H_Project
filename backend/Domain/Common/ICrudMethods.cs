namespace Backend.Domain.Common
{
    public interface ICrudMethods<T>
    {
        Task<List<T>> Get();
        Task<T> Get(Guid id);
        Task Add(T obj);
    }
}