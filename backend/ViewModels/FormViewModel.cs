
namespace Backend.ViewModels
{
    public sealed class FormViewModel
    {
        public string SubmitterName { get; set; }
        public DateTime CreatedAt { get; set; }
        public FormViewModel(string submitterName, DateTime createdAt) => (SubmitterName, CreatedAt) = (submitterName, createdAt);
    }
}