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

using GJP_IMIS.IMIS_Main_Menu;
using GJP_IMIS.IMIS_Main_Menu.Interns;
using GJP_IMIS.IMIS_Class;
using GJP_IMIS.IMIS_Methods.Univ_Queries;

namespace GJP_IMIS.IMIS_Main_Menu.University
{
    public partial class Add_University : Form
    {
        public Main_Menu mainMenu;
        public Add_Intern ai;

        public bool fromAddIntern = false;
        public bool fromMainMenu = false;

        public Add_University()
        {
            InitializeComponent();
        }
        public Add_University(Main_Menu m)
        {
            InitializeComponent();
            fromMainMenu = true;
            fromAddIntern = false;
            mainMenu = m;
        }
        public Add_University(Add_Intern a)
        {
            InitializeComponent();
            fromMainMenu = false;
            fromAddIntern = true;
            ai = a;
        }

        private void add_univ_cancel_Click(object sender, EventArgs e)
        {
            if(fromMainMenu == true)
            {

            }

            if(fromAddIntern == true)
            {
                ai.clearUniversityCombo();
            }
            this.Dispose();
        }

        private void add_univ_confirm_Click(object sender, EventArgs e)
        {
            string univ = txtUniversity.Text;

            if(Classes.checkData(this.Controls))
            {
                DialogResult dr = MessageBox.Show("Add " + univ + "\nto the University Database?", "Add University", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    universityClass.addUniversity(univ);
                    MessageBox.Show(univ + " has been successfully added", "Add University", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUniversity.Clear();
                }
            }
            else
            {
                Classes.alert("Invalid Input");
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUniversity.Clear();
        }

        private void main_menu_univ_find_univ_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        private void Add_University_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(fromAddIntern == true)
            {
                ai.clearUniversityCombo();
            }
            if(fromMainMenu == true)
            {

            }
            this.Dispose();
        }
    }
}
