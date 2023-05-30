using GJP_IMIS.IMIS_Methods.Database_Connection;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GJP_IMIS.IMIS_Methods.AutoComplete
{
    class acQueries
    {

        public static AutoCompleteStringCollection getACSource(DataTable table)
        {
            AutoCompleteStringCollection autoSourceCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in table.Rows)
            {
                autoSourceCollection.Add(row[0].ToString());
            }

            return autoSourceCollection;
        }

        public static DataTable getACDataTable(string q)
        {
            Connection_String.dbConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(q, Connection_String.con);
            da.Fill(dt);

            da.Dispose();
            Connection_String.con.Dispose();

            return dt;
        }

        public static AutoCompleteStringCollection getAC_CoordinatorName()
        {
            string query = @"select distinct i.Coordinator_Name from Intern_Info i";
            return getACSource(getACDataTable(query));
        }

        public static AutoCompleteStringCollection getAC_University()
        {
            string query = @"select distinct i.School_Name from Intern_Info i";
            return getACSource(getACDataTable(query));
        }

        public static AutoCompleteStringCollection getAC_Office()
        {
            string query = @"select distinct i.Office_Name from Intern_Info i";
            return getACSource(getACDataTable(query));
        }

        public static AutoCompleteStringCollection getAC_Course()
        {
            string query = @"select distinct i.Course from Intern_Info i";
            return getACSource(getACDataTable(query));
        }

        public static AutoCompleteStringCollection getAC_CoordinatorPosition()
        {
            string query = @"select distinct i.Coordinator_Position from Intern_Info i";
            return getACSource(getACDataTable(query));
        }


    }
}
