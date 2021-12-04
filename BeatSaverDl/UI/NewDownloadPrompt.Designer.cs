
namespace BeatSaverDl.UI
{
    partial class NewDownloadPrompt
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
            this.txtMapID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDownload = new System.Windows.Forms.Button();
            this.txtCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMapID
            // 
            this.txtMapID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.txtMapID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMapID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(122)))), ((int)(((byte)(218)))));
            this.txtMapID.Location = new System.Drawing.Point(12, 42);
            this.txtMapID.Name = "txtMapID";
            this.txtMapID.Size = new System.Drawing.Size(246, 39);
            this.txtMapID.TabIndex = 1;
            this.txtMapID.TextChanged += new System.EventHandler(this.txtMapID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Map ID:";
            // 
            // txtDownload
            // 
            this.txtDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtDownload.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDownload.Location = new System.Drawing.Point(12, 88);
            this.txtDownload.Name = "txtDownload";
            this.txtDownload.Size = new System.Drawing.Size(119, 35);
            this.txtDownload.TabIndex = 3;
            this.txtDownload.Text = "Download";
            this.txtDownload.UseVisualStyleBackColor = true;
            this.txtDownload.Click += new System.EventHandler(this.txtDownload_Click);
            // 
            // txtCancel
            // 
            this.txtCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCancel.Location = new System.Drawing.Point(137, 88);
            this.txtCancel.Name = "txtCancel";
            this.txtCancel.Size = new System.Drawing.Size(121, 35);
            this.txtCancel.TabIndex = 4;
            this.txtCancel.Text = "Cancel";
            this.txtCancel.UseVisualStyleBackColor = true;
            this.txtCancel.Click += new System.EventHandler(this.txtCancel_Click);
            // 
            // NewDownloadPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(274, 132);
            this.Controls.Add(this.txtCancel);
            this.Controls.Add(this.txtDownload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMapID);
            this.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(122)))), ((int)(((byte)(218)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "NewDownloadPrompt";
            this.Text = "Download Map";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMapID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button txtDownload;
        private System.Windows.Forms.Button txtCancel;
    }
}