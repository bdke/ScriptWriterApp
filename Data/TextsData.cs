using ScriptWriterApp.IData;

namespace ScriptWriterApp.Data
{
    public class TextsData : IDatabaseData
    {
        public int ID { get; set; }
        public string? FilePath { get; set; }
        public int? LineNum { get; set; }
        public string? Text { get; set; }
    }
}
