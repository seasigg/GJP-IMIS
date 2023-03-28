using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GJP_IMIS.IMIS_Methods.Database_Connection;
using GJP_IMIS.IMIS_Methods.Main_Menu_Queries;
using GJP_IMIS.IMIS_Methods.Course_Queries;
using GJP_IMIS.IMIS_Methods.Intern_Queries;


using GJP_IMIS.IMIS_Class;
using System.Data.SqlClient;
using GJP_IMIS.IMIS_Methods.Report_Queries;
using GJP_IMIS.Reports;

namespace GJP_IMIS.IMIS_Main_Menu
{
    public partial class Main_Menu_Remastered : Form
    {
        // DATA TABLES
        public static DataTable internData = menuQueries.viewInternPlain1();
        public static DataTable universityData = InternQueries.getUniversities1();
        public static DataTable officeData = InternQueries.getOffices1();
        public static DataTable courseData = InternQueries.getCourses1();

        // reports
        public static DataTable internAcceptData = menuQueries.reportAcceptanceDataGrid1();

        public Main_Menu_Remastered()
        {
            InitializeComponent();

            // view intern strip
            viewInternStrip();

            // add intern strip
            addInternStrip();

            // edit intern strip
            editInternStrip();

            // letter strip
            defaultLetter();

            // report strip
            defaultReport();
        }


        // -------------------- INTERN STRIP --------------------

        // ********** VIEW INTERN **********
        private void viewInternStrip()
        {
            viewInternPanel.BringToFront();

            dataGridInterns.DataSource = internData;
            dataGridInterns.ClearSelection();
            dataGridInterns.AutoResizeColumns();

            setInternDataGridHeaderSize();
        }

        private void setInternDataGridHeaderSize()
        {
            // column header size
            /*Classes.setDataGridHeaderWidth(0, 80, dataGridInterns); // OJT ID
            Classes.setDataGridHeaderWidth(1, 100, dataGridInterns); // LAST NAME
            Classes.setDataGridHeaderWidth(2, 100, dataGridInterns); // FIRST NAME
            Classes.setDataGridHeaderWidth(3, 150, dataGridInterns); // COURSE
            Classes.setDataGridHeaderWidth(4, 150, dataGridInterns); // UNIVERSITY
            Classes.setDataGridHeaderWidth(5, 100, dataGridInterns); // COORDINATOR
            Classes.setDataGridHeaderWidth(6, 150, dataGridInterns); // OFFICE DEPLOYED
            Classes.setDataGridHeaderWidth(7, 100, dataGridInterns); // STATUS*/

            // rows size
            /*for (int i = 0; i < dataGridInterns.Rows.Count; i++)
                Classes.setDataGridRowHeight(i, 50, dataGridInterns);*/
        }
        // ********** END OF VIEW INTERN **********

        // ********** ADD INTERN **********
        private void addInternStrip()
        {
            txtMinitial.MaxLength = 1;
            courseCombo();
        }

