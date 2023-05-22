using AxisNotes.Models;
using System.Diagnostics;

namespace AxisNotes.Data
{
    public class DbTestData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Notes.Any())
            {
                return;   // DB has been seeded
            }

            var notes = new Note[]
            {
                new Note(),
                new Note()
            };
            foreach (Note s in notes)
            {
                context.Notes.Add(s);
            }
            context.SaveChanges();

            var noteKeys = new NoteKey[]
            {
                new NoteKey{Name="Language"},
                new NoteKey{Name="Content"},
                new NoteKey{Name="Definition"}
            };
            foreach (NoteKey s in noteKeys)
            {
                context.NoteKeys.Add(s);
            }
            context.SaveChanges();

            var noteElements = new NoteElement[]
            {
                new NoteElement{ NoteId = notes[0].Id, NoteKeyId = noteKeys[0].NoteKeyId, Value="Korean" },
                new NoteElement{ NoteId = notes[0].Id, NoteKeyId = noteKeys[1].NoteKeyId, Value="Yangpa" },
                new NoteElement{ NoteId = notes[0].Id, NoteKeyId = noteKeys[2].NoteKeyId, Value="Onion" },
                new NoteElement{ NoteId = notes[1].Id, NoteKeyId = noteKeys[0].NoteKeyId, Value="English" },
                new NoteElement{ NoteId = notes[1].Id, NoteKeyId = noteKeys[1].NoteKeyId, Value="Onion" },
                new NoteElement{ NoteId = notes[1].Id, NoteKeyId = noteKeys[2].NoteKeyId, Value="Onion" },
            };
            foreach (NoteElement n in noteElements)
            {
                context.NoteElements.Add(n);
            }
            context.SaveChanges();
        }
    }
}
