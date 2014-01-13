using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DivisionByZeroLevelBuilder
{
    public partial class StartPage : UserControl
    {
        List<LinkLabel> labels = new List<LinkLabel>();

        public StartPage()
        {
            InitializeComponent();
        }

        private void StartPage_Load(object sender, EventArgs e)
        {
            var list = RecentList.Instance.GetRecentFiles();

            int y = lblRecent.Bottom;
            int j = 0;
            for (int i = list.Count - 1; i >= 0; i--, j++)
            {
                RecentFile f = list[i];
                LinkLabel label;
                if (j < labels.Count)
                {
                    label = labels[j];
                }
                else
                {
                    label = new LinkLabel();
                    label.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
                    label.LinkColor = Color.FromArgb(0, 81, 152);
                    label.ActiveLinkColor = Color.DarkGray;


                    label.Click += (Object s, EventArgs arg) =>
                    {
                        RecentFile recent = (RecentFile)((LinkLabel)s).Tag;

                        ItemSelected(this, new RecentEventArgs(recent));
                    };

                    labels.Add(label);
                }
                toolTip.SetToolTip(label, f.fullPath);
                label.Top = y + 3;
                label.Left = lblRecent.Left + 5;
                label.Text = f.levelName + " | " + f.fileName;
                label.AutoSize = true;
                label.ForeColor = Color.Black;
                label.Tag = f;

                this.Controls.Add(label);
                y = label.Bottom;

            }
        }

        public override void Refresh()
        {
            StartPage_Load(null, null);
            base.Refresh();
        }

        public class RecentEventArgs : EventArgs
        {
            public RecentFile ItemSelected { get;set; }

            public RecentEventArgs(RecentFile file)
                : base()
            {
                ItemSelected = file;
            }
        }

        public delegate void ItemSelectedEventHandler(object sender, RecentEventArgs e);
        public event ItemSelectedEventHandler ItemSelected;

        public delegate void NewLevelClickEventHandler(object sender, EventArgs e);
        public event NewLevelClickEventHandler NewLevelClick;

        private void windowControl1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void llNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewLevelClick(this, new EventArgs());
        }
    }
}
