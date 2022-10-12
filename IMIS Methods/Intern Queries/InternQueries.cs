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

        // Part Two University Data Grid
        public static DataTable addInternUniversityData()
        {
            return dataTable("SELECT * FROM University");
        }

        // Part Two Addresse Data Grid Filtered by University
        public static DataTable addInternAddresseData(string univID)
        {
            return dataTable("SELECT Addresse_ID, Addresse_Name as 'Addresse Name', Position, Department, Salutation, University.University_Name as 'University' " +
                "FROM Addresse_Info " +
                "INNER JOIN University ON Addresse_Info.University_ID = University.University_ID WHERE Addresse_Info.University_ID = '" + univID + "'");
        }

        // Part Three Office DataGrid
        public static DataTable addOfficeData()
        {
            return dataTable("SELECT Office_ID, Office_Name as 'Office Name', Office_Abr as 'Office Abbreviation' FROM Office");
        }

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
        
        public static void addInternData(string o, string f, string m, string l, string c, string g, string u, string a, string off)
        {
            Connection_String.dbConnection();
            string query = "INSERT INTO Intern_Info VALUES ('"+o+"', '"+f+"', '"+m+"', '"+l+"', '"+c+"', '"+a+"', '"+u+"', '"+g+"', '"+off+"')";
            SqlCommand cmd = new SqlCommand(query, Connection_String.con);
            cmd.ExecuteNonQuery();

            Connection_String.con.Close();
        }

        public static void addInternStatus(string o, string t)
        {
            string status = "INCOMPLETE";
            string dateBegin = DateTime.Now.ToShortDateString();
            string currentHours = "0";

            Connection_String.dbConnection();
            string query = "INSERT INTO Intern_Status VALUES('"+o+"', '"+t+"', '"+currentHours+"', '"+status+"', '"+dateBegin+"')";
            SqlCommand cmd = new SqlCommand(query, Connection_String.con);
            cmd.ExecuteNonQuery();

            Connection_String.con.Close();
        }

        /////////////////////////////////////////////////
        public static DataTable getUniversities()
        {
            return dataTable("SELECT * FROM University");
        }

        public static DataTable getCourses()
        {
            return dataTable("SELECT * FROM Course");
        }

        public static DataTable getOffices()
        {
            return dataTable("SELECT * FROM Office");
        }
    }
}
