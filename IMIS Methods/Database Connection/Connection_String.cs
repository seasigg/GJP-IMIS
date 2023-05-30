using System.Configuration;
using System.Data.SqlClient;

namespace GJP_IMIS.IMIS_Methods.Database_Connection
{
    class Connection_String
    {

        public static SqlConnection con;

        //MAIN
        public static string conn = ConfigurationManager.ConnectionStrings["Main"].ConnectionString;

        public static void dbConnection()
        {
            con = new SqlConnection(conn);
            con.Open();
        }

    }
}
