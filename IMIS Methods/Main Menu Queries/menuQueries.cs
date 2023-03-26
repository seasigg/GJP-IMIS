using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GJP_IMIS.IMIS_Methods.Database_Connection;
using System.Data.SqlClient;
using System.Data;

namespace GJP_IMIS.IMIS_Methods.Main_Menu_Queries
{
    class menuQueries
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
        
        //MAIN MENU - INTERN PANEL - INTERN DATA GRID
        public static DataTable viewInternPlain()
        {
            String query = "SELECT Intern_Info.OJT_Number as 'OJT ID'," +
                "Intern_Info.Last_Name as 'Last Name'," +
                "Intern_Info.First_Name as 'First Name'," +
                "Course.Course_Name as 'Course'," +
                "University.University_Name as 'University'," +
                "CONCAT(Coordinator_Info.First_Name, ' ', Coordinator_Info.Last_Name) as 'Coordinator'," +
                "Office.Office_Name as 'Office Deployed'," +
                "Intern_Status.Status as 'Status'" +
                "from Intern_Info " +
                "INNER JOIN Course ON Intern_Info.Course_ID = Course.Course_ID " +
                "INNER JOIN University ON Intern_Info.University_ID = University.University_ID " +
                "INNER JOIN Coordinator_Info ON Intern_Info.Coordinator_ID = Coordinator_Info.Coordinator_ID " +
                "INNER JOIN Office ON Intern_Info.Office_ID = Office.Office_ID " +
                "INNER JOIN Intern_Status ON Intern_Info.id = Intern_Status.id";
            return dataTable(query);
        }
        
        public static DataTable viewInternPlain1()
        {
            String query = "SELECT Intern_Info1.OJT_Number as 'OJT ID',"+
                        "Intern_Info1.Last_Name as 'Last Name'," +
                        "Intern_Info1.First_Name as 'First Name'," +
                        "Course.Course_Name as 'Course'," +
                        "Intern_Info1.University_Name as 'University'," +
                        "Intern_Info1.Coordinator_Name as 'Coordinator Name'," +
                        "Intern_Info1.Office_Name as 'Office'," +
                        "Intern_Status1.Target_Hours as 'Target Hours'," +
                        "Intern_Status1.Status as 'Status'" +
                        "FROM Intern_Info1 " +
                        "INNER JOIN Course ON Intern_Info1.Course_ID = Course.Course_ID " +
                        "INNER JOIN Intern_Status1 ON Intern_Info1.OJT_Number = Intern_Status1.OJT_Number";
            return dataTable(query);
        }

        //MAIN MENU - UNIVERSITY PANEL/ADDRESSE PANEL - UNIVERSITY DATA GRID
        public static DataTable universityDataGrid()
        {
            return dataTable("select University_ID as 'University ID', University_Name as 'University Name' from University");
        }

        public static DataTable coordinatorDataGridUnfiltered()
        {
            return dataTable("SELECT CONCAT(Coordinator_Info.First_Name, ' ' , Coordinator_Info.Middle_Initial, '. ' , Coordinator_Info.Last_Name) AS 'Coordinator Name', " +
                "Coordinator_Info.Gender, " +
                "Coordinator_Info.Position, " +
                "Coordinator_Info.Department, " +
                "University.University_Name " +
                "FROM Coordinator_Info " +
                "INNER JOIN University ON Coordinator_Info.University_ID = University.University_ID");
        }

        public static DataTable coordinatorDataGridFiltered(int id)
        {
            return dataTable("SELECT CONCAT(Coordinator_Info.First_Name, ' ' , Coordinator_Info.Middle_Initial, '. ' , Coordinator_Info.Last_Name) AS 'Coordinator Name', " +
                "Coordinator_Info.Gender, " +
                "Coordinator_Info.Position, " +
                "Coordinator_Info.Department, " +
                "University.University_Name " +
                "FROM Coordinator_Info " +
                "INNER JOIN University ON Coordinator_Info.University_ID = University.University_ID " +
                "WHERE Coordinator_Info.University_ID = '"+id+"'");
        }

        public static DataTable reportAcceptanceDataGrid()
        {
            return dataTable("SELECT DISTINCT " +
                "OJT_Number AS 'OJT Number', " +
                "CONCAT(First_Name, ' ' , Middle_Initial, '. ', Last_Name) AS 'Intern' " +
                "FROM Intern_Info ");
        }
    }
}
