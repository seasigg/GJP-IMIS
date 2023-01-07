
namespace GJP_IMIS.IMIS_Main_Menu.Office
{
    partial class editOffice
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblOfficeId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOfficeName = new System.Windows.Forms.TextBox();
            this.txtOfficeAbbr = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(458, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "EDIT OFFICE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Office ID:";
            // 
            // lblOfficeId
            // 
            this.lblOfficeId.AutoSize = true;
            this.lblOfficeId.Location = new System.Drawing.Point(249, 127);
            this.lblOfficeId.Name = "lblOfficeId";
            this.lblOfficeId.Size = new System.Drawing.Size(31, 13);
            this.lblOfficeId.TabIndex = 2;
            this.lblOfficeId.Text = "// ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Office Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Office Abbreviation:";
            // 
            // txtOfficeName
            // 
            this.txtOfficeName.Location = new System.Drawing.Point(252, 161);
            this.txtOfficeName.Name = "txtOfficeName";
            this.txtOfficeName.Size = new System.Drawing.Size(226, 20);
            this.txtOfficeName.TabIndex = 5;
            // 
            // txtOfficeAbbr
            // 
            this.txtOfficeAbbr.Location = new System.Drawing.Point(252, 199);
            this.txtOfficeAbbr.Name = "txtOfficeAbbr";
            this.txtOfficeAbbr.Size = new System.Drawing.Size(226, 20);
            this.txtOfficeAbbr.TabIndex = 6;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(403, 273);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // editOffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 481);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtOfficeAbbr);
            this.Controls.Add(this.txtOfficeName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblOfficeId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "editOffice";
            this.Text = "editOffice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOfficeId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOfficeName;
        private System.Windows.Forms.TextBox txtOfficeAbbr;
        private System.Windows.Forms.Button btnUpdate;
    }
}