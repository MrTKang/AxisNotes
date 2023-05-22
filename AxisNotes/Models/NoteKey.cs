using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AxisNotes.Models
{
    public class NoteKey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteKeyId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
