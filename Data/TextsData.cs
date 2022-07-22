using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ScriptWriterApp.Data
{
    public class TextsData
    {
        [Key, NotNull]
        public int ID { get; set; }
        [Required, NotNull]
        public string FilePath { get; set; }
        [Required, NotNull]
        public int LineNum { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
