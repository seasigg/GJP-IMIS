using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GJP_IMIS.IMIS_Main_Menu.Interns;
using GJP_IMIS.IMIS_Methods.Intern_Queries;

namespace GJP_IMIS.IMIS_Main_Menu.Interns
{
    public partial class Add_Intern_Details : Form
    {
        public Add_Intern_Details()
        {
            InitializeComponent();
        }
        string ojtId, fName, midInit, lName, g, uId,
            courseId, coordId, offId, tHours, sDate,
            tDate,pic;
        public Add_Intern_Details(string ojtId, string fName, string midInit, string lName, string g, string uId,
            string courseId, string coordId, string offId, string tHours, string sDate, string tDate,
            string univName, string courseName, string coordName, string officeName, // DISPLAY ONLY
            string pic) 
        {
            InitializeComponent();

            lblOjt.Text = ojtId;
            lblFname.Text = fName;
            lblMid.Text = midInit;
            lblLast.Text = lName;
            lblGender.Text = g;
            lblUniv.Text = univName;
            lblCourse.Text = courseName;
            lblCoord.Text = coordName;
            lblOffice.Text = officeName;
            lblTargetHours.Text = tHours;
            lblStartDate.Text = sDate;
            lblTargetDate.Text = tDate;

            this.ojtId = ojtId;
            this.fName = fName;
            this.midInit = midInit;
            this.lName = lName;
            this.g = g;
            this.uId = uId;
            this.courseId = courseId;
            this.coordId = coordId;
            this.offId = offId;
            this.tHours = tHours;
            this.sDate = sDate;
            this.tDate = tDate;
            this.pic = pic;
            
        }

        
        private void btnReg_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("CONFIRM ADD INTERN", "Add Intern", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                
                InternQueries.addInternData(ojtId, fName, midInit, lName, g, courseId, uId, coordId, offId, pic);
                InternQueries.addInternStatus(ojtId, sDate, tDate, tHours);

                MessageBox.Show("Intern Successfully Registered on the Database", "Add Intern", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Dispose();
            }
            
        }
    }
}
