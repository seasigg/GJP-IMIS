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
            Connection_String.con.Dispose();
        }

        public static void updateUniversity(string university, string univId)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("UPDATE University SET University_Name = '"+ university + "' WHERE University_Id = '"+univId+"'", Connection_String.con);
            cmd.ExecuteNonQuery();
            Connection_String.con.Dispose();
        }

        public static void deleteUniversity(string univId)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM University where University_ID = '" + univId + "'", Connection_String.con);
            cmd.ExecuteNonQuery();
            Connection_String.con.Dispose();
        }

        public static bool isUniv(string univId)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) as 'count' FROM Intern_Info WHERE University_ID = '" + univId + "'", Connection_String.con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (Convert.ToInt32(dr["count"]) > 0)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
