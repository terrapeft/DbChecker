using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbChecker
{
    public static class SqlGenerator
    {
        public static string GenerateSelectFromValues(DataTable dt)
        {
            var sb = new StringBuilder("select * from \n( values ");
            sb.AppendLine();
            var isFirstRow = true;

            foreach (DataRow row in dt.Rows)
            {
                var values = row.ItemArray
                    .Cast<object>()
                    .Select(c => c.ToString())
                    .Aggregate((i, k) => $"'{i}', '{k}'");

                sb.Append($"{(isFirstRow ? "":",\n")}\t({values})");
                isFirstRow = false;
            }

            var names = dt.Columns
                .Cast<DataColumn>()
                .Select(c => c.ColumnName
                    .Replace(" ", "")
                    .Replace("/", "")
                    .Replace("?", "")
                    .Replace("\\", ""))
                .Aggregate((i, k) => $"{i}, {k}");

            sb.Append("\n) as v ");
            sb.AppendLine($"({names})");

            return sb.ToString();
        }

        public static string GenerateSelectIntoTemp(DataTable dt, int batchSize = 1000000)
        {
            var tableName = "#tempTable";
            var batches = dt.Rows
                .Cast<DataRow>()
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / batchSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();

            var sb = new StringBuilder($"drop table if exists {tableName}");
            sb.AppendLine();

            foreach (var batch in batches)
            {
                sb.AppendLine($"select * into {tableName} from (values ");

                foreach (var row in batch)
                {
                    sb.Append("('");
                    var rowStr = string.Join("','",
                        dt.Columns.Cast<DataColumn>().Select(c => $"{row[c].ToString().Replace("'", "''")}"));
                    sb.Append(rowStr);
                    sb.Append("')");
                    if (batch.IndexOf(row) != batch.Count - 1)
                    {
                        sb.AppendLine(",");
                    }
                    else
                    {
                        sb.AppendLine();
                    }
                }

                var names = dt.Columns
                    .Cast<DataColumn>()
                    .Select(c => c.ColumnName
                        .Replace(" ", "")
                        .Replace("/", "")
                        .Replace("?", "")
                        .Replace("\\", ""))
                    .Aggregate((i, k) => $"{i}, {k}");

                sb.Append(") v ");
                sb.AppendLine($"({names})");
            }

            return sb.ToString();
        }
    }
}
