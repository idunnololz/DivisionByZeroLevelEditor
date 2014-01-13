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
    public partial class MapEditor : UserControl
    {
        private Map map;

        private double offX, offY, gridSize, zoom = 1;

        private int overTileX, overTileY;

        public void setMap(Map map)
        {
            if (this.map != map)
            {
                OnMapChanged();
            }
            this.map = map;
        }

        public MapEditor()
        {
            InitializeComponent();
        }

        public MapEditor(Map map)
        {
            setMap(map);
            InitializeComponent();
        }

        private void OnMapChanged()
        {
            if (map == null)
            {

            }
            else
            {
                // remeasure grid size...
                double co1 = (double)pnlMapDrawer.Width / pnlMapDrawer.Height;
                double co2 = (double)map.Width / map.Height;

                if (co1 > co2)
                {
                    // limiting factor is height...
                    gridSize = (double)pnlMapDrawer.Height / map.Height;
                }
                else
                {
                    gridSize = (double)pnlMapDrawer.Width / map.Width;
                }
            }
        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Object o in contextMenu.Items)
            {
                ((ToolStripMenuItem)o).Tag = i;
                i++;
            }

        }

        private void windowControl1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void pnlMapDrawer_Paint(object sender, PaintEventArgs e)
        {
            double s = gridSize * zoom;
            int ss = (int)s;
            int w = (int)(s * map.Width);
            int h = (int)(s * map.Height);
            int cleanX = (int)(offX * zoom);
            int cleanY = (int)(offY * zoom);
            double x = cleanX, y = cleanY;
            for (int _x = 0; _x < map.tiles.Count; _x++)
            {
                List<Tile> tiles = map.tiles[_x];
                for (int _y = 0; _y < tiles.Count; _y++)
                {
                    Tile t = tiles[_y];
                    Brush b;
                    if (t.IsBlocked() && !t.IsBuildable())
                    {
                        b = Brushes.Black;
                    }
                    else if (t.IsBlocked())
                    {
                        b = Brushes.DarkGray;
                    }
                    else if (!t.IsBuildable())
                    {
                        b = Brushes.Gray;
                    }
                    else
                    {
                        b = Brushes.LightGray;
                    }

                    if (_x == overTileX && _y == overTileY)
                    {
                        e.Graphics.FillRectangle(Brushes.AliceBlue, (int)(x + 1), (int)(y + 1), ss, ss);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(b, (int)(x + 1), (int)(y + 1), ss, ss);
                    }

                    y += s;
                }
                x += s;
                y = cleanY;
            }

            // draw a grid...
            x = cleanX;
            y = cleanY;
            for (int i = 0; i <= map.Width; i++)
            {
                e.Graphics.DrawLine(Pens.LightSlateGray, (int)x, cleanY, (int)x, h + cleanY);
                x += s;
            }
            for (int i = 0; i <= map.Height; i++)
            {
                e.Graphics.DrawLine(Pens.LightSlateGray, cleanX, (int)y, w + cleanX, (int)y);
                y += s;
            }
        }

        private void MapEditor_VisibleChanged(object sender, EventArgs e)
        {
            if (map == null)
            {

            }
            else
            {
                // remeasure grid size...
                double co1 = (double)pnlMapDrawer.Width / pnlMapDrawer.Height;
                double co2 = (double)map.Width / map.Height;

                if (co1 > co2)
                {
                    // limiting factor is height...
                    gridSize = (double)pnlMapDrawer.Height / map.Height;
                }
                else
                {
                    gridSize = (double)pnlMapDrawer.Width / map.Width;
                }
            }
        }

        private double startX, startY;
        private double lastX, lastY;
        private const double DRAG_SLOP = 10;
        private bool dragging = false;

        private double GetDist(double x1, double y1, double x2, double y2)
        {
            double x = x1 - x2;
            double y = y1 - y2;
            return Math.Sqrt((x * x) + (y * y));
        }

        private void pnlMapDrawer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dragging)
                {
                    offX += (e.X - lastX) / zoom;
                    offY += (e.Y - lastY) / zoom;
                    lastX = e.X;
                    lastY = e.Y;
                    pnlMapDrawer.Invalidate();
                }
                else if (GetDist(e.X, e.Y, startX, startY) > DRAG_SLOP)
                {
                    dragging = true;
                }
            }
            else
            {
                int oldX = overTileX;
                int oldY = overTileY;

                double tx = e.X / (gridSize * zoom) - (offX / gridSize);
                double ty = e.Y / (gridSize * zoom) - (offY / gridSize);
                overTileX = (int)(tx);
                overTileY = (int)(ty);

                if (overTileX >= map.Width || overTileY >= map.Height || tx < 0.0 || ty < 0.0)
                {
                    lblTileX.Text = "X -";
                    lblTileY.Text = "Y -";
                    overTileX = -1;
                    overTileY = -1;
                }
                else
                {
                    lblTileX.Text = "X " + overTileX;
                    lblTileY.Text = "Y " + overTileY;
                }

                if (overTileX != oldX || overTileY != oldY)
                    pnlMapDrawer.Invalidate();

            }
        }

        private void pnlMapDrawer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lastX = startX = e.X;
                lastY = startY = e.Y;
            }
        }

        private void ZoomIn(double pX, double pY)
        {
            zoom /= 0.75;
        }

        private void ZoomOut(double pX, double pY)
        {
            zoom *= 0.75;
        }

        private void pnlMapDrawer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ZoomIn(0, 0);
                pnlMapDrawer.Invalidate();
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            ZoomIn(0, 0);
            pnlMapDrawer.Invalidate();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOut(0, 0);
            pnlMapDrawer.Invalidate();
        }

        private void pnlMapDrawer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
            }
        }

        private void contextMenu_ResetSelection()
        {
            foreach (Object o in contextMenu.Items) {
                ((ToolStripMenuItem)o).Checked = false;
            }
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            contextMenu_ResetSelection();
            if (overTileX == -1)
            {
                return;
            }
            Tile t = map.tiles[overTileX][overTileY];
            if (t.IsBlocked() && !t.IsBuildable())
            {
                ((ToolStripMenuItem)contextMenu.Items[3]).Checked = true;
            }
            else if (t.IsBlocked())
            {
                ((ToolStripMenuItem)contextMenu.Items[2]).Checked = true;
            }
            else if (!t.IsBuildable())
            {
                ((ToolStripMenuItem)contextMenu.Items[1]).Checked = true;
            }
            else
            {
                ((ToolStripMenuItem)contextMenu.Items[0]).Checked = true;
            }
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (overTileX == -1)
            {
                return;
            }
            Tile t = map.tiles[overTileX][overTileY];
            switch ((int)((ToolStripMenuItem)e.ClickedItem).Tag)
            {
                case 0:
                    t.SetIsBlocked(false);
                    t.SetIsBuildable(true);
                    break;
                case 1:
                    t.SetIsBlocked(false);
                    t.SetIsBuildable(false);
                    break;
                case 2:
                    t.SetIsBlocked(true);
                    t.SetIsBuildable(true);
                    break;
                case 3:
                    t.SetIsBlocked(true);
                    t.SetIsBuildable(false);
                    break;
                default:
                    break;
            }

            pnlMapDrawer.Invalidate();
        }
    }
}
