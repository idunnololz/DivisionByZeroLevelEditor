namespace DivisionByZeroLevelBuilder
{
    partial class AboutBox
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblNameAndVersion = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.windowControl1 = new GeneralControlLibrary.WindowControl();
            this.aniDismiss = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.windowControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "About";
            // 
            // lblNameAndVersion
            // 
            this.lblNameAndVersion.AutoSize = true;
            this.lblNameAndVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameAndVersion.ForeColor = System.Drawing.Color.White;
            this.lblNameAndVersion.Location = new System.Drawing.Point(5, 25);
            this.lblNameAndVersion.Name = "lblNameAndVersion";
            this.lblNameAndVersion.Size = new System.Drawing.Size(77, 17);
            this.lblNameAndVersion.TabIndex = 0;
            this.lblNameAndVersion.Text = "LevelBuilder";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthor.ForeColor = System.Drawing.Color.White;
            this.lblAuthor.Location = new System.Drawing.Point(5, 42);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(117, 17);
            this.lblAuthor.TabIndex = 0;
            this.lblAuthor.Text = "© 2013 GGStudios";
            // 
            // windowControl1
            // 
            this.windowControl1.DownColor = System.Drawing.Color.White;
            this.windowControl1.DownImage = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_close_over;
            this.windowControl1.Image = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_close_down;
            this.windowControl1.Location = new System.Drawing.Point(300, -1);
            this.windowControl1.Name = "windowControl1";
            this.windowControl1.OverColor = System.Drawing.Color.Red;
            this.windowControl1.OverImage = global::DivisionByZeroLevelBuilder.Properties.Resources.window_icon_close_down;
            this.windowControl1.Size = new System.Drawing.Size(34, 26);
            this.windowControl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.windowControl1.TabIndex = 1;
            this.windowControl1.TabStop = false;
            this.windowControl1.Click += new System.EventHandler(this.windowControl1_Click);
            // 
            // aniDismiss
            // 
            this.aniDismiss.Interval = 15;
            this.aniDismiss.Tick += new System.EventHandler(this.aniDismiss_Tick);
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.Controls.Add(this.windowControl1);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblNameAndVersion);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AboutBox";
            this.Size = new System.Drawing.Size(333, 68);
            this.Load += new System.EventHandler(this.AboutBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.windowControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNameAndVersion;
        private System.Windows.Forms.Label lblAuthor;
        private GeneralControlLibrary.WindowControl windowControl1;
        private System.Windows.Forms.Timer aniDismiss;
    }
}
