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

using System.Data.SqlClient;
using GJP_IMIS.IMIS_Methods.Report_Queries;
using GJP_IMIS.Reports;
using System.IO;
using System.Threading;
using System.ServiceModel;

namespace GJP_IMIS.IMIS_Main_Menu
{
    public partial class Main_Menu_Remastered : Form
    {
        loadingScreen loadScreen = new loadingScreen();
        public Main_Menu_Remastered()
        {
            InitializeComponent();

            imisWelcome.BringToFront();

            // view intern strip
            setViewInternDataGrid();

            // add intern strip
            addInternStrip();

            // letter strip
            defaultLetter();

            // report strip
            defaultReport();

            // button tool tips
            buttonToolTips();
        }

        private void buttonToolTips()
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.buttonRefresh, "To refresh intern's information");
            ToolTip1.SetToolTip(this.buttonViewDTR, "To view intern's DTR");
            ToolTip1.SetToolTip(this.btnEditIntern, "To edit intern's personal information");
            ToolTip1.SetToolTip(this.btnAddNewIntern, "To add new intern from the biometrics");
            ToolTip1.SetToolTip(this.btnAddIntern, "Add intern's credentials");
            ToolTip1.SetToolTip(this.btnUpdate, "Update intern's credentials");
            ToolTip1.SetToolTip(this.addUnregIntern, "add this intern's information");

        }
        // ------------------------------------------------------------ INTERN STRIP ------------------------------------------------------------

        // refresh intern dtr
        private async void buttonRefresh_Click(object sender, EventArgs e)
        {
            buttonRefresh.Enabled = false;
            loadScreen.Show();
            loadScreen.TopMost = true;
            await Task.Run(() => {
               /* try
                {*/
                    InternQueries.calculateDTR();
                    setViewInternDataGrid();
                    dataGridInterns.ClearSelection();
                /*}
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Refresh Button Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
            });
            loadScreen.Hide();
            buttonRefresh.Enabled = true;
        }

        private void buttonViewDTR_Click(object sender, EventArgs e)
        {
            string ojtNum = dataGridInterns.CurrentRow.Cells[0].Value.ToString();
            if (ojtNum != null)
            {
                viewDTR(ojtNum);
            }
            else
                MessageBox.Show("Select an intern", "No Selected Intern", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void viewDTR(string ojtNum)
        {
            try
            {
                buttonViewDTR.Enabled = false;
                loadScreen.Show();
                loadScreen.TopMost = true;

                await Task.Run(() => {

                        

                        BindingSource bs = new BindingSource();
                        bs.DataSource = menuQueries.viewInternDTR(ojtNum);

                        DataTable dt = menuQueries.viewDTRLabels(ojtNum);

                        var method = new Action(() => {
                            dataGridViewInternDTR.DataSource = bs;
                            dataGridViewInternDTR.ClearSelection();
                        });

                        var method2 = new Action(() => { panelViewDTR.BringToFront(); });

                        var method3 = new Action(() => {
                            textDTR_Name.Text = dt.Rows[0][1].ToString();
                            textDTR_OJTID.Text = dt.Rows[0][0].ToString();
                            textDTR_TerminalName.Text = dt.Rows[0][2].ToString();
                            textDTR_Rendered.Text = dt.Rows[0][3].ToString();
                            textDTR_Status.Text = dt.Rows[0][4].ToString();
                            txtDTR_TermName.Text = dt.Rows[0][5].ToString();

                            textDTR_Name.Visible = true;
                            textDTR_OJTID.Visible = true;
                            textDTR_TerminalName.Visible = true;
                            textDTR_Rendered.Visible = true;
                            textDTR_Status.Visible = true;
                        });

                        if (dataGridViewInternDTR.InvokeRequired)
                            dataGridViewInternDTR.Invoke(method);
                        else
                            method();

                        if (panelViewDTR.InvokeRequired)
                            panelViewDTR.Invoke(method2);
                        else
                            method2();

                        if (textDTR_Name.InvokeRequired || textDTR_OJTID.InvokeRequired || textDTR_TerminalName.InvokeRequired || textDTR_Rendered.InvokeRequired || textDTR_Status.InvokeRequired || txtDTR_TermName.InvokeRequired)
                        {
                            textDTR_Name.Invoke(method3);
                            textDTR_OJTID.Invoke(method3);
                            textDTR_TerminalName.Invoke(method3);
                            textDTR_Rendered.Invoke(method3);
                            textDTR_Status.Invoke(method3);
                            txtDTR_TermName.Invoke(method3);
                        }
                        else
                            method3();

                        dt.Dispose();
                    
                });
                loadScreen.Hide();
                buttonViewDTR.Enabled = true;
            }
            catch (ProtocolException ex)
            {
                loadScreen.Hide();
                buttonViewDTR.Enabled = true;
                MessageBox.Show(ex.Message, "View DTR Button Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtInternFilter_TextChanged_1(object sender, EventArgs e)
        {
            internFilter();
        }

        private void comboBoxInternFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            internFilter();
        }

        private void internFilter()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridInterns.DataSource;

            if (comboBoxInternFilter.SelectedIndex == 0)
                bs.Filter = "[Name] like '%" + txtInternFilter.Text + "%'";
            if (comboBoxInternFilter.SelectedIndex == 1)
                bs.Filter = "[Course] like '%" + txtInternFilter.Text + "%'";
            if (comboBoxInternFilter.SelectedIndex == 2)
                bs.Filter = "[School] like '%" + txtInternFilter.Text + "%'";
            if (comboBoxInternFilter.SelectedIndex == 3)
                bs.Filter = "[Office] like '%" + txtInternFilter.Text + "%'";
            if (comboBoxInternFilter.SelectedIndex == 4)
                bs.Filter = "[OJT ID] like '%" + txtInternFilter.Text + "%'";

            dataGridInterns.DataSource = bs;
            dataGridInterns.ClearSelection();
        }
        // ********* ADD UNREGISTERED INTERNS *********
        // add new intern
        private void btnAddNewIntern_Click(object sender, EventArgs e)
        {
            addInternUnreg.BringToFront();
            addInternStrip();
        }
        // unreg interns filter
        private void textFilter_unregInterns_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridUnregInterns.DataSource;
            bs.Filter = "Name like '%" + textFilter_unregInterns.Text + "%'";
            dataGridUnregInterns.DataSource = bs;
            dataGridUnregInterns.ClearSelection();
        }
        // unreg interns
        private async void addUnregIntern_Click(object sender, EventArgs e)
        {
            var internPanel = new Action(() => { addInternPanel.BringToFront(); });
            var tbOJTNumber = new Action(() => { txtOjtNum.Text = dataGridUnregInterns.CurrentRow.Cells[0].Value.ToString(); });
            var tbTerminalName = new Action(() => { txtTerminalName.Text = dataGridUnregInterns.CurrentRow.Cells[1].Value.ToString(); });
            var tbCoordinatorName = new Action(() => {
                txtCoordinatorName.AutoCompleteCustomSource = acQueries.getAC_CoordinatorName();
                txtCoordinatorName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCoordinatorName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            });
            var tbUniversity = new Action(() => {
                txtUniversity.AutoCompleteCustomSource = acQueries.getAC_University();
                txtUniversity.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtUniversity.AutoCompleteSource = AutoCompleteSource.CustomSource;
            });
            var tbOffice = new Action(() => {
                txtOffice.AutoCompleteCustomSource = acQueries.getAC_Office();
                txtOffice.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtOffice.AutoCompleteSource = AutoCompleteSource.CustomSource;
            });
            var tbCourse = new Action(() => {
                txtCourse.AutoCompleteCustomSource = acQueries.getAC_Course();
                txtCourse.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCourse.AutoCompleteSource = AutoCompleteSource.CustomSource;
            });
            var tbCoordPosition = new Action(() => {
                txtCoordPosition.AutoCompleteCustomSource = acQueries.getAC_CoordinatorPosition();
                txtCoordPosition.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCoordPosition.AutoCompleteSource = AutoCompleteSource.CustomSource;
            });

            
            if (dataGridUnregInterns.Rows.Count != 0)
            {
                addUnregIntern.Enabled = false;
                loadScreen.Show();
                loadScreen.TopMost = true;

                await Task.Run(() => {
                        
                    if (addInternPanel.InvokeRequired)
                        addInternPanel.Invoke(new Action(() => internPanel()));
                    else
                        internPanel();

                    if (txtOjtNum.InvokeRequired)
                        txtOjtNum.Invoke(new Action(() => tbOJTNumber()));
                    else
                        tbOJTNumber();

                    if (txtTerminalName.InvokeRequired)
                        txtTerminalName.Invoke(new Action(() => tbTerminalName()));
                    else
                        tbTerminalName();

                    if (txtCoordinatorName.InvokeRequired)
                        txtCoordinatorName.Invoke(new Action(() => tbCoordinatorName()));
                    else
                        tbCoordinatorName();

                    if (txtUniversity.InvokeRequired)
                        txtUniversity.Invoke(new Action(() => tbUniversity()));
                    else
                        tbUniversity();

                    if (txtOffice.InvokeRequired)
                        txtOffice.Invoke(new Action(() => tbOffice()));
                    else
                        tbOffice();

                    if (txtCourse.InvokeRequired)
                        txtCourse.Invoke(new Action(() => tbCourse()));
                    else
                        tbCourse();

                    if (txtCoordPosition.InvokeRequired)
                        txtCoordPosition.Invoke(new Action(() => tbCoordPosition()));
                    else
                        tbCoordPosition();
                });

                addUnregIntern.Enabled = true;
                loadScreen.Hide();
            }
            else
                MessageBox.Show("There are no unregistered interns", "Add Intern", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ********* EDIT INTERN DATA *********

        // ********** VIEW INTERN **********

        
        private void setViewInternDataGrid()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = menuQueries.viewInternPlain1();
            
            var method = new Action(() => {
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
                dataGridInterns.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            });

            if(dataGridInterns.InvokeRequired)
                dataGridInterns.Invoke(new Action(() => method())); 
            else
                method();
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

        // middle initial to uppercase
        private void txtMinitial_TextChanged(object sender, EventArgs e)
        {
            txtMinitial.Text = txtMinitial.Text.ToUpper();
            txtMinitial.SelectionStart = txtMinitial.Text.Length;
            txtMinitial.SelectionLength = 0;
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
                MessageBox.Show(incompleteInfo());

        }

        // data validation
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
            // please fill up the following:
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
                    InternQueries.addInternData(ojtNumber, fname, mini, lname, suffix,
                        gender, course, univ, coordName, coordSal, coordPos, coordDept, office, ojtTerminal);
                    InternQueries.addInternStatus1(ojtNumber, startDate, schedAM, schedPM, hours);

                    MessageBox.Show("Intern Successfully Registered on the Database", "Add Intern", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addInternUnreg.BringToFront();
                    addInternStrip();
                }
            }
            else
                MessageBox.Show("OJT NUMBER ALREADY EXISTS.");
        }
        // intern suffix
        private void boxSuffix_CheckedChanged(object sender, EventArgs e)
        {
            if (boxSuffix.Checked)
                txtSuffix.Enabled = true;
            else
                txtSuffix.Enabled = false;
            txtSuffix.Text = "";
        }
        private string getSuffix()
        {
            string s = "";
            if (boxSuffix.Checked)
                s = txtSuffix.Text;

            return s;
        }
        // clear add interns fields
        private void clearAddInternControls()
        {
            txtOjtNum.Text = "";
            txtTerminalName.Text = "";
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

            boxSuffix.Checked = false;
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
        // schedule AM
        private string getScheduleAM()
        {
            string timeAM = "";
            if (radioScheduleNormal.Checked)
                timeAM = "08:30:00";
            if (radioScheduleOT.Checked)
                timeAM = "08:00:00";
            return timeAM;
        }
        // schedule PM
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

        // ********** END OF ADD INTERN **********

        // ********** EDIT INTERN **********
        // edit intern button
        private void btnEditIntern_Click(object sender, EventArgs e)
        {
            editStatusPanel.Visible = false;
            label31.Visible = false;
            string ojtNum = dataGridInterns.CurrentRow.Cells[0].Value.ToString();

            if (ojtNum != null)
            {
                editIntern(ojtNum);
                editInternPanel.BringToFront();
            }
            else
                MessageBox.Show("Select an Intern First.");
        }
        // populate edit intern
        private void editIntern(string o)
        {
            Connection_String.dbConnection();
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
            cmd.Dispose();
            Connection_String.con.Dispose();
        }
        // suffix
        private void boxEditSuffix_CheckedChanged(object sender, EventArgs e)
        {
            if (boxEditSuffix.Checked)
                txtEditSuffix.Enabled = true;
            else
                txtEditSuffix.Enabled = false;
            txtEditSuffix.Text = "";
        }
        private void internSuffix(string s)
        {
            if (s != "")
            {
                boxEditSuffix.Checked = true;
                txtEditSuffix.Text = s;
            }
        }
        // gender
        private void genderEdit(string g)
        {
            if (g == "Male")
                radioEditmale.Checked = true;
            if (g == "Female")
                radioEditfemale.Checked = true;
        }
        // schedule type
        private void scheduleEdit(string s)
        {
            if (s == "08:30:00")
                radioEditScheduleNormal.Checked = true;
            if (s == "08:00:00")
                radioEditScheduleOvertime.Checked = true;
        }
        // status
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
                    string hours = numericEdit.Value.ToString();
                    string schedAM = getScheduleEditAM();
                    string schedPM = getScheduleEditPM();

                    InternQueries.updateInternData(ojtNumber, fname, mini,
                        lname, suffix, gender, univ, coordName, coordSal, coordPos, coordDept,
                        course, office);

                    InternQueries.updateInternStatus(ojtNumber, schedAM, schedPM, hours);
                    MessageBox.Show("INTERN UPDATED.");

                    InternQueries.calculateDTR(ojtNumber);

                    buttonRefresh.PerformClick();

                    viewInternPanel.BringToFront();
                }
            }
            else
                MessageBox.Show(editIncompleteInfos());
        }
        // suffix
        private string getInternSuffixEdit()
        {
            if (boxEditSuffix.Checked)
                return txtEditSuffix.Text;

            return "";
        }
        // gender
        private Boolean checkEditGender()
        {
            bool s = false;
            if (radioEditmale.Checked || radioEditfemale.Checked)
                s = true;
            return s;
        }
        // schedule
        private Boolean checkEditSchedule()
        {
            bool s = false;
            if (radioEditScheduleNormal.Checked || radioEditScheduleOvertime.Checked)
                s = true;
            return s;
        }
        // schedule AM
        private string getScheduleEditAM()
        {
            string s = "";

            if (radioEditScheduleNormal.Checked)
                s = "08:30:00";
            if (radioEditScheduleOvertime.Checked)
                s = "08:00:00";
            return s;
        }
        // schedule PM
        private string getScheduleEditPM()
        {
            string s = "";
            if (radioEditScheduleNormal.Checked)
                s = "17:30:00";
            if (radioEditScheduleOvertime.Checked)
                s = "19:00:00";
            return s;
        }
        // data validation
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
        // middle initial upper case
        private void txtEditmini_TextChanged(object sender, EventArgs e)
        {
            txtEditmini.Text = txtEditmini.Text.ToUpper();
        }

        // ********** END OF EDIT INTERN **********

        // ------------------------------------------------------------ END OF INTERN STRIP ------------------------------------------------------------

        // ------------------------------------------------------------ UPDATE LOGS STRIP ------------------------------------------------------------
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
                            
                            MessageBox.Show("Rows Added: " + cmd.ExecuteNonQuery().ToString());
                            cmd2.ExecuteNonQuery();

                            cmd.Dispose();
                            cmd2.Dispose();

                            csvDataTable.Dispose();
                        }
                    }

                    InternQueries.calculateDTR();
                    buttonRefresh.PerformClick();
                    imisWelcome.BringToFront();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Update Logs Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        // ------------------------------------------------------------ END OF UPDATE LOG STRIP ------------------------------------------------------------

        // ------------------------------------------------------------ MODIFY LOG STRIP ------------------------------------------------------------
        // logs data grid

        private void dataGridLogs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dateTimePickerDate.Enabled = true;
            dateTimePickerTime.Enabled = true;

            btnUpdateLog.Enabled = true;

            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerDate.CustomFormat = "yyyy-MM-dd";

            dateTimePickerTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerTime.CustomFormat = "HH:mm:ss";
            dateTimePickerTime.ShowUpDown = true;
        }
        // update intern log button
        private void btnUpdateLog_Click(object sender, EventArgs e)
        {
            string ojtID = textDTR_OJTID.Text;
            string newDate = dateTimePickerDate.Value.Date.ToString("yyyy-MM-dd");
            string newTime = dateTimePickerTime.Value.ToString("HH:mm:ss");
            string terminal = txtDTR_TermName.Text;

            InternQueries.insertInternLog(ojtID, newDate, newTime, terminal);

            // REFRESH THE LOG DATA
            InternQueries.calculateDTR();
            viewDTR(ojtID);
            
        }

        // ------------------------------------------------------------ END OF MODIFY LOG STRIP ------------------------------------------------------------

        // ------------------------------------------------------------ CERTIFICATES STRIP ------------------------------------------------------------

        // data grid
        private void defaultLetter()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = menuQueries.reportAcceptanceDataGrid1();
            dataGridAccept.DataSource = bs;

            dataGridAccept.AutoResizeColumns();
            dataGridAccept.ClearSelection();
        }
        // generate certificate button
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
                } else
                    MessageBox.Show("Select Director first.");
            } else
                MessageBox.Show("Select certification first.");
        }
        // type of certification
        private void viewReport()
        {
            ReportViewer rv = new ReportViewer();

            if (radioAcceptance.Checked)
                rv.viewAcceptanceLetter(dataGridAccept.CurrentRow.Cells[0].Value.ToString(), getDirector(), getDirectorPos());
            if (radioCompletion.Checked)
                rv.viewCertificateOfCompletion(dataGridAccept.CurrentRow.Cells[0].Value.ToString(), getDirector(), getDirectorPos());
                
            rv.ShowDialog();
        }
        // data validation
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
        // get director's name
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
        // get director's position
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
        // other director
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

        // ------------------------------------------------------------ END OF LETTER STRIP ------------------------------------------------------------

        // ------------------------------------------------------------ REPORT STRIP ------------------------------------------------------------
        
        private void defaultReport()
        {
            populateComboBoxes();
            
            reportMale.Enabled = false;
            reportFemale.Enabled = false;

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
        // report combo boxes
        private void populateComboBoxes()
        {
            // UNIV
            populateUnivReport();
            // OFFICE
            populateOfficeReport();
            // COURSE
            populateCourseReport();
        }
        // university combo box
        private void populateUnivReport()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = ReportQueries.getUniversities();
            reportUnivCombo.DataSource = bs;
            reportUnivCombo.DisplayMember = "School_Name";
            reportUnivCombo.ValueMember = "School_Name";
        }
        // office combo box
        private void populateOfficeReport()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = ReportQueries.getOffices();
            reportOfficeCombo.DataSource = bs;
            reportOfficeCombo.DisplayMember = "Office_Name";
            reportOfficeCombo.ValueMember = "Office_Name";
        }
        // course combo box
        private void populateCourseReport()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = ReportQueries.getCourses();
            reportCourseCombo.DataSource = bs;
            reportCourseCombo.DisplayMember = "Course";
            reportCourseCombo.ValueMember = "Course";
        }

        // ********** REPORT CHECK BOXES **********
        // GENDER
        private void reportGender_CheckedChanged(object sender, EventArgs e)
        {
            if (reportGender.Checked)
            {
                reportMale.Enabled = true;
                reportFemale.Enabled = true;
                reportMale.Checked = true;
            }
            else
            {
                reportMale.Enabled = false;
                reportFemale.Enabled = false;
                reportMale.Checked = false;
                reportFemale.Checked = false;
            }
        }
        // UNIVERSITY
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
        // OFFICE
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
        // COURSE
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

        // generate report button
        private void internButtonGenerate_Click(object sender, EventArgs e)
        {
            string query = ReportQueries.reportsInternQuery();
            string filter = "";
            ReportViewer rv = new ReportViewer();

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

                rv.viewInternReport(query);
            }
            else
                rv.viewInternReport(ReportQueries.reportsInternQuery());
            
            rv.ShowDialog();
        }

        // ------------------------------------------------------------ END OF REPORT STRIP ------------------------------------------------------------

        // ------------------------------------------------------------ SYSTEM CLOSING ------------------------------------------------------------
        private void Main_Menu_Remastered_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                this.Dispose();
                Application.Exit();
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Dispose();
                Application.Restart();
            }
        }
        // ------------------------------------------------------------ END OF SYSTEM CLOSING ------------------------------------------------------------

        //------------------------------------------------------------ STRIP BUTTONS ------------------------------------------------------------
        // intern
        private void toolStripInterns_Click(object sender, EventArgs e)
        {
            viewInternPanel.BringToFront();
            comboBoxInternFilter.SelectedIndex = 0;
        }
        // certificates/letter
        private void toolStripLetter_Click(object sender, EventArgs e)
        {
            letterPanel.BringToFront();
        }
        // report
        private void reportsToolStripButton2_Click_1(object sender, EventArgs e)
        {
            reportsPanel.BringToFront();
        }
        
        // test dtr
        private void buttonTestDTR_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rv.viewInternDTR();
            rv.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
