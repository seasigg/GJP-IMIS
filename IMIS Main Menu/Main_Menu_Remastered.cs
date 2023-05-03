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
using GJP_IMIS.IMIS_Methods.Intern_Queries;
using GJP_IMIS.IMIS_Methods.Stored_Queries;


using GJP_IMIS.IMIS_Class;
using System.Data.SqlClient;
using GJP_IMIS.IMIS_Methods.Report_Queries;
using GJP_IMIS.Reports;
using System.IO;

namespace GJP_IMIS.IMIS_Main_Menu
{
    public partial class Main_Menu_Remastered : Form
    {
        // DATA TABLES
        public static DataTable internData = menuQueries.viewInternPlain1();
        public static DataTable internUnregData = menuQueries.viewUnregInternPlain();
        public static DataTable universityData = InternQueries.getUniversities1();
        public static DataTable officeData = InternQueries.getOffices1();
        //public static DataTable courseData = InternQueries.getCourses1();
        public static DataTable addLogData = menuQueries.insertInternLogDataGrid();

        // reports
        public static DataTable internAcceptData = menuQueries.reportAcceptanceDataGrid1();

        public Main_Menu_Remastered()
        {
            InitializeComponent();
            imisWelcome.BringToFront();
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

            dataGridUnregInterns.DataSource = internUnregData;
            dataGridUnregInterns.ClearSelection();
            dataGridUnregInterns.AutoResizeColumns();
            
        }

