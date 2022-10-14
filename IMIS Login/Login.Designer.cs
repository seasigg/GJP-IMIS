
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
            this.login_txtUsername = new System.Windows.Forms.TextBox();
            this.login_txtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login_btn_login
            // 
            this.login_btn_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.login_btn_login.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_btn_login.ForeColor = System.Drawing.Color.White;
            this.login_btn_login.Location = new System.Drawing.Point(344, 456);
            this.login_btn_login.Name = "login_btn_login";
            this.login_btn_login.Size = new System.Drawing.Size(162, 66);
            this.login_btn_login.TabIndex = 0;
            this.login_btn_login.Text = "Login";
            this.login_btn_login.UseVisualStyleBackColor = false;
            this.login_btn_login.Click += new System.EventHandler(this.login_btn_login_Click);
            // 
            // login_txtUsername
            // 
            this.login_txtUsername.Font = new System.Drawing.Font("Bell MT", 27.75F);
            this.login_txtUsername.Location = new System.Drawing.Point(421, 255);
            this.login_txtUsername.Name = "login_txtUsername";
            this.login_txtUsername.Size = new System.Drawing.Size(337, 49);
            this.login_txtUsername.TabIndex = 2;
            // 
            // login_txtPass
            // 
            this.login_txtPass.Font = new System.Drawing.Font("Bell MT", 27.75F);
            this.login_txtPass.Location = new System.Drawing.Point(421, 347);
            this.login_txtPass.Name = "login_txtPass";
            this.login_txtPass.PasswordChar = '*';
            this.login_txtPass.Size = new System.Drawing.Size(337, 49);
            this.login_txtPass.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bell MT", 27.75F);
            this.label2.Location = new System.Drawing.Point(224, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 42);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bell MT", 27.75F);
            this.label3.Location = new System.Drawing.Point(231, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 42);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(596, 456);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 66);
            this.button1.TabIndex = 6;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1031, 620);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.login_txtPass);
            this.Controls.Add(this.login_txtUsername);
            this.Controls.Add(this.login_btn_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login_btn_login;
        private System.Windows.Forms.TextBox login_txtUsername;
        private System.Windows.Forms.TextBox login_txtPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}