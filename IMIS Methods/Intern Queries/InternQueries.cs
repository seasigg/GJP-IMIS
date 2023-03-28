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
            Connection_String.con.Dispose();

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

            Connection_String.con.Dispose();

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

            Connection_String.con.Dispose();

            return incremented.ToString("D3");
        }
        
        // ------------------------ Adding of Interns ------------------------ //
        // IMIS
        public static void addInternData(string o, string f, string m, string l, string g, string c, string univ, string coo, string off, string pic)
        {
            Connection_String.dbConnection();
            string query = "INSERT INTO Intern_Info VALUES ('"+o+"', '"+f+"', '"+m+"', '"+l+"', '"+g+"', '"+c+"', '"+univ+"', '"+coo+"', '"+off+"', '"+pic+"')";
            SqlCommand cmd = new SqlCommand(query, Connection_String.con);
            cmd.ExecuteNonQuery();

            Connection_String.con.Dispose();
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

            Connection_String.con.Dispose();
        }

        // ------- IMIS REMASTERED -------
        public static Boolean isInternExist(string ojt)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("SELECT OJT_Number from Intern_Info1 WHERE OJT_Number LIKE '" + ojt + "'", Connection_String.con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
                return true;

            Connection_String.con.Dispose();

            return false;
        }

        // add intern data
        public static void addInternData1(string ojt, string f, string m, string l, string g,
            int c, string u, string coo, string cooG, string cooPos, string cooDept, string o)
        {
            Connection_String.dbConnection();
            string query = "INSERT into Intern_Info1 VALUES('"+ojt+ "', '"+f+ "', '"+m+ "', '"+l+ "', '"+g+ "', '"+c+ "', '"+u+ "', '"+coo+ "','"+cooG+"', '"+cooPos+"', '"+cooDept+"', '" + o+"')";
            SqlCommand cmd = new SqlCommand(query, Connection_String.con);
            cmd.ExecuteNonQuery();

            Connection_String.con.Dispose();
        }

        // add intern status
        public static void addInternStatus1(string ojt, string date, string hrs)
        {
            string status = "INCOMPLETE";

            Connection_String.dbConnection();
            string query = "INSERT INTO Intern_Status1 VALUES ('"+ojt+ "', '"+date+ "', '"+hrs+ "', '"+status+"')";
            SqlCommand cmd = new SqlCommand(query, Connection_String.con);
            cmd.ExecuteNonQuery();

            Connection_String.con.Dispose();

        }

        // update intern data
        public static void updateInternData(string ojt, string f, string m,
            string l, string g, string u, string coord,
            int c, string o)
        {
            Connection_String.dbConnection();
            string query = updateInternDataQuery(ojt, f, m, l, g, u, coord, c, o);
            SqlCommand cmd = new SqlCommand(query, Connection_String.con);
            cmd.ExecuteNonQuery();
            Connection_String.con.Dispose();
        }

        // update intern status
        public static void updateInternStatus(string ojt, string h, string status)
        {
            Connection_String.dbConnection();
            string query = updateInternStatusQuery(ojt, h, status);
            SqlCommand cmd = new SqlCommand(query, Connection_String.con);
            cmd.ExecuteNonQuery();
            Connection_String.con.Dispose();
        }

        // query for update intern data
        public static string updateInternDataQuery(string ojt, string f, string m,
            string l, string g, string u, string coord,
            int c, string o)
        {
            return "update Intern_Info1 SET " +
                "First_Name = '"+f+"', " +
                "Middle_Initial = '"+m+"', " +
                "Last_Name = '"+l+"', " +
                "Gender = '"+g+"', " +
                "Course_ID = '"+c+"', " +
                "University_Name = '"+u+"', " +
                "Coordinator_Name = '"+coord+"', " +
                "Office_Name = '"+o+"' " +
                "WHERE OJT_Number = '"+ojt+"' ";
        }

        // query for update intern status
        public static string updateInternStatusQuery(string ojt, string hours, string status)
        {
            return "update Intern_Status1 SET " +
                "Target_Hours = '"+ hours + "', " +
                "Status = '"+ status + "' " +
                "WHERE OJT_Number = '"+ ojt + "'";
        }
        // query for edit intern
        public static string editInternQuery(string ojt)
        {
            return "SELECT Intern_Info1.OJT_Number as 'OJT ID'," +
                        "Intern_Info1.Last_Name as 'Last Name'," +
                        "Intern_Info1.Middle_Initial as 'Middle Initial'," +
                        "Intern_Info1.First_Name as 'First Name'," +
                        "Intern_Info1.Gender as 'Gender'," +
                        "Course.Course_ID as 'Course'," +
                        "Intern_Info1.University_Name as 'University'," +
                        "Intern_Info1.Coordinator_Name as 'Coordinator Name'," +
                        "Intern_Info1.Office_Name as 'Office'," +
                        "Intern_Status1.Target_Hours as 'Target Hours'," +
                        "Intern_Status1.Status as 'Status'" +
                        "FROM Intern_Info1 " +
                        "INNER JOIN Course ON Intern_Info1.Course_ID = Course.Course_ID " +
                        "INNER JOIN Intern_Status1 ON Intern_Info1.OJT_Number = Intern_Status1.OJT_Number " +
                        "WHERE Intern_Info1.OJT_Number = '"+ojt+"'";
        }

        // ------- END OF IMIS REMASTERED -------
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

        public static DataTable getUniversities1()
        {
            return dataTable("SELECT Intern_Info1.University_Name FROM Intern_Info1;");
        }
        public static DataTable getOffices1()
        {
            return dataTable("SELECT Intern_Info1.Office_Name FROM Intern_Info1;");
        }
        public static DataTable getCourses1()
        {
            return dataTable("SELECT DISTINCT Course.Course_Name, Course.Course_ID FROM Course, Intern_Info1 WHERE Course.Course_ID = Intern_Info1.Course_ID");
        }
    }
}
