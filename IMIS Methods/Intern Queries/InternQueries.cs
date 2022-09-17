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

        /// Part Two University Data Grid Cell Click
        public static DataTable selectUniversityCellClick(string uni)
        {
            Connection_String.dbConnection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Addresse_Info WHERE University = '" + uni + "'", Connection_String.con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }


        /////Adding of Interns/////
        ///Part One
        

        

    }
}
