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
using GJP_IMIS.IMIS_Methods.Office_Queries;

namespace GJP_IMIS.IMIS_Main_Menu.Office
{
    public partial class editOffice : Form
    {
        string officeId = "";

        public editOffice()
        {
            InitializeComponent();
        }
        
        public editOffice(string oId)
        {
            InitializeComponent();

            officeId = oId;
            populateOffice(oId);
        }

        private void populateOffice(string o)
        {
            lblOfficeId.Text = o;

            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("SELECT * from Office where Office_ID = '" + o + "'", Connection_String.con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtOfficeName.Text = dr["Office_Name"].ToString();
                txtOfficeAbbr.Text = dr["Office_Abr"].ToString();
            }
            Connection_String.con.Close();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string newOfficeName = txtOfficeName.Text;
            string newOfficeAbbr = txtOfficeAbbr.Text;

            DialogResult dr = MessageBox.Show("Confirm update??", "Clear Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                OfficeQueries.updateOffice(officeId, newOfficeName, newOfficeAbbr);
                MessageBox.Show("SUCCESSFUL UPDATED OFFICE.");
            }
        }
    }
}
