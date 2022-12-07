using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//FORMS
using GJP_IMIS.IMIS_Main_Menu.Interns;
using GJP_IMIS.IMIS_Main_Menu.University;
using GJP_IMIS.IMIS_Main_Menu.Addresse;
using GJP_IMIS.Reports;

//QUERIES
using GJP_IMIS.IMIS_Methods.Database_Connection;
using GJP_IMIS.IMIS_Methods.Intern_Queries;
using GJP_IMIS.IMIS_Methods.Main_Menu_Queries;
using GJP_IMIS.IMIS_Methods.Report_Queries;

//CLASS
using GJP_IMIS.IMIS_Class;

namespace GJP_IMIS.IMIS_Main_Menu
{
    public partial class Main_Menu : Form
    {
        // SELECTION COLOR FOR NAV BAR
        Color selectBackColor = Color.FromArgb(51, 96, 185);
        Color selectForeColor = Color.FromArgb(255,255,255);
        Color deSelectBackColor = Color.FromArgb(255,255,255);
        Color deSelectForeColor = Color.FromArgb(0,0,0);


        public Main_Menu()
        {
            InitializeComponent();
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {
            main_menu_welcome_panel.BringToFront();

            universityDataGrid();
            coordinatorUniversityCombo();
        }



        // ============================== INTERN PANEL ==============================
        public void btn_interns_panel_Click(object sender, EventArgs e)
        {
            // Intern Panel Selection
            main_menu_interns_panel.BringToFront();
            internSelect();

            //Intern Data Grid Query and Resize
            internDataGrid();
            setInternDataGridHeaderSize();
        }

        public void internRefreshTable()
        {
            internDataGrid();
        }

        // Add Intern Button
        private void main_menu_interns_btn_newintern_Click(object sender, EventArgs e)
        {
            Add_Intern ai = new Add_Intern(this);
            ai.ShowDialog();
        }

        public void internDataGrid()
        {
            dataGridIntern.DataSource = menuQueries.viewInternPlain();
            dataGridIntern.ClearSelection();
            dataGridIntern.AutoResizeColumns();
        }

        private void setInternDataGridHeaderSize()
        {
            // column header size
            Classes.setDataGridHeaderWidth(0, 100, dataGridIntern); // OJT NUMBER
            Classes.setDataGridHeaderWidth(1, 120, dataGridIntern); // LAST NAME
            Classes.setDataGridHeaderWidth(2, 120, dataGridIntern); // FIRST NAME
            Classes.setDataGridHeaderWidth(3, 200, dataGridIntern); // COURSE
            Classes.setDataGridHeaderWidth(4, 250, dataGridIntern); // UNIVERSITY
            Classes.setDataGridHeaderWidth(5, 120, dataGridIntern); // COORDINATOR
            Classes.setDataGridHeaderWidth(6, 240, dataGridIntern); // OFFICE DEPLOYED
            Classes.setDataGridHeaderWidth(7, 100, dataGridIntern); // STATUS

            // rows size
            for (int i = 0; i < dataGridIntern.Rows.Count; i++)
                Classes.setDataGridRowHeight(i, 50, dataGridIntern);
        }

        // ============================== END INTERN PANEL ==============================



        // ============================== COORDINATOR PANEL ==============================
        private void btn_addresse_panel_Click(object sender, EventArgs e)
        {
            // Coordinator Panel Selection
            main_menu_addresse_panel.BringToFront();
            coordinatorSelect();

            //University Combobox [Filter]
            coordinatorUniversityCombo();

            //Coordinator DataGrid Query
            coordinatorDataGrid();

        }
        public void coordinatorUniversityCombo()
        {       
            coordComboUniversity.DataSource = InternQueries.getUniversities();
            coordComboUniversity.DisplayMember = "University_Name";
            coordComboUniversity.ValueMember = "University_ID";
            coordComboUniversity.SelectedIndex = -1;
        }
        public void coordinatorDataGrid()
        {
            main_menu_addresse_addresse_DataGrid.DataSource = menuQueries.coordinatorDataGridUnfiltered();
            main_menu_addresse_addresse_DataGrid.ClearSelection();
            main_menu_addresse_addresse_DataGrid.AutoResizeColumns();

            main_menu_addresse_addresse_DataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            main_menu_addresse_addresse_DataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            main_menu_addresse_addresse_DataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            main_menu_addresse_addresse_DataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            main_menu_addresse_addresse_DataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            main_menu_addresse_addresse_DataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
        private void coordinatorDataGridFiltered(int id)
        {
            main_menu_addresse_addresse_DataGrid.DataSource = menuQueries.coordinatorDataGridFiltered(id);
            main_menu_addresse_addresse_DataGrid.ClearSelection();
            main_menu_addresse_addresse_DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        // ADD NEW ADDRESSE BUTTON
        private void main_menu_interns_btn_newaddresse_Click(object sender, EventArgs e)
        {
            Add_Coordinator aa = new Add_Coordinator();
            aa.ShowDialog();
        }
        // CLEAR SELECTION OF ADDRESSE
        private void main_menu_addresse_btn_clearSelection_Click(object sender, EventArgs e)
        {
            coordinatorUniversityCombo();
            coordinatorDataGrid();
        }

        // ============================== END COORDINATOR PANEL ==============================



        // ============================== UNIVERSITY PANEL ==============================
        public void btn_univ_panel_Click(object sender, EventArgs e)
        {
            // University Panel Selection
            main_menu_univ_panel.BringToFront();
            universitySelect();
        }
        
        public void universityDataGrid()
        {
            main_menu_univ_dataGridView.DataSource = menuQueries.universityDataGrid();
            main_menu_univ_dataGridView.AutoResizeColumns();
            main_menu_univ_dataGridView.ClearSelection();

            // univ id alignment center and resize
            main_menu_univ_dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Classes.setDataGridHeaderWidth(0, 150, main_menu_univ_dataGridView);

            // univ name resize
            main_menu_univ_dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // resize all rows
            for (int i = 0; i < main_menu_univ_dataGridView.Rows.Count; i++)
                Classes.setDataGridRowHeight(i, 50, main_menu_univ_dataGridView);

        }

        // ADD UNIVERSITY BUTTON
        private void main_menu_interns_btn_newUniv_Click(object sender, EventArgs e)
        {
            Add_University au = new Add_University(this);
            au.ShowDialog();
        }

        // ============================== END UNIVERSITY PANEL ==============================



        // ============================== REPORTS PANEL ==============================
        private void btn_reports_panel_Click(object sender, EventArgs e)
        {
            main_menu_reports_panel.BringToFront();
            reports_default_panel.BringToFront();
            reportsSelection("");
            // reports button select
            reportSelect();
        }
        // INTERN REPORTS BUTTON
        private void reports_btn_intern_Click(object sender, EventArgs e)
        {
            reportsSelection("intern");
        }
        // DTR BUTTON
        private void reports_btn_dtr_Click(object sender, EventArgs e)
        {
            reportsSelection("dtr");
        }
        // STATUS BUTTON
        private void reports_btn_stats_Click(object sender, EventArgs e)
        {
            reportsSelection("status");
        }
        // CERTIFICATE BUTTON
        private void reports_btn_cert_Click(object sender, EventArgs e)
        {
            reportsSelection("certificate");
        }
        // ACCEPTANCE BUTTON
        private void reports_btn_accept_Click(object sender, EventArgs e)
        {
            reportsSelection("acceptance");
        }

        private void reportsSelection(string b)
        {
            reports_btn_intern.BackColor = deSelectBackColor;
            reports_btn_dtr.BackColor = deSelectBackColor;
            reports_btn_stats.BackColor = deSelectBackColor;
            reports_btn_cert.BackColor = deSelectBackColor;
            reports_btn_accept.BackColor = deSelectBackColor;

            reports_btn_intern.ForeColor = deSelectForeColor;
            reports_btn_dtr.ForeColor = deSelectForeColor;
            reports_btn_stats.ForeColor = deSelectForeColor;
            reports_btn_cert.ForeColor = deSelectForeColor;
            reports_btn_accept.ForeColor = deSelectForeColor;

            switch (b)
            {
                case "intern":
                    reports_btn_intern.BackColor = selectBackColor;
                    reports_btn_intern.ForeColor = selectForeColor;
                    reports_intern_report_panel.BringToFront();

                    // Loading Combo Boxes with Data
                    internReportPopulateCombos();

                    // Gender Radio Buttons
                    internRadioMale.Enabled = false;
                    internRadioFemale.Enabled = false;

                    //Combo Boxes
                    internComboUniversity.Enabled = false;
                    internComboOffice.Enabled = false;
                    internComboCourse.Enabled = false;

                    internComboUniversity.SelectedIndex = -1;
                    internComboOffice.SelectedIndex = -1;
                    internComboCourse.SelectedIndex = -1;

                    break;
                case "dtr":
                    reports_btn_dtr.BackColor = selectBackColor;
                    reports_btn_dtr.ForeColor = selectForeColor;
                    reports_dtr_panel.BringToFront();
                    break;
                case "status":
                    reports_btn_stats.BackColor = selectBackColor;
                    reports_btn_stats.ForeColor = selectForeColor;
                    reports_status_panel.BringToFront();
                    break;
                case "certificate":
                    reports_btn_cert.BackColor = selectBackColor;
                    reports_btn_cert.ForeColor = selectForeColor;
                    reports_certificate_panel.BringToFront();
                    break;
                case "acceptance":
                    reports_btn_accept.BackColor = selectBackColor;
                    reports_btn_accept.ForeColor = selectForeColor;
                    reports_acceptance_panel.BringToFront();

                    acceptanceDataGridIntern.DataSource = menuQueries.reportAcceptanceDataGrid();
                    acceptanceDataGridIntern.ClearSelection();
                    acceptanceDataGridIntern.AutoResizeColumns();

                    acceptanceDataGridIntern.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    acceptanceDataGridIntern.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    acceptanceDataGridIntern.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                    break;
                default:
                    break;
            }
        }

        // -------------------- Report Panel Intern Report Methods --------------------
        private void internReportPopulateCombos()
        {
            internComboUniversity.DataSource = InternQueries.getUniversities();
            internComboUniversity.DisplayMember = "University_Name";
            internComboUniversity.ValueMember = "University_ID";

            internComboOffice.DataSource = InternQueries.getOffices();
            internComboOffice.DisplayMember = "Office_Name";
            internComboOffice.ValueMember = "Office_ID";

            internComboCourse.DataSource = InternQueries.getCourses();
            internComboCourse.DisplayMember = "Course_Name";
            internComboCourse.ValueMember = "Course_ID";
        }

        // -------------------- Report Panel Intern Report Methods --------------------

        // ============================== END REPORTS PANEL ==============================



        // ============================== LOGOUT PANEL ==============================
        private void btn_logout_panel_Click(object sender, EventArgs e)
        {
            IMIS wf = new IMIS();
            wf.Show();
            this.Dispose();
        }
        // ============================== END LOGOUT PANEL ==============================



        // ============================== PANEL SELECTION METHODS ==============================
        private void internSelect()
        {
            btn_interns_panel.BackColor = selectBackColor;
            btn_interns_panel.ForeColor = selectForeColor;

            btn_addresse_panel.BackColor = deSelectBackColor;
            btn_addresse_panel.ForeColor = deSelectForeColor;

            btn_univ_panel.BackColor = deSelectBackColor;
            btn_univ_panel.ForeColor = deSelectForeColor;

            btn_reports_panel.BackColor = deSelectBackColor;
            btn_reports_panel.ForeColor = deSelectForeColor;
        }

        // coordinator button select color
        private void coordinatorSelect()
        {
            btn_interns_panel.BackColor = deSelectBackColor;
            btn_interns_panel.ForeColor = deSelectForeColor;

            btn_addresse_panel.BackColor = selectBackColor;
            btn_addresse_panel.ForeColor = selectForeColor;

            btn_univ_panel.BackColor = deSelectBackColor;
            btn_univ_panel.ForeColor = deSelectForeColor;

            btn_reports_panel.BackColor = deSelectBackColor;
            btn_reports_panel.ForeColor = deSelectForeColor;
        }

        // university button select color
        private void universitySelect()
        {
            btn_interns_panel.BackColor = deSelectBackColor;
            btn_interns_panel.ForeColor = deSelectForeColor;

            btn_addresse_panel.BackColor = deSelectBackColor;
            btn_addresse_panel.ForeColor = deSelectForeColor;

            btn_univ_panel.BackColor = selectBackColor;
            btn_univ_panel.ForeColor = selectForeColor;

            btn_reports_panel.BackColor = deSelectBackColor;
            btn_reports_panel.ForeColor = deSelectForeColor;
        }

        // report button select color
        private void reportSelect()
        {
            btn_interns_panel.BackColor = deSelectBackColor;
            btn_interns_panel.ForeColor = deSelectForeColor;

            btn_addresse_panel.BackColor = deSelectBackColor;
            btn_addresse_panel.ForeColor = deSelectForeColor;

            btn_univ_panel.BackColor = deSelectBackColor;
            btn_univ_panel.ForeColor = deSelectForeColor;

            btn_reports_panel.BackColor = selectBackColor;
            btn_reports_panel.ForeColor = selectForeColor;
        }
        // ============================== END PANEL SELECTION METHODS ==============================



        // ============================== EVENTS ==============================
        private void Main_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                this.Dispose();
                Application.Exit();
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                IMIS wf = new IMIS();
                wf.Show();
                this.Dispose();
            }
        }

        private void coordComboUniversity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(coordComboUniversity.SelectedIndex != -1)
            {
                int coordUnivFilter = Convert.ToInt32(coordComboUniversity.SelectedValue.ToString());
                coordinatorDataGridFiltered(coordUnivFilter);
            }
        }

