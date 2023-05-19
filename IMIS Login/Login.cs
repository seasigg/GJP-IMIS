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
            using(var con = new SqlConnection(Connection_String.conn))
            {
                con.Open();
                String user = login_txtUsername.Text;
                String pass = login_txtPass.Text;
                String acc_type = "";

                using (SqlCommand cmd = new SqlCommand("SELECT * from User_Account where username = '" + user + "' and password = '" + pass + "'", con))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        acc_type = dr["user_type"].ToString();
                        //Main_Menu m = new Main_Menu(acc_type);
                        //m.Show();
                        this.Dispose();

                        con.Dispose();
                    }
                    else
                        MessageBox.Show("Incorrect Credentials.");

                }
                
            }

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
