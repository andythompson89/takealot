using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TakealotApi.Sql
{
    public class SqlClient : ISqlClient
    {
        // example
        public async void Write()
        {
            var str = Environment.GetEnvironmentVariable("sqldb_connection");
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                var text = "UPDATE SalesLT.SalesOrderHeader " +
                        "SET [Status] = 5  WHERE ShipDate < GetDate();";

                using (SqlCommand cmd = new SqlCommand(text, conn))
                {
                    var rows = await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
