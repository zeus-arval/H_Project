namespace Backend.Domain.Common
{
    public interface IUniqueEntity : IEntity
    {
        Guid Id { get; }
    }
    public interface IUniqueEntity<out TData> : IUniqueEntity, IEntity<TData> { }
}