namespace Backend.Domain.Common {
     public interface IEntity {
        bool IsUnspecified { get; }
    }
    public interface IEntity<out TData> {
        TData Data { get; }
    }
}