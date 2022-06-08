using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GJP_IMIS.IMIS_Main_Menu.Addresse
{
    public partial class Add_Addresse : Form
    {
        public Add_Addresse()
        {
            InitializeComponent();
        }

        // CANCEL BUTTON
        private void add_addresse_btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // SUBMIT BUTTON
        private void add_addresse_btn_confirm_Click(object sender, EventArgs e)
        {
            // CODES TO SUBMIT THE ADDRESSE TO DB SSOB
            // REFRESH NA DEN NUNG PANEL NA ADDRESSE PARA ANDUN NA YUNG
            // BAGONG ADDRESSE SALAMAS


            this.Hide();
        }
    }
}
