using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AxisNotes.Models.ViewModels
{
    public class PostNoteRequest
    {
        public string Definition { get; set; }
        public string Language { get; set; }
        public string Content { get; set; }
    }
}
