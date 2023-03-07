using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using GJP_IMIS.IMIS_Methods.Database_Connection;

namespace GJP_IMIS.IMIS_Methods.Course_Queries
{
    class courseQueries
    {
        public static void insertCourse(string c)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO Course VALUES ('" + c + "')", Connection_String.con);
            cmd.ExecuteNonQuery();
            Connection_String.con.Dispose();
        }

        public static void updateCourse(string cId, string cName)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Course SET Course_Name = '" + cName + "' WHERE Course_ID = '" + cId + "'", Connection_String.con);
            cmd.ExecuteNonQuery();
            Connection_String.con.Dispose();
        }

        public static void deleteCourse(string cId)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM Course WHERE Course_ID = '" + cId + "'", Connection_String.con);
            cmd.ExecuteNonQuery();
            Connection_String.con.Dispose();
        }
    }
}
