using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


	}
}
