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
        public ScriptResult(Script script)
        {
            Script = script;
            Guid = script.Guid;
        }

        public Script Script { get; set; }
        public Guid Guid { get; }
        public DataTable Results { get; set; }
        public string Messages { get; set; }
    }

    public interface IScriptResult
    {
        Script Script { get; set; }
        Guid Guid { get; }
        DataTable Results { get; set; }
        string Messages { get; set; }
    }
}
