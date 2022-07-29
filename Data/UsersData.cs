using ScriptWriterApp.IData;

namespace ScriptWriterApp.Data
{
    public class UsersData : IDatabaseData
    {
        public int ID { get; set; }
        public string? UserName { get; set; }
        public string? IP { get; set; }
    }
}
