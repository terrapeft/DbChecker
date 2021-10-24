using System.Data;

namespace BackofficeTools.Models
{
    public class ScriptResult:IScriptResult
    {
        private readonly string _scriptName;

        public ScriptResult(string scriptName)
        {
            _scriptName = scriptName;
        }

        public DataSet Results { get; set; }
        public string Messages { get; set; }
    }

    public interface IScriptResult
    {
        DataSet Results { get; set; }
        string Messages { get; set; }
    }
}
