using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DbChecker.Models;

namespace DbChecker
{
    public class SqlRunner
    {
        private readonly Script _script;

        public SqlRunner(Script script)
        {
            _script = script;
        }

        public async Task<ScriptResult> GetDataSet(string connStr)
        {
            var result = new ScriptResult(_script);
            var ds = new DataSet();
            await Task.Run(() =>
            {
                try
                {
                    using (var connection = new SqlConnection(connStr))
                    {
                        using (var cmd = new SqlCommand(_script.Text, connection))
                        {
                            cmd.CommandTimeout = 3600;
                            connection.Open();

                            using (var sda = new SqlDataAdapter(cmd))
                            {
                                try
                                {
                                    sda.Fill(ds);
                                    result.Results = ds;
                                }
                                catch (SqlException ex)
                                {
                                    result.Messages = ex.Message;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Messages = ex.Message;
                }
            });

            return result;
        }
    }
}
