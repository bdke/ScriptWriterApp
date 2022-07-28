using ScriptWriterApp.IData;

namespace ScriptWriterApp.Data
{
    public class FoldersData : IDatabaseData
    {
        public int ID { get; set; }
        public string? FolderName { get; set; }
        public List<PagesData>? Pages { get; set; }
        public List<FoldersData>? Folders { get; set; }
    }
}
