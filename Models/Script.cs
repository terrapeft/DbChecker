using Newtonsoft.Json;

namespace BackofficeTools.Models
{
    public interface IScript
    {
        string Text { get; set; }
        string Name { get; set; }
        string ConnectionString { get; set; }
    }

    public class Script : IScript
    {
        [JsonIgnore]
        public string Text { get; set; }

        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }
}
