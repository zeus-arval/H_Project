namespace Backend.Domain.Common {
    public interface IEntity<out TData> {
        TData Data { get; }
    }
}