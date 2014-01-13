using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeneralControlLibrary
{
    interface CustomToolStrip
    {
        Color SelectedColor { get; set; }
    }

    class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        CustomToolStrip strip;

        public CustomToolStripRenderer(CustomToolStrip strip)
        {
            this.strip = strip;
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) {
			if (!e.Item.Selected && !e.Item.Pressed){
				e.Graphics.FillRectangle(new SolidBrush(e.ToolStrip.BackColor), 0, 0, e.Item.Width, e.Item.Height);
			}else {
				e.Graphics.FillRectangle(new SolidBrush(strip.SelectedColor), 0, 0, e.Item.Width, e.Item.Height);
				//e.Graphics.DrawRectangle(new Pen(Color::FromArgb(32,32,32)), 0, 0, rc.Width - 1, rc.Height - 1);
			}
		}

		protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e) {
			e.Graphics.FillRectangle(new SolidBrush(e.Item.BackColor), 0, 0, e.ToolStrip.Bounds.Width, e.ToolStrip.Bounds.Height);
			e.Graphics.DrawLine(new Pen(Color.LightGray), 20, 3, e.Item.Width, 3);

			//e.Graphics.FillRectangle(new SolidBrush(Color::FromArgb(100,100,100)), 0, 0, e.Item.Width, e.Item.Height);
		}

		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e) {
            base.OnRenderItemText(e);
            /*
            StringFormat sf = new StringFormat();
            
			sf.Alignment = StringAlignment.Near;
			sf.LineAlignment = StringAlignment.Center;
			e.Graphics.DrawString(e.Text, e.TextFont, new SolidBrush(Color.Black), e.TextRectangle, sf);
		
             */ 
       }

		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e) {
            //base.OnRenderToolStripBackground(e);
            //e.Graphics.FillRectangle(new SolidBrush(Color::FromArgb(64,64,64)), 0, 0, e.ToolStrip.Bounds.Width, e.ToolStrip.Bounds.Height);
			//e.Graphics.DrawLine(new Pen(Color::FromArgb(32,32,32)), 20, 3, e.Item.Width, 3);

			//e.Graphics.FillRectangle(new SolidBrush(Color::FromArgb(100,100,100)), 0, 0, e.Item.Width, e.Item.Height);
		}

		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) {
			if(e.AffectedBounds.Width < 200)
				e.Graphics.DrawRectangle(new Pen(e.BackColor, 2), 0, 0, e.AffectedBounds.Width, e.AffectedBounds.Height);
			//e.Graphics.DrawLine(new Pen(Color::FromArgb(32,32,32)), 20, 3, e.Item.Width, 3);

			//e.Graphics.FillRectangle(new SolidBrush(Color::FromArgb(100,100,100)), 0, 0, e.Item.Width, e.Item.Height);
		}
    }
}