        // ojt number
        private void txtOjtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        // ojt first name
        private void txtFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }
        // ojt middle initial
        private void txtMinitial_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }
        private void txtMinitial_TextChanged(object sender, EventArgs e)
        {
            txtMinitial.Text = txtMinitial.Text.ToUpper();
            txtMinitial.SelectionStart = txtMinitial.Text.Length;
            txtMinitial.SelectionLength = 0;
        }
        // ojt last name
        private void txtLname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        // university
        private void txtUniversity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        // coordinator
        private void txtCoordinator_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }
        private void txtCoordPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }
        private void txtCoordDept_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        // course
        private void courseCombo()
        {
            // add intern combo course
            comboCourse.DataSource = InternQueries.getCourses();
            comboCourse.DisplayMember = "Course_Name";
            comboCourse.ValueMember = "Course_ID";
            comboCourse.DropDownStyle = ComboBoxStyle.DropDownList;

            // edit intern combo course
            comboEditcourse.DataSource = InternQueries.getCourses();
            comboEditcourse.DisplayMember = "Course_Name";
            comboEditcourse.ValueMember = "Course_ID";
            comboEditcourse.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // clear fields
        private void addInternClearFields()
        {
            comboCourse.SelectedIndex = -1;
        }


        // add intern button
        private void btnAddIntern_Click(object sender, EventArgs e)
        {
            //insertIntern();
            if (dataValidation())
            {
                insertIntern();
            }
            else
            {
                MessageBox.Show(incompleteInfo());
            }
        }

        // incomplete information
        private string incompleteInfo()
        {
            string errorHandling = "Please fill up the following first before proceeding:\n\n";

            if (!checkTextbox())
            {
                if (string.IsNullOrWhiteSpace(txtOjtNum.Text))
                    errorHandling += "* OJT Number\n";
                if (string.IsNullOrWhiteSpace(txtFname.Text))
                    errorHandling += "* First Name\n";
                if (string.IsNullOrWhiteSpace(txtMinitial.Text))
                    errorHandling += "* Middle Initial\n";
                if (string.IsNullOrWhiteSpace(txtLname.Text))
                    errorHandling += "* Last Name\n";
                if (string.IsNullOrWhiteSpace(txtUniversity.Text))
                    errorHandling += "* University\n";
                if (string.IsNullOrWhiteSpace(txtCoordinator.Text))
                    errorHandling += "* Coordinator Name\n";
                if (string.IsNullOrWhiteSpace(txtCoordDept.Text))
                    errorHandling += "* Coordinator Department\n";
                if (string.IsNullOrWhiteSpace(txtCoordPosition.Text))
                    errorHandling += "* Coordinator Position\n";
                if (string.IsNullOrWhiteSpace(txtOffice.Text))
                    errorHandling += "* Office\n";
                if (numericTargetHours.Value <= 0)
                    errorHandling += "* Number of Hours\n";
            }

            if (!checkCombo())
            {
                if (comboCourse.SelectedIndex == -1)
                    errorHandling += "* Course\n";
            }
            if (!checkGender())
            {
                if (!radioMale.Checked || !radioFemale.Checked)
                    errorHandling += "* Intern Gender\n";
            }
            if (!checkCoordGender())
            {
                if (!radioMaleCoord.Checked || !radioFemaleCoord.Checked)
                    errorHandling += "* Coordinator Gender";
            }

            return errorHandling;
            // in specific error handling
            // please fill up the following
            // - first name
            // - etc.
        }

        // insert intern to intern table
        private void insertIntern()
        {
            string ojtNumber = txtOjtNum.Text;
            string fname = txtFname.Text;
            string mini = txtMinitial.Text;
            string lname = txtLname.Text;
            string gender = getGender();
            string univ = txtUniversity.Text;
            string coord = txtCoordinator.Text;
            string coordGender = getCoordGender();
            string coordPos = txtCoordPosition.Text;
            string coordDept = txtCoordDept.Text;
            int course = Int32.Parse(comboCourse.SelectedValue.ToString());
            string office = txtOffice.Text;
            string startDate = dateTimeStartDate.Value.ToShortDateString();
            string hours = numericTargetHours.Value.ToString();

            if (!InternQueries.isInternExist(ojtNumber))
            {
                DialogResult dr = MessageBox.Show("CONFIRM ADD INTERN", "Add Intern", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    InternQueries.addInternData1(ojtNumber, fname, mini, lname, gender, course, univ, coord, coordGender, coordPos, coordDept, office);
                    InternQueries.addInternStatus1(ojtNumber, startDate, hours);

                    MessageBox.Show("Intern Successfully Registered on the Database", "Add Intern", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Dispose();
                }
            }
            else
                MessageBox.Show("INTERN ALREADY EXISTED.");
            
        }

        // intern gender
        private string getGender()
        {
            string gender = "";
            if (radioMale.Checked)
                gender = "Male";
            if (radioFemale.Checked)
                gender = "Female";
            return gender;
        }

        private string getCoordGender()
        {
            string gender = "";
            if (radioMaleCoord.Checked)
                gender = "Male";
            if (radioFemaleCoord.Checked)
                gender = "Female";
            return gender;
        }

        // DATA VALIDATION SECTION
        private Boolean dataValidation()
        {
            return (checkTextbox() && checkCombo() && checkGender() && checkCoordGender());
        }

        private Boolean checkTextbox()
        {
            return !(
                string.IsNullOrWhiteSpace(txtOjtNum.Text) ||
                string.IsNullOrWhiteSpace(txtFname.Text) ||
                string.IsNullOrWhiteSpace(txtMinitial.Text) ||
                string.IsNullOrWhiteSpace(txtLname.Text) ||
                string.IsNullOrWhiteSpace(txtOffice.Text) ||
                string.IsNullOrWhiteSpace(txtUniversity.Text) ||
                string.IsNullOrWhiteSpace(txtCoordinator.Text) ||
                string.IsNullOrWhiteSpace(txtCoordPosition.Text) ||
                string.IsNullOrWhiteSpace(txtCoordPosition.Text) ||
                numericTargetHours.Value <= 0
                );
        }

        private Boolean checkCombo()
        {
            return !(comboCourse.SelectedIndex == -1);
        }

        private Boolean checkGender()
        {
            return (radioMale.Checked || radioFemale.Checked);
        }

        private Boolean checkCoordGender()
        {
            return (radioMaleCoord.Checked || radioFemaleCoord.Checked);
        }

        // END OF DATA VALIDATION SECTION

        // ********** END OF ADD INTERN **********

        // ********** EDIT INTERN **********

        private void editInternStrip()
        {
            txtEditmini.MaxLength = 1;
        }
        private void btnSearchIntern_Click(object sender, EventArgs e)
        {
            string ojtNum = txtSearchIntern.Text;
            
            if (searchInternField())
            {
                if (InternQueries.isInternExist(ojtNum))
                {

                    editIntern(ojtNum);
                    editInternPanel.BringToFront();
                }
                else
                    MessageBox.Show("INTERN DOES NOT EXIST.");
            }
            else
                MessageBox.Show("Enter OJT Number First.");

        }

        private void editIntern(string o)
        {
            Connection_String.dbConnection();
            String query = InternQueries.editInternQuery(o);
            SqlCommand cmd = new SqlCommand(query, Connection_String.con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtEditOjtNum.Text = dr["OJT ID"].ToString();
                txtEditfname.Text = dr["First Name"].ToString();
                txtEditmini.Text = dr["Middle Initial"].ToString();
                txtEditlname.Text = dr["Last Name"].ToString();
                genderEdit(dr["Gender"].ToString());
                txtEdituniv.Text = dr["University"].ToString();
                txtEditcoord.Text = dr["Coordinator Name"].ToString();
                comboEditcourse.SelectedValue = int.Parse(dr["Course"].ToString());
                txtEditoffice.Text = dr["Office"].ToString();
                numericEdit.Value = int.Parse(dr["Target Hours"].ToString());
                statusEdit(dr["Status"].ToString());
            }
            Connection_String.con.Dispose();
        }

        // edit gender
        private void genderEdit(string g)
        {
            if (g == "Male")
                radioEditmale.Checked = true;
            if (g == "Female")
                radioEditfemale.Checked = true;
        }
        // edit status 
        private void statusEdit(string s)
        {
            if (s == "COMPLETE")
                radioEditcomplete.Checked = true;
            if (s == "INCOMPLETE")
                radioEditincomplete.Checked = true;
        }
        // edit search intern fields
        private Boolean searchInternField()
        {
            return !(string.IsNullOrWhiteSpace(txtSearchIntern.Text));
        }

        // search of intern
        private void txtSearchIntern_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        // update button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (editInternValidation())
            {
                DialogResult dr = MessageBox.Show("CONFIRM UPDATE INTERN", "Update Intern", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string ojtNumber = txtEditOjtNum.Text;
                    string fname = txtEditfname.Text;
                    string mini = txtEditmini.Text;
                    string lname = txtEditlname.Text;
                    string gender = getGenderEdit();
                    string univ = txtEdituniv.Text;
                    string coord = txtEditcoord.Text;
                    int course = Int32.Parse(comboEditcourse.SelectedValue.ToString());
                    string office = txtEditoffice.Text;
                    //string startDate = dateTimeStartDate.Value.ToShortDateString();
                    string hours = numericEdit.Value.ToString();
                    string status = getStatusEdit();

                    InternQueries.updateInternData(ojtNumber, fname, mini,
                        lname, gender, univ, coord, course, office);

                    InternQueries.updateInternStatus(ojtNumber, hours, status);

                    MessageBox.Show("INTERN UPDATED.");
                }
            }
            else
                MessageBox.Show(editIncompleteInfos());
        }
        private string getStatusEdit()
        {
            string s = "";
            if (radioEditcomplete.Checked)
                s = "COMPLETE";
            if (radioEditincomplete.Checked)
                s = "INCOMPLETE";
            return s;
        }
        private string editIncompleteInfos()
        {
            string errorHandling = "Please fill up the following first before proceeding:\n\n";

            if (!checkTextbox())
            {
                if (string.IsNullOrWhiteSpace(txtEditfname.Text))
                    errorHandling += "* First Name\n";
                if (string.IsNullOrWhiteSpace(txtEditmini.Text))
                    errorHandling += "* Middle Initial\n";
                if (string.IsNullOrWhiteSpace(txtEditlname.Text))
                    errorHandling += "* Last Name\n";
                if (string.IsNullOrWhiteSpace(txtEdituniv.Text))
                    errorHandling += "* University\n";
                if (string.IsNullOrWhiteSpace(txtEditcoord.Text))
                    errorHandling += "* Coordinator\n";
                if (string.IsNullOrWhiteSpace(txtEditoffice.Text))
                    errorHandling += "* Office\n";
                if (numericEdit.Value <= 0)
                    errorHandling += "* Number of Hours\n";
            }
            return errorHandling;
        }
        private Boolean editInternValidation()
        {
            return !(
                string.IsNullOrWhiteSpace(txtEditfname.Text) ||
                string.IsNullOrWhiteSpace(txtEditmini.Text) ||
                string.IsNullOrWhiteSpace(txtEditlname.Text) ||
                string.IsNullOrWhiteSpace(txtEditoffice.Text) ||
                string.IsNullOrWhiteSpace(txtEditcoord.Text) ||
                string.IsNullOrWhiteSpace(txtEdituniv.Text) ||
                numericTargetHours.Value <= 0
                );
        }
        private string getGenderEdit()
        {
            string g = "";
            if (radioEditmale.Checked)
                g = "Male";
            if (radioEditfemale.Checked)
                g = "Female";
            return g;
        }

        // intern edit first name
        private void txtEditfname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        // intern edit last name
        private void txtEditlname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        // intern edit middle initial
        private void txtEditmini_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }
        private void txtEditmini_TextChanged(object sender, EventArgs e)
        {
            txtEditmini.Text = txtEditmini.Text.ToUpper();
            txtEditmini.SelectionStart = txtEditmini.Text.Length;
            txtEditmini.SelectionLength = 0;
        }

        // intern edit university
        private void txtEdituniv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        // intern edit coordinator
        private void txtEditcoord_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        // ********** END OF EDIT INTERN **********

        // ********** DELETE INTERN **********

        // ********** END OF DELETE INTERN **********
        // -------------------- END OF INTERN STRIP --------------------

        // ---------------------- MENU STRIP MENU ----------------------
        private void viewInternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewInternPanel.BringToFront();
        }

        private void addInternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addInternPanel.BringToFront();
            addInternClearFields();
        }

        private void editInternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editInternPanelFind.BringToFront();
        }

        private void deleteInternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteInternPanel.BringToFront();
        }

        private void viewDtrToolStripButton1_Click(object sender, EventArgs e)
        {
            viewDtrPanel.BringToFront();
        }

        private void acceptanceLetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acceptancePanel.BringToFront();
        }

        private void letterOfCompletionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            completionPanel.BringToFront();
        }

        private void reportsToolStripButton2_Click(object sender, EventArgs e)
        {
            reportsPanel.BringToFront();
        }

        // -------------------- LETTER STRIP --------------------

        private void defaultLetter()
        {
            dataGridAccept.DataSource = internAcceptData;
            dataGridAccept.ClearSelection();
            dataGridAccept.AutoResizeColumns();
        }

        private void btnAcceptance_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rv.viewAcceptanceLetter(dataGridAccept.CurrentRow.Cells[0].Value.ToString());
            rv.ShowDialog();
        }

        // -------------------- END OF LETTER STRIP --------------------

        // -------------------- REPORT STRIP --------------------
        private void reportGender_CheckedChanged(object sender, EventArgs e)
        {
            if (reportGender.Checked)
            {
                reportMale.Enabled = true;
                reportFemale.Enabled = true;
                reportMale.Checked = true;
            } else
            {
                reportMale.Enabled = false;
                reportFemale.Enabled = false;
                reportMale.Checked = false;
                reportFemale.Checked = false;
            }
        }

        private void defaultReport()
        {
            populateComboBoxes();
            // gender radio buttons
            reportMale.Enabled = false;
            reportFemale.Enabled = false;

            // combo boxes
            reportUnivCombo.Enabled = false;
            reportOfficeCombo.Enabled = false;
            reportCourseCombo.Enabled = false;

            reportUnivCombo.SelectedIndex = -1;
            reportOfficeCombo.SelectedIndex = -1;
            reportCourseCombo.SelectedIndex = -1;

            reportUnivCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            reportOfficeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            reportCourseCombo.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void populateComboBoxes()
        {
            // UNIV
            reportUnivCombo.DataSource = universityData;
            reportUnivCombo.DisplayMember = "University_Name";
            reportUnivCombo.ValueMember = "University_Name";
            // OFFICE
            reportOfficeCombo.DataSource = officeData;
            reportOfficeCombo.DisplayMember = "Office_Name";
            reportOfficeCombo.ValueMember = "Office_Name";
            // COURSE
            reportCourseCombo.DataSource = courseData;
            reportCourseCombo.DisplayMember = "Course_Name";
            reportCourseCombo.ValueMember = "Course_ID";
        }

        private void reportUniv_CheckedChanged(object sender, EventArgs e)
        {
            if (reportUniv.Checked)
            {
                reportUnivCombo.Enabled = true;
                reportUnivCombo.SelectedIndex = 0;
            }
            else
            {
                reportUnivCombo.Enabled = false;
                reportUnivCombo.SelectedIndex = -1;
            }
        }

        private void reportOffice_CheckedChanged(object sender, EventArgs e)
        {
            if (reportOffice.Checked)
            {
                reportOfficeCombo.Enabled = true;
                reportOfficeCombo.SelectedIndex = 0;
            }
            else
            {
                reportOfficeCombo.Enabled = false;
                reportOfficeCombo.SelectedIndex = -1;
            }
        }

        private void reportCourse_CheckedChanged(object sender, EventArgs e)
        {
            if (reportCourse.Checked)
            {
                reportCourseCombo.Enabled = true;
                reportCourseCombo.SelectedIndex = 0;
            }
            else
            {
                reportCourseCombo.Enabled = false;
                reportCourseCombo.SelectedIndex = -1;
            }
        }

        private void internButtonGenerate_Click(object sender, EventArgs e)
        {
            string query = ReportQueries.reportsInternQuery1();
            string filter = "";

            if (reportCourse.Checked || reportGender.Checked || reportOffice.Checked || reportUniv.Checked)
            {
                if (reportGender.Checked)
                {
                    if (reportMale.Checked)
                        filter = "Male";
                    else if (reportFemale.Checked)
                        filter = "Female";

                    query += "AND Intern_Info1.Gender = '" + filter + "' ";
                }

                if (reportUniv.Checked)
                {
                    filter = reportUnivCombo.SelectedValue.ToString();
                    query += "AND Intern_Info1.University_Name = '" + filter + "' ";
                }

                if (reportOffice.Checked)
                {
                    filter = reportOfficeCombo.SelectedValue.ToString();
                    query += "AND Intern_Info1.Office_Name = '" + filter + "' ";
                }

                if (reportCourse.Checked)
                {
                    filter = reportCourseCombo.SelectedValue.ToString();
                    query += "AND Intern_Info1.Course_ID = '" + filter + "' ";
                }

                ReportViewer rv = new ReportViewer();
                rv.viewInternReport(query);
                rv.ShowDialog();
            }
            else
            {
                ReportViewer rv = new ReportViewer();
                rv.viewInternReport(ReportQueries.reportsInternQuery1());
                rv.ShowDialog();
            }
        }

        


        // -------------------- REPORT STRIP --------------------














        // ---------------------- END OF  MENU STRIP MENU ----------------------
    }
}
