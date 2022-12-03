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

            // loads the university data grid view
            universityData();

            // loads the addresse data grid view
            coordinatorUniversityCombo();

        }

        /* --------------------INTERN PANEL---------------------  */
        public void btn_interns_panel_Click(object sender, EventArgs e)
        {
            main_menu_interns_panel.BringToFront();

            //intern button select
            internSelect();

            //Intern List
            internDataGrid();
            
            // loads the university data grid view
            //universityData();

            // loads the addresse data grid view
            //coordComboData();

            // intern datagridview resize column header
            setInternDataGridHeaderSize();

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

        public void internRefreshTable()
        {
            internDataGrid();
        }

        // ADD NEW INTERN BUTTON
        private void main_menu_interns_btn_newintern_Click(object sender, EventArgs e)
        {
            Add_Intern ai = new Add_Intern(this);
            ai.ShowDialog();
        }

        /*
         * COORDINATOR PANEL
         */

        // main_menu_univ_dataGridView
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
            main_menu_addresse_addresse_DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }


        private void btn_addresse_panel_Click(object sender, EventArgs e)
        {
            main_menu_addresse_panel.BringToFront();

            // coordinator button select
            coordinatorSelect();
            // loads the university data grid view
            //universityData();

            // loads the addresse data grid view
            coordinatorUniversityCombo();
            coordinatorDataGrid();

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
            // loads the university data grid view
            //universityData();

            // loads the addresse data grid view
            coordinatorUniversityCombo();
            coordinatorDataGrid();
        }

        /*
         * UNIVERSITIES PANEL
         */
        public void btn_univ_panel_Click(object sender, EventArgs e)
        {
            main_menu_univ_panel.BringToFront();

            // university button select
            universitySelect();

            // loads the university data grid view
            //universityData();

            // loads the addresse data grid view
            //coordComboData();
        }
        
        public void universityData()
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

        public void internDataGrid()
        {
            dataGridIntern.DataSource = menuQueries.viewInternPlain();
            dataGridIntern.ClearSelection();
            dataGridIntern.AutoResizeColumns();
        }

        // ADD NEW UNIVERSITY BUTTON
        private void main_menu_interns_btn_newUniv_Click(object sender, EventArgs e)
        {
            Add_University au = new Add_University(this);
            au.ShowDialog();
        }

        /*
         * REPORTS PANEL
         */
        private void btn_reports_panel_Click(object sender, EventArgs e)
        {
            main_menu_reports_panel.BringToFront();

            // reports button select
            reportSelect();
        }

        private void btn_logout_panel_Click(object sender, EventArgs e)
        {
            IMIS wf = new IMIS();
            wf.Show();
            this.Dispose();
        }

        // intern button select color
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

        private void btnTestReport_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer("Acceptance_Letter");
            rv.ShowDialog();
        }

        private void buttonInternReport_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer("Intern");
            rv.ShowDialog();
        }

        private void buttonInternFiltered_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rv.viewInternGender();
            rv.ShowDialog();
        }

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
    }
}
