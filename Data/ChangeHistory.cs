using ScriptWriterApp.IData;

namespace ScriptWriterApp.Data
{
    public class ChangeHistory : IDatabaseData
    {
        public int ID { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Modifier { get; set; }
        public string? FilePath { get; set; }
        public int? LineNum { get; set; }
        public string? Origin { get; set; }
        public string? Modified { get; set; }
        public char? Status { get; set; }
    }
}
