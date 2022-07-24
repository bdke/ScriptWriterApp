using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ScriptWriterApp.Data
{
    public class ChangeHistory
    {
        public int ID { get; set; }
        public DateTime? DateTime { get; set; }
        public string? FilePath { get; set; }
        public int? LineNum { get; set; }
        public string? Origin { get; set; }
        public string? Modified { get; set; }
        public string? Status { get; set; }
    }
}
