using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using GJP_IMIS.IMIS_Methods.Database_Connection;

namespace GJP_IMIS.IMIS_Methods.Univ_Queries
{
    class universityClass
    {
        public static void addUniversity(string university)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("INSERT into University VALUES ('" + university + "')", Connection_String.con);
            cmd.ExecuteNonQuery();
            Connection_String.con.Close();
        }

        public static void updateUniversity(string university, string univId)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("UPDATE University SET University_Name = '"+ university + "' WHERE University_Id = '"+univId+"'", Connection_String.con);
            cmd.ExecuteNonQuery();
            Connection_String.con.Close();
        }
    }
}
