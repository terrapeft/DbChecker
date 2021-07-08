using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbChecker.Models
{
    public interface IScript
    {
        string Text { get; set; }
        string Name { get; set; }
        Guid Guid { get; set; }
        string ConnectionString { get; set; }
        string ConnectionStringComment { get; }
    }

    public class Script : IScript
    {
        internal const string CONNSTR_COMMENT = "-- >> ";

        public Script()
        {
            Guid = Guid.NewGuid();
        }

        public string Text { get; set; }
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public string ConnectionString { get; set; }
        public string ConnectionStringComment => CONNSTR_COMMENT + ConnectionString;
    }
}
