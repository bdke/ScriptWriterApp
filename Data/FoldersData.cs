using ScriptWriterApp.IData;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScriptWriterApp.Data
{
    public class FoldersData : IDatabaseData
    {
        public int ID { get; set; }
        public string? FolderName { get; set; }
        public List<PagesData>? Pages { get; set; }
        public List<FoldersData>? Folders { get; set; }

        [ForeignKey("FoldersData")]
        public int? FoldersDataID { get; set; }
    }
}
