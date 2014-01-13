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
    public class CustomButton : Button
    {
		const int LEAVE = 0, ENTER = 1;
		float saturation;
		int action;

        [Description("Background color of the button border when selected."), Category("Appearance")]
		public Color BorderColor { get; set; }

        [Description("Background color of the button when selected."), Category("Appearance")]
		public Color SelectedBackColor { get; set; }

		private Timer aTimer;
		private bool selected;

		public CustomButton() : base() {
			selected = false;
        	
            aTimer = new Timer();
			aTimer.Tick += new EventHandler(animate);
			aTimer.Interval = 10;
			aTimer.Enabled = false;

			this.SetStyle(
				//ControlStyles::OptimizedDoubleBuffer |
				ControlStyles.ResizeRedraw |
				ControlStyles.UserPaint,
				true);

			saturation = 0.0f;
		}

		void animate(Object sender, EventArgs  e){
			switch(action){
			case ENTER:
				if(saturation < 1.0f){
					saturation += 0.02f + 0.05f*saturation;
					Invalidate();
				} else
					aTimer.Enabled = false;

				if(saturation > 1.0f){ 
					saturation = 1.0f;
					aTimer.Enabled = false;
				}
				break;
			case LEAVE:
				if(saturation > 0.0f){
					saturation -= 0.02f + 0.05f*(1 - saturation);
					Invalidate();
				} else {
					saturation = 0.0f;
					aTimer.Enabled = false;
				}
				if(saturation < 0.0f) saturation = 0.0f;
				break;
			}
		}

		protected override void OnMouseDown(MouseEventArgs e) 
        {
			base.OnMouseDown(e);
            selected = true;
            Invalidate();
		}

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            selected = false;
			Invalidate();
		}

        protected override void OnMouseLeave(EventArgs e)
        {
			action = LEAVE;
			aTimer.Enabled = true;
		}

        protected override void OnMouseEnter(EventArgs e)
        {
			action = ENTER;
			aTimer.Enabled = true;
		}

        protected override void OnPaint(PaintEventArgs e)
        {
			Graphics gfx = e.Graphics;

			Brush bgBrush;
			if(!selected){
				bgBrush = new SolidBrush(BackColor);
			}else{
				bgBrush = new SolidBrush(SelectedBackColor);
			}

			Font f = Font;

			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;

            if (this.BackgroundImage != null)
            {
                gfx.DrawImage(this.BackgroundImage, e.ClipRectangle);
            }
            else
            {
                gfx.FillRectangle(bgBrush, e.ClipRectangle); 
            }

			gfx.DrawRectangle(new Pen(Color.FromArgb((int)(saturation*255), BorderColor)), 0, 
				0, this.Width - 1, this.Height - 1);
			Rectangle r = e.ClipRectangle;
			if(this.Enabled){
				gfx.DrawString(Text, f, new SolidBrush(ForeColor), this.ClientRectangle, sf);
			} else {
				gfx.DrawString(Text, f, 
					new SolidBrush(Color.FromArgb(100, ForeColor)), r, sf);
			}
		}

        protected override void OnPaintBackground(PaintEventArgs e)
        {
			Graphics gfx = e.Graphics;
			Brush bgBrush;
			if(!selected){
				bgBrush = new SolidBrush(BackColor);
			}else{
				bgBrush = new SolidBrush(SelectedBackColor);
			}

			gfx.FillRectangle(bgBrush, e.ClipRectangle); 
		}

        /*
        protected override void OnMove(EventArgs e)
        {
			Invalidate();
		}

        protected override void OnParentChanged(EventArgs e)
        {
			Invalidate();
		}
         * */

        //override void WndProc(Message m) {
        //    switch(m.Msg){
        //    case WM_PAINT:
        //        Invalidate();
        //        break;
        //    }

        //    Button::WndProc(m);

        //}
	
    }
}
