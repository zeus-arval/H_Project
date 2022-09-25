using Backend.Data.Common;
namespace Backend.Domain.Common
{
    public abstract class UniqueEntity<T> : Entity<T>, IUniqueEntity<T>
        where T : UniqueEntityData, new() 
    {
        protected internal UniqueEntity(T d = null) : base(d) { }
        public virtual Guid Id => Data?.Id ?? UnspecifiedGuid;
    }
}