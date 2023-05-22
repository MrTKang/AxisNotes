using AxisNotes.Data;
using AxisNotes.Models;
using AxisNotes.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Diagnostics.Metrics;

namespace AxisNotes.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private ApplicationDbContext dbContext { get; set; }
        public NotesController(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public NotesGrid Get()
        {
            var columns = new string[] { "Korean", "English" };
            var rows = new string[] { "Onion" };

            var grid = new NotesGrid() { };
            var rowKeys = new List<NoteKey>();
            var columnKeys = new List<NoteKey>();
            var definitionKey = this.dbContext.NoteKeys.First(n => n.Name.Equals("Definition"));
            var languageKey = this.dbContext.NoteKeys.First(n => n.Name.Equals("Language"));
            var contentKey = this.dbContext.NoteKeys.First(n => n.Name.Equals("Content"));

            var notes = this.dbContext.Notes.Include(n => n.NoteElements)
                .Where(n => n.NoteElements.Any(el => el.Key == definitionKey) 
                && n.NoteElements.Any(el => el.Key == languageKey));

            var cs = new List<string>();
            var rs = new List<string>();
            var contentRows = new List<List<string>>();
            foreach (var note in notes)
            {
                var language = note.NoteElements.First(e => e.NoteKeyId == languageKey.NoteKeyId);
                var definition = note.NoteElements.First(e => e.NoteKeyId == definitionKey.NoteKeyId);
                var content = note.NoteElements.FirstOrDefault(e => e.NoteKeyId == contentKey.NoteKeyId);
                var langIndex = cs.IndexOf(language.Value);
                var defIndex = rs.IndexOf(definition.Value);

                if (langIndex == -1)
                {
                    langIndex = cs.Count;
                    cs.Add(language.Value);
                }
                if (defIndex == -1)
                {
                    defIndex = rs.Count;
                    rs.Add(definition.Value);
                }

                if (defIndex >= contentRows.Count)
                {
                    contentRows.Add(new List<string> { });
                }
                if (langIndex >= contentRows[defIndex].Count)
                {
                    for (int i = 0; i <= langIndex; i++)
                    {
                        contentRows[defIndex].Add(string.Empty);
                    }
                }
                contentRows[defIndex][langIndex] = content.Value;
            }

            grid.ColumnHeaders = cs;
            grid.RowHeaders = rs;
            grid.Grid = contentRows;

            return grid;
        }

        [HttpPost]
        public PostResult Post(PostNoteRequest postNoteRequest)
        {
            var definitionKey = this.dbContext.NoteKeys.First(n => n.Name.Equals("Definition"));
            var languageKey = this.dbContext.NoteKeys.First(n => n.Name.Equals("Language"));
            var contentKey = this.dbContext.NoteKeys.First(n => n.Name.Equals("Content"));

            var note = new Note();
            var noteElements = new List<NoteElement>();
            noteElements.Add(new NoteElement() { Key = definitionKey, Value = postNoteRequest.Definition });
            noteElements.Add(new NoteElement() { Key = languageKey, Value = postNoteRequest.Language });
            noteElements.Add(new NoteElement() { Key = contentKey, Value = postNoteRequest.Content });
            note.NoteElements = noteElements;

            var notes = this.dbContext.Notes.Add(note);
            this.dbContext.SaveChanges();

            return new PostResult() { Success = true };
        }

        [HttpPost("collection")]
        public PostResult PostCollection([FromBody] PostNotesRequest postNotesRequest)
        {
            var definitionKey = this.dbContext.NoteKeys.First(n => n.Name.Equals("Definition"));
            var languageKey = this.dbContext.NoteKeys.First(n => n.Name.Equals("Language"));
            var contentKey = this.dbContext.NoteKeys.First(n => n.Name.Equals("Content"));
            foreach (var phraseNotes in postNotesRequest.PhraseCollection)
            {
                foreach (var phraseNote in phraseNotes.Notes)
                {
                    var note = new Note();
                    var noteElements = new List<NoteElement>();
                    var definitionElement = new NoteElement() { Key = definitionKey, Value = phraseNotes.Definition };
                    noteElements.Add(definitionElement);
                    noteElements.Add(new NoteElement() { Key = languageKey, Value = phraseNote.Language });
                    noteElements.Add(new NoteElement() { Key = contentKey, Value = phraseNote.Content });
                    note.NoteElements = noteElements;
                    var notes = this.dbContext.Notes.Add(note);
                }
            }
            this.dbContext.SaveChanges();
            return new PostResult() { Success = true };
        }
    }
}
