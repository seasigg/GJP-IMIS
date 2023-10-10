using GJP_IMIS.IMIS_Methods.Database_Connection;
using GJP_IMIS.IMIS_Methods.Report_Queries;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GJP_IMIS.Reports
{
    public partial class ReportViewer : Form
    {
        public ReportViewer()
        {
            InitializeComponent();
        }

        public void viewAcceptanceLetter(string ojtID, string dir, string dirPos)
        {
            ReportDataSet ds = new ReportDataSet();
            ReportAcceptanceLetter rt = new ReportAcceptanceLetter();

            Connection_String.dbConnection();

            SqlCommand cmd = new SqlCommand(ReportQueries.acceptanceLetter(), Connection_String.con);
            cmd.Parameters.Add("@ojtID", SqlDbType.Int);
            cmd.Parameters.Add("@director", SqlDbType.NVarChar);
            cmd.Parameters.Add("@dirPosition", SqlDbType.NVarChar);
            cmd.Parameters["@ojtID"].Value = ojtID;
            cmd.Parameters["@director"].Value = dir;
            cmd.Parameters["@dirPosition"].Value = dirPos;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds, "AcceptanceTable");
            Connection_String.con.Dispose();


            rt.SetDataSource(ds.Tables["AcceptanceTable"]);
            crystalReportViewer1.ReportSource = rt;
            crystalReportViewer1.Refresh();
            ds.Dispose();

        }

        public void viewCertificateOfCompletion(string ojtID, string dir, string dirPos, string dirOff)
        {
            ReportDataSet ds = new ReportDataSet();
            ReportCertificateOfCompletion coc = new ReportCertificateOfCompletion();

            Connection_String.dbConnection();

            SqlCommand cmd = new SqlCommand(ReportQueries.certOfCompletion(), Connection_String.con);
            cmd.Parameters.Add("@ojtID", SqlDbType.Int);
            cmd.Parameters.Add("@director", SqlDbType.NVarChar);
            cmd.Parameters.Add("@dirPosition", SqlDbType.NVarChar);
            cmd.Parameters.Add("@dirOffice", SqlDbType.NVarChar);
            cmd.Parameters["@ojtID"].Value = ojtID;
            cmd.Parameters["@director"].Value = dir;
            cmd.Parameters["@dirPosition"].Value = dirPos;
            cmd.Parameters["@dirOffice"].Value = dirOff;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds, "CertOfCompletion");
            Connection_String.con.Dispose();

            coc.SetDataSource(ds.Tables["CertOfCompletion"]);
            crystalReportViewer1.ReportSource = coc;
            crystalReportViewer1.Refresh();
            ds.Dispose();
        }

        public void viewInternReport(string q)
        {
            ReportDataSet ds = new ReportDataSet();
            ReportInterns ri = new ReportInterns();

            Connection_String.dbConnection();
            SqlDataAdapter da = new SqlDataAdapter(q, Connection_String.con);
            da.Fill(ds, "Interns");
            Connection_String.con.Dispose();

            ri.SetDataSource(ds.Tables["Interns"]);
            crystalReportViewer1.ReportSource = ri;
            crystalReportViewer1.Refresh();
            ds.Dispose();
        }

        public void viewInternDTR(string ojtID)
        {
            ReportInternDTR dtr = new ReportInternDTR();
            ReportDataSet ds = ReportQueries.reportViewDTR(ojtID);

            DataTable dt = new DataTable();
            dt.Columns.Add("dtr_Signee1_Name", typeof(string));
            dt.Columns.Add("dtr_Signee1_Position", typeof(string));
            dt.Columns.Add("dtr_Signee2_Name", typeof(string));
            dt.Columns.Add("dtr_Signee2_Position", typeof(string));
            DataRow dr = dt.NewRow();
            dr["dtr_Signee1_Name"] = Settings1.Default.dtr_Signee1_Name;
            dr["dtr_Signee1_Position"] = Settings1.Default.dtr_Signee1_Position;
            dr["dtr_Signee2_Name"] = Settings1.Default.dtr_Signee2_Name;
            dr["dtr_Signee2_Position"] = Settings1.Default.dtr_Signee2_Position;
            dt.Rows.Add(dr);

            dt.TableName = "Intern_Signee";
            dtr.Database.Tables[0].SetDataSource(ds.Tables["InternDTR"]);
            dtr.Database.Tables[1].SetDataSource(dt);
            //dtr.SetDataSource(dt);
            //dtr.SetDataSource(ds.Tables["InternDTR"]);
            crystalReportViewer1.ReportSource = dtr;
            crystalReportViewer1.Refresh();
            ds.Dispose();
        }

        public void viewDTR(string ojtID)
        {
            Connection_String.dbConnection();

        }

        private void ReportViewer_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Dispose();
        }
    }
}
