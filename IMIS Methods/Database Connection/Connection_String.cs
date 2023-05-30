using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace GJP_IMIS.IMIS_Methods.Database_Connection
{
    class Connection_String
    {

        public static SqlConnection con;

        //EarlTEST
        //public static string conn = ConfigurationManager.ConnectionStrings["EarlTEST"].ConnectionString;

        // Earl
        //public static string conn = ConfigurationManager.ConnectionStrings["Earl"].ConnectionString;

        // Maverick
        //public static string conn = ConfigurationManager.ConnectionStrings["Maverick"].ConnectionString;

        // Miggy
        //public static string conn = ConfigurationManager.ConnectionStrings["Miggy"].ConnectionString;

        //OJT
        //public static string conn = ConfigurationManager.ConnectionStrings["OJT"].ConnectionString;

        //MAIN
        public static string conn = ConfigurationManager.ConnectionStrings["Main"].ConnectionString;

        public static void dbConnection()
        {
            con = new SqlConnection(conn);
            con.Open();
        }

    }
}
