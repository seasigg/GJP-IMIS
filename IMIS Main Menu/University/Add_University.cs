using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GJP_IMIS.IMIS_Main_Menu.University
{
    public partial class Add_University : Form
    {
        public Add_University()
        {
            InitializeComponent();
        }

        private void add_univ_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void add_univ_confirm_Click(object sender, EventArgs e)
        {
            // SUBMIT THE INPUTTED UNIV TO DB CODES DITO SSOB



            this.Hide();
        }
    }
}
