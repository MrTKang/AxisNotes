namespace AxisNotes.Models.ViewModels
{
    public class PhraseNotes
    {
        public string Definition { get; set; }
        public List<LanguageNote> Notes { get; set; }
    }

    public class LanguageNote
    {
        public string Language { get; set; }
        public string Content { get; set; }
        public string Definition { get; set; }
    }
}
