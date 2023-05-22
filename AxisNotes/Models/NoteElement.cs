using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AxisNotes.Models
{
    public class NoteElement
    {
        public int NoteId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteElementId { get; set; }
        public NoteKey? Key { get; set; }
        public int NoteKeyId { get; set; }
        public string? Value { get; set; }
    }
}
