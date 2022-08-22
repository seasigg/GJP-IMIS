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

        /////Intern Panel Default/////
        public static DataTable viewInternPlain()
        {
            String query = "select First_Name as 'First Name', Last_Name as 'Last Name', Course, Addresse_Info.Salutation as 'Addresse', University.University_Name as 'University', Office.Office_Name as 'Office Deployed' " +
                "from(((Intern_Info " +
                "inner join Addresse_Info on Intern_Info.Addresse_ID = Addresse_Info.Addresse_ID)" +
                "inner join University on Intern_Info.School_ID = University.University_ID)" +
                "inner join Office on Intern_Info.Office_ID = Office.Office_ID)";
            
            Connection_String.dbConnection();
            SqlDataAdapter da = new SqlDataAdapter(query, Connection_String.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Connection_String.con.Close();

            return dt;
        }

        ////////// Add Intern Form //////////
        
        /// Part Two University Data Grid
        public static DataTable addInternUniversityData()
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("SELECT * from University", Connection_String.con);
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Connection_String.con.Close();

            return dt;
        }

        /// Part Two Addresse Data Grid
        public static DataTable addInternAddresseData()
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("SELECT * from Addresse_Info", Connection_String.con);
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Connection_String.con.Close();

            return dt;
        }

        /// 

        /////Adding of Interns/////
        ///Part One
        

        

    }
}
