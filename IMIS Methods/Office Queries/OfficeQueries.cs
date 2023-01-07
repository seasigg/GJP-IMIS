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

        public static void updateOffice(string oId, string oName, string oAbbre) // office ID, office Name, office Abbreviation
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Office SET Office_Name = '" + oName + "', Office_Abr = '" + oAbbre + "' WHERE Office_ID = '" + oId + "'", Connection_String.con);
            cmd.ExecuteNonQuery();
            Connection_String.con.Close();
        }

        public static void deleteOffice(string oId)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM Office WHERE Office_ID = '"+oId+"'", Connection_String.con);
            cmd.ExecuteNonQuery();
            Connection_String.con.Close();
        }
    }
}
