using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataHelper
    {
        private static SqlConnection con = new SqlConnection();
        static DataHelper()
        {
            con.ConnectionString = "Server=.; Database=ShoeDb; Integrated Security=true";
        }

        public static DataTable GetTable(string sql)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public static bool RunCommand(string sql, params SqlParameter[] parameters)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(parameters);
            int rows = cmd.ExecuteNonQuery();
            con.Close();
            return rows > 0;
        }
    }
}
