
namespace GJP_IMIS.Reports
{
    partial class Report_Filter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxGender = new System.Windows.Forms.CheckBox();
            this.radioMale = new System.Windows.Forms.RadioButton();
            this.radioFemale = new System.Windows.Forms.RadioButton();
            this.checkBoxUniv = new System.Windows.Forms.CheckBox();
            this.comboUniversity = new System.Windows.Forms.ComboBox();
            this.comboOffice = new System.Windows.Forms.ComboBox();
            this.checkBoxOffice = new System.Windows.Forms.CheckBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.comboCourse = new System.Windows.Forms.ComboBox();
            this.checkBoxCourse = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // checkBoxGender
            // 
            this.checkBoxGender.AutoSize = true;
            this.checkBoxGender.Location = new System.Drawing.Point(115, 84);
            this.checkBoxGender.Name = "checkBoxGender";
            this.checkBoxGender.Size = new System.Drawing.Size(61, 17);
            this.checkBoxGender.TabIndex = 1;
            this.checkBoxGender.Text = "Gender";
            this.checkBoxGender.UseVisualStyleBackColor = true;
            this.checkBoxGender.CheckedChanged += new System.EventHandler(this.checkBoxGender_CheckedChanged);
            // 
            // radioMale
            // 
            this.radioMale.AutoSize = true;
            this.radioMale.Location = new System.Drawing.Point(148, 117);
            this.radioMale.Name = "radioMale";
            this.radioMale.Size = new System.Drawing.Size(48, 17);
            this.radioMale.TabIndex = 2;
            this.radioMale.TabStop = true;
            this.radioMale.Text = "Male";
            this.radioMale.UseVisualStyleBackColor = true;
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.Location = new System.Drawing.Point(227, 117);
            this.radioFemale.Name = "radioFemale";
            this.radioFemale.Size = new System.Drawing.Size(59, 17);
            this.radioFemale.TabIndex = 3;
            this.radioFemale.TabStop = true;
            this.radioFemale.Text = "Female";
            this.radioFemale.UseVisualStyleBackColor = true;
            // 
            // checkBoxUniv
            // 
            this.checkBoxUniv.AutoSize = true;
            this.checkBoxUniv.Location = new System.Drawing.Point(115, 159);
            this.checkBoxUniv.Name = "checkBoxUniv";
            this.checkBoxUniv.Size = new System.Drawing.Size(72, 17);
            this.checkBoxUniv.TabIndex = 4;
            this.checkBoxUniv.Text = "University";
            this.checkBoxUniv.UseVisualStyleBackColor = true;
            this.checkBoxUniv.CheckedChanged += new System.EventHandler(this.checkBoxUniv_CheckedChanged);
            // 
            // comboUniversity
            // 
            this.comboUniversity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboUniversity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboUniversity.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboUniversity.FormattingEnabled = true;
            this.comboUniversity.Location = new System.Drawing.Point(139, 182);
            this.comboUniversity.Name = "comboUniversity";
            this.comboUniversity.Size = new System.Drawing.Size(605, 29);
            this.comboUniversity.TabIndex = 31;
            // 
            // comboOffice
            // 
            this.comboOffice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboOffice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboOffice.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboOffice.FormattingEnabled = true;
            this.comboOffice.Location = new System.Drawing.Point(139, 255);
            this.comboOffice.Name = "comboOffice";
            this.comboOffice.Size = new System.Drawing.Size(605, 29);
            this.comboOffice.TabIndex = 33;
            // 
            // checkBoxOffice
            // 
            this.checkBoxOffice.AutoSize = true;
            this.checkBoxOffice.Location = new System.Drawing.Point(115, 232);
            this.checkBoxOffice.Name = "checkBoxOffice";
            this.checkBoxOffice.Size = new System.Drawing.Size(54, 17);
            this.checkBoxOffice.TabIndex = 32;
            this.checkBoxOffice.Text = "Office";
            this.checkBoxOffice.UseVisualStyleBackColor = true;
            this.checkBoxOffice.CheckedChanged += new System.EventHandler(this.checkBoxOffice_CheckedChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(669, 388);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 34;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // comboCourse
            // 
            this.comboCourse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboCourse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboCourse.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCourse.FormattingEnabled = true;
            this.comboCourse.Location = new System.Drawing.Point(139, 321);
            this.comboCourse.Name = "comboCourse";
            this.comboCourse.Size = new System.Drawing.Size(605, 29);
            this.comboCourse.TabIndex = 36;
            // 
            // checkBoxCourse
            // 
            this.checkBoxCourse.AutoSize = true;
            this.checkBoxCourse.Location = new System.Drawing.Point(115, 298);
            this.checkBoxCourse.Name = "checkBoxCourse";
            this.checkBoxCourse.Size = new System.Drawing.Size(59, 17);
            this.checkBoxCourse.TabIndex = 35;
            this.checkBoxCourse.Text = "Course";
            this.checkBoxCourse.UseVisualStyleBackColor = true;
            this.checkBoxCourse.CheckedChanged += new System.EventHandler(this.checkBoxCourse_CheckedChanged);
            // 
            // Report_Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 525);
            this.Controls.Add(this.comboCourse);
            this.Controls.Add(this.checkBoxCourse);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.comboOffice);
            this.Controls.Add(this.checkBoxOffice);
            this.Controls.Add(this.comboUniversity);
            this.Controls.Add(this.checkBoxUniv);
            this.Controls.Add(this.radioFemale);
            this.Controls.Add(this.radioMale);
            this.Controls.Add(this.checkBoxGender);
            this.Controls.Add(this.label1);
            this.Name = "Report_Filter";
            this.Text = "Report_Filter";
            this.Load += new System.EventHandler(this.Report_Filter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxGender;
        private System.Windows.Forms.RadioButton radioMale;
        private System.Windows.Forms.RadioButton radioFemale;
        private System.Windows.Forms.CheckBox checkBoxUniv;
        private System.Windows.Forms.ComboBox comboUniversity;
        private System.Windows.Forms.ComboBox comboOffice;
        private System.Windows.Forms.CheckBox checkBoxOffice;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox comboCourse;
        private System.Windows.Forms.CheckBox checkBoxCourse;
    }
}