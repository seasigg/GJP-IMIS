using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

using GJP_IMIS.IMIS_Methods.Intern_Queries;
using GJP_IMIS.IMIS_Methods.Database_Connection;

namespace GJP_IMIS.IMIS_Methods.Report_Queries
{
    class ReportQueries
    {

        // ---------------------------------------------- POPULATE REPORTS QUERIES ----------------------------------------------
        public static DataTable getUniversities()
        {
            return InternQueries.dataTable("SELECT DISTINCT Intern_Info.School_Name FROM Intern_Info;");
        }
        public static DataTable getOffices()
        {
            return InternQueries.dataTable("SELECT DISTINCT Intern_Info.Office_Name FROM Intern_Info;");
        }
        public static DataTable getCourses()
        {
            return InternQueries.dataTable("SELECT DISTINCT Intern_Info.Course FROM Intern_Info");
        }

        // ---------------------------------------------- ACCEPTANCE LETTER QUERY ----------------------------------------------
        public static string acceptanceLetter()
        {
            return (@"SELECT DISTINCT 
				DATENAME(MONTH, GETDATE()) + ' ' + DATENAME(DAY,GETDATE()) + ', ' + DATENAME(YEAR,GETDATE()) AS 'Date_Now',
                
                Intern_Info.Coordinator_Name AS 'Coord_Name',
                Intern_Info.Coordinator_Position AS 'Position',
                Intern_Info.Coordinator_Department AS 'Department',
                Intern_Info.School_Name AS 'University',
                Intern_Info.Coordinator_Salutation as 'Coord_Intro',

				CASE
				WHEN Intern_Info.Suffix = ''
				THEN Intern_Info.First_Name + ' ' + Intern_Info.Middle_Initial + '. ' + Intern_Info.Last_Name
				ELSE Intern_Info.First_Name + ' ' + Intern_Info.Middle_Initial + '. ' + Intern_Info.Last_Name + ' ' + Intern_Info.Suffix
				END AS 'Intern_Name',

                Intern_Info.Course AS 'Intern_Course',
                
                CASE
                WHEN Intern_Info.Gender = 'Male' THEN 'Mr. ' + Intern_Info.Last_Name
                ELSE 'Ms. ' + Intern_Info.Last_Name
                END AS 'Intern_Intro',
                
                CASE
                WHEN Intern_Info.Gender = 'Male' THEN 'His'
                ELSE 'Her'
                END AS 'Intern_Pronoun',
                
                CAST(Intern_Status.Target_Hours / 3600 AS nvarchar) AS 'Target_Hours',
                Intern_Info.Office_Name,
                Intern_Info.Office_Name AS 'Office_Abr',
				--'test' as 'Director',
				--'test1' as 'Director_Position'
                @director as 'Director',
				@dirPosition as 'Director_Position'
                
                FROM Intern_Info, Intern_Status

                --WHERE Intern_Info1.OJT_Number = @ojtID
                
                WHERE Intern_Status.OJT_Number = Intern_Info.OJT_Number");
        }

        // ---------------------------------------------- CERTIFICATE OF COMPLETION QUERY ----------------------------------------------
        public static string certOfCompletion()
        {
            return @"DECLARE @day as INT;
                            DECLARE @month as varchar(15);
                            DECLARE @year as varchar(15);

                            SET @day = DATENAME(DAY, GETDATE());
                            SET @month = DATENAME(MONTH, GETDATE());
                            SET @year = DATENAME(YEAR, GETDATE());

                            SELECT
								CASE
									WHEN i.Suffix = '' THEN i.First_Name + ' ' + i.Middle_Initial + '. ' + i.Last_Name
									ELSE i.First_Name + ' ' + i.Middle_Initial + '. ' + i.Last_Name + ' ' + i.Suffix
									END AS 'Intern Name',
	                            i.School_Name as 'School',
	                            i.Course as 'Course',
	                            (s.Target_Hours / 3600) as 'Hours',
	                            i.Office_Name as 'Office',
	                            @day as 'Day',
	                            CASE
		                            WHEN @day % 100 IN (11, 12, 13) THEN 'th'
		                            WHEN @day % 10 = 1 THEN 'st'
		                            WHEN @day % 10 = 2 THEN 'nd'
		                            WHEN @day % 10 = 3 THEN 'rd'
		                            ELSE 'th'
	                            END AS 'Ordinal Number',
	                            @month as 'Month',
	                            @year as 'Year',
                                @director as 'Director',
								@dirPosition as 'Director_Position'

                            FROM Intern_Info i, Intern_Status s
                            WHERE
	                            i.OJT_Number = @ojtID
								AND i.OJT_Number = s.OJT_Number";
        }

        // ---------------------------------------------- POPULATE REPORTS QUERIES QUERY ----------------------------------------------
        public static string reportsInternQuery()
        {
            return @"SELECT DISTINCT
				CASE
					WHEN Intern_Info.Suffix = ''
						THEN Intern_Info.Last_Name + ', ' + Intern_Info.First_Name + ' ' + Intern_Info.Middle_Initial + '.'
					ELSE Intern_Info.Last_Name + ' ' + Intern_Info.Suffix + ', ' + Intern_Info.First_Name + ' ' + Intern_Info.Middle_Initial + '.'
					END AS 'Intern Name',
                Intern_Info.Gender AS 'Gender',
                Intern_Info.Course AS 'Course',
                Intern_Info.School_Name AS 'University',
                Intern_Info.Office_Name AS 'Office Deployed'
                FROM Intern_Info ";
        }

        // ---------------------------------------------- TESTING REPORT INTERN DTR ----------------------------------------------

        public static string reportTestDTR1()
        {
            return @"use IMIS
                    insert into Intern_DTR_Report (UserID, Date, Time_In, Time_Out)

	                                            select
		                                            i.UserID,
		                                            i.Date,
		                                            min(i.Time),

		                                            case
			                                            when max(i.Time) = min(i.Time) then null
			                                            else max(i.Time)
		                                            end

		                                            from Intern_Logs i
                                                    where i.UserID = '00000002'

		                                            group by i.UserID, i.Date
		                                            order by i.Date";
        }

        public static string reportTestDTR2()
        {
			return @"declare @sched_AM Time(0) = (select i.Sched_AM from Intern_Status i where OJT_Number ='00000002')
					declare @sched_PM Time(0) = (select i.Sched_PM from Intern_Status i where OJT_Number ='00000002')
					declare @break_AM Time(0) = '12:00:00'
					declare @break_PM Time(0) = '13:00:00'

                    update i
	                    set i.Hours_Rendered = case
		                    --Check if DTR is complete
		                    when i.Time_Out is not null then
			                    case
				                    --During lunch Time In
				                    when i.Time_In > @break_AM and i.Time_In < @break_PM then
					                    case
						                    when i.Time_Out <= @sched_PM then
							                    datediff(second, @break_PM, i.Time_Out)

						                    when i.Time_Out > @sched_PM then
							                    datediff(second, @break_PM, @sched_PM)
						                    end

				                    --After 1pm Time In
				                    when i.Time_In >= @break_PM then
					                    case
						                    --Time Out After Sched
						                    when i.Time_Out > @sched_PM then
							                    datediff(second, i.Time_In, @sched_PM)

						                    --Time Out Before Sched
						                    when i.Time_Out <= @sched_PM then
							                    datediff(second, i.Time_In, i.Time_Out)
						                    end



				                    --Early Time In
				                    when i.Time_In < @sched_AM then
					                    case
						                    when i.Time_Out <= @break_AM then
							                    datediff(second, @sched_AM, i.Time_Out)

						                    when i.Time_Out > @break_AM and i.Time_Out < @break_PM then
							                    (datediff(second, @sched_AM, i.Time_Out)  - datediff(second, @break_AM, i.Time_Out))

						                    when i.Time_Out >= @break_PM and i.Time_Out <= @sched_PM then
							                    (datediff(second, @sched_AM, i.Time_Out) - 3600)

						                    when i.Time_Out > @sched_PM then
							                    (datediff(second, @sched_AM, @sched_PM) - 3600)
						                    end


				                    --Late Time In
				                    when i.Time_In > @sched_AM then
					                    case
						                    when i.Time_Out <= @break_AM then
							                    datediff(second, i.Time_In, i.Time_Out)

						                    when i.Time_Out > @break_AM and i.Time_Out < @break_PM then
							                    (datediff(second, i.Time_In, i.Time_Out)  - datediff(second, @break_AM, i.Time_Out))

						                    when i.Time_Out >= @break_PM and i.Time_Out <= @sched_PM then
							                    (datediff(second, i.Time_In, i.Time_Out) - 3600)

						                    when i.Time_Out > @sched_PM then
							                    (datediff(second, i.Time_In, @sched_PM) - 3600)

						                    end
				                    end
		
		                    else null
		                    end

		                    from Intern_DTR_Report i";
		}

		public static string reportTestDTR3()
        {
			return @"use IMIS

					update d
					set Lunch = 
						case 
							when l.Time != d.Time_Out then l.Time
							else null
							end
					

					from Intern_DTR_Report d
					inner join Intern_Logs l
					on d.UserID = l.UserID
					and d.Date = l.Date
					and l.Time >= '12:00:00'
					and l.Time < '13:00:00'";
        }

		public static string reportTestDTR4()
        {
			return @"use IMIS

					update d
					set Lunch = 
						case 
							when l.Time != d.Time_Out then l.Time
							else null
							end
					

					from Intern_DTR_Report d
					inner join Intern_Logs l
					on d.UserID = l.UserID
					and d.Date = l.Date
					and l.Time >= '12:00:00'
					and l.Time < '13:00:00'";
        }

		public static string reportTestDTR5()
        {
			return @"use IMIS
					declare @break_AM Time(0) = '12:00:00'
					declare @break_PM Time(0) = '13:00:00'
					declare @sched_PM Time(0) = (select i.Sched_PM from Intern_Status i where OJT_Number ='00000002')

					select
						n.Last_Name + ', ' + n.First_Name + ' ' + n.Middle_Initial as 'Name',
						n.Office_Name,
						i.UserID,
						convert(varchar, cast(i.Date as datetime), 106) as 'Date',
						i.Time_In,
						i.Lunch,
						i.Time_Out,
						(CAST(i.Hours_Rendered / 3600 AS VARCHAR(10)) + RIGHT(CONVERT(CHAR(8),DATEADD(ss,i.Hours_Rendered,0),108),6)) as 'Hours_Rendered',
						case
		
							when i.Time_Out is not null then
								case
				
									when i.Lunch is null then
										case
											when i.Time_Out < @break_PM then 'Half Day'
											when i.Time_Out >= @break_PM then 'No Lunch'
											end

									when i.Time_In >= @break_PM then 'Half Day'
					

				
									when i.Lunch is not null then
										case
											when i.Time_Out < @sched_PM then 'Undertime'
											when i.Time_Out >= @sched_PM then ''
											end

									end
		
							else 'No Timeout'
							end as 'Remark'
	

					from Intern_DTR_Report i
					inner join Intern_Info n
					on i.UserID = n.OJT_Number";
        }

		public static string reportTestDTR6()
        {
			return @"truncate table Intern_DTR_Report";
        }
    }
}