        // -------------------- Report Panel Intern Report Events --------------------
        private void internCheckGender_CheckedChanged(object sender, EventArgs e)
        {
            if(internCheckGender.Checked)
            {
                internRadioMale.Enabled = true;
                internRadioFemale.Enabled = true;
                internRadioMale.Checked = true;
            }
            else
            {
                internRadioMale.Enabled = false;
                internRadioFemale.Enabled = false;
                internRadioFemale.Checked = false;
                internRadioMale.Checked = false;
            }
        }

        private void internCheckUniversity_CheckedChanged(object sender, EventArgs e)
        {
            if(internCheckUniversity.Checked)
            {
                internComboUniversity.Enabled = true;
                internComboUniversity.SelectedIndex = 0;
            }
            else
            {
                internComboUniversity.Enabled = false;
                internComboUniversity.SelectedIndex = -1;
            }
        }

        private void internCheckOffice_CheckedChanged(object sender, EventArgs e)
        {
            if(internCheckOffice.Checked)
            {
                internComboOffice.Enabled = true;
                internComboOffice.SelectedIndex = 0;
            }
            else
            {
                internComboOffice.Enabled = false;
                internComboOffice.SelectedIndex = -1;
            }
        }

        private void internCheckCourse_CheckedChanged(object sender, EventArgs e)
        {
            if(internCheckOffice.Checked)
            {
                internComboCourse.Enabled = true;
                internComboCourse.SelectedIndex = 0;
            }
            else
            {
                internComboCourse.Enabled = false;
                internComboCourse.SelectedIndex = -1;
            }
        }

