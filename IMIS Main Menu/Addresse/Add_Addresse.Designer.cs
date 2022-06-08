
namespace GJP_IMIS.IMIS_Main_Menu.Addresse
{
    partial class Add_Addresse
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
            this.label7 = new System.Windows.Forms.Label();
            this.add_addresse_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.add_addresse_btn_confirm = new System.Windows.Forms.Button();
            this.add_addresse_btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(269, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 33);
            this.label7.TabIndex = 9;
            this.label7.Text = "Addresse:";
            // 
            // add_addresse_txt
            // 
            this.add_addresse_txt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F);
            this.add_addresse_txt.Location = new System.Drawing.Point(435, 208);
            this.add_addresse_txt.Name = "add_addresse_txt";
            this.add_addresse_txt.Size = new System.Drawing.Size(323, 31);
            this.add_addresse_txt.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 30F);
            this.label2.Location = new System.Drawing.Point(253, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(450, 46);
            this.label2.TabIndex = 10;
            this.label2.Text = "ADD NEW ADDRESSE";
            // 
            // add_addresse_btn_confirm
            // 
            this.add_addresse_btn_confirm.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.add_addresse_btn_confirm.Location = new System.Drawing.Point(645, 322);
            this.add_addresse_btn_confirm.Name = "add_addresse_btn_confirm";
            this.add_addresse_btn_confirm.Size = new System.Drawing.Size(113, 39);
            this.add_addresse_btn_confirm.TabIndex = 20;
            this.add_addresse_btn_confirm.Text = "CONFIRM";
            this.add_addresse_btn_confirm.UseVisualStyleBackColor = true;
            this.add_addresse_btn_confirm.Click += new System.EventHandler(this.add_addresse_btn_confirm_Click);
            // 
            // add_addresse_btn_cancel
            // 
            this.add_addresse_btn_cancel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.add_addresse_btn_cancel.Location = new System.Drawing.Point(435, 322);
            this.add_addresse_btn_cancel.Name = "add_addresse_btn_cancel";
            this.add_addresse_btn_cancel.Size = new System.Drawing.Size(113, 39);
            this.add_addresse_btn_cancel.TabIndex = 21;
            this.add_addresse_btn_cancel.Text = "CANCEL";
            this.add_addresse_btn_cancel.UseVisualStyleBackColor = true;
            this.add_addresse_btn_cancel.Click += new System.EventHandler(this.add_addresse_btn_cancel_Click);
            // 
            // Add_Addresse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1100, 521);
            this.Controls.Add(this.add_addresse_btn_cancel);
            this.Controls.Add(this.add_addresse_btn_confirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.add_addresse_txt);
            this.Name = "Add_Addresse";
            this.Text = "Add_Addresse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox add_addresse_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button add_addresse_btn_confirm;
        private System.Windows.Forms.Button add_addresse_btn_cancel;
    }
}