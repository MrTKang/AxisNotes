namespace AxisNotes.Models.ViewModels
{
    public class NotesGrid
    {
        public List<string> ColumnHeaders { get; set; } = new List<string>();
        public List<string> RowHeaders { get; set; } = new List<string>();
        public List<List<string>> Grid { get; set; } = new List<List<string>>();
    }
}
