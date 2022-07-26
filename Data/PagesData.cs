using ScriptWriterApp.IData;

namespace ScriptWriterApp.Data
{
    public class PagesData : IDatabaseData
    {
        public int ID { get; set; }
        public string? Path { get; set; }
        public string? Texts { get; set; }
    }
}
