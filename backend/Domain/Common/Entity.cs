using Backend.Data.Common;

namespace Backend.Domain.Common {
    public abstract class Entity<T> :ValueObject<T>, IEntity<T> 
        where T : BaseEntity, new() {
        protected internal Entity(T d = null) : base(d) { }
    }
}