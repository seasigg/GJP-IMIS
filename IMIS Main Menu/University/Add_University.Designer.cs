
namespace GJP_IMIS.IMIS_Main_Menu.University
{
    partial class Add_University
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
            this.txtUniversity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.add_univ_confirm = new System.Windows.Forms.Button();
            this.add_univ_cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUniversity
            // 
            this.txtUniversity.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F);
            this.txtUniversity.Location = new System.Drawing.Point(134, 125);
            this.txtUniversity.Name = "txtUniversity";
            this.txtUniversity.Size = new System.Drawing.Size(534, 31);
            this.txtUniversity.TabIndex = 5;
            this.txtUniversity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.main_menu_univ_find_univ_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(227, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "ADD NEW UNIVERSITY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "New University:";
            // 
            // add_univ_confirm
            // 
            this.add_univ_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_univ_confirm.Location = new System.Drawing.Point(479, 195);
            this.add_univ_confirm.Name = "add_univ_confirm";
            this.add_univ_confirm.Size = new System.Drawing.Size(189, 39);
            this.add_univ_confirm.TabIndex = 20;
            this.add_univ_confirm.Text = "Add";
            this.add_univ_confirm.UseVisualStyleBackColor = true;
            this.add_univ_confirm.Click += new System.EventHandler(this.add_univ_confirm_Click);
            // 
            // add_univ_cancel
            // 
            this.add_univ_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_univ_cancel.Location = new System.Drawing.Point(134, 195);
            this.add_univ_cancel.Name = "add_univ_cancel";
            this.add_univ_cancel.Size = new System.Drawing.Size(113, 39);
            this.add_univ_cancel.TabIndex = 21;
            this.add_univ_cancel.Text = "Cancel";
            this.add_univ_cancel.UseVisualStyleBackColor = true;
            this.add_univ_cancel.Click += new System.EventHandler(this.add_univ_cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(191, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "*Make sure to check if the university already exists";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(360, 195);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 39);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Add_University
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(695, 261);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.add_univ_cancel);
            this.Controls.Add(this.add_univ_confirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUniversity);
            this.Name = "Add_University";
            this.Text = "Add_University";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Add_University_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUniversity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add_univ_confirm;
        private System.Windows.Forms.Button add_univ_cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
    }
}