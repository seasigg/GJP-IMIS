using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using GJP_IMIS.IMIS_Methods.Coordinator_Queries;
using GJP_IMIS.IMIS_Methods.Course_Queries;
using GJP_IMIS.IMIS_Methods.Database_Connection;
using GJP_IMIS.IMIS_Methods.Intern_Queries;
using GJP_IMIS.IMIS_Methods.Main_Menu_Queries;
using GJP_IMIS.IMIS_Methods.Office_Queries;
using GJP_IMIS.IMIS_Methods.Report_Queries;
using GJP_IMIS.IMIS_Methods.Univ_Queries;

namespace GJP_IMIS.IMIS_Class
{
    class DataTables
    {
        public DataTable universityDataTable = InternQueries.getUniversities();
        public DataTable internDataTable = menuQueries.viewInternPlain();
        public DataTable coordinatorDataTable = menuQueries.coordinatorDataGridUnfiltered();
        public DataTable officeDataTable = InternQueries.getOffices();
        public DataTable courseDataTable = InternQueries.getCourses();
    }
}
