namespace DivisionByZeroLevelBuilder
{
    partial class StartPage
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
            this.components = new System.ComponentModel.Container();
            this.lblRecent = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.windowControl1 = new GeneralControlLibrary.WindowControl();
            this.llNew = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.windowControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecent
            // 
            this.lblRecent.AutoSize = true;
            this.lblRecent.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecent.Location = new System.Drawing.Point(3, 0);
            this.lblRecent.Name = "lblRecent";
            this.lblRecent.Size = new System.Drawing.Size(94, 37);
            this.lblRecent.TabIndex = 0;
            this.lblRecent.Text = "Recent";
            // 
            // windowControl1
            // 
            this.windowControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.windowControl1.DownColor = System.Drawing.Color.Maroon;
            this.windowControl1.DownImage = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_close_down;
            this.windowControl1.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_close;
            this.windowControl1.Location = new System.Drawing.Point(278, 0);
            this.windowControl1.Name = "windowControl1";
            this.windowControl1.OverColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.windowControl1.OverImage = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_close_down;
            this.windowControl1.Size = new System.Drawing.Size(34, 26);
            this.windowControl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.windowControl1.TabIndex = 3;
            this.windowControl1.TabStop = false;
            this.windowControl1.Click += new System.EventHandler(this.windowControl1_Click);
            // 
            // llNew
            // 
            this.llNew.ActiveLinkColor = System.Drawing.Color.DarkGray;
            this.llNew.AutoSize = true;
            this.llNew.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llNew.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(182)))));
            this.llNew.Location = new System.Drawing.Point(6, 189);
            this.llNew.Name = "llNew";
            this.llNew.Size = new System.Drawing.Size(89, 21);
            this.llNew.TabIndex = 4;
            this.llNew.TabStop = true;
            this.llNew.Text = "New Level...";
            this.llNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llNew_LinkClicked);
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.llNew);
            this.Controls.Add(this.windowControl1);
            this.Controls.Add(this.lblRecent);
            this.Name = "StartPage";
            this.Size = new System.Drawing.Size(312, 220);
            this.Load += new System.EventHandler(this.StartPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.windowControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecent;
        private System.Windows.Forms.ToolTip toolTip;
        private GeneralControlLibrary.WindowControl windowControl1;
        private System.Windows.Forms.LinkLabel llNew;
    }
}