        private void internButtonGenerate_Click(object sender, EventArgs e)
        {
            string query = ReportQueries.reportsInternQuery();
            string filter = "";

            if (internCheckCourse.Checked || internCheckGender.Checked || internCheckOffice.Checked || internCheckUniversity.Checked)
            {
                if(internCheckGender.Checked)
                {
                    if (internRadioMale.Checked)
                        filter = "Male";
                    else if (internRadioFemale.Checked)
                        filter = "Female";

                    query += "AND Intern_Info.Gender = '" + filter + "' ";
                }

                if(internCheckUniversity.Checked)
                {
                    filter = internComboUniversity.SelectedValue.ToString();
                    query += "AND Intern_Info.University_ID = " + filter + " ";
                }

                if(internCheckOffice.Checked)
                {
                    filter = internComboOffice.SelectedValue.ToString();
                    query += "AND Intern_Info.Office_ID = " + filter + " ";
                }

                if(internCheckCourse.Checked)
                {
                    filter = internComboCourse.SelectedValue.ToString();
                    query += "AND Intern_Info.Course_ID = " + filter + " ";
                }

                ReportViewer rv = new ReportViewer();
                rv.viewInternReport(query);
                rv.ShowDialog();
            }
            else
            {
                ReportViewer rv = new ReportViewer();
                rv.viewInternReport(ReportQueries.reportsInternQuery());
                rv.ShowDialog();
            }
        }



        // -------------------- End Report Panel Intern Report Events --------------------

        // -------------------- Report Panel Acceptance Letter Events --------------------

        private void acceptanceDataGridIntern_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rv.viewAcceptanceLetter(acceptanceDataGridIntern.CurrentRow.Cells[0].Value.ToString());
            rv.ShowDialog();
        }

        // -------------------- End Report Panel Acceptance Letter Events --------------------

        // ============================== END EVENTS ==============================


    }
}
