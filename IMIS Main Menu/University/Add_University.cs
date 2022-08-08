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
using System.Data.SqlClient;
using GJP_IMIS.IMIS_Main_Menu;

namespace GJP_IMIS.IMIS_Main_Menu.University
{
    public partial class Add_University : Form
    {
        public Add_University()
        {
            InitializeComponent();
        }

        SqlCommand cmd;

        private void add_univ_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void addUniversity(string university)
        {
            Connection_String.dbConnection();
            cmd = new SqlCommand("INSERT into University VALUES ('" + university + "')", Connection_String.con);
            cmd.ExecuteNonQuery();
            Connection_String.con.Close();

            MessageBox.Show("University Added.");
        }

        private void add_univ_confirm_Click(object sender, EventArgs e)
        {
            // SUBMIT THE INPUTTED UNIV TO DB CODES DITO SSOB

            string univ_name = main_menu_univ_find_univ.Text;
            addUniversity(univ_name);

            Main_Menu m = new Main_Menu();
            m.universityData();
            m.Show();
            m.univPanelClicked();
            this.Hide();
        }
    }
}
