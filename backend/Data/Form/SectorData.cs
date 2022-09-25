using System.ComponentModel.DataAnnotations;
using Backend.Data.Common;
namespace Backend.Data.Form
{
    public sealed class SectorData : UniqueEntityData
    {
        public Guid ParentId { get; set; }
        [StringLength(50)] public string Name { get; set; }
    }
}