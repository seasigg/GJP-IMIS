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
using GJP_IMIS.IMIS_Main_Menu;
using GJP_IMIS.IMIS_Class;
using GJP_IMIS.IMIS_Main_Menu.Addresse;

namespace GJP_IMIS.IMIS_Main_Menu.Interns
{
    public partial class Add_Intern : Form
    {
        public Add_Intern()
        {
            InitializeComponent();
        }

        public Main_Menu mainMenu;

        public Add_Intern(Main_Menu m)
        {
            InitializeComponent();
            
            mainMenu = m;
        }

        private void Add_Intern_Load(object sender, EventArgs e)
        {
            clearEntry();
            lblCoordinatorError.Text = "* Select a University First";
        }

        string pictureFile = "none";


        private void btnAddIntern_Click(object sender, EventArgs e)
        {
            if(Classes.checkData(this.Controls))
            {
                MessageBox.Show("MAY DATA");
            }
            else
            {
                MessageBox.Show("Walang DATA");
            }
        }

        private void dataValidation()
        {

        }

        /*private Boolean checkData()
        {

            if(Classes.checkData(this.Controls))
            {
                MessageBox.Show("MAY DATA");
                return true;
            }
            else
            {
                MessageBox.Show("Walang DATA");
                return false;
            }
                
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
            {
                mainMenu.internRefreshTable();
                this.Dispose();
            }
                
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

            Classes.clearTextBox(this.Controls);

            if (InternQueries.checkYearData())
                txtOJTNumber.Text = InternQueries.addOJTNumberIncrement();
            else
                txtOJTNumber.Text = DateTime.Now.Year.ToString() + "001";
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

        private void btnAddCoordinator_Click(object sender, EventArgs e)
        {
            if(comboUniversity.SelectedIndex != -1)
            {
                Add_Coordinator ac = new Add_Coordinator(comboUniversity.SelectedValue.ToString());
                ac.ShowDialog();
            }
            else
            {
                Add_Coordinator ac = new Add_Coordinator();
                ac.ShowDialog();
            }
        }

        private void comboUniversity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboUniversity.SelectedIndex != -1)
            {
                int comboValue = Convert.ToInt32(comboUniversity.SelectedValue.ToString());
                DataTable dt = InternQueries.checkCoordinator(comboValue);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        comboOJTCoordinator.Enabled = true;
                        comboOJTCoordinator.DataSource = dt;
                        comboOJTCoordinator.DisplayMember = "FullName";
                        comboOJTCoordinator.ValueMember = "Coordinator_ID";

                        lblCoordinatorError.Visible = false;
                    }
                    else
                    {
                        comboOJTCoordinator.Enabled = false;
                        comboOJTCoordinator.DataSource = null;
                        comboOJTCoordinator.Items.Clear();

                        lblCoordinatorError.Text = "* No Coordinator within selected university";
                    }
                }
            }
        }

        private void btnUploadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg, *.jpeg; *.png; *.bmp; *.gif)|*.jpg; *.jpeg; *.png; *.bmp; *.gif";
            if(open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                MessageBox.Show(open.FileName);
            }
        }

        private void btnClearPicture_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureFile = "none";
        }
    }
}
