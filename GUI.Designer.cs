namespace WindowsITimeSync
{
    partial class GUI
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.SyncBtn = new System.Windows.Forms.Button();
            this.StartupCbx = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // SyncBtn
            // 
            this.SyncBtn.Location = new System.Drawing.Point(12, 12);
            this.SyncBtn.Name = "SyncBtn";
            this.SyncBtn.Size = new System.Drawing.Size(266, 23);
            this.SyncBtn.TabIndex = 0;
            this.SyncBtn.Text = "Sync Now";
            this.SyncBtn.UseVisualStyleBackColor = true;
            // 
            // StartupCbx
            // 
            this.StartupCbx.AutoSize = true;
            this.StartupCbx.Location = new System.Drawing.Point(98, 40);
            this.StartupCbx.Name = "StartupCbx";
            this.StartupCbx.Size = new System.Drawing.Size(100, 17);
            this.StartupCbx.TabIndex = 1;
            this.StartupCbx.Text = "Sync on startup";
            this.StartupCbx.UseVisualStyleBackColor = true;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 69);
            this.Controls.Add(this.StartupCbx);
            this.Controls.Add(this.SyncBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Internet Time Sync";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SyncBtn;
        private System.Windows.Forms.CheckBox StartupCbx;
    }
}

