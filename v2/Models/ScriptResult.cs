using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbChecker.Models
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
