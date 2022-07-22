using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ScriptWriterApp.Data
{
    public class ChangeHistory
    {
        [Key, NotNull]
        public int ID { get; set; }
        [Required, NotNull]
        public DateTime DateTime { get; set; }
        [Required, NotNull]
        public string FilePath { get; set; }
        [Required, NotNull]
        public int LineNum { get; set; }
        [Required, NotNull]
        public string Origin { get; set; }
        [Required]
        public string Modified { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
