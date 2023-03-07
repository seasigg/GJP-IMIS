using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GJP_IMIS.IMIS_Methods.Intern_Queries;
using GJP_IMIS.IMIS_Methods.Database_Connection;
using System.Data.SqlClient;

namespace GJP_IMIS.IMIS_Main_Menu.Interns
{
    public partial class Edit_Intern : Form
    {
        public Edit_Intern()
        {
            InitializeComponent();
        }

        public Edit_Intern(string ojtID)
        {
            InitializeComponent();

            ojt_id.Text = ojtID;

            comboBoxes();
            populateFields(ojtID);
        }

        private void populateFields(string ojtid)
        {
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Intern_Info where OJT_Number = " + ojtid, Connection_String.con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtFirstName.Text = dr["First_Name"].ToString();
                txtMiddleInitial.Text = dr["Middle_Initial"].ToString();
                txtLastName.Text = dr["Last_Name"].ToString();
                editGender(dr["Gender"].ToString());
                comboCourse.SelectedValue = int.Parse(dr["Course_ID"].ToString());
                comboUniversity.SelectedValue = int.Parse(dr["University_ID"].ToString());
                comboOJTCoordinator.SelectedValue = int.Parse(dr["Coordinator_ID"].ToString());
                comboOfficeDeployed.SelectedValue = int.Parse(dr["Office_ID"].ToString());
            }
            Connection_String.con.Dispose();
        }

        private void editGender(string g)
        {
            if (g == "Male")
                radioMale.Checked = true;
            if (g == "Female")
                radioFemale.Checked = true;
        }

        private void comboBoxes()
        {
            // COURSE COMBO
            comboCourse.DataSource = InternQueries.getCourses();
            comboCourse.DisplayMember = "Course_Name";
            comboCourse.ValueMember = "Course_ID";

            // UNIVERSITY COMBO
            comboUniversity.ValueMember = "University_ID";
            comboUniversity.DisplayMember = "University_Name";
            comboUniversity.DataSource = InternQueries.getUniversities();

            // OFFICE COMBO
            comboOfficeDeployed.DataSource = InternQueries.getOffices();
            comboOfficeDeployed.DisplayMember = "Office_Name";
            comboOfficeDeployed.ValueMember = "Office_ID";
        }

        private void coordinatorCombo()
        {
            int comboValue = Convert.ToInt32(comboUniversity.SelectedValue.ToString());
            DataTable dt = InternQueries.checkCoordinator(comboValue);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    comboOJTCoordinator.Enabled = true;
                    comboOJTCoordinator.DataSource = dt;
                    comboOJTCoordinator.DisplayMember = "FullName";
                    comboOJTCoordinator.ValueMember = "Coordinator_ID";

                    lblCoordinatorError.Text = null;
                }
                else
                {
                    comboOJTCoordinator.Enabled = false;
                    comboOJTCoordinator.DataSource = null;
                    comboOJTCoordinator.Items.Clear();

                    lblCoordinatorError.Text = "* No Coordinator within selected university";
                }
            }

        }

        private void comboUniversity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboUniversity.SelectedIndex != -1)
            {
                coordinatorCombo();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            comboCourse.SelectedValue = 33;
        }
    }
}
