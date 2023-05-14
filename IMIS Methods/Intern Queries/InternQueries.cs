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
        

        // ------- IMIS REMASTERED -------
        public static Boolean isInternExist(string ojt)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand(@"SELECT OJT_Number from Intern_Info WHERE OJT_Number LIKE @ojtID", Connection_String.con);
            cmd.Parameters.Add("@ojtID", SqlDbType.Int);
            cmd.Parameters["@ojtID"].Value = ojt;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
                return true;

            Connection_String.con.Dispose();

            return false;
        }

        // add intern data
        public static void addInternData(string ojt, string f, string m, string l, string s, string g,
            string c, string u, string cooN, string cooS, string cooPos, string cooDept, string o, string oT)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand(addInternQuery(), Connection_String.con);

            cmd.Parameters.Add("@ojtID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@fname", SqlDbType.NVarChar);
            cmd.Parameters.Add("@mname", SqlDbType.NVarChar);
            cmd.Parameters.Add("@lname", SqlDbType.NVarChar);
            cmd.Parameters.Add("@suffix", SqlDbType.NVarChar);
            cmd.Parameters.Add("@gender", SqlDbType.NVarChar);
            cmd.Parameters.Add("@course", SqlDbType.NVarChar);
            cmd.Parameters.Add("@univ", SqlDbType.NVarChar);
            cmd.Parameters.Add("@coordName", SqlDbType.NVarChar);
            cmd.Parameters.Add("@coordSal", SqlDbType.NVarChar);
            cmd.Parameters.Add("@coordPos", SqlDbType.NVarChar);
            cmd.Parameters.Add("@coordDept", SqlDbType.NVarChar);
            cmd.Parameters.Add("@office", SqlDbType.NVarChar);
            cmd.Parameters.Add("@ojtTerminal", SqlDbType.NVarChar);

            cmd.Parameters["@ojtID"].Value = ojt;
            cmd.Parameters["@fname"].Value = f;
            cmd.Parameters["@mname"].Value = m;
            cmd.Parameters["@lname"].Value = l;
            cmd.Parameters["@suffix"].Value = s;
            cmd.Parameters["@gender"].Value = g;
            cmd.Parameters["@course"].Value = c;
            cmd.Parameters["@univ"].Value = u;
            cmd.Parameters["@coordName"].Value = cooN;
            cmd.Parameters["@coordSal"].Value = cooS;
            cmd.Parameters["@coordPos"].Value = cooPos;
            cmd.Parameters["@coordDept"].Value = cooDept;
            cmd.Parameters["@office"].Value = o;
            cmd.Parameters["@ojtTerminal"].Value = oT;

            cmd.ExecuteNonQuery();

            Connection_String.con.Dispose();
        }

        private static string addInternQuery()
        {
            return @"INSERT into Intern_Info
                    VALUES (@ojtID, @fname, @mname, @lname, @suffix, @gender, @course,
                    @univ, @coordName, @coordSal, @coordPos, @coordDept, @office, @ojtTerminal)";
        }

        // add intern status
        public static void addInternStatus1(string ojt, string date, string schedAM, string schedPM, string hrs)
        {
            string status = "INCOMPLETE";
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand(addInternStatusQuery(), Connection_String.con);

            cmd.Parameters.Add("@ojtID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@start", SqlDbType.NVarChar);
            cmd.Parameters.Add("@scheduleAM", SqlDbType.Time);
            cmd.Parameters.Add("@schedulePM", SqlDbType.Time);
            cmd.Parameters.Add("@targetHours", SqlDbType.Int);
            cmd.Parameters.Add("@currentHours", SqlDbType.Int);
            cmd.Parameters.Add("@status", SqlDbType.NVarChar);

            cmd.Parameters["@ojtID"].Value = ojt;
            cmd.Parameters["@start"].Value = date;
            cmd.Parameters["@scheduleAM"].Value = schedAM;
            cmd.Parameters["@schedulePM"].Value = schedPM;
            cmd.Parameters["@targetHours"].Value = hrs;
            cmd.Parameters["@currentHours"].Value = 0;
            cmd.Parameters["@status"].Value = status;

            cmd.ExecuteNonQuery();

            Connection_String.con.Dispose();

        }

        private static string addInternStatusQuery()
        {
            return @"INSERT into Intern_Status
                    VALUES 
                    (@ojtID, @start, @scheduleAM, @schedulePM, @targetHours, @currentHours, @status)";
        }

        // update intern data
        public static void updateInternData(string ojt, string f, string m,
            string l, string g, string u,
            string coordF, string coordL, string coordG, string coordPos, string coordDept,
            string c, string o)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand(updateInternDataQuery(), Connection_String.con);
            cmd.Parameters.Add("@ojtID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@fname", SqlDbType.NVarChar);
            cmd.Parameters.Add("@mname", SqlDbType.NVarChar);
            cmd.Parameters.Add("@lname", SqlDbType.NVarChar);
            cmd.Parameters.Add("@gender", SqlDbType.NVarChar);
            cmd.Parameters.Add("@course", SqlDbType.NVarChar);
            cmd.Parameters.Add("@univ", SqlDbType.NVarChar);
            cmd.Parameters.Add("@coordF", SqlDbType.NVarChar);
            cmd.Parameters.Add("@coordL", SqlDbType.NVarChar);
            cmd.Parameters.Add("@coordG", SqlDbType.NVarChar);
            cmd.Parameters.Add("@coordPos", SqlDbType.NVarChar);
            cmd.Parameters.Add("@coordDept", SqlDbType.NVarChar);
            cmd.Parameters.Add("@office", SqlDbType.NVarChar);

            cmd.Parameters["@ojtID"].Value = ojt;
            cmd.Parameters["@fname"].Value = f;
            cmd.Parameters["@mname"].Value = m;
            cmd.Parameters["@lname"].Value = l;
            cmd.Parameters["@gender"].Value = g;
            cmd.Parameters["@course"].Value = c;
            cmd.Parameters["@univ"].Value = u;
            cmd.Parameters["@coordF"].Value = coordF;
            cmd.Parameters["@coordL"].Value = coordL;
            cmd.Parameters["@coordG"].Value = coordG;
            cmd.Parameters["@coordPos"].Value = coordPos;
            cmd.Parameters["@coordDept"].Value = coordDept;
            cmd.Parameters["@office"].Value = o;

            cmd.ExecuteNonQuery();
            Connection_String.con.Dispose();
        }

        // update intern query
        private static string updateInternDataQuery()
        {
            return @"UPDATE intern_Info1 SET 
                    First_Name = @fname,
                    Middle_Initial = @mname,
                    Last_Name = @lname,
                    Gender = @gender,
                    Course = @course,
                    School_Name = @univ,
                    Coordinator_FirstName = @coordF,
                    Coordinator_LastName = @coordL,
                    Coordinator_Gender = @coordG,
                    Coordinator_Position = @coordPos,
                    Coordinator_Department = @coordDept,
                    Office_Name = @office 

                    WHERE OJT_Number = @ojtID";
        }

        // update intern status
        public static void updateInternStatus(string ojt, string schedAM, string schedPM, string h, string status)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand(updateInternStatusQuery(), Connection_String.con);
            cmd.Parameters.Add("@ojtID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@scheduleAM", SqlDbType.Time);
            cmd.Parameters.Add("@schedulePM", SqlDbType.Time);
            cmd.Parameters.Add("@targetHrs", SqlDbType.NVarChar);
            cmd.Parameters.Add("@status", SqlDbType.NVarChar);

            cmd.Parameters["@ojtID"].Value = ojt;
            cmd.Parameters["@scheduleAM"].Value = schedAM;
            cmd.Parameters["@schedulePM"].Value = schedPM;
            cmd.Parameters["@targetHrs"].Value = h;
            cmd.Parameters["@status"].Value = status;

            cmd.ExecuteNonQuery();
            Connection_String.con.Dispose();
        }
        // update intern status query
        private static string updateInternStatusQuery()
        {
            return @"UPDATE Intern_status1
                    SET
                    Schedule_AM = @scheduleAM,
                    Schedule_PM = @schedulePM,
                    Target_Hours = @targetHrs, 
                    Status = @status 
                    WHERE OJT_Number = @ojtID";
        }
        
        // query for edit intern
        public static string editInternQuery()
        {
            return @"SELECT Intern_Info1.OJT_Number as 'OJT ID',
                        Intern_Info1.Last_Name as 'Last Name',
                        Intern_Info1.Middle_Initial as 'Middle Initial',
                        Intern_Info1.First_Name as 'First Name',
                        Intern_Info1.Gender as 'Gender',
                        Intern_Info1.Course as 'Course',
                        Intern_Info1.School_Name as 'University',
                        Intern_Info1.Coordinator_FirstName as 'Coordinator FirstName',
                        Intern_Info1.Coordinator_LastName as 'Coordinator LastName',
                        Intern_Info1.Coordinator_Gender as 'Coordinator Gender',
                        Intern_Info1.Coordinator_Position as 'Coordinator Position',
						Intern_Info1.Coordinator_Department as 'Coordinator Department',
                        Intern_Info1.Office_Name as 'Office',
                        (Intern_Status.Target_Hours / 3600) as 'Target Hours',
						--Intern_Status.Start_Date as 'Start Date',
                        Intern_Status.Sched_AM as 'Schedule_AM',
                        Intern_Status.Status as 'Status'
                        FROM Intern_Info1 
                        INNER JOIN Intern_Status ON Intern_Info1.OJT_Number = Intern_Status.OJT_Number
                        WHERE Intern_Info1.OJT_Number = @ojtID";
        }

        public static void insertInternLog(int ojtID, string date, string time, string name)
        {
            string res = "Success";
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand(insertInternLogQuery(), Connection_String.con);
            cmd.Parameters.Add("@date", SqlDbType.NVarChar);
            cmd.Parameters.Add("@time", SqlDbType.NVarChar);
            cmd.Parameters.Add("@ojtID", SqlDbType.Int);
            cmd.Parameters.Add("@res", SqlDbType.NVarChar);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar);

            cmd.Parameters["@date"].Value = date;
            cmd.Parameters["@time"].Value = time;
            cmd.Parameters["@ojtID"].Value = ojtID;
            cmd.Parameters["@res"].Value = res;
            cmd.Parameters["@name"].Value = name;

            cmd.ExecuteNonQuery();
            Connection_String.con.Dispose();
        }

        private static string insertInternLogQuery()
        {
            return @"INSERT into Intern_Logs
                    VALUES
                    (@date, @time, @ojtID, @name, @res)";
        }

        public static DataTable internLogsData(int id)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand(internLogsQuery(), Connection_String.con);
            cmd.Parameters.Add("@ojtId", SqlDbType.Int);
            cmd.Parameters["@ojtId"].Value = id;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Connection_String.con.Dispose();

            return dt;
        }

        private static string internLogsQuery()
        {
            return @"select Date as 'Date',
                    Time as 'Time',
                    UserID as 'OJT ID',
                    Name as 'Terminal Name' 

                    FROM Intern_Logs
                    WHERE userid = @ojtId
                    ORDER BY Date DESC";
        }

        public static void updateInternLog(int ojtID,
            string oldTime, string oldDate,
            string newTime, string newDate)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand(updateInternLogQuery(), Connection_String.con);
            cmd.Parameters.Add("@ojtID", SqlDbType.Int);
            cmd.Parameters.Add("@oldTime", SqlDbType.NVarChar);
            cmd.Parameters.Add("@oldDate", SqlDbType.NVarChar);
            cmd.Parameters.Add("@newTime", SqlDbType.NVarChar);
            cmd.Parameters.Add("@newDate", SqlDbType.NVarChar);

            cmd.Parameters["@ojtID"].Value = ojtID;
            cmd.Parameters["@oldTime"].Value = oldTime;
            cmd.Parameters["@oldDate"].Value = oldDate;
            cmd.Parameters["@newTime"].Value = newTime;
            cmd.Parameters["@newDate"].Value = newDate;

            cmd.ExecuteNonQuery();
            Connection_String.con.Dispose();
        }

        private static string updateInternLogQuery()
        {
            return @"UPDATE Intern_Logs 
                    SET 
                    Date = @newDate, 
                    Time = @newTime 
                    WHERE 
                    UserID = @ojtID 
                    AND Date = @oldDate 
                    AND Time = @oldTime ";
        }

        public static DataTable getUniversities1()
        {
            return dataTable("SELECT DISTINCT Intern_Info.School_Name FROM Intern_Info;");
        }
        public static DataTable getOffices1()
        {
            return dataTable("SELECT Intern_Info.Office_Name FROM Intern_Info;");
        }
        /*public static DataTable getCourses1()
        {
            return dataTable("SELECT DISTINCT Course.Course_Name, Course.Course_ID FROM Course, Intern_Info1 WHERE Course.Course_ID = Intern_Info1.Course_ID");
        }*/

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

        
    }
}
