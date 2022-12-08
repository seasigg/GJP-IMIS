using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

using GJP_IMIS.IMIS_Class;
using GJP_IMIS.IMIS_Methods.Course_Queries;
using GJP_IMIS.IMIS_Main_Menu.Interns;

namespace GJP_IMIS.IMIS_Main_Menu.Course
{
    public partial class addCourse : Form
    {
        public Add_Intern ai;
        public Main_Menu mm;

        bool fromAddIntern = false;
        bool fromMainMenu = false;
        public addCourse()
        {
            InitializeComponent();
        }
        public addCourse(Main_Menu m)
        {
            InitializeComponent();
            fromMainMenu = true;
            fromAddIntern = false;
            mm = m;
        }

        public addCourse(Add_Intern a)
        {
            InitializeComponent();
            fromMainMenu = false;
            fromAddIntern = true;
            ai = a;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(Classes.checkData(this.Controls))
            {
                string course = txtCourse.Text;

                DialogResult dr = MessageBox.Show("Add " + course + "\nto the Course database?", "Add Course", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    courseQueries.insertCourse(course);
                    MessageBox.Show("Course " + course + "\nhas been successfully added.", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCourse.Clear();
                }
            }
            else
            {
                Classes.alert("Invalid Input");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCourse.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(fromMainMenu == true)
            {

            }
 
            if(fromAddIntern == true)
            {
                ai.fillCourseCombo();
            }
                
            this.Dispose();
        }

        private void txtCourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        private void addCourse_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
