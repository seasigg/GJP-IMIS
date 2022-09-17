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
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient;
using GJP_IMIS.IMIS_Methods.Database_Connection;
using GJP_IMIS.IMIS_Methods.Intern_Queries;

namespace GJP_IMIS.IMIS_Main_Menu.Interns
{
    public partial class Add_Interns : Form
    {
        public Add_Interns()
        {
            InitializeComponent();
        }

        public Main_Menu mainMenu;

        public Add_Interns(Main_Menu m)
        {
            InitializeComponent();

            mainMenu = m;
        }

        //Target Hours
        string targetHours;
        // OJT Number
        string int_ojt;
        // Part One Variables
        string int_fname, int_mname, int_lname, int_course, int_gender = "";
        // Part Two Variables
        string int_univ_name, int_addr_name = "", int_off_name;
        // Part Three Variables
        string addInternOfficeID = "";
        string addInternUnivID;
        string addInternAddresseID;



        private void Add_Interns_Load(object sender, EventArgs e)
        {
            add_intern_one.BringToFront();

            // part two of adding of interns univ & addresse datagridview
            addInternUniversityData();

            // part three of adding of interns
            addOfficeDataGrid();

            foreach (DataGridViewColumn column in add_intern_univ_dataGridView.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            foreach (DataGridViewColumn column in add_intern_addresse_dataGridView.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;


            if(InternQueries.checkYearData())
            {
                int_ojt = InternQueries.addOJTNumberIncrement();
            }
            else
            {
                int_ojt = DateTime.Now.Year.ToString() + "001";
            }
        }

        // PART ONE
        private void add_intern_btn_next1_Click(object sender, EventArgs e)
        {
            add_intern_two.BringToFront();
        }

        // PART TWO
        // Getting all data grids and queries from a seperate class at InternQueries.cs
        
        // Data Grid View for Part Two - University Data Grid
        public void addInternUniversityData()
        {
            add_intern_univ_dataGridView.DataSource = InternQueries.addInternUniversityData();
            add_intern_univ_dataGridView.ClearSelection();
            add_intern_univ_dataGridView.AutoResizeColumns();
            add_intern_univ_dataGridView.Columns["University_ID"].Visible = false;
        }

        // Data Grid View for Part Two - Addresse Data Grid

        //string for storing the string value of the selected university
        
        private void add_intern_univ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                addInternUnivID = add_intern_univ_dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                add_intern_addresse_dataGridView.DataSource = InternQueries.addInternAddresseData(addInternUnivID);
                add_intern_addresse_dataGridView.ClearSelection();
                add_intern_addresse_dataGridView.AutoResizeColumns();
                add_intern_addresse_dataGridView.Columns["Addresse_ID"].Visible = false;
                int_univ_name = add_intern_univ_dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                lblUnivSelected.Text = int_univ_name;
            }
        }

