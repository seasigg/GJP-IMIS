using GJP_IMIS.IMIS_Main_Menu;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace GJP_IMIS
{
    public partial class IMIS : Form
    {
        public IMIS()
        {
            InitializeComponent();
        }

        static Form SplashScreen;
        static Form MainForm;
        [STAThread]

        private void wc_btn_proceed_Click(object sender, EventArgs e)
        {
            this.Hide();
            openMenu();
        }

        private static void openMenu()
        {
            SplashScreen = new loadingScreen();
            var splashThread = new Thread(new ThreadStart(
            () => Application.Run(SplashScreen)));
            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();

            MainForm = new Main_Menu_Remastered();
            MainForm.Load += MainForm_LoadCompleted;
            MainForm.Show();
        }

        private static void MainForm_LoadCompleted(object sender, EventArgs e)
        {
            if (SplashScreen != null && !SplashScreen.Disposing && !SplashScreen.IsDisposed)
                SplashScreen.Invoke(new Action(() => SplashScreen.Close()));
            MainForm.TopMost = true;
            MainForm.Activate();
            MainForm.TopMost = false;
        }

        private void IMIS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                this.Dispose();
                Application.Exit();
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dr = MessageBox.Show("Exit the Application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    this.Dispose();
                    Application.Exit();
                }
                else
                    e.Cancel = true;
            }
        }

        private void IMIS_Load(object sender, EventArgs e)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Connection String", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
