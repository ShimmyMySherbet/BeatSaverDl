
namespace BeatSaverDl.UI
{
    partial class ActiveDownloadComponent
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
            this.lblMap = new System.Windows.Forms.Label();
            this.progDownload = new System.Windows.Forms.ProgressBar();
            this.pbArtwork = new System.Windows.Forms.PictureBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblRanked = new System.Windows.Forms.Label();
            this.lblDif = new System.Windows.Forms.Label();
            this.cmxControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbArtwork)).BeginInit();
            this.cmxControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Location = new System.Drawing.Point(121, 3);
            this.lblMap.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(110, 25);
            this.lblMap.TabIndex = 0;
            this.lblMap.Text = "MAP NAME";
            // 
            // progDownload
            // 
            this.progDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progDownload.Location = new System.Drawing.Point(121, 90);
            this.progDownload.Name = "progDownload";
            this.progDownload.Size = new System.Drawing.Size(430, 23);
            this.progDownload.TabIndex = 1;
            // 
            // pbArtwork
            // 
            this.pbArtwork.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pbArtwork.Location = new System.Drawing.Point(3, 3);
            this.pbArtwork.Name = "pbArtwork";
            this.pbArtwork.Size = new System.Drawing.Size(110, 110);
            this.pbArtwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbArtwork.TabIndex = 2;
            this.pbArtwork.TabStop = false;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAuthor.Location = new System.Drawing.Point(145, 32);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(172, 17);
            this.lblAuthor.TabIndex = 3;
            this.lblAuthor.Text = "Author, Mapped By Mapper";
            // 
            // lblRanked
            // 
            this.lblRanked.AutoSize = true;
            this.lblRanked.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRanked.Location = new System.Drawing.Point(145, 49);
            this.lblRanked.Name = "lblRanked";
            this.lblRanked.Size = new System.Drawing.Size(112, 17);
            this.lblRanked.TabIndex = 4;
            this.lblRanked.Text = "Ranked/Unranked";
            // 
            // lblDif
            // 
            this.lblDif.AutoSize = true;
            this.lblDif.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDif.Location = new System.Drawing.Point(145, 66);
            this.lblDif.Name = "lblDif";
            this.lblDif.Size = new System.Drawing.Size(206, 17);
            this.lblDif.TabIndex = 5;
            this.lblDif.Text = "Easy Normal Hard Expert Expert+";
            // 
            // cmxControl
            // 
            this.cmxControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.cmxControl.Name = "cmxControl";
            this.cmxControl.Size = new System.Drawing.Size(118, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // ActiveDownloadComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblDif);
            this.Controls.Add(this.lblRanked);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.pbArtwork);
            this.Controls.Add(this.progDownload);
            this.Controls.Add(this.lblMap);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(122)))), ((int)(((byte)(218)))));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ActiveDownloadComponent";
            this.Size = new System.Drawing.Size(554, 116);
            this.Load += new System.EventHandler(this.ActiveDownloadComponent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbArtwork)).EndInit();
            this.cmxControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.ProgressBar progDownload;
        private System.Windows.Forms.PictureBox pbArtwork;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblRanked;
        private System.Windows.Forms.Label lblDif;
        private System.Windows.Forms.ContextMenuStrip cmxControl;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    }
}
