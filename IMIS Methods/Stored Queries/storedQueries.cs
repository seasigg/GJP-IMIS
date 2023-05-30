namespace GJP_IMIS.IMIS_Methods.Stored_Queries
{
    class storedQueries
    {
        public static string truncatePlaceholder = @"truncate table Log_Placeholder";

        public static string mergeLogs = @"insert into Intern_Logs select Date, Time, UserID, Name, Result from Log_Placeholder where Log_PlaceHolder.Result = 'Success' and not exists(select * from Intern_Logs where (Log_Placeholder.Date = Intern_Logs.Date  and Log_Placeholder.Time = Intern_Logs.Time and Log_Placeholder.UserID = Intern_Logs.UserID))";

        public static string insertDTR_fromLogs = @"insert into Intern_DTR (UserID, Date, Time_In, Time_Out)

		select 
		i.UserID, 
		i.Date,  
		min(convert(time(0), i.Time)) as 'Time_In',
	
		case
		when max(convert(time(0), i.Time)) = min(convert(time(0), i.Time)) then null
		else max(convert(time(0), i.Time))
		end as 'Time_Out'

		from Intern_Logs i

		where not exists (select * from Intern_Logs i, Intern_DTR d where (i.UserID = d.UserID and i.Date = d.Date))

		group by i.UserID, i.Date 
		order by i.Date asc";

        public static string reportInternDTR = @"use IMIS


declare @sched_AM Time(0) = '8:30:00'
declare @sched_PM Time(0) = '17:30:00'
declare @break_AM Time(0) = '12:00:00'
declare @break_PM Time(0) = '13:00:00'

select 
	i.UserID,
	i.Date,
	i.Time_In,
	i.Lunch,
	i.Time_Out,

	case
		--Check if DTR is complete
		when i.Time_Out is not null then
			case
				--During lunch Time In
				when i.Time_In > @break_AM and i.Time_In < @break_PM then
					case
						when i.Time_Out <= @sched_PM then
							convert(time(0), dateadd(second, datediff(second, @break_PM, i.Time_Out), 0), 108)

						when i.Time_Out > @sched_PM then
						convert(time(0), dateadd(second, datediff(second, @break_PM, @sched_PM), 0), 108)
							
						end

				--After 1pm Time In
				when i.Time_In >= @break_PM then
					case
						--Time Out After Sched
						when i.Time_Out > @sched_PM then
							convert(time(0), dateadd(second, datediff(second, i.Time_In, @sched_PM), 0), 108)
							
						--Time Out Before Sched
						when i.Time_Out <= @sched_PM then
							convert(time(0), dateadd(second, datediff(second, i.Time_In, i.Time_Out), 0), 108)
							
						end

				--Early Time In
				when i.Time_In < @sched_AM then
					case
						when i.Time_Out <= @break_AM then
							convert(time(0), dateadd(second, datediff(second, @sched_AM, i.Time_Out), 0), 108)
							

						when i.Time_Out > @break_AM and i.Time_Out < @break_PM then
							convert(time(0), dateadd(second, (datediff(second, @sched_AM, i.Time_Out)  - datediff(second, @break_AM, i.Time_Out)), 0), 108)
							

						when i.Time_Out >= @break_PM and i.Time_Out <= @sched_PM then
							convert(time(0), dateadd(second, (datediff(second, @sched_AM, i.Time_Out) - 3600), 0), 108)
							

						when i.Time_Out > @sched_PM then
							convert(time(0), dateadd(second, (datediff(second, @sched_AM, @sched_PM) - 3600), 0), 108)
							
						end


				--Late Time In
				when i.Time_In > @sched_AM then
					case
						when i.Time_Out <= @break_AM then
							convert(time(0), dateadd(second, datediff(second, i.Time_In, i.Time_Out), 0), 108)
							

						when i.Time_Out > @break_AM and i.Time_Out < @break_PM then
							convert(time(0), dateadd(second, (datediff(second, i.Time_In, i.Time_Out)  - datediff(second, @break_AM, i.Time_Out)), 0), 108)
							

						when i.Time_Out >= @break_PM and i.Time_Out <= @sched_PM then
							convert(time(0), dateadd(second, (datediff(second, i.Time_In, i.Time_Out) - 3600), 0), 108)
							

						when i.Time_Out > @sched_PM then
							convert(time(0), dateadd(second, (datediff(second, i.Time_In, @sched_PM) - 3600), 0), 108)
							
						end
				end
		
		else null
		end as Time_Rendered,

		case
		--Check if DTR is complete
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
						when i.Time_Out >= @sched_PM then 'Complete'
						end

				end
		
		else 'No Timeout'
		end as 'Remark'



from Intern_Logs l, Intern_DTR i
where i.UserID = 17

group by i.UserID, i.Date, i.Time_In, i.Lunch, i.Time_Out";
    }
}
