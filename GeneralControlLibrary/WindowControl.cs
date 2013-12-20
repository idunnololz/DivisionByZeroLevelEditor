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
    public class WindowControl : PictureBox
    {
        [Description("Color of the button when the mouse is placed over it."), Category("Appearance")]
        public Color OverColor
        {
            get;
            set;
        }

        [Description("Color of the button when the button is clicked."), Category("Appearance")]
        public Color DownColor
        {
            get;
            set;
        }

        [Description("Image of the button when the mouse is placed over it."), Category("Appearance")]
        public Image OverImage
        {
            get;
            set;
        }

        [Description("Image of the button when the button is clicked."), Category("Appearance")]
        public Image DownImage
        {
            get;
            set;
        }

        private Image originalImage;
        private Color originalBackColor;

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            originalImage = Image;
            originalBackColor = BackColor;

            Image = OverImage;
            BackColor = OverColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Image = originalImage;
            BackColor = originalBackColor;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Image = DownImage;
            BackColor = DownColor;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            OnMouseLeave(null);
        }
    }
}
