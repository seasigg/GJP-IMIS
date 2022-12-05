using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using GJP_IMIS.IMIS_Methods.Report_Queries;
using GJP_IMIS.IMIS_Methods.Database_Connection;

namespace GJP_IMIS.Reports
{
    public partial class ReportViewer : Form
    {
        public ReportViewer()
        {
            InitializeComponent();
        }

        public ReportViewer(string r)
        {
            InitializeComponent();

            switch(r)
            {
                case "Acceptance_Letter":
                    viewAcceptanceLetter();
                    break;
                case "Intern":
                    viewIntern();
                    break;
                default:
                    break;
            }
        }

        private void viewAcceptanceLetter()
        {
            ReportDataSet ds = new ReportDataSet();
            ReportAcceptanceLetter rt = new ReportAcceptanceLetter();

            Connection_String.dbConnection();
            SqlDataAdapter da = new SqlDataAdapter(ReportQueries.acceptLetter("2022002"), Connection_String.con);
            da.Fill(ds, "AcceptanceTable");
            Connection_String.con.Close();


            rt.SetDataSource(ds.Tables["AcceptanceTable"]);
            crystalReportViewer1.ReportSource = rt;
            crystalReportViewer1.Refresh();
        }

        private void viewIntern()
        {
            ReportDataSet ds = new ReportDataSet();
            ReportInterns ri = new ReportInterns();

            Connection_String.dbConnection();
            SqlDataAdapter da = new SqlDataAdapter(ReportQueries.Intern(), Connection_String.con);
            da.Fill(ds, "Interns");
            Connection_String.con.Close();


            ri.SetDataSource(ds.Tables["Interns"]);
            crystalReportViewer1.ReportSource = ri;
            crystalReportViewer1.Refresh();
        }

        public void viewInternGender()
        {
            ReportDataSet ds = new ReportDataSet();
            ReportInterns ri = new ReportInterns();

            string query = "SELECT DISTINCT " +
                "" +
                "Intern_Info.Last_Name + ', ' + Intern_Info.First_Name + ' ' + Intern_Info.Middle_Initial + '.' AS 'Intern Name', " +
                "Intern_Info.Gender AS 'Gender', " +
                "Course.Course_Name AS 'Course', " +
                "University.University_Name AS 'University', " +
                "Office.Office_Name AS 'Office Deployed' " +
                "" +
                "FROM Intern_Info, Course, University, Office " +
                "WHERE " +
                "Intern_Info.Gender = 'Female'" +
                "AND Intern_Info.Course_ID = Course.Course_ID " +
                "AND Intern_Info.University_ID = University.University_ID " +
                "AND Intern_Info.Office_ID = Office.Office_ID";

            string query2 = "SELECT DISTINCT " +
                "" +
                "Intern_Info.Last_Name + ', ' + Intern_Info.First_Name + ' ' + Intern_Info.Middle_Initial + '.' AS 'Intern Name', " +
                "Intern_Info.Gender AS 'Gender', " +
                "Course.Course_Name AS 'Course', " +
                "University.University_Name AS 'University', " +
                "Office.Office_Name AS 'Office Deployed' " +
                "" +
                "FROM Intern_Info, Course, University, Office " +
                "WHERE " +
                "Intern_Info.Office_ID = 8" +
                "AND Intern_Info.Course_ID = Course.Course_ID " +
                "AND Intern_Info.University_ID = University.University_ID " +
                "AND Intern_Info.Office_ID = Office.Office_ID";
            /*
            Connection_String.dbConnection();
            SqlDataAdapter da = new SqlDataAdapter(query2, Connection_String.con);
            da.Fill(ds, "Interns");
            Connection_String.con.Close();


            ri.SetDataSource(ds.Tables["Interns"]);
            crystalReportViewer1.ReportSource = ri;
            crystalReportViewer1.Refresh();
            */
        }

        public void viewInternReport(string q)
        {
            ReportDataSet ds = new ReportDataSet();
            ReportInterns ri = new ReportInterns();
            

            Connection_String.dbConnection();
            SqlDataAdapter da = new SqlDataAdapter(q, Connection_String.con);
            da.Fill(ds, "Interns");
            Connection_String.con.Close();

            ri.SetDataSource(ds.Tables["Interns"]);
            crystalReportViewer1.ReportSource = ri;
            crystalReportViewer1.Refresh();
        }
    }
}
