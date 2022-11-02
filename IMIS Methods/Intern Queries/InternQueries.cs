using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GJP_IMIS.IMIS_Methods.Database_Connection;
using System.Data.SqlClient;
using System.Data;

namespace GJP_IMIS.IMIS_Methods.Intern_Queries
{
    class InternQueries
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


        // -------------------- Add Intern Form -------------------- //

        // OJT ID
        public static Boolean checkYearData()
        {
            string currentYear = "%" + DateTime.Now.Year.ToString() + "%";
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Intern_Info WHERE OJT_Number LIKE '" + currentYear + "'", Connection_String.con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
                return true;

            Connection_String.con.Close();

            return false;
        }

        public static string addOJTNumberIncrement()
        {
            string currentID = "";
            
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("SELECT MAX(OJT_Number) FROM Intern_Info", Connection_String.con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
                currentID = dr.GetString(0);

            int incremented = Convert.ToInt32(currentID);
            incremented++;

            Connection_String.con.Close();

            return incremented.ToString("D3");
        }
        
        // ------------------------ Adding of Interns ------------------------ //
        
        public static void addInternData(string o, string f, string m, string l, string g, string c, string univ, string coo, string off, string pic)
        {
            Connection_String.dbConnection();
            string query = "INSERT INTO Intern_Info VALUES ('"+o+"', '"+f+"', '"+m+"', '"+l+"', '"+g+"', '"+c+"', '"+univ+"', '"+coo+"', '"+off+"', '"+pic+"')";
            SqlCommand cmd = new SqlCommand(query, Connection_String.con);
            cmd.ExecuteNonQuery();

            Connection_String.con.Close();
        }

        public static void addInternStatus(string o, string start, string targetD, string targetH)
        {
            string status = "INCOMPLETE";
            string currentHours = "0";
            string endDate = "None";

            Connection_String.dbConnection();
            string query = "INSERT INTO Intern_Status VALUES('"+o+"', '"+start+"', '"+targetD+"', '"+endDate+"', '"+targetH+"', '"+currentHours+"', '"+status+"')";
            SqlCommand cmd = new SqlCommand(query, Connection_String.con);
            cmd.ExecuteNonQuery();

            Connection_String.con.Close();
        }

        /////////////////////////////////////////////////
        public static DataTable getUniversities()
        {
            return dataTable("SELECT * FROM University ORDER BY University_Name ASC");
        }

        public static DataTable getCourses()
        {
            return dataTable("SELECT * FROM Course ORDER BY Course_Name ASC");
        }

        public static DataTable getOffices()
        {
            return dataTable("SELECT * FROM Office");
        }

        public static DataTable checkCoordinator(int uID)
        {
            return dataTable("SELECT Coordinator_ID, Last_Name +', '+ First_Name +' '+Middle_Initial as 'FullName' FROM Coordinator_Info WHERE University_ID = "+uID+"");
        }
    }
}
