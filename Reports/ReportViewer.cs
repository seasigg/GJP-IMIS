﻿using System;
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

    }
}
