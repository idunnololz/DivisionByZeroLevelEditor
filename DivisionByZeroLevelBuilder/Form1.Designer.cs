namespace DivisionByZeroLevelBuilder
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlSpawnPoint = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSpawnPoint = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalGold = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblHpIncrease = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimeAllotted = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReward = new System.Windows.Forms.NumericUpDown();
            this.txtHp = new System.Windows.Forms.NumericUpDown();
            this.txtSpawnDelay = new System.Windows.Forms.NumericUpDown();
            this.txtAmount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTypes = new System.Windows.Forms.ComboBox();
            this.btnRestore = new System.Windows.Forms.PictureBox();
            this.lblLevelName = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.txtLevelName = new System.Windows.Forms.TextBox();
            this.btnAcceptName = new System.Windows.Forms.Button();
            this.cmbDifficulty = new System.Windows.Forms.ComboBox();
            this.aniAboutIn = new System.Windows.Forms.Timer(this.components);
            this.aniMapEditorIn = new System.Windows.Forms.Timer(this.components);
            this.lbWaves = new GeneralControlLibrary.DoubleBufferedListBox();
            this.tlblTitle = new GeneralControlLibrary.TransparentLabel();
            this.btnMin = new GeneralControlLibrary.WindowControl();
            this.btnClose = new GeneralControlLibrary.WindowControl();
            this.menuStrip = new GeneralControlLibrary.CustomMenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tOOLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startPage1 = new DivisionByZeroLevelBuilder.StartPage();
            this.aboutBox = new DivisionByZeroLevelBuilder.AboutBox();
            this.pnlMain.SuspendLayout();
            this.pnlSpawnPoint.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeAllotted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpawnDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddItem.Location = new System.Drawing.Point(15, 410);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(176, 28);
            this.btnAddItem.TabIndex = 6;
            this.btnAddItem.Text = "+";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.pnlSpawnPoint);
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Controls.Add(this.txtTimeAllotted);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.txtReward);
            this.pnlMain.Controls.Add(this.txtHp);
            this.pnlMain.Controls.Add(this.txtSpawnDelay);
            this.pnlMain.Controls.Add(this.txtAmount);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.cmbTypes);
            this.pnlMain.Location = new System.Drawing.Point(197, 100);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(368, 235);
            this.pnlMain.TabIndex = 7;
            this.pnlMain.Visible = false;
            // 
            // pnlSpawnPoint
            // 
            this.pnlSpawnPoint.Controls.Add(this.label8);
            this.pnlSpawnPoint.Controls.Add(this.cmbSpawnPoint);
            this.pnlSpawnPoint.Location = new System.Drawing.Point(8, 130);
            this.pnlSpawnPoint.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSpawnPoint.Name = "pnlSpawnPoint";
            this.pnlSpawnPoint.Size = new System.Drawing.Size(180, 37);
            this.pnlSpawnPoint.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-4, 7);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Spawn Point";
            // 
            // cmbSpawnPoint
            // 
            this.cmbSpawnPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpawnPoint.FormattingEnabled = true;
            this.cmbSpawnPoint.Location = new System.Drawing.Point(93, 4);
            this.cmbSpawnPoint.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSpawnPoint.Name = "cmbSpawnPoint";
            this.cmbSpawnPoint.Size = new System.Drawing.Size(79, 24);
            this.cmbSpawnPoint.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalGold);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblHpIncrease);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(4, 172);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(360, 59);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stats";
            // 
            // lblTotalGold
            // 
            this.lblTotalGold.AutoSize = true;
            this.lblTotalGold.Location = new System.Drawing.Point(101, 36);
            this.lblTotalGold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalGold.Name = "lblTotalGold";
            this.lblTotalGold.Size = new System.Drawing.Size(48, 17);
            this.lblTotalGold.TabIndex = 3;
            this.lblTotalGold.Text = "20000";
            this.lblTotalGold.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 36);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Total Gold:";
            // 
            // lblHpIncrease
            // 
            this.lblHpIncrease.AutoSize = true;
            this.lblHpIncrease.Location = new System.Drawing.Point(107, 20);
            this.lblHpIncrease.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHpIncrease.Name = "lblHpIncrease";
            this.lblHpIncrease.Size = new System.Drawing.Size(44, 17);
            this.lblHpIncrease.TabIndex = 1;
            this.lblHpIncrease.Text = "100%";
            this.lblHpIncrease.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Hp Increase:";
            // 
            // txtTimeAllotted
            // 
            this.txtTimeAllotted.Location = new System.Drawing.Point(189, 108);
            this.txtTimeAllotted.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimeAllotted.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtTimeAllotted.Name = "txtTimeAllotted";
            this.txtTimeAllotted.Size = new System.Drawing.Size(175, 22);
            this.txtTimeAllotted.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 111);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Time allotted for wave (ms)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Reward";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(184, 49);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 17);
            this.label10.TabIndex = 7;
            this.label10.Text = "Hp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Spawn Delay";
            // 
            // txtReward
            // 
            this.txtReward.Location = new System.Drawing.Point(281, 69);
            this.txtReward.Margin = new System.Windows.Forms.Padding(4);
            this.txtReward.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtReward.Name = "txtReward";
            this.txtReward.Size = new System.Drawing.Size(83, 22);
            this.txtReward.TabIndex = 5;
            this.txtReward.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            // 
            // txtHp
            // 
            this.txtHp.Location = new System.Drawing.Point(184, 69);
            this.txtHp.Margin = new System.Windows.Forms.Padding(4);
            this.txtHp.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txtHp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtHp.Name = "txtHp";
            this.txtHp.Size = new System.Drawing.Size(89, 22);
            this.txtHp.TabIndex = 5;
            this.txtHp.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.txtHp.ValueChanged += new System.EventHandler(this.txtHp_ValueChanged);
            // 
            // txtSpawnDelay
            // 
            this.txtSpawnDelay.Location = new System.Drawing.Point(87, 69);
            this.txtSpawnDelay.Margin = new System.Windows.Forms.Padding(4);
            this.txtSpawnDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.txtSpawnDelay.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtSpawnDelay.Name = "txtSpawnDelay";
            this.txtSpawnDelay.Size = new System.Drawing.Size(89, 22);
            this.txtSpawnDelay.TabIndex = 5;
            this.txtSpawnDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(8, 69);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(67, 22);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type";
            // 
            // cmbTypes
            // 
            this.cmbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypes.FormattingEnabled = true;
            this.cmbTypes.Location = new System.Drawing.Point(8, 20);
            this.cmbTypes.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTypes.Name = "cmbTypes";
            this.cmbTypes.Size = new System.Drawing.Size(224, 24);
            this.cmbTypes.TabIndex = 1;
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_maximize;
            this.btnRestore.Location = new System.Drawing.Point(491, 1);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(4);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(34, 26);
            this.btnRestore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnRestore.TabIndex = 2;
            this.btnRestore.TabStop = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            this.btnRestore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRestore_MouseDown);
            this.btnRestore.MouseEnter += new System.EventHandler(this.btnRestore_MouseEnter);
            this.btnRestore.MouseLeave += new System.EventHandler(this.btnRestore_MouseLeave);
            this.btnRestore.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRestore_MouseUp);
            // 
            // lblLevelName
            // 
            this.lblLevelName.AutoSize = true;
            this.lblLevelName.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevelName.Location = new System.Drawing.Point(9, 70);
            this.lblLevelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLevelName.Name = "lblLevelName";
            this.lblLevelName.Size = new System.Drawing.Size(128, 25);
            this.lblLevelName.TabIndex = 12;
            this.lblLevelName.Text = "Level Name";
            this.lblLevelName.SizeChanged += new System.EventHandler(this.lblLevelName_SizeChanged);
            this.lblLevelName.Click += new System.EventHandler(this.lblLevelName_Click);
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifficulty.ForeColor = System.Drawing.Color.Gray;
            this.lblDifficulty.Location = new System.Drawing.Point(149, 78);
            this.lblDifficulty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(80, 18);
            this.lblDifficulty.TabIndex = 13;
            this.lblDifficulty.Text = "(Difficulty)";
            this.lblDifficulty.Click += new System.EventHandler(this.lblDifficulty_Click);
            // 
            // txtLevelName
            // 
            this.txtLevelName.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLevelName.Location = new System.Drawing.Point(15, 66);
            this.txtLevelName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLevelName.Name = "txtLevelName";
            this.txtLevelName.Size = new System.Drawing.Size(173, 33);
            this.txtLevelName.TabIndex = 14;
            this.txtLevelName.Visible = false;
            this.txtLevelName.Leave += new System.EventHandler(this.txtLevelName_Leave);
            this.txtLevelName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtLevelName_MouseDown);
            // 
            // btnAcceptName
            // 
            this.btnAcceptName.Location = new System.Drawing.Point(-267, -246);
            this.btnAcceptName.Margin = new System.Windows.Forms.Padding(4);
            this.btnAcceptName.Name = "btnAcceptName";
            this.btnAcceptName.Size = new System.Drawing.Size(100, 28);
            this.btnAcceptName.TabIndex = 15;
            this.btnAcceptName.Text = "Dummy";
            this.btnAcceptName.UseVisualStyleBackColor = true;
            this.btnAcceptName.Click += new System.EventHandler(this.btnAcceptName_Click);
            // 
            // cmbDifficulty
            // 
            this.cmbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDifficulty.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDifficulty.FormattingEnabled = true;
            this.cmbDifficulty.Items.AddRange(new object[] {
            "Unrated",
            "Easy",
            "Medium",
            "Hard",
            "Brutal",
            "EX"});
            this.cmbDifficulty.Location = new System.Drawing.Point(244, 75);
            this.cmbDifficulty.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDifficulty.Name = "cmbDifficulty";
            this.cmbDifficulty.Size = new System.Drawing.Size(160, 26);
            this.cmbDifficulty.TabIndex = 16;
            this.cmbDifficulty.Visible = false;
            this.cmbDifficulty.DropDownClosed += new System.EventHandler(this.cmbDifficulty_DropDownClosed);
            this.cmbDifficulty.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbDifficulty_MouseDown);
            // 
            // aniAboutIn
            // 
            this.aniAboutIn.Interval = 15;
            this.aniAboutIn.Tick += new System.EventHandler(this.aniAboutIn_Tick);
            // 
            // aniMapEditorIn
            // 
            this.aniMapEditorIn.Interval = 15;
            this.aniMapEditorIn.Tick += new System.EventHandler(this.aniMapEditorIn_Tick);
            // 
            // lbWaves
            // 
            this.lbWaves.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbWaves.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbWaves.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbWaves.FormattingEnabled = true;
            this.lbWaves.IntegralHeight = false;
            this.lbWaves.Location = new System.Drawing.Point(15, 100);
            this.lbWaves.Margin = new System.Windows.Forms.Padding(4);
            this.lbWaves.Name = "lbWaves";
            this.lbWaves.Size = new System.Drawing.Size(174, 319);
            this.lbWaves.TabIndex = 9;
            this.lbWaves.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbWaves_DrawItem);
            this.lbWaves.SelectedIndexChanged += new System.EventHandler(this.lbWaves_SelectedIndexChanged);
            // 
            // tlblTitle
            // 
            this.tlblTitle.AutoSize = true;
            this.tlblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlblTitle.ForeColor = System.Drawing.Color.Gray;
            this.tlblTitle.Location = new System.Drawing.Point(17, 7);
            this.tlblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tlblTitle.Name = "tlblTitle";
            this.tlblTitle.Size = new System.Drawing.Size(119, 24);
            this.tlblTitle.TabIndex = 4;
            this.tlblTitle.Text = "Level Builder";
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.DownColor = System.Drawing.Color.Empty;
            this.btnMin.DownImage = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_minimize_down;
            this.btnMin.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_minimize;
            this.btnMin.Location = new System.Drawing.Point(447, 1);
            this.btnMin.Margin = new System.Windows.Forms.Padding(4);
            this.btnMin.Name = "btnMin";
            this.btnMin.OverColor = System.Drawing.SystemColors.Control;
            this.btnMin.OverImage = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_minimize_over;
            this.btnMin.Size = new System.Drawing.Size(34, 26);
            this.btnMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMin.TabIndex = 1;
            this.btnMin.TabStop = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DownColor = System.Drawing.Color.Empty;
            this.btnClose.DownImage = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_close_down;
            this.btnClose.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_close;
            this.btnClose.Location = new System.Drawing.Point(535, 1);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.OverColor = System.Drawing.SystemColors.Control;
            this.btnClose.OverImage = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_close_over;
            this.btnClose.Size = new System.Drawing.Size(34, 26);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.eDITToolStripMenuItem,
            this.tOOLSToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(1, 37);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.SelectedColor = System.Drawing.Color.LightGray;
            this.menuStrip.Size = new System.Drawing.Size(257, 30);
            this.menuStrip.TabIndex = 11;
            this.menuStrip.Text = "customMenuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(47, 26);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(156, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(156, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(52, 26);
            this.eDITToolStripMenuItem.Text = "EDIT";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // tOOLSToolStripMenuItem
            // 
            this.tOOLSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapEditorToolStripMenuItem});
            this.tOOLSToolStripMenuItem.Name = "tOOLSToolStripMenuItem";
            this.tOOLSToolStripMenuItem.Size = new System.Drawing.Size(66, 26);
            this.tOOLSToolStripMenuItem.Text = "TOOLS";
            // 
            // mapEditorToolStripMenuItem
            // 
            this.mapEditorToolStripMenuItem.Name = "mapEditorToolStripMenuItem";
            this.mapEditorToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.mapEditorToolStripMenuItem.Text = "Map Editor";
            this.mapEditorToolStripMenuItem.Click += new System.EventHandler(this.mapEditorToolStripMenuItem_Click);
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.hELPToolStripMenuItem.Text = "HELP";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // startPage1
            // 
            this.startPage1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startPage1.BackColor = System.Drawing.SystemColors.Control;
            this.startPage1.Location = new System.Drawing.Point(93, 126);
            this.startPage1.Margin = new System.Windows.Forms.Padding(5);
            this.startPage1.Name = "startPage1";
            this.startPage1.Size = new System.Drawing.Size(376, 271);
            this.startPage1.TabIndex = 18;
            this.startPage1.ItemSelected += new DivisionByZeroLevelBuilder.StartPage.ItemSelectedEventHandler(this.startPage1_ItemSelected);
            this.startPage1.NewLevelClick += new DivisionByZeroLevelBuilder.StartPage.NewLevelClickEventHandler(this.startPage1_NewLevelClick);
            // 
            // aboutBox
            // 
            this.aboutBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.aboutBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutBox.Location = new System.Drawing.Point(535, 348);
            this.aboutBox.Margin = new System.Windows.Forms.Padding(4);
            this.aboutBox.Name = "aboutBox";
            this.aboutBox.Size = new System.Drawing.Size(445, 187);
            this.aboutBox.TabIndex = 17;
            this.aboutBox.Visible = false;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnAcceptName;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(581, 453);
            this.ControlBox = false;
            this.Controls.Add(this.startPage1);
            this.Controls.Add(this.aboutBox);
            this.Controls.Add(this.cmbDifficulty);
            this.Controls.Add(this.btnAcceptName);
            this.Controls.Add(this.txtLevelName);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.lblLevelName);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.lbWaves);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tlblTitle);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(575, 236);
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "DBZ Level Builder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlSpawnPoint.ResumeLayout(false);
            this.pnlSpawnPoint.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeAllotted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpawnDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GeneralControlLibrary.WindowControl btnClose;
        private GeneralControlLibrary.WindowControl btnMin;
        private System.Windows.Forms.PictureBox btnRestore;
        private GeneralControlLibrary.TransparentLabel tlblTitle;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ComboBox cmbTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtSpawnDelay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown txtReward;
        private System.Windows.Forms.NumericUpDown txtHp;
        private System.Windows.Forms.Label label4;
        private GeneralControlLibrary.DoubleBufferedListBox lbWaves;
        private GeneralControlLibrary.CustomMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eDITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tOOLSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapEditorToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown txtTimeAllotted;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Label lblLevelName;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.TextBox txtLevelName;
        private System.Windows.Forms.Button btnAcceptName;
        private System.Windows.Forms.ComboBox cmbDifficulty;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblHpIncrease;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalGold;
        private System.Windows.Forms.Timer aniAboutIn;
        private AboutBox aboutBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbSpawnPoint;
        private System.Windows.Forms.Panel pnlSpawnPoint;
        private System.Windows.Forms.Timer aniMapEditorIn;
        private StartPage startPage1;

    }
}

