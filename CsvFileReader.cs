using System.Data;
using System.Globalization;
using System.IO;
using CsvHelper;
using Microsoft.VisualBasic.FileIO;

namespace DbChecker
{
    public class CsvFileReader
    {
        public static DataTable Load(string filePath)
        {
            var dt = new DataTable();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                using (var dr = new CsvDataReader(csv))
                {
                    dt.Load(dr);
                }
            }

            return dt;
        }
    }
}
