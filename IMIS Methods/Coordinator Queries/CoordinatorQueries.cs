using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using GJP_IMIS.IMIS_Methods.Database_Connection;

namespace GJP_IMIS.IMIS_Methods.Coordinator_Queries
{
    class CoordinatorQueries
    {
        public static DataTable dataTable(string query)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand(query, Connection_String.con);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Connection_String.con.Close();

            return dt;
        }

        public static void insertCoordinator(string first, string middle, string last, string gend, string pos, string dep, int uID )
        {
            Connection_String.dbConnection();
            string query = "INSERT INTO Coordinator_Info VALUES ('" + first + "', '" + middle + "', '" + last + "', '" + gend + "', '" + pos + "', '" + dep + "', " + uID + ")";
            SqlCommand cmd = new SqlCommand(query, Connection_String.con);
            cmd.ExecuteNonQuery();

            Connection_String.con.Close();
        }

        public static DataTable getUniversity()
        {
            return dataTable("SELECT * FROM University");
        }
    }
}
