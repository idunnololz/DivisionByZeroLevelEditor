using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace DivisionByZeroLevelBuilder
{
    public partial class AboutBox : UserControl
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblNameAndVersion.Text += " Version " + version;
        }

        private void windowControl1_Click(object sender, EventArgs e)
        {
            // dismiss this...
            dismiss();
        }

        private double time = 0;
        private const double DURATION = 0.5;
        private double b = 0;
        private double change = 0;

        private void dismiss()
        {
            if (!Visible)
            {
                return;
            }

            time = 0;

            change = -1;
            b = 1;

            aniDismiss.Start();
        }

        private void aniDismiss_Tick(object sender, EventArgs e)
        {
            time += aniDismiss.Interval / 1000.0;
            if (time < DURATION)
            {
                double t = time / DURATION;
                double l = change * t * t + b;

                Color c = Color.FromArgb((int)(255 * l), BackColor);
                BackColor = c;
                lblAuthor.BackColor = Color.Transparent;
                lblNameAndVersion.BackColor = Color.Transparent;
                label1.BackColor = Color.Transparent;
                windowControl1.BackColor = Color.Transparent;
                this.Invalidate();
            }
            else
            {
                this.Visible = false;
                BackColor = Color.FromArgb(255, BackColor);
                aniDismiss.Stop();
            }
        }
    }
}
