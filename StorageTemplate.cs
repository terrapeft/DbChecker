using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbChecker
{
    public class QueryItem
    {
        public string GroupName { get; set; }
        public string Query { get; set; }
        public string ConnectionString { get; set; }
    }
}
