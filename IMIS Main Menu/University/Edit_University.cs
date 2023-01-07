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
using GJP_IMIS.IMIS_Methods.Univ_Queries;

namespace GJP_IMIS.IMIS_Main_Menu.University
{
    public partial class Edit_University : Form
    {
        string univ = "";
        string univId = "";
        public Edit_University()
        {
            InitializeComponent();
        }

        public Edit_University(string uId)
        {
            InitializeComponent();

            populateField(uId);
            univId = uId;
        }

        private void populateField(string u)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("SELECT * from University where University_ID = '" + u + "'", Connection_String.con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtUniversity.Text = dr["University_Name"].ToString();
                univ = dr["University_Name"].ToString();
            }
            Connection_String.con.Close();
        }

        private void edit_univ_confirm_Click(object sender, EventArgs e)
        {
            string newUniv = txtUniversity.Text;

            DialogResult dr = MessageBox.Show("Confirm update the "+univ+" to "+newUniv+"?", "Clear Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                universityClass.updateUniversity(newUniv, univId);
                MessageBox.Show("SUCCESSFUL UPDATED UNIVERSITY NAME.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUniversity.Text = "";
        }
    }
}
