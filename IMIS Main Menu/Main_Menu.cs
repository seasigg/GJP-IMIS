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

//QUERIES
using GJP_IMIS.IMIS_Methods.Database_Connection;
using GJP_IMIS.IMIS_Methods.Intern_Queries;
using GJP_IMIS.IMIS_Methods.Main_Menu_Queries;

namespace GJP_IMIS.IMIS_Main_Menu
{
    public partial class Main_Menu : Form
    {
        // SELECTION COLOR FOR NAV BAR
        Color selectBackColor = Color.FromArgb(51, 96, 185);
        Color selectForeColor = Color.FromArgb(255,255,255);
        Color deSelectBackColor = Color.FromArgb(255,255,255);
        Color deSelectForeColor = Color.FromArgb(0,0,0);

        // SQL COMMANDS
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

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
            addresseData();
        }

        /* 
         * INTERN PANEL
         */
        public void btn_interns_panel_Click(object sender, EventArgs e)
        {
            main_menu_interns_panel.BringToFront();

            //intern button select
            internSelect();

            //Intern List
            dataGridIntern.DataSource = menuQueries.viewInternPlain();
            dataGridIntern.ClearSelection();
            dataGridIntern.AutoResizeColumns();
            // loads the university data grid view
            universityData();

            // loads the addresse data grid view
            addresseData();

        }

        public void internRefreshTable()
        {
            dataGridIntern.DataSource = menuQueries.viewInternPlain();
            dataGridIntern.ClearSelection();
            dataGridIntern.AutoResizeColumns();
        }

        // ADD NEW INTERN BUTTON
        private void main_menu_interns_btn_newintern_Click(object sender, EventArgs e)
        {
            Add_Intern ai = new Add_Intern(this);
            ai.ShowDialog();
        }

        /*
         * ADDRESSE PANEL
         */

        // main_menu_univ_dataGridView
        public void addresseData()
        {
            main_menu_addresse_addresse_DataGrid.DataSource = menuQueries.addresseDataGrid();
            main_menu_addresse_addresse_DataGrid.Columns["Addresse_ID"].Visible = false;
            main_menu_addresse_addresse_DataGrid.AutoResizeColumns();
            main_menu_addresse_addresse_DataGrid.ClearSelection();
            
        }

        
        private void main_menu_addresse_univ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string addresseUnivID = main_menu_addresse_univ_DataGrid.SelectedRows[0].Cells[0].Value.ToString();

            main_menu_addresse_addresse_DataGrid.DataSource = menuQueries.filterAddresse(addresseUnivID);
            main_menu_addresse_addresse_DataGrid.ClearSelection();
        }

        private void btn_addresse_panel_Click(object sender, EventArgs e)
        {
            main_menu_addresse_panel.BringToFront();

            // coordinator button select
            coordinatorSelect();
            // loads the university data grid view
            universityData();

            // loads the addresse data grid view
            addresseData();
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
            universityData();

            // loads the addresse data grid view
            addresseData();
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
            universityData();

            // loads the addresse data grid view
            addresseData();
        }

        public void univPanelClicked()
        {
            main_menu_univ_panel.BringToFront();
            

            // loads the university data grid view
            universityData();

            // loads the addresse data grid view
            addresseData();
        }
        
        public void universityData()
        {
            main_menu_addresse_univ_DataGrid.DataSource = menuQueries.universityDataGrid();
            main_menu_univ_dataGridView.DataSource = menuQueries.universityDataGrid();

            main_menu_addresse_univ_DataGrid.AutoResizeColumns();
            main_menu_univ_dataGridView.AutoResizeColumns();

            main_menu_addresse_univ_DataGrid.ClearSelection();
            main_menu_univ_dataGridView.ClearSelection();;

            main_menu_addresse_univ_DataGrid.Columns["University_ID"].Visible = false;
        }
        // main_menu_univ_dataGridView


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

            // loads the university data grid view
            universityData();

            // loads the addresse data grid view
            addresseData();
        }

        private void btn_logout_panel_Click(object sender, EventArgs e)
        {
            this.Hide();
            IMIS wf = new IMIS();
            wf.Show();
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
    }
}