        private void add_intern_addresse_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                addInternAddresseID = add_intern_addresse_dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                int_addr_name = add_intern_addresse_dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                lblAddresseSelected.Text = int_addr_name;
            }
        }

        //Part Two Clear Selection Button
        private void add_intern_univ_addresse_clearSelection_Click(object sender, EventArgs e)
        {
            // refresh the university datagrid
            addInternUniversityData();
            // refresh the addresse datagrid
            add_intern_addresse_dataGridView.DataSource = null;
            add_intern_addresse_dataGridView.ClearSelection();

            lblUnivSelected.Text = "None";
            lblAddresseSelected.Text = "None";
        }

        private void add_intern_btn_prev2_Click(object sender, EventArgs e)
        {
            add_intern_one.BringToFront();
        }

        private void add_intern_btn_next2_Click(object sender, EventArgs e)
        {
            add_intern_three.BringToFront();
        }

        // PART THREE
        private void add_intern_btn_prev3_Click(object sender, EventArgs e)
        {
            add_intern_two.BringToFront();
        }

        // add interns office combo box (TO BE CHANGED)
        private void addOfficeDataGrid()
        {
            dataGridViewOffice.DataSource = InternQueries.addOfficeData();
            dataGridViewOffice.AutoResizeColumns();
            dataGridViewOffice.AutoResizeRows();
            dataGridViewOffice.ClearSelection();
            dataGridViewOffice.Columns["Office_ID"].Visible = false;
        }

        private void dataGridViewOffice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                addInternOfficeID = dataGridViewOffice.SelectedRows[0].Cells[0].Value.ToString();
                int_off_name = dataGridViewOffice.SelectedRows[0].Cells[1].Value.ToString();
                labelOfficeSelected.Text = int_off_name;
            }
        }

        // BUTTON FOR CONFIRMATION
        private void add_intern_btn_next3_Click(object sender, EventArgs e)
        {     
            add_intern_four.BringToFront();

            // collect intern's information and store it to local variable
            internsFullInformation();

            // output the intern's full information
            outputInternsFullInformation(int_ojt, int_fname, int_mname, int_lname, int_course, int_gender, int_univ_name, int_addr_name, int_off_name);
        }

        // method to collect all the intern's information
        private void internsFullInformation()
        {
            // part one
            int_fname = add_intern_txtFname.Text;
            int_mname = add_intern_txtMname.Text;
            int_lname = add_intern_txtLname.Text;
            int_course = add_intern_txtCourse.Text;
            int_gender = internGender();
            targetHours = textBoxTargetHours.Text;

        }
        // PART FOUR, OUTPUT PART

        // BUTTON TO CONFIRM INSERTION OF INTERN INFORMATION
        private void add_intern_btn_confirm_Click(object sender, EventArgs e)
        {
            InternQueries.addInternData(int_ojt, int_fname, int_mname, int_lname, int_course, int_gender, addInternUnivID, addInternAddresseID, addInternOfficeID);
            InternQueries.addInternStatus(int_ojt, targetHours);
            MessageBox.Show("Intern Number: " + int_ojt + " named as " + int_fname + " " + int_lname + " has been registered");
            
            mainMenu.internRefreshTable();

            this.Close();
        } 

        private void add_intern_editFname_Click(object sender, EventArgs e)
        {
            add_intern_one.BringToFront();
        }

        private void add_intern_editMname_Click(object sender, EventArgs e)
        {
            add_intern_one.BringToFront();
        }

        private void add_intern_editLname_Click(object sender, EventArgs e)
        {
            add_intern_one.BringToFront();
        }

        private void add_intern_editCourse_Click(object sender, EventArgs e)
        {
            add_intern_one.BringToFront();
        }

        

        private void add_intern_editGender_Click(object sender, EventArgs e)
        {
            add_intern_one.BringToFront();
        }

        private void add_intern_editUniversity_Click(object sender, EventArgs e)
        {
            add_intern_two.BringToFront();
        }

        private void add_intern_editAddresse_Click(object sender, EventArgs e)
        {
            add_intern_two.BringToFront();
        }
        private void add_intern_editOffice_Click(object sender, EventArgs e)
        {
            add_intern_three.BringToFront();
        }

        
        private string internGender()
        {
            string g = "";
            if (add_intern_btnMale.Checked)
                g = "Male";
            if (add_intern_btnFemale.Checked)
                g = "Female";
            return g;
        }

        private void outputInternsFullInformation(string ojt, string f, string m, string l, string c, string g, string u, string a, string o) // first - mid - last name - course - gender - univ - addre - office
        {
            lblOJTID.Text = int_ojt;
            add_intern_output_fName.Text = f;
            add_intern_output_mName.Text = m;
            add_intern_output_lName.Text = l;
            add_intern_output_course.Text = c;
            add_intern_output_gender.Text = g;
            add_intern_output_univ.Text = u;
            add_intern_output_addresse.Text = a;
            add_intern_output_office.Text = o;
            lblTargetHours.Text = targetHours;

        }
    }
}
