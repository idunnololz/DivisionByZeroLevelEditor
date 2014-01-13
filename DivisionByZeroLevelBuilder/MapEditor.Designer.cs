namespace DivisionByZeroLevelBuilder
{
    partial class MapEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.windowControl1 = new GeneralControlLibrary.WindowControl();
            this.pnlMapDrawer = new GeneralControlLibrary.Canvas();
            this.contextMenu = new GeneralControlLibrary.CustomContextMenuStrip();
            this.openItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unbuildableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnZoomIn = new GeneralControlLibrary.CustomButton();
            this.btnZoomOut = new GeneralControlLibrary.CustomButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTileX = new System.Windows.Forms.Label();
            this.lblTileY = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.windowControl1)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowControl1
            // 
            this.windowControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.windowControl1.DownColor = System.Drawing.Color.Maroon;
            this.windowControl1.DownImage = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_close_down;
            this.windowControl1.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_close_down;
            this.windowControl1.Location = new System.Drawing.Point(443, 0);
            this.windowControl1.Name = "windowControl1";
            this.windowControl1.OverColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.windowControl1.OverImage = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_close_down;
            this.windowControl1.Size = new System.Drawing.Size(34, 26);
            this.windowControl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.windowControl1.TabIndex = 2;
            this.windowControl1.TabStop = false;
            this.windowControl1.Click += new System.EventHandler(this.windowControl1_Click);
            // 
            // pnlMapDrawer
            // 
            this.pnlMapDrawer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMapDrawer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlMapDrawer.ContextMenuStrip = this.contextMenu;
            this.pnlMapDrawer.Location = new System.Drawing.Point(3, 3);
            this.pnlMapDrawer.Name = "pnlMapDrawer";
            this.pnlMapDrawer.Size = new System.Drawing.Size(342, 292);
            this.pnlMapDrawer.TabIndex = 3;
            this.pnlMapDrawer.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMapDrawer_Paint);
            this.pnlMapDrawer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlMapDrawer_MouseClick);
            this.pnlMapDrawer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnlMapDrawer_MouseDoubleClick);
            this.pnlMapDrawer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMapDrawer_MouseDown);
            this.pnlMapDrawer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMapDrawer_MouseMove);
            // 
            // contextMenu
            // 
            this.contextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openItem,
            this.unbuildableToolStripMenuItem,
            this.blockedToolStripMenuItem,
            this.closedToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.SelectedColor = System.Drawing.Color.Black;
            this.contextMenu.Size = new System.Drawing.Size(139, 92);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            this.contextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenu_ItemClicked);
            // 
            // openItem
            // 
            this.openItem.CheckOnClick = true;
            this.openItem.ForeColor = System.Drawing.Color.White;
            this.openItem.Name = "openItem";
            this.openItem.Size = new System.Drawing.Size(152, 22);
            this.openItem.Text = "Open";
            // 
            // unbuildableToolStripMenuItem
            // 
            this.unbuildableToolStripMenuItem.CheckOnClick = true;
            this.unbuildableToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.unbuildableToolStripMenuItem.Name = "unbuildableToolStripMenuItem";
            this.unbuildableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.unbuildableToolStripMenuItem.Text = "Unbuildable";
            // 
            // blockedToolStripMenuItem
            // 
            this.blockedToolStripMenuItem.CheckOnClick = true;
            this.blockedToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.blockedToolStripMenuItem.Name = "blockedToolStripMenuItem";
            this.blockedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.blockedToolStripMenuItem.Text = "Blocked";
            // 
            // closedToolStripMenuItem
            // 
            this.closedToolStripMenuItem.CheckOnClick = true;
            this.closedToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.closedToolStripMenuItem.Name = "closedToolStripMenuItem";
            this.closedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closedToolStripMenuItem.Text = "Closed";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomIn.BackColor = System.Drawing.Color.Black;
            this.btnZoomIn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnZoomIn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomIn.ForeColor = System.Drawing.Color.White;
            this.btnZoomIn.Location = new System.Drawing.Point(346, 0);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnZoomIn.Size = new System.Drawing.Size(34, 31);
            this.btnZoomIn.TabIndex = 5;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomOut.BackColor = System.Drawing.Color.Black;
            this.btnZoomOut.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnZoomOut.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomOut.ForeColor = System.Drawing.Color.White;
            this.btnZoomOut.Location = new System.Drawing.Point(346, 32);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnZoomOut.Size = new System.Drawing.Size(34, 31);
            this.btnZoomOut.TabIndex = 5;
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // lblTileX
            // 
            this.lblTileX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTileX.AutoSize = true;
            this.lblTileX.ForeColor = System.Drawing.Color.White;
            this.lblTileX.Location = new System.Drawing.Point(351, 269);
            this.lblTileX.Name = "lblTileX";
            this.lblTileX.Size = new System.Drawing.Size(14, 13);
            this.lblTileX.TabIndex = 6;
            this.lblTileX.Text = "X";
            // 
            // lblTileY
            // 
            this.lblTileY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTileY.AutoSize = true;
            this.lblTileY.ForeColor = System.Drawing.Color.White;
            this.lblTileY.Location = new System.Drawing.Point(351, 282);
            this.lblTileY.Name = "lblTileY";
            this.lblTileY.Size = new System.Drawing.Size(14, 13);
            this.lblTileY.TabIndex = 6;
            this.lblTileY.Text = "Y";
            // 
            // MapEditor
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.lblTileY);
            this.Controls.Add(this.lblTileX);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.pnlMapDrawer);
            this.Controls.Add(this.windowControl1);
            this.Name = "MapEditor";
            this.Size = new System.Drawing.Size(477, 298);
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.VisibleChanged += new System.EventHandler(this.MapEditor_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.windowControl1)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GeneralControlLibrary.WindowControl windowControl1;
        private GeneralControlLibrary.Canvas pnlMapDrawer;
        private GeneralControlLibrary.CustomButton btnZoomIn;
        private GeneralControlLibrary.CustomButton btnZoomOut;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private GeneralControlLibrary.CustomContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem openItem;
        private System.Windows.Forms.ToolStripMenuItem unbuildableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closedToolStripMenuItem;
        private System.Windows.Forms.Label lblTileX;
        private System.Windows.Forms.Label lblTileY;

    }
}
