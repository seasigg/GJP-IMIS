
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
            this.main_menu_univ_find_univ = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.add_univ_confirm = new System.Windows.Forms.Button();
            this.add_univ_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // main_menu_univ_find_univ
            // 
            this.main_menu_univ_find_univ.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F);
            this.main_menu_univ_find_univ.Location = new System.Drawing.Point(307, 169);
            this.main_menu_univ_find_univ.Name = "main_menu_univ_find_univ";
            this.main_menu_univ_find_univ.Size = new System.Drawing.Size(398, 31);
            this.main_menu_univ_find_univ.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 30F);
            this.label2.Location = new System.Drawing.Point(226, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(471, 46);
            this.label2.TabIndex = 6;
            this.label2.Text = "ADD NEW UNIVERSITY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "University:";
            // 
            // add_univ_confirm
            // 
            this.add_univ_confirm.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.add_univ_confirm.Location = new System.Drawing.Point(584, 314);
            this.add_univ_confirm.Name = "add_univ_confirm";
            this.add_univ_confirm.Size = new System.Drawing.Size(113, 39);
            this.add_univ_confirm.TabIndex = 20;
            this.add_univ_confirm.Text = "CONFIRM";
            this.add_univ_confirm.UseVisualStyleBackColor = true;
            this.add_univ_confirm.Click += new System.EventHandler(this.add_univ_confirm_Click);
            // 
            // add_univ_cancel
            // 
            this.add_univ_cancel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.add_univ_cancel.Location = new System.Drawing.Point(206, 314);
            this.add_univ_cancel.Name = "add_univ_cancel";
            this.add_univ_cancel.Size = new System.Drawing.Size(113, 39);
            this.add_univ_cancel.TabIndex = 21;
            this.add_univ_cancel.Text = "CANCEL";
            this.add_univ_cancel.UseVisualStyleBackColor = true;
            this.add_univ_cancel.Click += new System.EventHandler(this.add_univ_cancel_Click);
            // 
            // Add_University
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(918, 394);
            this.Controls.Add(this.add_univ_cancel);
            this.Controls.Add(this.add_univ_confirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.main_menu_univ_find_univ);
            this.Name = "Add_University";
            this.Text = "Add_University";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox main_menu_univ_find_univ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add_univ_confirm;
        private System.Windows.Forms.Button add_univ_cancel;
    }
}