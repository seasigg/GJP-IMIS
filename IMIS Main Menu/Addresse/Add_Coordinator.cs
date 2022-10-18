﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GJP_IMIS.IMIS_Methods.Database_Connection;

using GJP_IMIS.IMIS_Methods.Coordinator_Queries;
using GJP_IMIS.IMIS_Class;

namespace GJP_IMIS.IMIS_Main_Menu.Addresse
{
    public partial class Add_Coordinator : Form
    {
        public Add_Coordinator()
        {
            InitializeComponent();
        }

        public Main_Menu mainMenu;
        string selectedUniv = null;
        public Add_Coordinator(string univID)
        {
            InitializeComponent();

            selectedUniv = univID;
        }

        SqlCommand cmd;

        string coord_fName;
        string coord_mName;
        string coord_lName;
        string coord_gender;
        string coord_pos;
        string coord_dep;
        int coord_univID;
        
        private void Add_Addresse_Load(object sender, EventArgs e)
        {
            populateUniversity();
            if (selectedUniv != null)
                comboUniversity.SelectedValue = selectedUniv;
        }

        private void populateUniversity()
        {
            comboUniversity.DataSource = CoordinatorQueries.getUniversity();
            comboUniversity.DisplayMember = "University_Name";
            comboUniversity.ValueMember = "University_ID";
            comboUniversity.SelectedIndex = -1;
        }

        // CANCEL BUTTON
        private void add_addresse_btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // SUBMIT BUTTON
        private void add_addresse_btn_confirm_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                coord_fName = txtFirstName.Text;
                coord_mName = txtMiddleName.Text;
                coord_lName = txtLastName.Text;
                coord_gender = getGender();
                coord_pos = txtPosition.Text;
                coord_dep = txtDepartment.Text;
                coord_univID = getUnivID();

                CoordinatorQueries.insertCoordinator(coord_fName, coord_mName, coord_lName, coord_gender, coord_pos, coord_dep, coord_univID);

                MessageBox.Show("OJT Coordinator Successfully Registered!");
            }
            else
            {
                MessageBox.Show("Details are Incomplete");
            }
        }

        private Boolean checkData()
        {
            return (Classes.checkDataCoord(this.Controls) && comboUniversity.SelectedIndex != -1 && (radioFemale.Checked || radioMale.Checked));
        }

        private String getGender()
        {
            string gender = null;
            if (radioMale.Checked)
                gender = radioMale.Text;
            if (radioFemale.Checked)
                gender = radioFemale.Text;

            return gender;
        }

        private int getUnivID()
        {
            return Int32.Parse(comboUniversity.SelectedValue.ToString());
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }
        private void txtMiddleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }
        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }
        private void txtPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }
        private void txtDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }
    }
}
