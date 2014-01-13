using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DivisionByZeroLevelBuilder
{

    public partial class frmMain : Form
    {
        private const Int32 BORDER_SIZE = 3;

        private const string DATA_FOLDER = "dat";
        private const string APP_FOLDER = "app";
        private const string FILE_SPRITE_DATA = DATA_FOLDER + @"\sprite.dat";

        private Color THEME_COLOR = Color.FromArgb(0, 122, 204);

        private bool hasFocus = false;

        private int gripSize = 16;

        private FileState file = new FileState();

        private List<SpriteType> types = new List<SpriteType>();
        private List<Wave> waves = new List<Wave>();

        private Map map;
        private Level level = new Level();

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Rectangle rect = Screen.GetWorkingArea(this);
            this.MaximizedBounds = rect;

            setupListeners();

            level.Name = "";

            // more UI setup here...
            btnClose.DownColor = THEME_COLOR;
            btnMin.DownColor = THEME_COLOR;

            // create folders if needed...
            System.IO.Directory.CreateDirectory(DATA_FOLDER);
            System.IO.Directory.CreateDirectory(APP_FOLDER);

            RecentList.Instance.Load(APP_FOLDER);
            startPage1.Refresh();

            // try to load our sprite list...
            LoadData();

            // after all loading is done, update the forms with the appropriate options
            UpdateOptions();

            this.MinimumSize = new Size(this.MinimumSize.Width, pnlMain.Bottom + 10);
        }

        void LoadData()
        {
            types.Clear();

            if (!System.IO.File.Exists(FILE_SPRITE_DATA))
            {
                MessageBox.Show("Error. Unable to find sprite data file.");
            }
            else
            {
                string[] lines = System.IO.File.ReadAllLines(FILE_SPRITE_DATA);
                for (int i = 0; i < lines.Length; i++)
                {
                    var l = lines[i];
                    var tokens = l.Split('=');

                    SpriteType type = new SpriteType();
                    type.index = i;
                    type.typeName = tokens[0].Trim();

                    // extract the integer parts from the second token...
                    tokens[1] = tokens[1].Trim();
                    int n = 0;
                    for (int j = 0; j < tokens[1].Length; j++)
                    {
                        char c = tokens[1][j];
                        if (c >= '0' && c <= '9')
                        {
                            n *= 10;
                            n += (c - '0');
                        }
                    }

                    type.color = Color.FromArgb(Convert.ToInt32(tokens[2].Trim(), 16));

                    type.typeEnum = n;

                    types.Add(type);
                }
            }
        }

        void UpdateOptions()
        {
            cmbTypes.Items.Clear();
            foreach (SpriteType s in types)
            {
                cmbTypes.Items.Add(s.typeName);
            }

            OnPathCountChanged();
        }

        #region BasicWindowSource
        public const Int32 WM_NCHITTEST = 0x84;
        public const Int32 WM_SYSCOMMAND = 0x0112;
        public const Int32 HTCLIENT = 1;
        public const Int32 HTCAPTION = 2;
        public const Int32 WM_SIZE = 0x0005;

        const int WM_GETMINMAXINFO = 0x0024;
        const int WM_WINDOWPOSCHANGING = 0x0046;
        const int WM_WINDOWPOSCHANGED = 0x0047;
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        const int WM_NCCALCSIZE = 0x83;

        const int SWP_FRAMECHANGED = 0x20;

        private bool maxed = false;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left, top, right, bottom;

            public RECT(Rectangle rc)
            {
                this.left = rc.Left;
                this.top = rc.Top;
                this.right = rc.Right;
                this.bottom = rc.Bottom;
            }

            public Rectangle ToRectangle()
            {
                return Rectangle.FromLTRB(left, top, right, bottom);
            }

        }

        [StructLayout(LayoutKind.Sequential)]
        private struct NCCALCSIZE_PARAMS
        {
            public RECT rgrc0, rgrc1, rgrc2;
            public WINDOWPOS lppos;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WINDOWPOS
        {
            public IntPtr hWnd, hWndInsertAfter;
            public int x, y, cx, cy, flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public Int32 x;
            public Int32 y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        }

        int titleHeight = -1;

        bool maxing = false;

        protected override void WndProc(ref Message message)
        {
            //Debug.WriteLine("0x{0:X}", message.Msg);

            if (message.Msg == WM_WINDOWPOSCHANGING)
            {
                WINDOWPOS winpos = (WINDOWPOS)message.GetLParam(typeof(WINDOWPOS));

                //Debug.WriteLine("x: {0} | y: {1} | w: {2} | h: {3}", winpos.x, winpos.y, winpos.cx, winpos.cy);

                if ((winpos.flags & SWP_FRAMECHANGED) != 0 && winpos.x < 0 && winpos.y < 0)
                {
                    maxing = true;
                }
            }

            base.WndProc(ref message);

            switch (message.Msg)
            {
                case WM_GETMINMAXINFO:
                    // this is so that we can detect if we are maximizing the form before the form gets maximized
                    // by setting special position values

                    // detection is done in WM_WINDOWPOSCHANGING
                    MINMAXINFO minmax = (MINMAXINFO)message.GetLParam(typeof(MINMAXINFO));
                    minmax.ptMaxPosition.x = -1;
                    minmax.ptMaxPosition.y = -1;

                    Marshal.StructureToPtr(minmax, message.LParam, true);
                    break;
                case WM_NCHITTEST:
                    try
                    {
                        if (!maxed)
                        {
                            Point pos = new Point(message.LParam.ToInt32() & 0xffff, message.LParam.ToInt32() >> 16);
                            pos = this.PointToClient(pos);
                            if (pos.X >= this.ClientSize.Width - gripSize && pos.Y >= this.ClientSize.Height - gripSize)
                            {
                                message.Result = (IntPtr)17; // HTBOTTOMRIGHT
                                return;
                            }
                            else if (pos.Y >= this.ClientSize.Height - BORDER_SIZE)
                            {
                                if (pos.X <= BORDER_SIZE)
                                {
                                    message.Result = (IntPtr)16; //HTBOTTOMLEFT
                                }
                                else
                                {
                                    message.Result = (IntPtr)15; // HTBOTTOM
                                }
                                return;
                            }
                            else if (pos.Y <= BORDER_SIZE)
                            {
                                if (pos.X >= this.ClientSize.Width - BORDER_SIZE)
                                {
                                    message.Result = (IntPtr)14; //HTTOPRIGHT
                                }
                                else if (pos.X <= BORDER_SIZE)
                                {
                                    message.Result = (IntPtr)13; //HTTOPLEFT
                                }
                                else
                                {
                                    message.Result = (IntPtr)12; // HTTOP
                                }
                                return;
                            }
                            else if (pos.X >= this.ClientSize.Width - BORDER_SIZE)
                            {
                                message.Result = (IntPtr)11; // HTRIGHT
                                return;
                            }
                            else if (pos.X <= BORDER_SIZE)
                            {
                                message.Result = (IntPtr)10; // HTLEFT
                                return;
                            }
                        }
                    }
                    catch (System.ObjectDisposedException e)
                    {
                        /* do nothing */
                    }

                    if ((int)message.Result == HTCLIENT)
                        message.Result = (IntPtr)HTCAPTION;

                    message.Result = (IntPtr)HTCAPTION;

                    break;
                case WM_SIZE:
                    switch ((int)message.WParam)
                    {
                        case 2: // maxed...
                            restore = true;
                            //this.FormBorderStyle = FormBorderStyle.None;
                            btnRestore_MouseLeave(null, null);
                            maxed = true;
                            break;
                        case 0:
                            restore = false;
                            //this.FormBorderStyle = FormBorderStyle.Sizable;
                            btnRestore_MouseLeave(null, null);
                            maxed = false;
                            break;
                    }
                    break;
                case WM_WINDOWPOSCHANGING:
                    WINDOWPOS winpos = (WINDOWPOS)message.GetLParam(typeof(WINDOWPOS));

                    //Debug.WriteLine("x: {0} | y: {1} | w: {2} | h: {3}", winpos.x, winpos.y, winpos.cx, winpos.cy);

                    if ((winpos.flags & SWP_FRAMECHANGED) != 0 && winpos.x < 0 && winpos.y < 0)
                    {
                        maxing = true;
                    }
                    break;
                case WM_NCCALCSIZE:
                    if (titleHeight == -1)
                    {
                        titleHeight = SystemInformation.CaptionHeight;
                    }

                    if (maxing)
                    {
                        RECT rc = (RECT)message.GetLParam(typeof(RECT));
                        Rectangle r = rc.ToRectangle();
                        r.Y -= titleHeight;
                        r.Height += titleHeight;
                        Marshal.StructureToPtr(new RECT(r), message.LParam, true);
                        maxing = false;
                        return;
                    }

                    if (message.WParam.Equals(IntPtr.Zero))
                    {
                        RECT rc = (RECT)message.GetLParam(typeof(RECT));
                        Rectangle r = rc.ToRectangle();
                        r.Inflate(8, 8);
                        r.Y -= titleHeight;
                        r.Height += titleHeight;
                        Marshal.StructureToPtr(new RECT(r), message.LParam, true);
                    }
                    else
                    {
                        NCCALCSIZE_PARAMS csp = (NCCALCSIZE_PARAMS)message.GetLParam(typeof(NCCALCSIZE_PARAMS));
                        Rectangle r = csp.rgrc0.ToRectangle();
                        r.Inflate(8, 8);
                        r.Y -= titleHeight;
                        r.Height += titleHeight;
                        csp.rgrc0 = new RECT(r);
                        Marshal.StructureToPtr(csp, message.LParam, true);
                    }
                    message.Result = IntPtr.Zero;
                    break;
            }
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            this.btnClose.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_close_over;
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            this.btnClose.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_close;
            this.btnClose.BackColor = System.Drawing.Color.White;
        }

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnClose.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_close_down;
            this.btnClose.BackColor = THEME_COLOR;
        }

        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            btnClose_MouseEnter(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        bool restore = false;

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (restore)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }

            btnRestore_MouseLeave(null, null);
        }

        private void btnRestore_MouseDown(object sender, MouseEventArgs e)
        {
            if (restore)
                this.btnRestore.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_restore_down_down;
            else
                this.btnRestore.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_maximize_down;

            this.btnRestore.BackColor = THEME_COLOR;
        }

        private void btnRestore_MouseEnter(object sender, EventArgs e)
        {
            if (restore)
                this.btnRestore.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_restore_down_over;
            else
                this.btnRestore.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_maximize_over;

            this.btnRestore.BackColor = System.Drawing.SystemColors.Control;
        }

        private void btnRestore_MouseLeave(object sender, EventArgs e)
        {
            if (restore)
                this.btnRestore.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_restore_down;
            else
                this.btnRestore.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_maximize;

            this.btnRestore.BackColor = System.Drawing.Color.White;
        }

        private void btnRestore_MouseUp(object sender, MouseEventArgs e)
        {
            btnRestore_MouseEnter(null, null);
        }

        private void btnMin_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnMin.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_minimize_down;
            this.btnMin.BackColor = THEME_COLOR;
        }

        private void btnMin_MouseEnter(object sender, EventArgs e)
        {
            this.btnMin.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_minimize_over;
            this.btnMin.BackColor = System.Drawing.SystemColors.Control;
        }

        private void btnMin_MouseLeave(object sender, EventArgs e)
        {
            this.btnMin.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_minimize;
            this.btnMin.BackColor = System.Drawing.Color.White;
        }

        private void btnMin_MouseUp(object sender, MouseEventArgs e)
        {
            btnMin_MouseEnter(null, null);
        }
        #endregion

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            if (!maxed)
            {
                // draw grip...
                Rectangle rc = new Rectangle(this.ClientSize.Width - gripSize, this.ClientSize.Height - gripSize, gripSize, gripSize);
                //ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);

                // draw border over form...
                rc = new Rectangle(0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
                e.Graphics.DrawRectangle(Pens.Gray, rc);
            }
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();

            if (aboutBox.Visible)
            {
                aboutBox.Top = (this.Height - aboutBox.Height) / 2;
                aboutBox.Left = (this.Width - aboutBox.Width) / 2;
            }

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            file.IsDirty = true;

            Wave wave = new Wave();
            wave.index = waves.Count;
            lbWaves.Items.Add(wave);
            waves.Add(wave);

            // copy over previous wave info is possible...
            if (waves.Count != 1)
            {
                Wave last = waves[waves.Count - 2];
                wave.hp = last.hp;
                wave.reward = last.reward;
                wave.spawnCount = last.spawnCount;
                wave.spawnDelay = last.spawnDelay;
                wave.timeAllotted = last.timeAllotted;
            }
        }

        private int lastIndex = -1;
        private void lbWaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            recalculateStats();

            if (lastIndex != -1)
            {
                // save the page before loading a new one...
                saveWave(lastIndex);
                // invalidate to update information...
                lbWaves.Invalidate(lbWaves.GetItemRectangle(lastIndex));
            }
            lastIndex = lbWaves.SelectedIndex;
            if (lbWaves.SelectedIndex >= 0 && lbWaves.SelectedIndex < waves.Count)
            {
                pnlMain.Visible = true;
                Wave wave = waves[lbWaves.SelectedIndex];
                if (wave.spriteType == null)
                {
                    cmbTypes.SelectedIndex = -1;
                }
                else
                {
                    cmbTypes.SelectedIndex = wave.spriteType.index;
                }

                trySetNumericUpDown(txtHp, wave.hp);
                trySetNumericUpDown(txtReward, wave.reward);
                trySetNumericUpDown(txtAmount, wave.spawnCount);
                trySetNumericUpDown(txtSpawnDelay, wave.spawnDelay);
                trySetNumericUpDown(txtTimeAllotted, wave.timeAllotted);

                if (pnlSpawnPoint.Visible == true && wave.entrance != '\0')
                {
                    cmbSpawnPoint.SelectedIndex = wave.entrance - 'a';
                }
            }
            else
            {
                pnlMain.Visible = false;
            }
        }

        void trySetNumericUpDown(NumericUpDown ctr, int value)
        {
            if (value >= ctr.Minimum && value <= ctr.Maximum)
            {
                ctr.Value = value;
            }
        }

        void saveWave(int index)
        {
            if (index == -1) return;

            var wave = waves[index];
            if (cmbTypes.SelectedIndex == -1)
            {
                wave.spriteType = null;
            }
            else
            {
                wave.spriteType = types[cmbTypes.SelectedIndex];
            }
            wave.hp = Convert.ToInt32(txtHp.Value);
            wave.reward = Convert.ToInt32(txtReward.Value);
            wave.spawnCount = Convert.ToInt32(txtAmount.Value);
            wave.spawnDelay = Convert.ToInt32(txtSpawnDelay.Value);
            wave.timeAllotted = Convert.ToInt32(txtTimeAllotted.Value);
            wave.entrance = (char)('a' + cmbSpawnPoint.SelectedIndex);
        }

        private int lastSelectedIndex = -1;
        private void lbWaves_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                return;
            }
            var wave = (Wave)lbWaves.Items[e.Index];
            if (e.Index == lbWaves.SelectedIndex)
            {

                if (lastSelectedIndex == -1 || lastSelectedIndex == e.Index)
                {
                }
                else
                {
                    lbWaves.Invalidate(lbWaves.GetItemRectangle(lastSelectedIndex));
                }

                lastSelectedIndex = lbWaves.SelectedIndex;

                e.Graphics.FillRectangle(Brushes.Blue, e.Bounds);
                e.Graphics.DrawString("Wave " + (wave.index + 1), lbWaves.Font, Brushes.White, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);

                if (wave.spriteType == null)
                {
                    e.Graphics.DrawString("Wave " + (wave.index + 1), lbWaves.Font, Brushes.Gray, e.Bounds);
                }
                else
                {
                    e.Graphics.DrawString("Wave " + (wave.index + 1), lbWaves.Font, Brushes.Black, e.Bounds);
                }
            }

            if (wave.spriteType == null)
            {
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(wave.spriteType.color),
                    e.Bounds.Right - 20, e.Bounds.Y, 20, e.Bounds.Height);

                if (e.Index > 0)
                {
                    var prevWave = (Wave)lbWaves.Items[e.Index - 1];
                    if (wave.timeAllotted == 0)
                    {
                        if (prevWave.timeAllotted != 0)
                        {
                            // this is the first one in the chain!
                            e.Graphics.FillRectangle(Brushes.DarkGray, e.Bounds.Right - 14,
                                e.Bounds.Y + 4, 8, e.Bounds.Height - 4);
                        }
                        else
                        {
                            // fill the whole thing otherwise to connect the chain
                            e.Graphics.FillRectangle(Brushes.DarkGray, e.Bounds.Right - 14,
                                e.Bounds.Y, 8, e.Bounds.Height);
                        }
                    }
                    else if (prevWave.timeAllotted == 0)
                    {
                        // this is the last one in the chain!
                        e.Graphics.FillRectangle(Brushes.DarkGray, e.Bounds.Right - 14,
                            e.Bounds.Y, 8, e.Bounds.Height - 4);
                    }
                }
                else if (e.Index == 0)
                {
                    if (wave.timeAllotted == 0)
                    {
                        // this is the first one in the chain!
                        e.Graphics.FillRectangle(Brushes.DarkGray, e.Bounds.Right - 14,
                            e.Bounds.Y + 4, 8, e.Bounds.Height - 4);
                    }
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            UpdateOptions();
        }

        MapEditor mapEditor;
        AnimationValues valMapEditor = new AnimationValues();

        class AnimationValues
        {
            public double c, t, d, b;

            public bool isAlive()
            {
                return t < d;
            }
        }

        private void mapEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapEditor == null)
            {
                mapEditor = new MapEditor(map);
                mapEditor.Width = this.Width - 2;
                mapEditor.Height = this.Height - menuStrip.Top - 1;
                mapEditor.Height = this.Height - menuStrip.Top - 12;
                mapEditor.Left = 1;
                mapEditor.Visible = false;
                mapEditor.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;

                this.Controls.Add(mapEditor);
                mapEditor.BringToFront();
            }

            mapEditor.setMap(map);

            mapEditor.Top = mapEditor.Height;
            mapEditor.Visible = true;
            valMapEditor.c = (menuStrip.Top) - mapEditor.Height;
            valMapEditor.t = 0;
            aniMapEditorIn.Start();
            valMapEditor.b = mapEditor.Top;
            valMapEditor.d = 0.7;
            aniMapEditorIn.Start();
        }

        private void aniMapEditorIn_Tick(object sender, EventArgs e)
        {
            valMapEditor.t += aniMapEditorIn.Interval / 1000.0;
            if (valMapEditor.isAlive())
            {
                double t = valMapEditor.t / valMapEditor.d;
                t--;
                double f = valMapEditor.c * (t * t * t + 1) + valMapEditor.b;
                mapEditor.Top = (int)f;
            }
            else
            {
                mapEditor.Top = (int)(valMapEditor.c + valMapEditor.b);
                aniMapEditorIn.Stop();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open DBZ Level File";
            theDialog.Filter = "DBZ Level Files|*.dbzl";
            //theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                var stream = theDialog.OpenFile();
                using (stream)
                {
                    LoadLevelFromFile(theDialog.FileName);

                    RecentList.Instance.AddRecent(theDialog.FileName, level.Name);
                    startPage1.Refresh();
                }
            }
        }

        private const char TYPE_INIT_LIVES = 'l',
            TYPE_INIT_GOLD = 'g',
            TYPE_SPAWN = 's',
            TYPE_SPAWN_BOSS = 'b',
            TYPE_SLEEP = 'p',	// pause
            TYPE_MESSAGE = 'm',
            TYPE_MAP = 'a',
            TYPE_SPECIAL = '!',
            TYPE_DIFFICULTY = '#',
            TYPE_LEVEL_NAME = '$';

        private void LoadLevelFromFile(string filename)
        {
            string[] filelines = File.ReadAllLines(filename);

            Level lev = new Level();
            Map m = lev.Map;
            List<Wave> waves = lev.Waves;

            for (int i = 0; i < filelines.Length; i++)
            {
                string l = filelines[i];

                if (l.Length == 0 || l[0] == '/')
                    continue;

                int index = l.IndexOf("//");
                if (index != -1)
                {
                    l = l.Substring(0, index);
                }

                char type = l[0];

                l = l.Substring(1);
                l = l.Trim();

                switch (type)
                {
                    case TYPE_MAP:
                        var tokens = l.Split(' ');
                        if (tokens.Length >= 1)
                        {
                            m.mapId = Convert.ToInt32(tokens[0]);
                        }

                        if (tokens.Length >= 3)
                        {
                            int w = Convert.ToInt32(tokens[1]);
                            int h = Convert.ToInt32(tokens[2]);
                            m.Width = w;
                            m.Height = h;
                        }

                        if (tokens.Length >= 4)
                        {
                            m.PathCount = Convert.ToInt32(tokens[3]);
                        }
                        else
                        {
                            m.PathCount = 0;
                        }


                        // we need to do preprocessing before reading in the map...
                        string[] symmap = new string[10];
                        int extraOffset = 0;
                        if (m.PathCount != 0)
                        {
                            int extras = Convert.ToInt32(filelines[i + m.Height + 1].Trim());
                            extraOffset = extras + 1;
                            for (int j = i + m.Height + 1; j < i + m.Height + extras + 2; j++)
                            {
                                string line = filelines[j];
                                var t = line.Split(' ');
                                int sysdex = Convert.ToInt32(t[0]);
                                for (int k = 1; k < t.Length; k++)
                                {
                                    symmap[sysdex] += t[k];
                                }
                            }
                        }

                        // process the map data...
                        m.build();

                        for (int y = 0; y < m.Height; y++)
                        {
                            i++;
                            string line = filelines[i];
                            for (int x = 0; x < line.Length; x++)
                            {
                                char c = line[x];
                                if (c == '#')
                                {
                                    m.tiles[x][y].SetIsBuildable(false);
                                }
                                else if (c == '*')
                                {
                                    m.tiles[x][y].SetIsBlocked(true);
                                }
                                else if (c == '@')
                                {
                                    m.tiles[x][y].SetIsBuildable(false);
                                    m.tiles[x][y].SetIsBlocked(true);
                                }
                                else if (c == '_')
                                {
                                    // empty tile...
                                }
                                else if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z')
                                {
                                    m.tiles[x][y].AddSymbol(c);
                                }
                                else if (c >= '0' && c <= '9')
                                {
                                    string syms = symmap[c - '0'];

                                    if (syms == null || syms.Length == 0)
                                    {
                                        MessageBox.Show("File format exception. No definition found for token " + c + ".");
                                        goto Outside;
                                    }

                                    for (int j = 0; j < syms.Length; j++)
                                    {
                                        m.tiles[x][y].AddSymbol(syms[j]);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Unsupported map tile flag! Type denoted by symbol '" + c + "' is currently not supported.");
                                    goto Outside;
                                }
                            }
                        }

                        i += extraOffset;

                        break;
                    case TYPE_DIFFICULTY:
                        lev.Difficulty = Convert.ToInt32(l);
                        break;
                    case TYPE_LEVEL_NAME:
                        lev.Name = l;
                        break;
                    case TYPE_INIT_LIVES:
                        lev.StartingLives = Convert.ToInt32(l);
                        break;
                    case TYPE_INIT_GOLD:
                        lev.StartingGold = Convert.ToInt32(l);
                        break;
                    case TYPE_SPAWN_BOSS:
                    case TYPE_SPAWN:
                        Wave wave = new Wave();
                        wave.index = waves.Count;

                        var temp = Regex.Split(l, "[ \t]+");
                        wave.spriteType = types[Convert.ToInt32(temp[0]) - 1];
                        wave.spawnCount = Convert.ToInt32(temp[1]);
                        wave.spawnDelay = Convert.ToInt32(temp[2]);
                        wave.hp = Convert.ToInt32(temp[3]);
                        wave.reward = Convert.ToInt32(temp[4]);
                        if (temp.Length > 5)
                            wave.entrance = temp[5][0];
                        waves.Add(wave);
                        break;
                    case TYPE_SLEEP:
                        if (waves.Count > 0)
                        {
                            Wave ww = waves[waves.Count - 1];
                            ww.timeAllotted += Convert.ToInt32(l);
                        }
                        break;
                    default:
                        MessageBox.Show("Unsupported type error! Type denoted by symbol '" + type + "' is currently not supported.");
                        goto Outside;
                };
            }

            // if we are here that means loading of the level file completed without a hitch!
            // construct the level object and set it!

            lev.Map = m;
            lev.Waves = waves;

            level_NameChanged(lev.Name);

            setLevelDifficulty(lev.Difficulty);

            this.level = lev;
            map = m;
            this.waves = waves;

            lbWaves.Items.Clear();

            // do last setup
            setupListeners();

            foreach (Wave w in waves)
            {
                lbWaves.Items.Add(w);
            }

            // set file...
            file.FileName = filename;

            // update the UI...
            OnPathCountChanged();

        Outside:
            return;
        }

        private void setupListeners()
        {
            level.NameChanged += level_NameChanged;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file.FileName != null)
            {
                saveWave(lbWaves.SelectedIndex);
                using (StreamWriter sw = new StreamWriter(file.FileName))
                {
                    saveTo(sw);
                }
            }
            else
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "DBZ Level Files (*.dbzl)|*.dbzl";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = saveFileDialog.OpenFile()) != null)
                {
                    file.FileName = saveFileDialog.FileName;

                    using (StreamWriter sw = new StreamWriter(stream))
                    {
                        saveTo(sw);
                    }
                    stream.Close();
                }
            }
        }

        private void saveTo(StreamWriter sw)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            List<String> extras = new List<String>();

            sw.WriteLine(@"// Auto generated by DBZ Level Builder version " + version);
            sw.WriteLine(@"// BEGIN ");

            // first write map info...
            Map m = level.Map;

            sw.Write(TYPE_MAP + " " + m.mapId);

            if (m.Width != 0 && m.Height != 0)
            {
                sw.Write(" " + m.Width + " " + m.Height);

                if (m.PathCount != 0)
                {
                    sw.Write(" " + m.PathCount);
                }
            }
            sw.WriteLine("");

            StringBuilder[] sbs = new StringBuilder[m.Height];

            for (int i = 0; i < sbs.Length; i++)
            {
                sbs[i] = new StringBuilder();
            }

            for (int x = 0; x < m.tiles.Count; x++)
            {
                List<Tile> temp = m.tiles[x];
                for (int y = 0; y < temp.Count; y++)
                {
                    Tile t = temp[y];
                    if (t.IsBlocked() && !t.IsBuildable())
                    {
                        sbs[y].Append('@');
                    }
                    else if (!t.IsBuildable())
                    {
                        sbs[y].Append('#');
                    }
                    else if (t.IsBlocked())
                    {
                        sbs[y].Append('*');
                    }
                    else if (t.HasSymbols())
                    {
                        string symList = t.GetSymbolList();
                        if (symList.Length == 1)
                        {
                            sbs[y].Append(symList[0]);
                        }
                        else
                        {
                            string extra = "";
                            char id = (extras.Count).ToString()[0];
                            extra += id;
                            for (int i = 0; i < symList.Length; i++)
                            {
                                extra += " " + symList[i];
                            }

                            sbs[y].Append(id);
                            extras.Add(extra);
                        }
                    }
                    else if (t.IsBuildable())
                    {
                        sbs[y].Append('_');
                    }
                }
            }

            for (int i = 0; i < sbs.Length; i++)
            {
                sw.WriteLine(sbs[i].ToString());
            }

            if (m.PathCount != 0)
            {
                sw.WriteLine(extras.Count.ToString());
                for (int i = 0; i < extras.Count; i++)
                {
                    sw.WriteLine(extras[i]);
                }
            }

            sw.WriteLine("");

            // write level data...

            sw.WriteLine(TYPE_DIFFICULTY + level.Difficulty.ToString());
            sw.WriteLine(TYPE_LEVEL_NAME + level.Name);

            sw.WriteLine("");

            sw.WriteLine(TYPE_INIT_LIVES + " " + level.StartingLives);
            sw.WriteLine(TYPE_INIT_GOLD + " " + level.StartingGold);

            sw.WriteLine("");

            sw.WriteLine("//{0, -10}{1, -10}{2, -10}{3, -10}{4, -10}",
                "type", "num", "spwnT", "hp", "reward");

            foreach (Wave w in level.Waves)
            {
                if (w.spriteType == null)
                    continue;
                try
                {
                    if (level.Map.PathCount > 1)
                    {
                        if (w.entrance == '\0')
                            w.entrance = 'a';

                        sw.WriteLine("{0} {1, -10}{2, -10}{3, -10}{4, -10}{5, -10}{6, -10} // {7}",
                            TYPE_SPAWN, w.spriteType.typeEnum, w.spawnCount,
                            w.spawnDelay, w.hp, w.reward, w.entrance, w.index + 1);
                    }
                    else
                    {
                        sw.WriteLine("{0} {1, -10}{2, -10}{3, -10}{4, -10}{5, -10} // {6}",
                            TYPE_SPAWN, w.spriteType.typeEnum, w.spawnCount,
                            w.spawnDelay, w.hp, w.reward, w.index + 1);
                    }

                    if (w.timeAllotted > 0)
                        sw.WriteLine("{0} {1}", TYPE_SLEEP, w.timeAllotted);
                }
                catch (Exception e)
                {
                    Debug.Write(e.StackTrace);
                }
            }
        }

        private void lblLevelName_Click(object sender, EventArgs e)
        {
            txtLevelName.Width = lblLevelName.Width;
            txtLevelName.Text = level.Name;
            txtLevelName.Visible = true;

            txtLevelName.Capture = true;
            txtLevelName.Focus();
        }

        private void setLevelName(string name)
        {
            lblLevelName.Text = name;
            level.Name = name;
            txtLevelName.Visible = false;
            txtLevelName.Capture = false;
        }

        private void txtLevelName_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtLevelName.Visible &&
                txtLevelName.Width < e.X || e.X < 0 ||
                txtLevelName.Height < e.Y || e.Y < 0)
            {
                setLevelName(txtLevelName.Text);
            }
        }

        private void txtLevelName_Leave(object sender, EventArgs e)
        {
            setLevelName(txtLevelName.Text);
        }

        void level_NameChanged(string newName)
        {
            if (newName.Length == 0)
            {
                lblLevelName.Text = "(Level Name)";
            }
            else
            {
                lblLevelName.Text = newName;
            }
        }

        private void btnAcceptName_Click(object sender, EventArgs e)
        {
            if (txtLevelName.Visible)
                setLevelName(txtLevelName.Text);
        }

        private void lblLevelName_SizeChanged(object sender, EventArgs e)
        {
            lblDifficulty.Left = lblLevelName.Right;
        }

        private void lblDifficulty_Click(object sender, EventArgs e)
        {
            cmbDifficulty.Left = lblDifficulty.Left;
            cmbDifficulty.SelectedIndex = level.Difficulty;
            cmbDifficulty.Visible = true;

            cmbDifficulty.Capture = true;
            cmbDifficulty.Focus();
            cmbDifficulty.DroppedDown = true;
        }

        private void cmbDifficulty_MouseDown(object sender, MouseEventArgs e)
        {
            if (cmbDifficulty.Visible &&
                cmbDifficulty.Width < e.X || e.X < 0 ||
                cmbDifficulty.Height < e.Y || e.Y < 0)
            {
                setLevelDifficulty(cmbDifficulty.SelectedIndex);
            }
        }

        private void setLevelDifficulty(int diff)
        {
            level.Difficulty = diff;
            lblDifficulty.Text = cmbDifficulty.Items[diff].ToString();
            cmbDifficulty.Visible = false;
            cmbDifficulty.Capture = false;
        }

        private void cmbDifficulty_DropDownClosed(object sender, EventArgs e)
        {
            setLevelDifficulty(cmbDifficulty.SelectedIndex);
        }

        private void recalculateStats()
        {
            if (lbWaves.SelectedIndex > 0)
            {
                Wave cur = waves[lbWaves.SelectedIndex];
                Wave last = waves[lbWaves.SelectedIndex - 1];

                double hpInc = (double)txtHp.Value / last.hp;
                lblHpIncrease.Text = Math.Truncate(hpInc * 100).ToString() + "%";
            }
        }

        private void txtHp_ValueChanged(object sender, EventArgs e)
        {
            recalculateStats();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = clean();
            switch (result)
            {
                case DialogResult.Yes:
                    saveToolStripMenuItem_Click(null, null);
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }

            if (!e.Cancel)
            {
                RecentList.Instance.Save(APP_FOLDER);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = clean();
            switch (result)
            {
                case DialogResult.Yes:
                    saveToolStripMenuItem_Click(null, null);
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    return;
            }

            level = new Level();
            waves = level.Waves;
            map = level.Map;

            lbWaves.Items.Clear();

            pnlMain.Visible = false;
        }

        private DialogResult clean()
        {
            if (file.IsDirty)
            {
                DialogResult result = MessageBox.Show("Save changes?", "Save", MessageBoxButtons.YesNoCancel);
                return result;
            }
            else
            {
                return DialogResult.No;
            }
        }

        private void OnPathCountChanged()
        {
            if (level.Map.PathCount < 2)
            {
                pnlSpawnPoint.Visible = false;
            }
            else
            {
                cmbSpawnPoint.Items.Clear();

                for (int i = 0; i < level.Map.PathCount; i++)
                {
                    cmbSpawnPoint.Items.Add((char)('a' + i));
                }
                pnlSpawnPoint.Visible = true;
            }
        }

        private const double DURATION = 0.7;
        private static double time = 0;
        private static double change = 0;
        private static double b = 0;

        private void startAboutIn()
        {
            if (aboutBox.Visible)
                return;

            double c = (this.Width - aboutBox.Width) / 2;
            aboutBox.Top = (this.Height - aboutBox.Height) / 2;
            aboutBox.Left = this.Width;
            aboutBox.Visible = true;

            change = c - aboutBox.Left;
            b = aboutBox.Left;

            time = 0f;
            aniAboutIn.Start();
        }

        private void aniAboutIn_Tick(object sender, EventArgs e)
        {
            time += aniAboutIn.Interval / 1000.0;
            if (time < DURATION)
            {
                double t = time / (DURATION / 2f);
                double l;
                if (t < 1)
                {
                    l = change / 2.0 * t * t + b;
                }
                else
                {
                    t--;
                    l = -change / 2.0 * (t * (t - 2) - 1) + b;
                }
                //double l = -change * Math.Cos(t * (Math.PI / 2)) + change + b;
                aboutBox.Left = (int)l;
            }
            else
            {
                aboutBox.Left = (int)(change + b);
                aniAboutIn.Stop();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startAboutIn();
        }

        private void startPage1_ItemSelected(object sender, StartPage.RecentEventArgs e)
        {
            LoadLevelFromFile(e.ItemSelected.fullPath);

            RecentList.Instance.AddRecent(e.ItemSelected.fullPath, level.Name);
            startPage1.Refresh();
            startPage1.Hide();
        }

        private void startPage1_NewLevelClick(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
            startPage1.Hide();
        }

        private void startPage1_ItemSelected_1(object sender, StartPage.RecentEventArgs e)
        {

        }

    }
}
