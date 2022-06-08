using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GJP_IMIS.IMIS_Main_Menu.Interns
{
    public partial class Add_Interns : Form
    {
        public Add_Interns()
        {
            InitializeComponent();
        }

        private void Add_Interns_Load(object sender, EventArgs e)
        {
            add_intern_one.BringToFront();
        }

        // PART ONE
        private void add_intern_btn_next1_Click(object sender, EventArgs e)
        {
            add_intern_two.BringToFront();
        }

        // PART TWO
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

        private void add_intern_btn_next3_Click(object sender, EventArgs e)
        {
            add_intern_four.BringToFront();
        }

        // PART FOUR, OUTPUT PART
        private void add_intern_btn_confirm_Click(object sender, EventArgs e)
        {
            // confirm button
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
    }
}
