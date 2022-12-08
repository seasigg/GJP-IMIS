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

using GJP_IMIS.IMIS_Methods.Intern_Queries;
using GJP_IMIS.IMIS_Main_Menu;
using GJP_IMIS.IMIS_Class;
using GJP_IMIS.IMIS_Main_Menu.Addresse;
using GJP_IMIS.IMIS_Main_Menu.Course;
using GJP_IMIS.IMIS_Main_Menu.Office;
using GJP_IMIS.IMIS_Main_Menu.University;

namespace GJP_IMIS.IMIS_Main_Menu.Interns
{
    public partial class Add_Intern : Form
    {
        public Add_Intern()
        {
            InitializeComponent();
        }

        public Main_Menu mainMenu;

        public Add_Intern(Main_Menu m)
        {
            InitializeComponent();
            
            mainMenu = m;
        }

        private void Add_Intern_Load(object sender, EventArgs e)
        {
            fillUniversityCombo();
            fillCourseCombo();
            fillOfficeCombo();
            clearEntry();


            txtMiddleInitial.MaxLength = 1;
        }

        string pictureFile = "none";


        private void btnAddIntern_Click(object sender, EventArgs e)
        {
            if (dataValidation())
            {
                if (pictureFile == "none")
                {
                    DialogResult dr = MessageBox.Show("No picture selected.\nProceed without picture?", "Clear Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                        addIntern();
                }
                else
                    addIntern();
            }
            else
                MessageBox.Show("Please fill up all necessary fields before proceding.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
                
        }

        private void addIntern()
        {
            string ojtID = txtOJTNumber.Text;
            string firstName = txtFirstName.Text;
            string middleInit = txtMiddleInitial.Text;
            string lastName = txtLastName.Text;
            string gender = getGender();
            string univID = comboUniversity.SelectedValue.ToString();
            string courseID = comboCourse.SelectedValue.ToString();
            string coordID = comboOJTCoordinator.SelectedValue.ToString();
            string officeID = comboOfficeDeployed.SelectedValue.ToString();
            string targetHours = numericTargetHours.Value.ToString();
            string startDate = dateTimeStartDate.Value.ToShortDateString();
            string targetDate = dateTimeTargetDate.Value.ToShortDateString();

            
            Add_Intern_Details aid = new Add_Intern_Details(ojtID, firstName, middleInit, lastName,
                gender, univID, courseID, coordID, officeID, targetHours, startDate, targetDate,
                getUnivName(), getCourseName(), getCoordName(), getOfficeName(),
                pictureFile);
            aid.ShowDialog();
            
            
            /*
            string dg = "OJT Number: " + ojtID
                + "\nFirst Name: " + firstName
                + "\nMiddle Initial: " + middleInit
                + "\nLast Name: " + lastName
                + "\nGender: " + gender
                + "\nCourse: " + getCourseName()
                + "\nUniversity: " + getUnivName()
                + "\nCoordinator: " + getCoordName()
                + "\nOffice Deployed: " + getOfficeName();

            DialogResult dr = MessageBox.Show("Add the following details to the database?\n" + dg, "Add Intern", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                InternQueries.addInternData(ojtID, firstName, middleInit, lastName, gender, courseID, univID, coordID, officeID, pictureFile);
                InternQueries.addInternStatus(ojtID, startDate, targetDate, targetHours);

                MessageBox.Show("Intern Successfully Registered on the Databse", "Add Intern", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearEntry();
            }
            */
        }

        public string getCourseName()
        {
            return this.comboCourse.GetItemText(this.comboCourse.SelectedItem);
        }
        public string getUnivName()
        {
            return this.comboUniversity.GetItemText(this.comboUniversity.SelectedItem);
        }
        public string getCoordName()
        {
            return this.comboOJTCoordinator.GetItemText(this.comboOJTCoordinator.SelectedItem);
        }
        public string getOfficeName()
        {
            return this.comboOfficeDeployed.GetItemText(this.comboOfficeDeployed.SelectedItem);
        }
        private string getGender()
        {
            string gender = null;
            if (radioMale.Checked)
                gender = radioMale.Text;
            if (radioFemale.Checked)
                gender = radioFemale.Text;

            return gender;
        }

        private Boolean dataValidation()
        {
            return (checkTextbox() && checkCombo() && checkGender());
        }

        private Boolean checkTextbox()
        {
            return !(string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtMiddleInitial.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                numericTargetHours.Value <= 0) ;
        }

        private Boolean checkCombo()
        {
            return !(comboUniversity.SelectedIndex == -1 ||
                comboCourse.SelectedIndex == -1 ||
                comboOJTCoordinator.SelectedIndex == -1 ||
                comboOfficeDeployed.SelectedIndex == -1);
        }

        private Boolean checkGender()
        {
            return (radioMale.Checked || radioFemale.Checked);
        }


        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("This will clear all data that has been entered. Proceed?", "Clear Entry", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                clearEntry();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Cancelling will take you back to the Main Menu. \nProceed?", "Cancel", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                mainMenu.internRefreshTable();
                this.Dispose();
            }
                
        }

        public void clearEntry()
        {
            clearUniversityCombo();
            clearCourseCombo();
            clearOfficeCombo();
            fillCoordinatorCombo();
            

            Classes.clearTextBox(this.Controls);

            if (InternQueries.checkYearData())
                txtOJTNumber.Text = InternQueries.addOJTNumberIncrement();
            else
                txtOJTNumber.Text = DateTime.Now.Year.ToString() + "001";
        }

        public void clearCourseCombo()
        {
            comboCourse.SelectedIndex = 0;
        }

        public void clearOfficeCombo()
        {
            comboOfficeDeployed.SelectedIndex = 0;
        }

        public void clearUniversityCombo()
        {
            comboUniversity.SelectedIndex = 0;
        }

        public void fillUniversityCombo()
        {
            comboUniversity.ValueMember = "University_ID";
            comboUniversity.DisplayMember = "University_Name";
            comboUniversity.DataSource = InternQueries.getUniversities();
            comboUniversity.SelectedIndex = 0;
        }
        
        public void fillCourseCombo()
        {
            comboCourse.DataSource = InternQueries.getCourses();
            comboCourse.DisplayMember = "Course_Name";
            comboCourse.ValueMember = "Course_ID";
            comboCourse.SelectedIndex = 0;
        }

        public void fillCoordinatorCombo()
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

        public void fillOfficeCombo()
        {
            comboOfficeDeployed.DataSource = InternQueries.getOffices();
            comboOfficeDeployed.DisplayMember = "Office_Name";
            comboOfficeDeployed.ValueMember = "Office_ID";
            comboOfficeDeployed.SelectedIndex = 0;
        }



 


        /* TextBox Alphabets Only Input */
        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        private void txtMiddleInitial_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        /* ComboBoxes */
        private void comboUniversity_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comboUniversity.DroppedDown = false;
        }

