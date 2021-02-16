using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbChecker.Models
{
    public interface IGroup
    {
        string Name { get; set; }
        List<Script> Scripts { get; set; }
        Guid Guid { get; set; }
    }

    public class Group : IGroup
    {
        public Group()
        {
            Guid = Guid.NewGuid();
        }

        public string Name { get; set; }
        public List<Script> Scripts { get; set; } = new List<Script>();
        public Guid Guid { get; set; }
    }
}
