using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using GJP_IMIS.IMIS_Methods.Database_Connection;

namespace GJP_IMIS.IMIS_Methods.Report_Queries
{
    class ReportQueries
    {
        

        public static string acceptLetter(string id)
        {
            return ("SELECT DISTINCT DATENAME(MONTH, GETDATE()) + ' ' + DATENAME(DAY,GETDATE()) + ', ' + DATENAME(YEAR,GETDATE()) AS 'Date_Now', " +
                "" +
                "Coordinator_Info.First_Name + ' ' + Coordinator_Info.Middle_Initial + '. ' + Coordinator_Info.Last_Name AS 'Coord_Name', " +
                "Coordinator_Info.Position, " +
                "University.University_Name AS 'University', " +
                "" +
                "CASE " +
                "WHEN Coordinator_Info.Gender = 'Male' THEN 'Mr. ' + Coordinator_Info.Last_Name " +
                "ELSE 'Ms. ' + Coordinator_Info.Last_Name " +
                "END AS 'Coord_Intro', " +
                "" +
                "Intern_Info.First_Name + ' ' + Intern_Info.Middle_Initial + '. ' + Intern_Info.Last_Name AS 'Intern_Name', " +
                "Course.Course_Name AS 'Intern_Course', " +
                "" +
                "CASE " +
                "WHEN Intern_Info.Gender = 'Male' THEN 'Mr. ' + Intern_Info.Last_Name " +
                "ELSE 'Ms. ' + Intern_Info.Last_Name " +
                "END AS 'Intern_Intro', " +
                "" +
                "CASE " +
                "WHEN Intern_Info.Gender = 'Male' THEN 'His' " +
                "ELSE 'Her' " +
                "END AS 'Intern_Pronoun', " +
                "" +
                "Intern_Status.Target_Hours, " +
                "Office.Office_Name, " +
                "Office.Office_Abr " +
                "" +
                "FROM Coordinator_Info, University, Intern_Info, Course, Intern_Status, Office " +
                "WHERE Intern_Info.OJT_Number = '"+id+"' " +
                "AND Intern_Info.Coordinator_ID = Coordinator_Info.Coordinator_ID " +
                "AND Intern_Info.University_ID = University.University_ID " +
                "AND Intern_Info.Office_ID = Office.Office_ID " +
                "AND Intern_Info.Course_ID = Course.Course_ID " +
                "AND Intern_Status.OJT_Number = Intern_Info.OJT_Number");
        }

        // IMIS REMASTERED
        public static string acceptanceLetter(string ojtid)
        {
            return ("SELECT DISTINCT DATENAME(MONTH, GETDATE()) + ' ' + DATENAME(DAY,GETDATE()) + ', ' + DATENAME(YEAR,GETDATE()) AS 'Date_Now', " +
                "" +
                "Intern_Info1.Coordinator_FirstName + ' ' + Intern_Info1.Coordinator_LastName AS 'Coord_Name', " +
                "Intern_Info1.Coordinator_Position AS 'Position', " +
                "Intern_Info1.School_Name AS 'University', " +
                "" +
                "CASE " +
                "WHEN Intern_Info1.Coordinator_Gender = 'Male' THEN 'Mr. ' + Intern_Info1.Coordinator_LastName " + // COORDINATOR SURNAME
                "ELSE 'Ms. ' + Intern_Info1.Coordinator_LastName " +
                "END AS 'Coord_Intro', " +
                "" +
                "Intern_Info1.First_Name + ' ' + Intern_Info1.Middle_Initial + '. ' + Intern_Info1.Last_Name AS 'Intern_Name', " +
                "Course.Course_Name AS 'Intern_Course', " +
                "" +
                "CASE " +
                "WHEN Intern_Info1.Gender = 'Male' THEN 'Mr. ' + Intern_Info1.Last_Name " +
                "ELSE 'Ms. ' + Intern_Info1.Last_Name " +
                "END AS 'Intern_Intro', " +
                "" +
                "CASE " +
                "WHEN Intern_Info1.Gender = 'Male' THEN 'His' " +
                "ELSE 'Her' " +
                "END AS 'Intern_Pronoun', " +
                "" +
                "Intern_Status1.Target_Hours, " +
                "Intern_Info1.Office_Name, " +
                "Intern_Info1.Office_Name AS 'Office_Abr'" + // OFFICE ABBREVIATION DAPAT TO (CLEARED)
                "" +
                "FROM Intern_Info1, Course, Intern_Status1 " +
                "WHERE Intern_Info1.OJT_Number = '" + ojtid + "' " +
                
                "AND Intern_Info1.Course_ID = Course.Course_ID " +
                "AND Intern_Status1.OJT_Number = Intern_Info1.OJT_Number"); ;
        }
        public static string Intern()
        {
            return "SELECT DISTINCT " +
                "" +
                "Intern_Info.Last_Name + ', ' + Intern_Info.First_Name + ' ' + Intern_Info.Middle_Initial + '.' AS 'Intern Name', " +
                "Intern_Info.Gender, " +
                "Course.Course_Name AS 'Course', " +
                "University.University_Name AS 'University', " +
                "Office.Office_Name AS 'Office Deployed' " +
                "" +
                "FROM Intern_Info, Course, University, Office " +
                "WHERE " +
                "Intern_Info.Course_ID = Course.Course_ID " +
                "AND Intern_Info.University_ID = University.University_ID " +
                "AND Intern_Info.Office_ID = Office.Office_ID";
        }

        public static string reportsInternQuery()
        {
            return "SELECT DISTINCT " +
                "" +
                "Intern_Info.Last_Name + ', ' + Intern_Info.First_Name + ' ' + Intern_Info.Middle_Initial + '.' AS 'Intern Name', " +
                "Intern_Info.Gender AS 'Gender', " +
                "Course.Course_Name AS 'Course', " +
                "University.University_Name AS 'University', " +
                "Office.Office_Name AS 'Office Deployed' " +
                "" +
                "FROM Intern_Info, Course, University, Office " +
                "WHERE " +
                "Intern_Info.Course_ID = Course.Course_ID " +
                "AND Intern_Info.University_ID = University.University_ID " +
                "AND Intern_Info.Office_ID = Office.Office_ID ";
        }

        public static string reportsInternQuery1()
        {
            return "SELECT DISTINCT " +
                "Intern_Info1.Last_Name + ', ' + Intern_Info1.First_Name + ' ' + Intern_Info1.Middle_Initial + '.' AS 'Intern Name', " +
                "Intern_Info1.Gender AS 'Gender', " +
                "Course.Course_Name AS 'Course', " +
                "Intern_Info1.School_Name AS 'University', " +
                "Intern_Info1.Office_Name AS 'Office Deployed' " +
                "FROM Intern_Info1, Course " +
                "WHERE " +
                "Intern_Info1.Course_ID = Course.Course_ID ";
        }
    }
}
