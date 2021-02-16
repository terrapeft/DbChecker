using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbChecker.Models;

namespace DbChecker.Models
{
    public class GroupResultsCollection
    {
        public GroupResultsCollection(List<Group> groups)
        {
            Results = new List<GroupResults>();

            foreach (var group in groups)
            {
                Results.Add(new GroupResults(group));
            }
        }

        public List<GroupResults> Results { get; }
    }
}
