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

        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        SqlDataReader dr;

        // Part One Variables
        string int_fname, int_mname, int_lname, int_course, int_gender = "";
        // Part Two Variables
        string int_univ, int_addr = "";
        // Part Three Variables
        string int_office = "";

        int int_univ_id, int_addr_id, int_office_id = 0;

        private void Add_Interns_Load(object sender, EventArgs e)
        {
            add_intern_one.BringToFront();


            // part two of adding of interns univ & addresse datagridview
            addInternUniversityData();
            addInternAddresseData();

            // part three of adding of interns
            add_interns_office_combo();

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
        }

        // Data Grid View for Part Two - Addresse Data Grid
        public void addInternAddresseData()
        {
            add_intern_addresse_dataGridView.DataSource = InternQueries.addInternAddresseData();
            add_intern_addresse_dataGridView.ClearSelection();
        }

        //string for storing the string of the selected university
        string addInternUnivName;
        private void add_intern_univ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Connection_String.dbConnection();
                addInternUnivName = add_intern_univ_dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                cmd = new SqlCommand("SELECT * from Addresse_Info WHERE University = '" + addInternUnivName + "'", Connection_String.con);
                cmd.ExecuteNonQuery();

                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                add_intern_addresse_dataGridView.DataSource = dt;
                Connection_String.con.Close();
            }
        }
        private void add_intern_univ_addresse_clearSelection_Click(object sender, EventArgs e)
        {
            // refresh the university datagrid
            addInternUniversityData();
            // refresh the addresse datagrid
            addInternAddresseData();

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

        // add interns office combo box
        private void add_interns_office_combo()
        {
            Connection_String.dbConnection();
            add_intern_office_comboBox.Items.Clear();

            cmd = new SqlCommand("SELECT * from Office", Connection_String.con);

            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                add_intern_office_comboBox.Items.Add(r["Office_Abr"].ToString());
                //add_intern_office_comboBox.Items.Add(r["Office_Name"].ToString());
            }
        }

        // BUTTON FOR CONFIRMATION
        private void add_intern_btn_next3_Click(object sender, EventArgs e)
        {
            add_intern_four.BringToFront();

            // collect intern's information and store it to local variable
            internsFullInformation();

            // output the intern's full information
            outputInternsFullInformation(int_fname, int_mname, int_lname, int_course, int_gender, int_univ, int_addr, int_office);
        }

        // PART FOUR, OUTPUT PART
        // insertion of interns information to db
        private void insertInternInformation(string f, string m, string l, string c, string g, int u, int a, int o)
        {
            Connection_String.dbConnection();
            cmd = new SqlCommand("INSERT into Intern_Info VALUES ('"+f+"', '"+m+"', '"+l+"', '"+c+"', '"+a+"', '"+u+"', '"+g+"', '"+o+"')", Connection_String.con);
            cmd.ExecuteNonQuery();
            Connection_String.con.Close();
            MessageBox.Show("Intern Successfully Added.");
        }

        // GET UNIVERSITY ID
        public int getUnivId(string u)
        {
            int i = 0;
            Connection_String.dbConnection();
            cmd = new SqlCommand("SELECT * from University where University_Name = '" + u + "'", Connection_String.con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i = Int32.Parse(dr["University_ID"].ToString());
            }
            Connection_String.con.Close();
            return i;
        }

        // GET ADDRESSEE ID
        public int getAddrId(string a)
        {
            int addr = 0;
            Connection_String.dbConnection();
            cmd = new SqlCommand("SELECT * from Addresse_Info where Addresse_Name = '" + int_addr + "'", Connection_String.con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                addr = Int32.Parse(dr["Addresse_ID"].ToString());
            }
            Connection_String.con.Close();
            return addr;
        }

        // GET OFFICE ID
        public int getOfficeId(string o)
        {
            int of = 0;
            Connection_String.dbConnection();
            cmd = new SqlCommand("SELECT * from Office where Office_Abr = '" + o + "'", Connection_String.con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                of = Int32.Parse(dr["Office_ID"].ToString());
            }
            Connection_String.con.Close();
            return of;
        }

        // BUTTON TO CONFIRM INSERTION OF INTERN INFORMATION
        private void add_intern_btn_confirm_Click(object sender, EventArgs e)
        {

            insertInternInformation(int_fname, int_mname, int_lname, int_course, int_gender, getUnivId(int_univ), getAddrId(int_addr), getOfficeId(int_office));
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

        // method to collect all the intern's information
        private void internsFullInformation()
        {
            // part one
            int_fname = add_intern_txtFname.Text;
            int_mname = add_intern_txtMname.Text;
            int_lname = add_intern_txtLname.Text;
            int_course = add_intern_txtCourse.Text;
            int_gender = internGender();

            // part two
            int_univ = add_intern_univ_dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            int_addr = add_intern_addresse_dataGridView.SelectedRows[0].Cells[1].Value.ToString();

            // part three
            int_office = add_intern_office_comboBox.Text;
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

        private void outputInternsFullInformation(string f, string m, string l, string c, string g, string u, string a, string o) // first - mid - last name - course - gender - univ - addre - office
        {
            add_intern_output_fName.Text = f;
            add_intern_output_mName.Text = m;
            add_intern_output_lName.Text = l;
            add_intern_output_course.Text = c;
            add_intern_output_gender.Text = g;
            add_intern_output_univ.Text = u;
            add_intern_output_addresse.Text = a;
            add_intern_output_office.Text = o;

        }
    }
}
