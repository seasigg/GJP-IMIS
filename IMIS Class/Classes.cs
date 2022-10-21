using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace GJP_IMIS.IMIS_Class
{
    class Classes
    {
        public static void clearTextBox(Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {
                if (ctrl is TextBoxBase)
                    ctrl.Text = String.Empty;
                else
                    clearTextBox(ctrl.Controls);
            }
        }

        public static Boolean checkData(Control.ControlCollection collection)
        {
            Boolean haveData = true;
            foreach (Control ctrl in collection)
            {
                if(ctrl is TextBoxBase)
                {
                    TextBox tb = ctrl as TextBox;
                    if(string.IsNullOrWhiteSpace(tb.Text))
                    {
                        haveData = false;
                    }
                }
            }

            return haveData;
        }

        public static Boolean checkDataCoord(Control.ControlCollection collection)
        {
            Boolean haveData = true;
            foreach (Control ctrl in collection)
            {
                if (ctrl is TextBoxBase)
                {
                    TextBox tb = ctrl as TextBox;
                    if (string.IsNullOrWhiteSpace(tb.Text))
                    {
                        haveData = false;
                    }
                }
            }

            return haveData;
        }

        public static void alert(string m)
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show(m);
        }
    }
}
