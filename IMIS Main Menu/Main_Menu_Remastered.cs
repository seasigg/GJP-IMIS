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
using GJP_IMIS.IMIS_Methods.AutoComplete;


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
        /*public static DataTable internData = menuQueries.viewInternPlain1();
        public static DataTable internUnregData = menuQueries.viewUnregInternPlain();
        public static DataTable universityData = InternQueries.getUniversities1();
        public static DataTable officeData = InternQueries.getOffices1();
        public static DataTable courseData = InternQueries.getCourses1();
        public static DataTable addLogData = menuQueries.insertInternLogDataGrid();*/

        // reports
        //public static DataTable internAcceptData = menuQueries.reportAcceptanceDataGrid1();

        public Main_Menu_Remastered()
        {
            InitializeComponent();

            imisWelcome.BringToFront();

            // view intern strip
            setViewInternDataGrid();

            // add intern strip
            addInternStrip();

            // edit intern strip
            editInternDataGrid();

            // letter strip
            defaultLetter();

            // report strip
            defaultReport();
        }

        // -------------------- INTERN STRIP --------------------
        private void editInternDataGrid()
        {
            dataGridModiftIntern.DataSource = menuQueries.reportAcceptanceDataGrid1();
            dataGridModiftIntern.ClearSelection();

            dataGridModiftIntern.AutoResizeColumns();
            dataGridModiftIntern.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridModiftIntern.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            datagridModifLog.DataSource = menuQueries.insertInternLogDataGrid();
            datagridModifLog.ClearSelection();
        }
        // ********** VIEW INTERN **********
        private void setViewInternDataGrid()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = menuQueries.viewInternPlain1();

            dataGridInterns.DataSource = null;
            dataGridInterns.DataSource = bs;
            
            dataGridInterns.ClearSelection();
            dataGridInterns.AutoResizeColumns();

            dataGridInterns.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridInterns.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridInterns.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridInterns.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridInterns.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridInterns.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridInterns.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridInterns.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridInterns.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
        // ********** END OF VIEW INTERN **********

        // ********** ADD INTERN **********
        private void addInternStrip()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = menuQueries.viewUnregInternPlain();
            dataGridUnregInterns.DataSource = bs;

            dataGridUnregInterns.ClearSelection();
            dataGridUnregInterns.AutoResizeColumns();
            dataGridUnregInterns.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridUnregInterns.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            clearAddInternControls();
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
            if (dataValidation())
            {
                insertIntern();
                InternQueries.calculateDTR();
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
                if (string.IsNullOrWhiteSpace(txtCoordinatorName.Text))
                    errorHandling += "* Coordinator Name\n";
                if (string.IsNullOrWhiteSpace(txtCoordinatorSal.Text))
                    errorHandling += "* Coordinator Salutation\n";
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
            string suffix = getSuffix();
            string gender = getGender();
            string univ = txtUniversity.Text;
            string coordName = txtCoordinatorName.Text;
            string coordSal = txtCoordinatorSal.Text;
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
                    InternQueries.addInternData(ojtNumber, fname, mini, lname, suffix, gender, course, univ, coordName, coordSal, coordPos, coordDept, office, ojtTerminal);
                    InternQueries.addInternStatus1(ojtNumber, startDate, schedAM, schedPM, hours);

                    MessageBox.Show("Intern Successfully Registered on the Database", "Add Intern", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //internUnregData = menuQueries.viewUnregInternPlain();

                    addInternUnreg.BringToFront();
                    addInternStrip();
                }
            }
            else
                MessageBox.Show("OJT NUMBER ALREADY EXISTS.");

        }

        private string getSuffix()
        {
            string s = "";
            if (boxSuffix.Checked)
                s = txtSuffix.Text;

            return s;
        }
        private void clearAddInternControls()
        {
            txtOjtNum.Clear();
            txtTerminalName.Clear();
            txtFname.Clear();
            txtMinitial.Clear();
            txtLname.Clear();
            radioMale.Checked = false;
            radioFemale.Checked = false;
            txtUniversity.Clear();
            txtCourse.Clear();
            dateTimeStartDate.Value = DateTime.Today;
            txtCoordinatorName.Clear();
            txtCoordinatorSal.Clear();
            txtCoordPosition.Clear();
            txtCoordDept.Clear();
            txtOffice.Clear();
            
            radioScheduleNormal.Checked = false;
            radioScheduleOT.Checked = false;
            numericTargetHours.Value = 1;
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

        private string getScheduleAM()
        {
            string timeAM = "";
            if (radioScheduleNormal.Checked)
                timeAM = "08:30:00";
            if (radioScheduleOT.Checked)
                timeAM = "08:00:00";
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
            return (checkTextbox() && checkGender() && checkSchedule());
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
                string.IsNullOrWhiteSpace(txtCoordinatorName.Text) ||
                string.IsNullOrWhiteSpace(txtCoordPosition.Text) ||
                string.IsNullOrWhiteSpace(txtCoordPosition.Text) ||
                numericTargetHours.Value <= 0
                );
        }

        private Boolean checkGender()
        {
            return (radioMale.Checked || radioFemale.Checked);
        }

        private Boolean checkSchedule()
        {
            return (radioScheduleNormal.Checked || radioScheduleOT.Checked);
        }

        // END OF DATA VALIDATION SECTION

        // ********** END OF ADD INTERN **********


        // ********** EDIT INTERN **********
        private void btnSearchIntern_Click(object sender, EventArgs e)
        {
            editStatusPanel.Visible = false;
            label31.Visible = false;
            string ojtNum = dataGridModiftIntern.CurrentRow.Cells[0].Value.ToString();

            if (ojtNum != null)
            {
                editIntern(ojtNum);
                editInternPanel.BringToFront();

                txtEdituniv.AutoCompleteCustomSource = acQueries.getAC_University();
                txtEdituniv.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtEdituniv.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtEditCourse.AutoCompleteCustomSource = acQueries.getAC_Course();
                txtEditCourse.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtEditCourse.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtEditCoordName.AutoCompleteCustomSource = acQueries.getAC_CoordinatorName();
                txtEditCoordName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtEditCoordName.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtEditCoordPos.AutoCompleteCustomSource = acQueries.getAC_CoordinatorPosition();
                txtEditCoordPos.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtEditCoordPos.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtEditoffice.AutoCompleteCustomSource = acQueries.getAC_Office();
                txtEditoffice.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtEditoffice.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
                MessageBox.Show("Select an Intern First.");
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
                txtEditTerminalName.Text = dr["Terminal Name"].ToString();
                txtEditOjtNum.Text = dr["OJT ID"].ToString();
                txtEditfname.Text = dr["First Name"].ToString();
                txtEditmini.Text = dr["Middle Initial"].ToString();
                txtEditlname.Text = dr["Last Name"].ToString();
                internSuffix(dr["Suffix"].ToString());
                genderEdit(dr["Gender"].ToString());
                txtEdituniv.Text = dr["University"].ToString();
                txtEditCoordName.Text = dr["Coordinator Name"].ToString();
                txtEditCoordSalutation.Text = dr["Coordinator Salutation"].ToString();
                txtEditCoordPos.Text = dr["Coordinator Position"].ToString();
                txtEditCoordDept.Text = dr["Coordinator Department"].ToString();
                txtEditCourse.Text = dr["Course"].ToString();
                txtEditoffice.Text = dr["Office"].ToString();
                numericEdit.Value = int.Parse(dr["Target Hours"].ToString());
                scheduleEdit(dr["Schedule_AM"].ToString());
                
                statusEdit(dr["Status"].ToString());
            }
            cmd.Dispose();
            Connection_String.con.Dispose();
        }

        // edit gender
        private void internSuffix(string s)
        {
            if (s != "")
            {
                boxEditSuffix.Checked = true;
                txtEditSuffix.Text = s;
            }
                
        }
        private void genderEdit(string g)
        {
            if (g == "Male")
                radioEditmale.Checked = true;
            if (g == "Female")
                radioEditfemale.Checked = true;
        }
        
        // edit status 
        private void scheduleEdit(string s)
        {
            if (s == "08:30:00")
                radioEditScheduleNormal.Checked = true;
            if (s == "08:00:00")
                radioEditScheduleOvertime.Checked = true;
        }

        private void statusEdit(string s)
        {
            if (s == "COMPLETE")
                radioEditcomplete.Checked = true;
            if (s == "INCOMPLETE")
                radioEditincomplete.Checked = true;
        }

        // update button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*string ojtNumber = txtEditOjtNum.Text;
            MessageBox.Show(ojtNumber);*/
            if (editInternValidation() && (checkEditGender() && checkEditSchedule()))
            {
                DialogResult dr = MessageBox.Show("CONFIRM UPDATE INTERN", "Update Intern", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string ojtNumber = txtEditOjtNum.Text;
                    string fname = txtEditfname.Text;
                    string mini = txtEditmini.Text;
                    string lname = txtEditlname.Text;
                    string suffix = getInternSuffixEdit();
                    string gender = getGenderEdit();
                    string univ = txtEdituniv.Text;
                    string coordName = txtEditCoordName.Text;
                    string coordSal = txtEditCoordSalutation.Text;
                    string coordPos = txtEditCoordPos.Text;
                    string coordDept = txtEditCoordDept.Text;
                    string course = txtEditCourse.Text;
                    string office = txtEditoffice.Text;
                    //string startDate = dateTimeStartDate.Value.ToShortDateString();
                    string hours = numericEdit.Value.ToString();
                    //string status = getStatusEdit();
                    string schedAM = getScheduleEditAM();
                    string schedPM = getScheduleEditPM();

                    InternQueries.updateInternData(ojtNumber, fname, mini,
                        lname, suffix, gender, univ, coordName, coordSal, coordPos, coordDept,
                        course, office);

                    InternQueries.updateInternStatus(ojtNumber, schedAM, schedPM, hours);
                    MessageBox.Show("INTERN UPDATED.");

                    InternQueries.calculateDTR(ojtNumber);

                    setViewInternDataGrid();

                    viewInternPanel.BringToFront();
                    MessageBox.Show(ojtNumber);
                }
            }
            else
                MessageBox.Show(editIncompleteInfos());
        }

        private string getInternSuffixEdit()
        {
            if (boxEditSuffix.Checked)
                return txtEditSuffix.Text;

            return "";
        }

        private Boolean checkEditGender()
        {
            bool s = false;
            if (radioEditmale.Checked || radioEditfemale.Checked)
                s = true;
            return s;
        }

        private Boolean checkEditSchedule()
        {
            bool s = false;
            if (radioEditScheduleNormal.Checked || radioEditScheduleOvertime.Checked)
                s = true;
            return s;
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

        private string getScheduleEditAM()
        {
            string s = "";

            if (radioEditScheduleNormal.Checked)
                s = "08:30:00";
            if (radioEditScheduleOvertime.Checked)
                s = "08:00:00";
            return s;
        }

        private string getScheduleEditPM()
        {
            string s = "";

            if (radioEditScheduleNormal.Checked)
                s = "17:30:00";
            if (radioEditScheduleOvertime.Checked)
                s = "19:00:00";
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
                if (string.IsNullOrWhiteSpace(txtEditCoordName.Text))
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
                string.IsNullOrWhiteSpace(txtEditCoordName.Text) ||
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
            //e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        // ********** END OF EDIT INTERN **********

        
        // -------------------- END OF INTERN STRIP --------------------

        // ---------------------- MENU STRIP MENU ----------------------

        private void viewDtrToolStripButton1_Click(object sender, EventArgs e)
        {
            //viewDtrPanel.BringToFront();
            viewDTRPanelWelcome.BringToFront();
        }

        
        // -------------------- LETTER STRIP --------------------

        private void defaultLetter()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = menuQueries.reportAcceptanceDataGrid1();
            dataGridAccept.DataSource = bs;

            dataGridAccept.ClearSelection();
            dataGridAccept.AutoResizeColumns();
        }

        private void btnGenerateCert_Click(object sender, EventArgs e)
        {

            if (!isLetterCerts())
            {
                if (!isDirectors())
                {
                    if (radioOthers.Checked)
                    {
                        if (isOthersFields())
                            viewReport();
                        else
                            MessageBox.Show("Input the Director's name and position first.");

                    } else
                        viewReport();
                }
                else
                    MessageBox.Show("Select Director first.");
            }
            else
                MessageBox.Show("Select certification first.");
        }

        private void viewReport()
        {
            ReportViewer rv = new ReportViewer();
            if (radioAcceptance.Checked)
            {
                rv.viewAcceptanceLetter(dataGridAccept.CurrentRow.Cells[0].Value.ToString(), getDirector(), getDirectorPos());
                rv.ShowDialog();
            }
            if (radioCompletion.Checked)
            {
                rv.viewCertificateOfCompletion(dataGridAccept.CurrentRow.Cells[0].Value.ToString(), getDirector(), getDirectorPos());
                rv.ShowDialog();
            }
        }
        private bool isLetterCerts()
        {
            return !radioAcceptance.Checked && !radioCompletion.Checked;
        }
        private bool isDirectors()
        {
            return !radioBorja.Checked && !radioVida.Checked && !radioOthers.Checked;
        }
        private bool isOthersFields()
        {
            return !string.IsNullOrWhiteSpace(txtDirName.Text) && !string.IsNullOrWhiteSpace(txtDirPos.Text);
        }
        private string getDirector()
        {
            string dir = "";

            if (radioVida.Checked)
                dir = "MARIA VIDA G. CAPARAS, Ph.D., RPsy";
            if (radioBorja.Checked)
                dir = "CHRISTIAN P. BORJA";
            if (radioOthers.Checked)
                dir = txtDirName.Text;
            return dir;
        }
        private string getDirectorPos()
        {
            string dirPos = "";
            if (radioVida.Checked)
                dirPos = "Director III";
            if (radioBorja.Checked)
                dirPos = "Director II";
            if (radioOthers.Checked)
                dirPos = txtDirPos.Text;
            return dirPos;
        }

        private void radioOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (radioOthers.Checked)
            {
                lblDirName.Visible = true;
                lblDirPos.Visible = true;
                txtDirName.Visible = true;
                txtDirPos.Visible = true;

                txtDirName.Text = "";
                txtDirPos.Text = "";
            }
            if (!radioOthers.Checked)
            {
                lblDirName.Visible = false;
                lblDirPos.Visible = false;
                txtDirName.Visible = false;
                txtDirPos.Visible = false;
            }
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
            populateUnivReport();
            // OFFICE
            populateOfficeReport();
            // COURSE
            populateCourseReport();
        }

        // REPORT university combo box
        private void populateUnivReport()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = InternQueries.getUniversities1();
            reportUnivCombo.DataSource = bs;
            reportUnivCombo.DisplayMember = "School_Name";
            reportUnivCombo.ValueMember = "School_Name";
        }
        // REPORT office combo box
        private void populateOfficeReport()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = InternQueries.getOffices1();
            reportOfficeCombo.DataSource = bs;
            reportOfficeCombo.DisplayMember = "Office_Name";
            reportOfficeCombo.ValueMember = "Office_Name";
        }
        // REPORT course combo box
        private void populateCourseReport()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = InternQueries.getCourses1();
            reportCourseCombo.DataSource = bs;
            reportCourseCombo.DisplayMember = "Course";
            reportCourseCombo.ValueMember = "Course";
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

                    query += "WHERE Intern_Info.Gender = '" + filter + "' ";
                }

                if (reportUniv.Checked)
                {
                    filter = reportUnivCombo.SelectedValue.ToString();
                    if (reportGender.Checked)
                        query += "AND Intern_Info.School_Name = '" + filter + "' ";
                    else
                        query += "WHERE Intern_Info.School_Name = '" + filter + "' ";
                }

                if (reportOffice.Checked)
                {
                    filter = reportOfficeCombo.SelectedValue.ToString();
                    if (reportGender.Checked || reportUniv.Checked)
                        query += "AND Intern_Info.Office_Name = '" + filter + "' ";
                    else
                        query += "WHERE Intern_Info.Office_Name = '" + filter + "' ";
                }

                if (reportCourse.Checked)
                {
                    filter = reportCourseCombo.SelectedValue.ToString();
                    if (reportGender.Checked || reportUniv.Checked || reportOffice.Checked)
                        query += "AND Intern_Info.Course = '" + filter + "' ";
                    else
                        query += "WHERE Intern_Info.Course = '" + filter + "' ";
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
            viewInternPanel.BringToFront();
            setViewInternDataGrid();
        }

        private void toolStripLetter_Click(object sender, EventArgs e)
        {
            letterPanel.BringToFront();
        }

        private void reportsToolStripButton2_Click_1(object sender, EventArgs e)
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

                    InternQueries.calculateDTR();
                    setViewInternDataGrid();
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

                txtCoordinatorName.AutoCompleteCustomSource = acQueries.getAC_CoordinatorName();
                txtCoordinatorName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCoordinatorName.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtUniversity.AutoCompleteCustomSource = acQueries.getAC_University();
                txtUniversity.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtUniversity.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtOffice.AutoCompleteCustomSource = acQueries.getAC_Office();
                txtOffice.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtOffice.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtCourse.AutoCompleteCustomSource = acQueries.getAC_Course();
                txtCourse.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCourse.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtCoordPosition.AutoCompleteCustomSource = acQueries.getAC_CoordinatorPosition();
                txtCoordPosition.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCoordPosition.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
                MessageBox.Show("There are no unregistered interns", "Add Intern",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // -------------------- END OF ADDING UNREGISTERED INTERNS --------------------

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

        private void boxSuffix_CheckedChanged(object sender, EventArgs e)
        {
            if (boxSuffix.Checked)
                txtSuffix.Enabled = true;
            else
                txtSuffix.Enabled = false;

            txtSuffix.Text = "";
        }

        private void boxEditSuffix_CheckedChanged(object sender, EventArgs e)
        {
            if (boxEditSuffix.Checked)
                txtEditSuffix.Enabled = true;
            else
                txtEditSuffix.Enabled = false;
            txtEditSuffix.Text = "";
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            InternQueries.calculateDTR();
            setViewInternDataGrid();
        }

        private void btnAddNewIntern_Click(object sender, EventArgs e)
        {
            addInternUnreg.BringToFront();
            addInternStrip();
        }

        private void toolStripInterns_Click(object sender, EventArgs e)
        {
            viewInternPanel.BringToFront();
            setViewInternDataGrid();
        }

        private void btnEditIntern_Click(object sender, EventArgs e)
        {
            editStatusPanel.Visible = false;
            label31.Visible = false;
            string ojtNum = dataGridInterns.CurrentRow.Cells[0].Value.ToString();
            //MessageBox.Show(ojtNum);

            if (ojtNum != null)
            {
                editIntern(ojtNum);
                editInternPanel.BringToFront();

                txtEdituniv.AutoCompleteCustomSource = acQueries.getAC_University();
                txtEdituniv.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtEdituniv.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtEditCourse.AutoCompleteCustomSource = acQueries.getAC_Course();
                txtEditCourse.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtEditCourse.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtEditCoordName.AutoCompleteCustomSource = acQueries.getAC_CoordinatorName();
                txtEditCoordName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtEditCoordName.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtEditCoordPos.AutoCompleteCustomSource = acQueries.getAC_CoordinatorPosition();
                txtEditCoordPos.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtEditCoordPos.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtEditoffice.AutoCompleteCustomSource = acQueries.getAC_Office();
                txtEditoffice.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtEditoffice.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
                MessageBox.Show("Select an Intern First.");
        }



        // -------------------- END OF MODIFY LOG STRIP --------------------


        // -------------------- REPORT STRIP --------------------














        // ---------------------- END OF  MENU STRIP MENU ----------------------
    }
}
