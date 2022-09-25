using Backend.Data.Common;

namespace Backend.Data.Form
{
    public sealed class FormData : UniqueEntityData
    {
        public string SubmitterName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}