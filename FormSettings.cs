using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GJP_IMIS
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }
        string typeSetting = "";

        public FormSettings(string type)
        {
            InitializeComponent();
            disableAll();
            this.typeSetting = type;
            switch (type)
            {
                case "LOA": LOA();
                    break;
                case "COC": COC();
                    break;
                case "DTR": DTR();
                    break;

                default:
                    break;
            }
        }

        private void enableHalf()
        {
            lblSigneeName.Visible = true;
            lblSigneePos.Visible = true;

            txtSigneeName.Visible = true;
            txtSigneePos.Visible = true;
        }
        
        private void enableAll()
        {
            lblSigneeName.Visible = true;
            lblSigneeName1.Visible = true;
            lblSigneePos.Visible = true;
            lblSigneePos1.Visible = true;

            txtSigneeName.Visible = true;
            txtSigneeName1.Visible = true;
            txtSigneePos.Visible = true;
            txtSigneePos1.Visible = true;
        }

        private void disableAll()
        {
            lblSigneeName.Visible = false;
            lblSigneeName1.Visible = false;
            lblSigneePos.Visible = false;
            lblSigneePos1.Visible = false;

            txtSigneeName.Visible = false;
            txtSigneeName1.Visible = false;
            txtSigneePos.Visible = false;
            txtSigneePos1.Visible = false;
        }
        private void LOA()
        {
            lblTitle.Text = "Letter of Acceptance";
            txtSigneeName.Text = Settings1.Default.letter_Signee_Name;
            txtSigneePos.Text = Settings1.Default.letter_Signee_Position;
            enableHalf();
        }
        private void COC()
        {
            lblTitle.Text = "Certificate of Completion";
            txtSigneeName.Text = Settings1.Default.cert_Signee_Name;
            txtSigneePos.Text = Settings1.Default.cert_Signee_Position;
            enableHalf();
        }
        private void DTR()
        {
            lblTitle.Text = "DTR Signee";
            txtSigneeName.Text = Settings1.Default.dtr_Signee1_Name;
            txtSigneePos.Text = Settings1.Default.dtr_Signee1_Position;
            txtSigneeName1.Text = Settings1.Default.dtr_Signee2_Name;
            txtSigneePos1.Text = Settings1.Default.dtr_Signee2_Position;
            enableAll();
        }
        private void FormSettings_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            switch (typeSetting)
            {
                case "LOA":
                    Settings1.Default.letter_Signee_Name = txtSigneeName.Text;
                    Settings1.Default.letter_Signee_Position = txtSigneePos.Text;
                    break;
                case "COC":
                    Settings1.Default.cert_Signee_Name = txtSigneeName.Text;
                    Settings1.Default.cert_Signee_Position = txtSigneePos.Text;
                    break;
                case "DTR":
                    Settings1.Default.dtr_Signee1_Name = txtSigneeName.Text;
                    Settings1.Default.dtr_Signee1_Position = txtSigneePos.Text;
                    Settings1.Default.dtr_Signee2_Name = txtSigneeName1.Text;
                    Settings1.Default.dtr_Signee2_Position = txtSigneePos1.Text;
                    break;
            }
            Settings1.Default.Save();
            MessageBox.Show("Details updated.");
            this.Dispose();
        }
    }
}
