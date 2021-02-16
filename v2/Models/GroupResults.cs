using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbChecker.Models
{
    public class GroupResults : IGroupResults
    {
        public GroupResults(Group group)
        {
            ScriptResults = new List<ScriptResult>();
            GroupName = group.Name;
            Guid = group.Guid;

            foreach (var script in group.Scripts)
            {
                ScriptResults.Add(new ScriptResult(script));
            }
        }

        public string GroupName { get; }
        public Guid Guid { get; }
        public List<ScriptResult> ScriptResults { get; }

        public Group ToGroup()
        {
            var group = new Group();
            group.Name = GroupName;
            group.Guid = Guid;

            foreach (var scriptResult in ScriptResults)
            {
                group.Scripts.Add(scriptResult.Script);
            }

            return group;
        }
    }

    public interface IGroupResults
    {
        string GroupName { get; }
        Guid Guid { get; }
        List<ScriptResult> ScriptResults { get; }
    }
}
