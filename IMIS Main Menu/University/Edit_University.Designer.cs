
namespace GJP_IMIS.IMIS_Main_Menu.University
{
    partial class Edit_University
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUniversity = new System.Windows.Forms.TextBox();
            this.edit_univ_confirm = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.add_univ_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bell MT", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(219, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(405, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "EDIT EXISTING UNIVERSITY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "University Name:";
            // 
            // txtUniversity
            // 
            this.txtUniversity.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F);
            this.txtUniversity.Location = new System.Drawing.Point(208, 107);
            this.txtUniversity.Name = "txtUniversity";
            this.txtUniversity.Size = new System.Drawing.Size(534, 31);
            this.txtUniversity.TabIndex = 9;
            // 
            // edit_univ_confirm
            // 
            this.edit_univ_confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.edit_univ_confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edit_univ_confirm.Font = new System.Drawing.Font("Bell MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_univ_confirm.ForeColor = System.Drawing.Color.White;
            this.edit_univ_confirm.Location = new System.Drawing.Point(553, 186);
            this.edit_univ_confirm.Name = "edit_univ_confirm";
            this.edit_univ_confirm.Size = new System.Drawing.Size(189, 39);
            this.edit_univ_confirm.TabIndex = 21;
            this.edit_univ_confirm.Text = "Confirm";
            this.edit_univ_confirm.UseVisualStyleBackColor = false;
            this.edit_univ_confirm.Click += new System.EventHandler(this.edit_univ_confirm_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("Bell MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(413, 186);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 39);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // add_univ_cancel
            // 
            this.add_univ_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.add_univ_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add_univ_cancel.Font = new System.Drawing.Font("Bell MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_univ_cancel.ForeColor = System.Drawing.Color.White;
            this.add_univ_cancel.Location = new System.Drawing.Point(208, 186);
            this.add_univ_cancel.Name = "add_univ_cancel";
            this.add_univ_cancel.Size = new System.Drawing.Size(113, 39);
            this.add_univ_cancel.TabIndex = 25;
            this.add_univ_cancel.Text = "Cancel";
            this.add_univ_cancel.UseVisualStyleBackColor = false;
            // 
            // Edit_University
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 299);
            this.Controls.Add(this.add_univ_cancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.edit_univ_confirm);
            this.Controls.Add(this.txtUniversity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Edit_University";
            this.Text = "Edit_University";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUniversity;
        private System.Windows.Forms.Button edit_univ_confirm;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button add_univ_cancel;
    }
}