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
using GJP_IMIS.IMIS_Methods.Database_Connection;

namespace GJP_IMIS
{
    public partial class LogSettings : Form
    {
        public LogSettings()
        {
            InitializeComponent();
        }

        private void btnDeleteLogs_Click(object sender, EventArgs e)
        {
            if (dateFrom.Value.Date > dateTo.Value.Date)
            {
                MessageBox.Show("Invalid start date", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string dateStart = dateFrom.Value.ToString("yyyy-MM-dd");
                string dateEnd = dateTo.Value.ToString("yyyy-MM-dd");

                if(MessageBox.Show("Delete logs from " + dateStart + " - " + dateEnd + "?", "Delete Logs", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query = @"delete from Intern_Logs where Date >= @start and Date <= @end";

                    Connection_String.dbConnection();
                    SqlCommand cmd = new SqlCommand(query, Connection_String.con);
                    cmd.Parameters.Add("@start", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@end", SqlDbType.NVarChar);
                    cmd.Parameters["@start"].Value = dateStart;
                    cmd.Parameters["@end"].Value = dateEnd;

                    MessageBox.Show("Rows Deleted: " + cmd.ExecuteNonQuery(), "Delete Log");
                }
            }
        }

        private void LogSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
