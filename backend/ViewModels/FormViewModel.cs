
namespace Backend.ViewModels
{
    public sealed class FormViewModel
    {
        public string SubmitterName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string[] SectorNames { get; set; }
        public FormViewModel(string submitterName, string[] sectorNames, DateTime createdAt) => (SubmitterName, SectorNames, CreatedAt) = (submitterName, sectorNames, createdAt);
    }
}