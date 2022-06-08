
namespace GJP_IMIS.IMIS_Login
{
    partial class Login
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
            this.login_btn_login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.login_txtUsername = new System.Windows.Forms.TextBox();
            this.login_txtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // login_btn_login
            // 
            this.login_btn_login.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F);
            this.login_btn_login.Location = new System.Drawing.Point(439, 348);
            this.login_btn_login.Name = "login_btn_login";
            this.login_btn_login.Size = new System.Drawing.Size(168, 66);
            this.login_btn_login.TabIndex = 0;
            this.login_btn_login.Text = "Login";
            this.login_btn_login.UseVisualStyleBackColor = true;
            this.login_btn_login.Click += new System.EventHandler(this.login_btn_login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F);
            this.label1.Location = new System.Drawing.Point(397, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "LOGIN FORM";
            // 
            // login_txtUsername
            // 
            this.login_txtUsername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.login_txtUsername.Location = new System.Drawing.Point(367, 163);
            this.login_txtUsername.Name = "login_txtUsername";
            this.login_txtUsername.Size = new System.Drawing.Size(337, 35);
            this.login_txtUsername.TabIndex = 2;
            // 
            // login_txtPass
            // 
            this.login_txtPass.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.login_txtPass.Location = new System.Drawing.Point(367, 242);
            this.login_txtPass.Name = "login_txtPass";
            this.login_txtPass.PasswordChar = '*';
            this.login_txtPass.Size = new System.Drawing.Size(337, 35);
            this.login_txtPass.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.label2.Location = new System.Drawing.Point(222, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.label3.Location = new System.Drawing.Point(222, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1031, 620);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.login_txtPass);
            this.Controls.Add(this.login_txtUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login_btn_login);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login_btn_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox login_txtUsername;
        private System.Windows.Forms.TextBox login_txtPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}