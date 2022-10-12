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
            Connection_String.con.Close();

            return dt;
        }
        
        //MAIN MENU - INTERN PANEL - INTERN DATA GRID
        public static DataTable viewInternPlain()
        {
            String query = "select Intern_Info.OJT_Number as 'OJT Number', First_Name as 'First Name', Last_Name as 'Last Name', Course, Addresse_Info.Salutation as 'Addresse', University.University_Name as 'University', Office.Office_Name as 'Office Deployed', Intern_Status.Status as 'Status' " +
                "from((((Intern_Info " +
                "inner join Addresse_Info on Intern_Info.Addresse_ID = Addresse_Info.Addresse_ID)" +
                "inner join University on Intern_Info.School_ID = University.University_ID)" +
                "inner join Office on Intern_Info.Office_ID = Office.Office_ID)" +
                "inner join Intern_Status on Intern_Status.OJT_Number = Intern_Info.OJT_Number)";

            return dataTable(query);
        }

        //MAIN MENU - UNIVERSITY PANEL/ADDRESSE PANEL - UNIVERSITY DATA GRID
        public static DataTable universityDataGrid()
        {
            return dataTable("select * from University");
        }
        //MAIN MENU - ADDRESSE PANEL - ADDRESSE DATA GRID
        public static DataTable addresseDataGrid()
        {
            return dataTable("SELECT Addresse_ID, Addresse_Name as 'Addresse Name', Position, Department, Salutation, University.University_Name as 'University' " +
                "FROM Addresse_Info " +
                "INNER JOIN University ON Addresse_Info.University_ID = University.University_ID");
        }

        //MAIN MENU - ADDRESSE PANEL - FILTER ADDRESE BY UNIVERSITY DATAGRID
        public static DataTable filterAddresse(string univID)
        {
            return dataTable("SELECT Addresse_ID, Addresse_Name as 'Addresse Name', Position, Department, Salutation, University.University_Name as 'University' " +
                "FROM Addresse_Info " +
                "INNER JOIN University ON Addresse_Info.University_ID = University.University_ID WHERE Addresse_Info.University_ID = '"+univID+"'");
        }
    }
}
