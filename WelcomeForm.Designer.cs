
namespace GJP_IMIS
{
    partial class WelcomeForm
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
            this.wc_btn_proceed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wc_btn_proceed
            // 
            this.wc_btn_proceed.Font = new System.Drawing.Font("Arial Rounded MT Bold", 30F);
            this.wc_btn_proceed.Location = new System.Drawing.Point(239, 160);
            this.wc_btn_proceed.Name = "wc_btn_proceed";
            this.wc_btn_proceed.Size = new System.Drawing.Size(298, 118);
            this.wc_btn_proceed.TabIndex = 0;
            this.wc_btn_proceed.Text = "PROCEED";
            this.wc_btn_proceed.UseVisualStyleBackColor = true;
            this.wc_btn_proceed.Click += new System.EventHandler(this.wc_btn_proceed_Click);
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(805, 427);
            this.Controls.Add(this.wc_btn_proceed);
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WelcomeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button wc_btn_proceed;
    }
}