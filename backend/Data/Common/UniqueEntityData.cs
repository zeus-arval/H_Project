using System;
namespace Backend.Data.Common
{
    public abstract class UniqueEntityData : BaseEntity
    {
        public Guid Id { get; set; }
    }
}