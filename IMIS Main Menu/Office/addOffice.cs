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
using GJP_IMIS.IMIS_Methods.Office_Queries;
using GJP_IMIS.IMIS_Main_Menu;
using GJP_IMIS.IMIS_Class;

namespace GJP_IMIS.IMIS_Main_Menu.Office
{
    public partial class addOffice : Form
    {
        public Main_Menu mm;
        public Add_Intern ai;

        bool fromMainMenu = false;
        bool fromAddIntern = false;

        public addOffice()
        {
            InitializeComponent();
        }
        public addOffice(Main_Menu m)
        {
            InitializeComponent();
            fromMainMenu = true;
            fromAddIntern = false;
            mm = m;
        }
        public addOffice(Add_Intern a)
        {
            InitializeComponent();
            fromMainMenu = false;
            fromAddIntern = true;
            ai = a;
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOffice.Clear();
            txtOfficeAbb.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(Classes.checkData(this.Controls))
            {
                string o = txtOffice.Text;
                string oa = txtOfficeAbb.Text;

                DialogResult dr = MessageBox.Show("Add Office: " + o + "\nAbbreviation: " + oa + "\ninto the Database?", "Add Office", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    OfficeQueries.insertOffice(o, oa);
                    MessageBox.Show("Office: " + o + "\nhas been succesfully added.", "Add Office", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOffice.Clear();
                    txtOfficeAbb.Clear();
                }
            }
            else
            {
                Classes.alert("Invalid Input");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(fromMainMenu == true)
            {

            }

            if(fromAddIntern == true)
            {
                ai.clearOfficeCombo();
            }
            this.Dispose();
        }

        private void addOffice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fromAddIntern == true)
                ai.clearOfficeCombo();
            if (fromMainMenu == true)
            {

            }
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
