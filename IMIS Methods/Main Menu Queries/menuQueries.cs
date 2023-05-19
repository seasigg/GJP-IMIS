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
        
        // intern data table
        public static DataTable viewInternPlain1()
        {
            String query = @"SELECT Intern_Info.OJT_Number as 'OJT ID',
                        (Intern_Info.First_Name + ' ' + Intern_Info.Last_Name + ' ' + Intern_Info.Suffix) as 'Name',
                        Intern_Info.Course as 'Course',
                        Intern_Info.School_Name as 'University',
                        Intern_Info.Coordinator_Name as 'Coordinator Name',
                        Intern_Info.Office_Name as 'Office',
                        (CAST(Intern_Status.Current_Hours / 3600 AS VARCHAR(10)) + RIGHT(CONVERT(CHAR(8),DATEADD(ss,Intern_Status.Current_Hours,0),108),6)) as 'Hours Rendered',
                        (Intern_Status.Target_Hours / 3600) as 'Target Hours',
                        Intern_Status.Status as 'Status'
                        FROM Intern_Info
                        INNER JOIN Intern_Status ON Intern_Info.OJT_Number = Intern_Status.OJT_Number";
            return dataTable(query);
        }
        
        // unreg interns
        public static DataTable viewUnregInternPlain()
        {
            String query = @"SELECT DISTINCT
		                        i.UserID, i.Name

                            from Intern_Logs i
                            left join Intern_Info n
		                        on i.UserID = n.OJT_Number

                            where n.OJT_Number is null and i.UserID != 1";
            return dataTable(query);
        }

        // acceptance letter data grid
        public static DataTable reportAcceptanceDataGrid1()
        {
            return dataTable(@"SELECT DISTINCT
                OJT_Number AS 'OJT Number',
                CONCAT(First_Name, ' ', Middle_Initial, '. ', Last_Name) AS 'Intern'
                FROM Intern_Info ");
        }
        
        // intern logs
        public static DataTable insertInternLogDataGrid()
        {
            return dataTable(@"SELECT DISTINCT
                OJT_Number AS 'OJT Number',
                CONCAT(First_Name, ' ', Middle_Initial, '. ', Last_Name) AS 'Intern',
                OJT_Terminal AS 'Terminal Name'
                FROM Intern_Info ");
        }

    }
}
