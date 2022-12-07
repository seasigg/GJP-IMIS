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

namespace GJP_IMIS.Reports
{
    public partial class Report_Filter : Form
    {
        public Report_Filter()
        {
            InitializeComponent();
        }

        private void Report_Filter_Load(object sender, EventArgs e)
        {
            // gender
            radioMale.Enabled = false;
            radioFemale.Enabled = false;

            // university
            comboUniversity.Enabled = false;
            populateUniversity();

            // office
            comboOffice.Enabled = false;
            populateOffice();

            // course
            comboCourse.Enabled = false;
            populateCourse();
        }

        // VARIABLES
        string query = "";
        string filter = "";
        string queryFinal = "";

        string query1 = "SELECT DISTINCT " +
                "" +
                "Intern_Info.Last_Name + ', ' + Intern_Info.First_Name + ' ' + Intern_Info.Middle_Initial + '.' AS 'Intern Name', " +
                "Intern_Info.Gender AS 'Gender', " +
                "Course.Course_Name AS 'Course', " +
                "University.University_Name AS 'University', " +
                "Office.Office_Name AS 'Office Deployed' " +
                "" +
                "FROM Intern_Info, Course, University, Office " +
                "WHERE " +
                "Intern_Info.Course_ID = Course.Course_ID " +
                "AND Intern_Info.University_ID = University.University_ID " +
                "AND Intern_Info.Office_ID = Office.Office_ID ";

        // ------------------------------ CHECK BOX ------------------------------
        // GENDER CHECK BOX
        private void checkBoxGender_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGender.Checked) {
                radioMale.Enabled = true;
                radioFemale.Enabled = true;
                radioMale.Checked = true;
            } else
            {
                radioMale.Enabled = false;
                radioMale.Checked = false;
                radioFemale.Enabled = false;
                radioFemale.Checked = false;
            }
        }
        // UNIVERSITY CHECK BOX
        private void checkBoxUniv_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUniv.Checked)
            {
                comboUniversity.Enabled = true;
                comboUniversity.SelectedIndex = 0;
            }
            else
            {
                comboUniversity.Enabled = false;
                comboUniversity.SelectedIndex = -1;
            }
        }
        // OFFICE CHECK BOX
        private void checkBoxOffice_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOffice.Checked)
            {
                comboOffice.Enabled = true;
                comboOffice.SelectedIndex = 0;
            }
            else
            {
                comboOffice.Enabled = false;
                comboOffice.SelectedIndex = -1;
            }
        }

        // COURSE CHECK BOX
        private void checkBoxCourse_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCourse.Checked)
            {
                comboCourse.Enabled = true;
                comboCourse.SelectedIndex = 0;
            }
            else
            {
                comboCourse.Enabled = false;
                comboCourse.SelectedIndex = -1;
            }
        }
        // ------------------------------ END CHECK BOX ------------------------------

        // ------------------------------ COMBO BOX ------------------------------
        // UNIVERSITY COMBO BOX
        private void populateUniversity()
        {
            comboUniversity.DataSource = InternQueries.getUniversities();
            comboUniversity.DisplayMember = "University_Name";
            comboUniversity.ValueMember = "University_ID";
            comboUniversity.SelectedIndex = -1;
        }

        // OFFICE COMBO BOX
        private void populateOffice()
        {
            comboOffice.DataSource = InternQueries.getOffices();
            comboOffice.DisplayMember = "Office_Name";
            comboOffice.ValueMember = "Office_ID";
            comboOffice.SelectedIndex = -1;
        }

        // COURSE COMBO BOX
        private void populateCourse()
        {
            comboCourse.DataSource = InternQueries.getCourses();
            comboCourse.DisplayMember = "Course_Name";
            comboCourse.ValueMember = "Course_ID";
            comboCourse.SelectedIndex = -1;
        }
        // ------------------------------ END OF COMBO BOX ------------------------------

        // SUBMIT BUTTON
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            query = "";
            filter = "";

            if (checkBoxGender.Checked || checkBoxUniv.Checked || checkBoxOffice.Checked || checkBoxCourse.Checked)
            {
                if (checkBoxGender.Checked) {
                    if (radioMale.Checked)
                        filter = "Male";
                    else if (radioFemale.Checked)
                        filter = "Female";

                    query += "AND Intern_Info.Gender = '" + filter + "' ";
                }

                if (checkBoxUniv.Checked)
                {
                    filter = comboUniversity.SelectedValue.ToString();
                    query += "AND Intern_Info.University_ID = " + filter + " ";
                }

                if (checkBoxOffice.Checked)
                {
                    filter = comboOffice.SelectedValue.ToString();
                    query += "AND Intern_Info.Office_ID = " + filter + " ";
                }

                if (checkBoxCourse.Checked)
                {
                    filter = comboCourse.SelectedValue.ToString();
                    query += "AND Intern_Info.Course_ID = " + filter + " ";
                }

                queryFinal = query1 + query;
                
                ReportViewer rv = new ReportViewer();
                rv.viewInternReport(queryFinal);
                rv.ShowDialog();
            } else
            {
                ReportViewer rv = new ReportViewer();
                rv.viewInternReport(query1);
                rv.ShowDialog();
            }
        }

        private void Report_Filter_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
