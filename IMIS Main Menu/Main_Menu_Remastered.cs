using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GJP_IMIS.IMIS_Main_Menu
{
    public partial class Main_Menu_Remastered : Form
    {
        public Main_Menu_Remastered()
        {
            InitializeComponent();
        }

        private void viewInternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewInternPanel.BringToFront();
        }

        private void addInternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addInternPanel.BringToFront();
        }

        private void editInternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editInternPanel.BringToFront();
        }

        private void deleteInternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteInternPanel.BringToFront();
        }

        private void viewDtrToolStripButton1_Click(object sender, EventArgs e)
        {
            viewDtrPanel.BringToFront();
        }

        private void acceptanceLetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acceptancePanel.BringToFront();
        }

        private void letterOfCompletionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            completionPanel.BringToFront();
        }

        private void reportsToolStripButton2_Click(object sender, EventArgs e)
        {
            reportsPanel.BringToFront();
        }
    }
}
