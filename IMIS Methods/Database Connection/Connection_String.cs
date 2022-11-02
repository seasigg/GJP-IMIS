using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GJP_IMIS.IMIS_Methods.Database_Connection
{
    class Connection_String
    {

        public static SqlConnection con;

        // MAB
        public static String conn = @"Data Source=DESKTOP-NAARK29\SQLEXPRESS;Initial Catalog=IMIS;Integrated Security=True";

        //Earl
        //public static String conn = @"Data Source=DESKTOP-S9H3AS7\SQLEXPRESS;Initial Catalog=IMIS;Integrated Security=True";

        //Earl Test Database
        //public static String conn = @"Data Source=DESKTOP-S9H3AS7\SQLEXPRESS;Initial Catalog=IMISTEST;Integrated Security=True";

        public static void dbConnection()
        {
            con = new SqlConnection(conn);
            con.Open();
        }


    }
}
