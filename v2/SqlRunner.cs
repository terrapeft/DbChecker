using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using DbChecker.Models;
using System.Timers;
using Timer = System.Timers.Timer;

namespace DbChecker
{
    public class SqlRunner
    {
        private readonly Script _script;
        private readonly CancellationToken _ctsToken;

        public SqlRunner(Script script, CancellationToken ctsToken)
        {
            _script = script;
            _ctsToken = ctsToken;
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
                                var cancellationTimer = new Timer(1000);
                                cancellationTimer.Elapsed += (sender, args) =>
                                {
                                    if (_ctsToken.IsCancellationRequested)
                                    {
                                        sda.SelectCommand.Cancel();
                                    }
                                };
                                cancellationTimer.Start();

                                try
                                {
                                    sda.Fill(ds);
                                    result.Results = ds;
                                }
                                catch (SqlException ex)
                                {
                                    result.Messages = ex.Message;
                                }
                                finally
                                {
                                    cancellationTimer.Stop();
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
