using Backend.Domain.Common;
using Backend.Domain.Repositories;
using Backend.Data.Form;

namespace Backend.Domain.Form
{
    public sealed class Sector : UniqueEntity<SectorData>
    {
        public Sector(SectorData d) : base(d) { }

        public string Name => Data?.Name ?? Unspecified;
        public Guid ParentId => Data?.ParentId ?? UnspecifiedGuid;

        public Sector Parent => new GetFrom<ISectorsRepository, Sector>().ById(ParentId);
    }
}