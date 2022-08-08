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
            /*
             CODES TO LOGIN
             */


            Main_Menu m = new Main_Menu();
            this.Hide();
            m.Show();
        }
    }
}
