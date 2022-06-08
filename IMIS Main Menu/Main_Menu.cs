using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GJP_IMIS.IMIS_Main_Menu.Interns;
using GJP_IMIS.IMIS_Main_Menu.University;
using GJP_IMIS.IMIS_Main_Menu.Addresse;

namespace GJP_IMIS.IMIS_Main_Menu
{
    public partial class Main_Menu : Form
    {
        // SELECTION COLOR FOR NAV BAR
        Color select = Color.FromArgb(242, 241, 239);
        Color deSelect = Color.FromArgb(46, 49, 49);

        public Main_Menu()
        {
            InitializeComponent();
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {
            main_menu_welcome_panel.BringToFront();

        }

        /* 
         * INTERN PANEL
         */
        private void btn_interns_panel_Click(object sender, EventArgs e)
        {
            main_menu_interns_panel.BringToFront();
            main_menu_intern_selector.BackColor = select;
            main_menu_addresse_selector.BackColor = deSelect;
            main_menu_univ_selector.BackColor = deSelect;
            main_menu_reports_selector.BackColor = deSelect;
        }
        // ADD NEW INTERN BUTTON
        private void main_menu_interns_btn_newintern_Click(object sender, EventArgs e)
        {
            Add_Interns ai = new Add_Interns();
            ai.Show();
        }

        /*
         * ADDRESSE PANEL
         */
        private void btn_addresse_panel_Click(object sender, EventArgs e)
        {
            main_menu_addresse_panel.BringToFront();
            main_menu_addresse_selector.BackColor = select;
            main_menu_intern_selector.BackColor = deSelect;
            main_menu_univ_selector.BackColor = deSelect;
            main_menu_reports_selector.BackColor = deSelect;
        }
        // ADD NEW ADDRESSE BUTTON
        private void main_menu_interns_btn_newaddresse_Click(object sender, EventArgs e)
        {
            Add_Addresse aa = new Add_Addresse();
            aa.Show();
        }

        /*
         * UNIVERSITIES PANEL
         */
        private void btn_univ_panel_Click(object sender, EventArgs e)
        {
            main_menu_univ_panel.BringToFront();
            main_menu_univ_selector.BackColor = select;
            main_menu_intern_selector.BackColor = deSelect;
            main_menu_addresse_selector.BackColor = deSelect;
            main_menu_reports_selector.BackColor = deSelect;
        }
        // ADD NEW UNIVERSITY BUTTON
        private void main_menu_interns_btn_newUniv_Click(object sender, EventArgs e)
        {
            Add_University au = new Add_University();
            au.Show();
        }

        /*
         * REPORTS PANEL
         */
        private void btn_reports_panel_Click(object sender, EventArgs e)
        {
            main_menu_reports_panel.BringToFront();
            main_menu_reports_selector.BackColor = select;
            main_menu_intern_selector.BackColor = deSelect;
            main_menu_addresse_selector.BackColor = deSelect;
            main_menu_univ_selector.BackColor = deSelect;
        }
    }
}
