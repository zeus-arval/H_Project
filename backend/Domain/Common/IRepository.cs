namespace Backend.Domain.Common
{
    public interface IRepository<T> : ICrudMethods<T>, ISorting, IRepository { }
    public interface IRepository
    {
        object GetById(Guid id);
    }
}