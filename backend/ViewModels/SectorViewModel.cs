namespace Backend.ViewModels
{
    public sealed class SectorViewModel
    {
        public string Name { get; set; }
        public string ParentName { get; set; }

        public SectorViewModel(string name, string parentName) => (Name, ParentName) = (name, parentName);
    }
}