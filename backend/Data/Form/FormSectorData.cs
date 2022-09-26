using Backend.Data.Common;

namespace Backend.Data.Form
{
    public sealed class FormSectorData : UniqueEntityData
    {
        public Guid FormId { get; set; }
        public Guid SectorId { get; set; }
    }
}