using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GJP_IMIS.IMIS_Methods.Database_Connection
{
    class Connection_String
    {

        public static SqlConnection con;
        //MIGGY
        //public static String conn = @"Data Source=MIGGYPAREJA\SQLEXPRESS;Initial Catalog=IMIS;Integrated Security=True";

        // MAB
        public static String conn = @"Data Source=DESKTOP-IOF93CS\SQLEXPRESS;Initial Catalog=IMIS;Integrated Security=True";

        //Earl
        //public static String conn = @"Data Source=DESKTOP-S9H3AS7\SQLEXPRESS;Initial Catalog=IMIS;Integrated Security=True";

        //ETO TEST APDATE
        //Earl Test Database
        //public static String conn = @"Data Source=DESKTOP-DC45MHQ\SQLEXPRESS;Initial Catalog=IMIS_Test;Integrated Security=True";


        // OFFICE DB
        //public static String conn = @"Data Source=HRMS-SARAH\SQLEXPRESS;Initial Catalog=IMIS;Integrated Security=True";

        public static void dbConnection()
        {
            con = new SqlConnection(conn);
            con.Open();
        }

    }
}
