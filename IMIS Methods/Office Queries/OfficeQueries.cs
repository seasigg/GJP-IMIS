using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using GJP_IMIS.IMIS_Methods.Database_Connection;

namespace GJP_IMIS.IMIS_Methods.Office_Queries
{
    class OfficeQueries
    {
        public static void insertOffice(string o, string oa)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO OFFICE VALUES ('" + o + "', '"+oa+"')", Connection_String.con);
            cmd.ExecuteNonQuery();
            Connection_String.con.Close();
        }
    }
}
