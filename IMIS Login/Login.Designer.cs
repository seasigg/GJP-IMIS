
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.login_btn_login = new System.Windows.Forms.Button();
            this.login_txtUsername = new System.Windows.Forms.TextBox();
            this.login_txtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // login_btn_login
            // 
            this.login_btn_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.login_btn_login.Font = new System.Drawing.Font("Bell MT", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_btn_login.ForeColor = System.Drawing.Color.White;
            this.login_btn_login.Location = new System.Drawing.Point(256, 630);
            this.login_btn_login.Margin = new System.Windows.Forms.Padding(4);
            this.login_btn_login.Name = "login_btn_login";
            this.login_btn_login.Size = new System.Drawing.Size(216, 81);
            this.login_btn_login.TabIndex = 0;
            this.login_btn_login.Text = "Login";
            this.login_btn_login.UseVisualStyleBackColor = false;
            this.login_btn_login.Click += new System.EventHandler(this.login_btn_login_Click);
            // 
            // login_txtUsername
            // 
            this.login_txtUsername.Font = new System.Drawing.Font("Bell MT", 27.75F);
            this.login_txtUsername.Location = new System.Drawing.Point(344, 384);
            this.login_txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.login_txtUsername.Name = "login_txtUsername";
            this.login_txtUsername.Size = new System.Drawing.Size(448, 59);
            this.login_txtUsername.TabIndex = 2;
            // 
            // login_txtPass
            // 
            this.login_txtPass.Font = new System.Drawing.Font("Bell MT", 27.75F);
            this.login_txtPass.Location = new System.Drawing.Point(344, 497);
            this.login_txtPass.Margin = new System.Windows.Forms.Padding(4);
            this.login_txtPass.Name = "login_txtPass";
            this.login_txtPass.PasswordChar = '*';
            this.login_txtPass.Size = new System.Drawing.Size(448, 59);
            this.login_txtPass.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bell MT", 27.75F);
            this.label2.Location = new System.Drawing.Point(81, 384);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 54);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bell MT", 27.75F);
            this.label3.Location = new System.Drawing.Point(81, 500);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 54);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.button1.Font = new System.Drawing.Font("Bell MT", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(592, 630);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 81);
            this.button1.TabIndex = 6;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GJP_IMIS.Properties.Resources.IMIS_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(344, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(328, 303);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(919, 763);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.login_txtPass);
            this.Controls.Add(this.login_txtUsername);
            this.Controls.Add(this.login_btn_login);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}