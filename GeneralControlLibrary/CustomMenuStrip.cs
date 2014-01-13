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
    public class CustomMenuStrip : MenuStrip, CustomToolStrip
    {
        [Description("The background color when the item is selected."), Category("Appearance")]
        public Color SelectedColor
        {
            get;
            set;
        }

        public CustomMenuStrip()
        {
            Renderer = new CustomToolStripRenderer(this);
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
			e.Graphics.FillRectangle(new SolidBrush(BackColor), e.ClipRectangle);
		}

		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;

			for(int i = 0; i < Items.Count; i++){                
				if(Items[i].Bounds.IntersectsWith(e.ClipRectangle)){
					// need to draw this...
					Rectangle r = Items[i].Bounds;

					if(Items[i].Selected || Items[i].Pressed){
						g.FillRectangle(new SolidBrush(SelectedColor), r);
					}

					StringFormat sf = new StringFormat();
					sf.Alignment = StringAlignment.Center;
					sf.LineAlignment = StringAlignment.Center;
					g.DrawString(Items[i].Text, Font, 
						new SolidBrush(ForeColor), r, sf); 
				}
			}

			//g.DrawLine(new Pen(Theme::hColor), 0, this->Height - 1, this->Width, this->Height - 1);
		}
    }
}