        // ojt number
        private void txtOjtNum_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        // ojt first name
        private void txtFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }
        // ojt middle initial
        private void txtMinitial_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
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
            //e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        // coordinator
        private void txtCoordinator_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }
        private void txtCoordPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }
        private void txtCoordDept_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
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
                if (string.IsNullOrWhiteSpace(txtCoordinatorFname.Text))
                    errorHandling += "* Coordinator Name\n";
                if (string.IsNullOrWhiteSpace(txtCoordDept.Text))
                    errorHandling += "* Coordinator Department\n";
                if (string.IsNullOrWhiteSpace(txtCoordPosition.Text))
                    errorHandling += "* Coordinator Position\n";
                if (string.IsNullOrWhiteSpace(txtOffice.Text))
                    errorHandling += "* Office\n";
                if (numericTargetHours.Value <= 0)
                    errorHandling += "* Number of Hours\n";
                if (string.IsNullOrWhiteSpace(txtCourse.Text))
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

            if(!checkSchedule())
            {
                if (!radioScheduleNormal.Checked || !radioScheduleOT.Checked)
                    errorHandling += "* Intern Schedule";
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
            string coordF = txtCoordinatorFname.Text;
            string coordL = txtCoordinatorLname.Text;
            string coordGender = getCoordGender();
            string coordPos = txtCoordPosition.Text;
            string coordDept = txtCoordDept.Text;
            string course = txtCourse.Text;
            string office = txtOffice.Text;
            string startDate = dateTimeStartDate.Value.ToString("yyyy-MM-dd");
            string hours = (numericTargetHours.Value * 3600).ToString();
            string ojtTerminal = txtTerminalName.Text;
            string schedAM = getScheduleAM();
            string schedPM = getSchedulePM();

            if (!InternQueries.isInternExist(ojtNumber))
            {
                DialogResult dr = MessageBox.Show("CONFIRM ADD INTERN", "Add Intern", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    InternQueries.addInternData1(ojtNumber, fname, mini, lname, gender, course, univ, coordF, coordL, coordGender, coordPos, coordDept, office, ojtTerminal);
                    InternQueries.addInternStatus1(ojtNumber, startDate, schedAM, schedPM, hours);

                    MessageBox.Show("Intern Successfully Registered on the Database", "Add Intern", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    internUnregData = menuQueries.viewUnregInternPlain();
                    addInternStrip();
                }
            }
            else
                MessageBox.Show("OJT NUMBER ALREADY EXISTED.");
            
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

        private string getScheduleAM()
        {
            string timeAM = "";
            if (radioScheduleNormal.Checked)
                timeAM = "8:30:00";
            if (radioScheduleOT.Checked)
                timeAM = "8:00:00";
            return timeAM;
        }

        private string getSchedulePM()
        {
            string timePM = "";
            if (radioScheduleNormal.Checked)
                timePM = "17:30:00";
            if (radioScheduleOT.Checked)
                timePM = "19:00:00";
            return timePM;
        }

        // DATA VALIDATION SECTION
        private Boolean dataValidation()
        {
            return (checkTextbox() && checkGender() && checkCoordGender() && checkSchedule());
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
                string.IsNullOrWhiteSpace(txtCoordinatorFname.Text) ||
                string.IsNullOrWhiteSpace(txtCoordPosition.Text) ||
                string.IsNullOrWhiteSpace(txtCoordPosition.Text) ||
                numericTargetHours.Value <= 0
                );
        }

        private Boolean checkGender()
        {
            return (radioMale.Checked || radioFemale.Checked);
        }

        private Boolean checkCoordGender()
        {
            return (radioMaleCoord.Checked || radioFemaleCoord.Checked);
        }

        private Boolean checkSchedule()
        {
            return (radioScheduleNormal.Checked || radioScheduleOT.Checked);
        }

        // END OF DATA VALIDATION SECTION

        // ********** END OF ADD INTERN **********


        // ********** EDIT INTERN **********

        private void editInternStrip()
        {
            dataGridModiftIntern.DataSource = internAcceptData;
            dataGridModiftIntern.ClearSelection();

            dataGridAddLog.DataSource = addLogData;
            dataGridAddLog.ClearSelection();

            datagridModifLog.DataSource = addLogData;
            datagridModifLog.ClearSelection();

            addLogDate.Format = DateTimePickerFormat.Custom;
            addLogDate.CustomFormat = "yyyy-MM-dd";

            addLogTime.Format = DateTimePickerFormat.Custom;
            addLogTime.CustomFormat = "HH:mm:ss";
            addLogTime.ShowUpDown = true;
        }

        private void btnSearchIntern_Click(object sender, EventArgs e)
        {
            string ojtNum = dataGridModiftIntern.CurrentRow.Cells[0].Value.ToString();

            if (ojtNum != null)
            {
                editIntern(ojtNum);
                editInternPanel.BringToFront();
            }
            else
                MessageBox.Show("SELECT INTERN FIRST.");
            
            

        }

        private void editIntern(string o)
        {
            Connection_String.dbConnection();
            //String query = InternQueries.editInternQuery(o);
            SqlCommand cmd = new SqlCommand(InternQueries.editInternQuery(), Connection_String.con);
            cmd.Parameters.Add("@ojtID", SqlDbType.NVarChar);
            cmd.Parameters["@ojtID"].Value = o;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtEditOjtNum.Text = dr["OJT ID"].ToString();
                txtEditfname.Text = dr["First Name"].ToString();
                txtEditmini.Text = dr["Middle Initial"].ToString();
                txtEditlname.Text = dr["Last Name"].ToString();
                genderEdit(dr["Gender"].ToString());
                txtEdituniv.Text = dr["University"].ToString();
                txtEditCoordFname.Text = dr["Coordinator FirstName"].ToString();
                txtEditCoordLname.Text = dr["Coordinator LastName"].ToString();
                genderCoordEdit(dr["Coordinator Gender"].ToString());
                txtEditCoordPos.Text = dr["Coordinator Position"].ToString();
                txtEditCoordDept.Text = dr["Coordinator Department"].ToString();
                txtEditCourse.Text = dr["Course"].ToString();
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
        private void genderCoordEdit(string g)
        {
            if (g == "Male")
                radioCoordEditMale.Checked = true;
            if (g == "Female")
                radioCoordEditFemale.Checked = true;
        }
        // edit status 
        private void statusEdit(string s)
        {
            if (s == "COMPLETE")
                radioEditcomplete.Checked = true;
            if (s == "INCOMPLETE")
                radioEditincomplete.Checked = true;
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
                    string coordFname = txtEditCoordFname.Text;
                    string coordLname = txtEditCoordLname.Text;
                    string coordGender = getCoordGenderEdit();
                    string coordPos = txtEditCoordPos.Text;
                    string coordDept = txtEditCoordDept.Text;
                    string course = txtEditCourse.Text;
                    string office = txtEditoffice.Text;
                    //string startDate = dateTimeStartDate.Value.ToShortDateString();
                    string hours = numericEdit.Value.ToString();
                    string status = getStatusEdit();

                    InternQueries.updateInternData(ojtNumber, fname, mini,
                        lname, gender, univ, coordFname, coordLname, coordGender, coordPos, coordDept,
                        course, office);

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
                if (string.IsNullOrWhiteSpace(txtEditCoordFname.Text))
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
                string.IsNullOrWhiteSpace(txtEditCoordFname.Text) ||
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
        private string getCoordGenderEdit()
        {
            string g = "";
            if (radioCoordEditMale.Checked)
                g = "Male";
            if (radioCoordEditFemale.Checked)
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
            //e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
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
            addInternUnreg.BringToFront();
            addInternStrip();
            
        }

        private void editInternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editInternPanelFind.BringToFront();
        }

        

        private void viewDtrToolStripButton1_Click(object sender, EventArgs e)
        {
            //viewDtrPanel.BringToFront();
            viewDTRPanelWelcome.BringToFront();
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

        private void btnCOC_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rv.viewCertificateOfCompletion(dataGridAccept.CurrentRow.Cells[0].Value.ToString());
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
            reportUnivCombo.DisplayMember = "School_Name";
            reportUnivCombo.ValueMember = "School_Name";
            // OFFICE
            reportOfficeCombo.DataSource = officeData;
            reportOfficeCombo.DisplayMember = "Office_Name";
            reportOfficeCombo.ValueMember = "Office_Name";
            
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
                    query += "AND Intern_Info1.School_Name = '" + filter + "' ";
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

        private void toolStripSplitIntern_ButtonClick(object sender, EventArgs e)
        {
            internsPanelWelcome.BringToFront();
        }

        private void toolStripSplitLetter_ButtonClick(object sender, EventArgs e)
        {
            letterPanelWelcome.BringToFront();
        }

        private void reportsToolStripButton2_Click_1(object sender, EventArgs e)
        {
            reportsPanelWelcome.BringToFront();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            reportsPanel.BringToFront();
        }

        private void btnViewDtr_Click(object sender, EventArgs e)
        {
            viewDtrPanel.BringToFront();
        }

        private void Main_Menu_Remastered_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.WindowsShutDown)
            {
                this.Dispose();
                Application.Exit();
            }

            if(e.CloseReason == CloseReason.UserClosing)
            {
                this.Dispose();
                Application.Restart();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void updateDTRToolStripButton1_Click(object sender, EventArgs e)
        {
            string selectedFile = "";

            OpenFileDialog csvFilePath = new OpenFileDialog();

            csvFilePath.InitialDirectory = "C:\\";
            csvFilePath.Filter = "Csv Files (*.csv) | *.csv";
            csvFilePath.FilterIndex = 0;
            csvFilePath.RestoreDirectory = true;

            if (csvFilePath.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    selectedFile = csvFilePath.FileName;

                    DataTable csvDataTable = new DataTable();

                    csvDataTable.Columns.Add("Date");
                    csvDataTable.Columns.Add("Time");
                    csvDataTable.Columns.Add("User ID");
                    csvDataTable.Columns.Add("Name");
                    csvDataTable.Columns.Add("Result");

                    StreamReader streamReader = new StreamReader(csvFilePath.FileName);
                    string[] totalData = new string[File.ReadAllLines(csvFilePath.FileName).Length];
                    totalData = streamReader.ReadLine().Split(',');

                    while (!streamReader.EndOfStream)
                    {
                        totalData = streamReader.ReadLine().Split(',');
                        csvDataTable.Rows.Add(totalData[0], totalData[1], totalData[3], totalData[4], totalData[10]);
                    }


                    using (SqlConnection con = new SqlConnection(Connection_String.conn))
                    {
                        con.Open();

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                        {
                            bulkCopy.DestinationTableName = "Log_Placeholder";
                            bulkCopy.BatchSize = csvDataTable.Rows.Count;
                            bulkCopy.WriteToServer(csvDataTable);
                            bulkCopy.Close();

                            SqlCommand cmd = new SqlCommand(storedQueries.mergeLogs, con);
                            SqlCommand cmd2 = new SqlCommand(storedQueries.truncatePlaceholder, con);
                            //SqlCommand cmd3 = new SqlCommand(storedQueries.insertDTR_fromLogs, con);

                            MessageBox.Show("Rows Added: " + cmd.ExecuteNonQuery().ToString());
                            cmd2.ExecuteNonQuery();
                            //cmd3.ExecuteNonQuery();

                            cmd.Dispose();
                            cmd2.Dispose();
                            //cmd3.Dispose();

                            csvDataTable.Dispose();
                        }
                    }
                }
                catch(Exception er)
                {
                    MessageBox.Show(er.Message, "Update Logs Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
                
        }

        // -------------------- ADDING UNREGISTERED INTERNS --------------------

        private void addUnregIntern_Click(object sender, EventArgs e)
        {

            if (dataGridUnregInterns.Rows.Count != 0)
            {
                addInternPanel.BringToFront();
                txtOjtNum.Text = dataGridUnregInterns.CurrentRow.Cells[0].Value.ToString();
                txtTerminalName.Text = dataGridUnregInterns.CurrentRow.Cells[1].Value.ToString();
            }
            else
                MessageBox.Show("There are no unregistered interns", "Add Intern",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }



        // -------------------- END OF ADDING UNREGISTERED INTERNS --------------------

        // -------------------- ADD LOG STRIP --------------------
        private void addLogToolStrip_Click(object sender, EventArgs e)
        {
            addLogPanel.BringToFront();
        }

        private void btnAddLog_Click(object sender, EventArgs e)
        {
            string d = addLogDate.Text;
            string t = addLogTime.Text;
            int oId = Int32.Parse(addLogOjtID.Text);
            string tName = addLogTerminal.Text;

            InternQueries.insertInternLog(oId, d, t, tName);

            MessageBox.Show("LOG ADDED.");
        }

        private void dataGridAddLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addLogOjtID.Text = dataGridAddLog.CurrentRow.Cells[0].Value.ToString();
            addLogOJTName.Text = dataGridAddLog.CurrentRow.Cells[1].Value.ToString();
            addLogTerminal.Text = dataGridAddLog.CurrentRow.Cells[2].Value.ToString();

            addLogOjtID.Visible = true;
            addLogOJTName.Visible = true;
            addLogTerminal.Visible = true;

            addLogDate.Enabled = true;
            addLogTime.Enabled = true;

            btnAddLog.Enabled = true;
        }


        // -------------------- END OF ADD LOG STRIP --------------------


        // -------------------- MODIFY LOG STRIP --------------------
        private void toolStripButtonModifLog_Click(object sender, EventArgs e)
        {
            panelModifLog.BringToFront();
        }

        private void datagridModifLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            modifLogOjtId.Text = datagridModifLog.CurrentRow.Cells[0].Value.ToString();
            modifLogOjtName.Text = datagridModifLog.CurrentRow.Cells[1].Value.ToString();
            modifLogTerminal.Text = datagridModifLog.CurrentRow.Cells[2].Value.ToString();

            modifLogOjtId.Visible = true;
            modifLogOjtName.Visible = true;
            modifLogTerminal.Visible = true;

            btnUpdateLog.Enabled = true;

            dateTimePickerDate.Enabled = true;
            dateTimePickerTime.Enabled = true;

            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerDate.CustomFormat = "yyyy-MM-dd";

            dateTimePickerTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerTime.CustomFormat = "HH:mm:ss";
            dateTimePickerTime.ShowUpDown = true;

            logsDataGrid();
        }

        private void logsDataGrid()
        {
            int ojtID = Int32.Parse(datagridModifLog.CurrentRow.Cells[0].Value.ToString());

            dataGridLogs.DataSource = InternQueries.internLogsData(ojtID);
        }

        private void dataGridLogs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*modifDate.Text = dataGridLogs.CurrentRow.Cells[0].Value.ToString();
            modifTime.Text = dataGridLogs.CurrentRow.Cells[1].Value.ToString();
            modifDate.Visible = true;
            modifTime.Visible = true;*/

            dateTimePickerDate.Enabled = true;
            dateTimePickerTime.Enabled = true;

            btnUpdateLog.Enabled = true;

            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerDate.CustomFormat = "yyyy-MM-dd";

            dateTimePickerTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerTime.CustomFormat = "HH:mm:ss";
            dateTimePickerTime.ShowUpDown = true;
        }

        private void btnUpdateLog_Click(object sender, EventArgs e)
        {
            //dateTimePickerTime.Value.ToLongTimeString()
            //dateTimePickerDate.Value.Date.ToString("yyyy-MM-dd")

            int ojtID = Int32.Parse(modifLogOjtId.Text);
            /*string oldDate = modifDate.Text;
            string oldTime = modifTime.Text;*/
            string newDate = dateTimePickerDate.Value.Date.ToString("yyyy-MM-dd");
            string newTime = dateTimePickerTime.Value.ToString("HH:mm:ss");
            string terminal = modifLogTerminal.Text;

            /*InternQueries.updateInternLog(ojtID, oldTime, oldDate, newTime, newDate);

            MessageBox.Show("LOG UPDATED.");

            string time = dataGridLogs.CurrentRow.Cells[1].Value.ToString();
            string[] timeSplit = time.Split(':');

            string hour = timeSplit[0].ToString();

            MessageBox.Show(hour);*/

            InternQueries.insertInternLog(ojtID, newDate, newTime, terminal);

            MessageBox.Show("LOG ADDED.");
            // REFRESH THE LOG DATA
            dataGridLogs.DataSource = InternQueries.internLogsData(ojtID);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Connection_String.dbConnection();
            string query = @"DECLARE @day as INT;
                            DECLARE @month as varchar(15);
                            DECLARE @year as varchar(15);

                            SET @day = DATENAME(DAY, GETDATE());
                            SET @month = DATENAME(MONTH, GETDATE());
                            SET @year = DATENAME(YEAR, GETDATE());

                            SELECT
	                            i.First_Name + ' ' + i.Middle_Initial + '. ' + i.Last_Name as 'Intern Name',
	                            i.School_Name as 'School',
	                            i.Course as 'Course',
	                            s.Target_Hours as 'Hours',
	                            i.Office_Name as 'Office',
	                            @day as 'Day',
	                            CASE
		                            WHEN @day % 100 IN (11, 12, 13) THEN 'th'
		                            WHEN @day % 10 = 1 THEN 'st'
		                            WHEN @day % 10 = 2 THEN 'nd'
		                            WHEN @day % 10 = 3 THEN 'rd'
		                            ELSE 'th'
	                            END AS 'Ordinal Number',
	                            @month as 'Month',
	                            @year as 'Year'

                            FROM Intern_Info1 i, Intern_Status1 s
                            WHERE
	                            i.OJT_Number = 2
								AND i.OJT_Number = s.OJT_Number";

            SqlCommand cmd = new SqlCommand(query, Connection_String.con);
            SqlDataReader dr = cmd.ExecuteReader();
            string day = "";
            string ordinal = "";

            while (dr.Read())
            {
                day = dr["Day"].ToString();
                ordinal = dr["Ordinal Number"].ToString();
                if (ordinal == "th")
                    ordinal = "ᵗʰ";
            }

            MessageBox.Show(day + ordinal);

            Connection_String.con.Dispose();
        }

        private void buttonTestDTR_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rv.viewInternDTR();
            rv.ShowDialog();

        }

        private void textFilter_unregInterns_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridUnregInterns.DataSource;
            bs.Filter = "Name like '%" + textFilter_unregInterns.Text + "%'";
            dataGridUnregInterns.DataSource = bs;
            dataGridUnregInterns.ClearSelection();
        }

        // -------------------- END OF MODIFY LOG STRIP --------------------


        // -------------------- REPORT STRIP --------------------














        // ---------------------- END OF  MENU STRIP MENU ----------------------
    }
}