        private void comboCourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comboCourse.DroppedDown = false;
        }

        private void btnAddCoordinator_Click(object sender, EventArgs e)
        {
            if(comboUniversity.SelectedIndex != -1)
            {
                Add_Coordinator ac = new Add_Coordinator(this, comboUniversity.SelectedValue.ToString());
                ac.ShowDialog();
            }
            else
            {
                Add_Coordinator ac = new Add_Coordinator();
                ac.ShowDialog();
            }
        }

        private void comboUniversity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboUniversity.SelectedIndex != -1)
            {
                
            }
        }

        private void comboUniversity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboUniversity.SelectedIndex != -1)
            {
                fillCoordinatorCombo();
            }
        }

        private void btnUploadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg, *.jpeg; *.png; *.bmp; *.gif)|*.jpg; *.jpeg; *.png; *.bmp; *.gif";
            if(open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                pictureFile = open.FileName;
            }
        }

        

        private void btnClearPicture_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureFile = "none";
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            addCourse ac = new addCourse(this);
            ac.ShowDialog();
        }

        private void btnAddUniversity_Click(object sender, EventArgs e)
        {
            Add_University au = new Add_University(this);
            au.ShowDialog();
        }

        private void btnAddOffice_Click(object sender, EventArgs e)
        {
            addOffice ao = new addOffice(this);
            ao.ShowDialog();
        }

        // to upper case initials
        private void midInitialToUpperCase(object sender, EventArgs e)
        {
            txtMiddleInitial.Text = txtMiddleInitial.Text.ToUpper();
            txtMiddleInitial.SelectionStart = txtMiddleInitial.Text.Length;
            txtMiddleInitial.SelectionLength = 0;
        }

        private void Add_Intern_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainMenu.internRefreshTable();
            this.Dispose();
        }

        
    }
}
