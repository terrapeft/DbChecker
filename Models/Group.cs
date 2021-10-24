using System.Collections.Generic;

namespace BackofficeTools.Models
{
    public interface IGroup
    {
        string Name { get; set; }
        List<Script> Scripts { get; set; }
    }

    public class Group : IGroup
    {
        public Group()
        {}

        public Group(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<Script> Scripts { get; set; } = new List<Script>();
    }
}
