using GJP_IMIS.IMIS_Methods.Database_Connection;
using System;
using System.Data;
using System.Data.SqlClient;

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
                        Intern_Info.School_Name as 'School',
                        
                        Intern_Info.Office_Name as 'Office',
                        (CONVERT(VARCHAR(12), Intern_Status.Current_Hours /3600) + ':' + CONVERT(VARCHAR(2), Intern_Status.Current_Hours /60 % 60)) as 'Hours Rendered',
                        (Intern_Status.Target_Hours / 3600) as 'Target Hours',
                        Intern_Status.Status as 'Status'
                        FROM Intern_Info
                        INNER JOIN Intern_Status ON Intern_Info.OJT_Number = Intern_Status.OJT_Number
						ORDER BY Intern_Info.OJT_Number ASC";
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
            return dataTable(@"SELECT Intern_Info.OJT_Number as 'OJT ID',
                        (Intern_Info.First_Name + ' ' + Intern_Info.Last_Name + ' ' + Intern_Info.Suffix) as 'Name',

                        (CONVERT(VARCHAR(12), Intern_Status.Current_Hours /3600) + ':' + CONVERT(VARCHAR(2), Intern_Status.Current_Hours /60 % 60)) as 'Hours Rendered',
                        (CONVERT(VARCHAR(12), Intern_Status.Target_Hours / 3600)) as 'Target Hours',
                        Intern_Status.Status as 'Status'
                        FROM Intern_Info
                        INNER JOIN Intern_Status ON Intern_Info.OJT_Number = Intern_Status.OJT_Number
						ORDER BY Intern_Info.OJT_Number ASC");
        }

        // intern logs
        public static DataTable viewDTRLabels(string ojtID)
        {
            string q = @"SELECT
                i.OJT_Number AS 'OJT Number',
                CONCAT(i.First_Name, ' ', i.Middle_Initial, '. ', i.Last_Name) AS 'Intern',
				REPLACE(CONVERT(varchar,(s.Target_Hours / 3600)),'.','') as 'Target_Hours',
				(CONVERT(VARCHAR(12), s.Current_Hours /3600) + ':' + CONVERT(VARCHAR(2), s.Current_Hours /60 % 60)) as 'Hours_Rendered',
				s.Status,
				i.OJT_Terminal
                FROM Intern_Info i
				
				INNER JOIN Intern_Status s 
				ON s.OJT_Number = i.OJT_Number
				WHERE i.OJT_Number = @ojtNumber";

            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand(q, Connection_String.con);
            cmd.Parameters.Add("@ojtNumber", SqlDbType.NVarChar);
            cmd.Parameters["@ojtNumber"].Value = ojtID;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Connection_String.con.Dispose();
            cmd.Dispose();
            da.Dispose();

            return dt;
        }

        public static DataTable viewInternDTR(string ojtID)
        {
            string q1 = @"insert into Intern_DTR_Report (UserID, Date, Time_In, Time_Out)

	                                            select
		                                            i.UserID,
		                                            i.Date,
		                                            min(i.Time),

		                                            case
			                                            when max(i.Time) = min(i.Time) then null
			                                            else max(i.Time)
		                                            end

		                                            from Intern_Logs i
                                                    where i.UserID = @ojtID

		                                            group by i.UserID, i.Date
		                                            order by i.Date";

            string q2 = @"declare @sched_AM Time(0) = (select i.Sched_AM from Intern_Status i where OJT_Number = @ojtID_AM)
					declare @sched_PM Time(0) = (select i.Sched_PM from Intern_Status i where OJT_Number = @ojtID_PM)
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

            string q3 = @"update d
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

            string q4 = @"declare @sum int = (select sum(i.Hours_Rendered) from Intern_DTR_Report i)
					declare @break_AM Time(0) = '12:00:00'
					declare @break_PM Time(0) = '13:00:00'
					declare @sched_PM Time(0) = (select i.Sched_PM from Intern_Status i where OJT_Number = @ojtID)

					select
						
						i.UserID,
						format(convert(datetime, i.Date, 102), 'dd MMMM yyyy') as 'Date',
						CONVERT(VARCHAR(5),i.Time_In,108) as 'Time In',
						CONVERT(VARCHAR(5),i.Lunch,108) as 'Lunch',
						CONVERT(VARCHAR(5),i.Time_Out,108) as 'Time Out',
						
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
							end as 'Remark',

					convert(varchar(5), dateadd(ss, i.Hours_Rendered, 0), 114) as 'Hours_Rendered'
						
						
					from Intern_DTR_Report i
					group by i.UserID, i.Date, i.Time_In, i.Lunch, i.Time_Out, i.Hours_Rendered";

            string q5 = @"truncate table Intern_DTR_Report";

            Connection_String.dbConnection();

            SqlCommand c1 = new SqlCommand(q1, Connection_String.con);
            c1.Parameters.Add("@ojtID", SqlDbType.NVarChar);
            c1.Parameters["@ojtID"].Value = ojtID;

            SqlCommand c2 = new SqlCommand(q2, Connection_String.con);
            c2.Parameters.Add("@ojtID_AM", SqlDbType.NVarChar);
            c2.Parameters.Add("@ojtID_PM", SqlDbType.NVarChar);
            c2.Parameters["@ojtID_AM"].Value = ojtID;
            c2.Parameters["@ojtID_PM"].Value = ojtID;

            SqlCommand c3 = new SqlCommand(q3, Connection_String.con);

            SqlCommand c4 = new SqlCommand(q4, Connection_String.con);
            c4.Parameters.Add("@ojtID", SqlDbType.NVarChar);
            c4.Parameters["@ojtID"].Value = ojtID;
            SqlDataAdapter da = new SqlDataAdapter(c4);
            DataTable dt = new DataTable();



            SqlCommand c5 = new SqlCommand(q5, Connection_String.con);

            c1.ExecuteNonQuery();
            c2.ExecuteNonQuery();
            c3.ExecuteNonQuery();
            da.Fill(dt);
            c5.ExecuteNonQuery();

            c1.Dispose();
            c2.Dispose();
            c3.Dispose();
            da.Dispose();
            c4.Dispose();
            c5.Dispose();

            return dt;
        }

    }
}
