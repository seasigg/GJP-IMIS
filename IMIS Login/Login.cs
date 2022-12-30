using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GJP_IMIS.IMIS_Main_Menu;
using GJP_IMIS.IMIS_Methods.Database_Connection;
using GJP_IMIS.IMIS_Main_Menu.Interns;
using GJP_IMIS;
using System.Data.SqlClient;

namespace GJP_IMIS.IMIS_Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login_btn_login_Click(object sender, EventArgs e)
        {

            Connection_String.dbConnection();
            String user = login_txtUsername.Text;
            String pass = login_txtPass.Text;
            String acc_type = "";
            SqlCommand cmd = new SqlCommand("SELECT * from User_Account where username = '" + user + "' and password = '" + pass + "'", Connection_String.con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
                acc_type = dr["user_type"].ToString();
            
            dr.Close();

            //MessageBox.Show(acc_type);

            Main_Menu m = new Main_Menu(acc_type);
            m.Show();
            this.Dispose();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                this.Dispose();
                Application.Exit();
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                IMIS wf = new IMIS();
                wf.Show();
                this.Dispose();
            }
        }
    }
}
