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
using GJP_IMIS.IMIS_Methods.Course_Queries;

namespace GJP_IMIS.IMIS_Main_Menu.Course
{
    public partial class editCourse : Form
    {
        string courseId = "";
        public editCourse()
        {
            InitializeComponent();
        }

        public editCourse (string c)
        {
            InitializeComponent();
            courseId = c;
            populateCourse(c);
        }

        private void populateCourse(string cId)
        {
            lblCourseID.Text = cId;
            Connection_String.dbConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Course where Course_ID = '" + cId + "'", Connection_String.con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtCourse.Text = dr["Course_Name"].ToString();
            }
            Connection_String.con.Close();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string newCourse = txtCourse.Text;
            DialogResult dr = MessageBox.Show("Confirm update the course?", "Clear Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                courseQueries.updateCourse(courseId, newCourse);
                MessageBox.Show("SUCCESSFULLY UPDATED COURSE.");
            }

        }
    }
}
