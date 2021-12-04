
namespace BeatSaverDl.UI
{
    partial class SettingsWindow
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
            this.cbAutoFocus = new System.Windows.Forms.CheckBox();
            this.cbNotifyDownloaded = new System.Windows.Forms.CheckBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCanccel = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnInstall = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAutoFocus
            // 
            this.cbAutoFocus.AutoSize = true;
            this.cbAutoFocus.Location = new System.Drawing.Point(13, 72);
            this.cbAutoFocus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbAutoFocus.Name = "cbAutoFocus";
            this.cbAutoFocus.Size = new System.Drawing.Size(124, 29);
            this.cbAutoFocus.TabIndex = 0;
            this.cbAutoFocus.Text = "Auto Focus";
            this.cbAutoFocus.UseVisualStyleBackColor = true;
            // 
            // cbNotifyDownloaded
            // 
            this.cbNotifyDownloaded.AutoSize = true;
            this.cbNotifyDownloaded.Location = new System.Drawing.Point(263, 74);
            this.cbNotifyDownloaded.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbNotifyDownloaded.Name = "cbNotifyDownloaded";
            this.cbNotifyDownloaded.Size = new System.Drawing.Size(194, 29);
            this.cbNotifyDownloaded.TabIndex = 1;
            this.cbNotifyDownloaded.Text = "Notify Downloaded";
            this.cbNotifyDownloaded.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(122)))), ((int)(((byte)(218)))));
            this.txtPath.Location = new System.Drawing.Point(11, 35);
            this.txtPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(398, 33);
            this.txtPath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Beat Saber Path:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Location = new System.Drawing.Point(415, 35);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 33);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BrowseForFolder);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(13, 107);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(244, 36);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // btnCanccel
            // 
            this.btnCanccel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCanccel.Location = new System.Drawing.Point(263, 107);
            this.btnCanccel.Name = "btnCanccel";
            this.btnCanccel.Size = new System.Drawing.Size(244, 36);
            this.btnCanccel.TabIndex = 6;
            this.btnCanccel.Text = "Cancel";
            this.btnCanccel.UseVisualStyleBackColor = true;
            this.btnCanccel.Click += new System.EventHandler(this.OnCancel);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // btnInstall
            // 
            this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstall.Location = new System.Drawing.Point(13, 149);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(494, 36);
            this.btnInstall.TabIndex = 7;
            this.btnInstall.Text = "Install One-Click Protocol Handler";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.OnInstallRequested);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(515, 193);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnCanccel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.cbNotifyDownloaded);
            this.Controls.Add(this.cbAutoFocus);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(122)))), ((int)(((byte)(218)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SettingsWindow";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAutoFocus;
        private System.Windows.Forms.CheckBox cbNotifyDownloaded;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCanccel;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.Button btnInstall;
    }
}