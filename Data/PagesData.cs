using ScriptWriterApp.IData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScriptWriterApp.Data
{
    public class PagesData : IDatabaseData
    {
        public int ID { get; set; }
        public string? Path { get; set; }
        public string? Texts { get; set; }
        public string? pTexts { get; set; }
        public string? Title { get; set; }
        [ForeignKey("FoldersData")]
        public int? FoldersDataID { get; set; }
        
    }
}
