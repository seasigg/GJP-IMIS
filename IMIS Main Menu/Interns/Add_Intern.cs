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

using GJP_IMIS.IMIS_Methods.Intern_Queries;

namespace GJP_IMIS.IMIS_Main_Menu.Interns
{
    public partial class Add_Intern : Form
    {
        public Add_Intern()
        {
            InitializeComponent();
        }

        private void Add_Intern_Load(object sender, EventArgs e)
        {
            clearEntry();
        }

        private void dataValidation()
        {

        }

        /*private Boolean checkData()
        {
            if(txtFirstName)
        }*/

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("This will clear all data that has been entered. Proceed?", "Clear Entry", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                clearEntry();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Cancelling will take you back to the Main Menu. \nProceed?", "Cancel", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                MessageBox.Show("MainMenu"); 
        }

        public void clearEntry()
        {
            comboUniversity.DataSource = InternQueries.getUniversities();
            comboUniversity.DisplayMember = "University_Name";
            comboUniversity.ValueMember = "University_ID";
            comboUniversity.SelectedIndex = -1;

            comboCourse.DataSource = InternQueries.getCourses();
            comboCourse.DisplayMember = "Course_Name";
            comboCourse.ValueMember = "Course_ID";
            comboCourse.SelectedIndex = -1;

            comboOfficeDeployed.DataSource = InternQueries.getOffices();
            comboOfficeDeployed.DisplayMember = "Office_Name";
            comboOfficeDeployed.ValueMember = "Office_ID";
            comboOfficeDeployed.SelectedIndex = -1;

            IMIS_Class.Classes.clearTextBox(this.Controls); 
        }

 


        




        /* TextBox Alphabets Only Input */
        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtMiddleInitial_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        /* ComboBoxes */

        private void comboUniversity_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comboUniversity.DroppedDown = false;
        }

        private void comboCourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comboCourse.DroppedDown = false;
        }

        private void comboUniversity_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
