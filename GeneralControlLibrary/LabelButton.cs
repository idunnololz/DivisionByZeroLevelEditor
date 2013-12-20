using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralControlLibrary
{
    public class LabelButton : Button
    {
        private Color originalBackColor;
        private Color originalForeColor;

        [Description("Foreground color when mouse is hovered or clicked"), Category("Appearance")]
        public Color SecondaryForeColor
        {
            get;
            set;
        }

        [Description("Background color when mouse is hovered or clicked"), Category("Appearance")]
        public Color SecondaryBackColor
        {
            get;
            set;
        }

        public LabelButton()
            : base()
        {
            FlatAppearance.BorderSize = 0;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SecondaryForeColor = Color.Black;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            originalBackColor = this.BackColor;
            originalForeColor = this.ForeColor;
            this.BackColor = SecondaryBackColor;
            this.ForeColor = SecondaryForeColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = originalBackColor;
            this.ForeColor = originalForeColor;
        }
    }
}
