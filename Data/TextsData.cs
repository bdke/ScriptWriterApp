using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ScriptWriterApp.Data
{
    public class TextsData
    {
        public int ID { get; set; }
        public string? FilePath { get; set; }
        public int? LineNum { get; set; }
        public string? Text { get; set; }
    }
}
