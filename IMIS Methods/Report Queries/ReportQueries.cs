﻿using System;
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
            return ("SELECT DISTINCT DATENAME(MONTH, GETDATE()) + ' ' + DATENAME(YEAR,GETDATE()) AS 'Date_Now', " +
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
                "AND Intern_Info.Course_ID = Course.Course_ID");
        } 
    }
}