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
    public class CustomContextMenuStrip : ContextMenuStrip, CustomToolStrip
    {
        [Description("The background color when the item is selected."), Category("Appearance")]
        public Color SelectedColor
        {
            get;
            set;
        }

        public CustomContextMenuStrip() : base()
        {
            Renderer = new CustomToolStripRenderer(this);
        }
    }
}
