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
            this.pnlMapViewer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlMapViewer
            // 
            this.pnlMapViewer.Location = new System.Drawing.Point(3, 3);
            this.pnlMapViewer.Name = "pnlMapViewer";
            this.pnlMapViewer.Size = new System.Drawing.Size(273, 178);
            this.pnlMapViewer.TabIndex = 0;
            this.pnlMapViewer.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMapViewer_Paint);
            // 
            // MapEditor
            // 
            this.Controls.Add(this.pnlMapViewer);
            this.Name = "MapEditor";
            this.Size = new System.Drawing.Size(279, 184);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMapViewer;
    }
}
