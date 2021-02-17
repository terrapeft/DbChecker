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
    }

    public class Script : IScript
    {
        public Script()
        {
            Guid = Guid.NewGuid();
        }

        public string Text { get; set; }
        public string Name { get; set; }
        public Guid Guid { get; set; }
    }
}
