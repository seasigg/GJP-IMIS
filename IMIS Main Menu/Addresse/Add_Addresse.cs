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
using GJP_IMIS.IMIS_Methods.Database_Connection;

namespace GJP_IMIS.IMIS_Main_Menu.Addresse
{
    public partial class Add_Addresse : Form
    {
        public Add_Addresse()
        {
            InitializeComponent();
        }

        public Main_Menu mainMenu;
        public Add_Addresse(Main_Menu m)
        {
            InitializeComponent();

            mainMenu = m;
        }

        SqlCommand cmd;
        
        private void Add_Addresse_Load(object sender, EventArgs e)
        {
            populateUniversity();
        }

        private void populateUniversity()
        {
            Connection_String.dbConnection();
            add_addresse_comboBox.Items.Clear();
            cmd = new SqlCommand("SELECT * from University", Connection_String.con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                add_addresse_comboBox.Items.Add(dr["University_Name"].ToString());
            }
            Connection_String.con.Close();
        }

        private void addAddresse(string n, string p, string d, string s, string u) // name - position - department - salutation - university
        {
            Connection_String.dbConnection();
            cmd = new SqlCommand("INSERT into Addresse_Info VALUES ('" + n + "', '" + p + "', '" + d + "', '" + s + "', '" + u + "')", Connection_String.con);
            cmd.ExecuteNonQuery();
            Connection_String.con.Close();

            MessageBox.Show("Addresse added.");
        }

        // CANCEL BUTTON
        private void add_addresse_btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // SUBMIT BUTTON
        private void add_addresse_btn_confirm_Click(object sender, EventArgs e)
        {
            string add_name = add_addresse_name.Text;
            string add_pos = add_addresse_position.Text;
            string add_department = add_addresse_department.Text;
            string add_salutation = add_addresse_salutation.Text;
            string add_univ = add_addresse_comboBox.Text;

            addAddresse(add_name, add_pos, add_department, add_salutation, add_univ);

            mainMenu.addresseData();

            this.Close();
        }
    }
}
