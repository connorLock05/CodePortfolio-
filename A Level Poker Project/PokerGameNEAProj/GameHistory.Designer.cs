namespace PokerGameNEAProj
{
    partial class GameHistory
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
            this.UsernameLBL = new System.Windows.Forms.Label();
            this.HistoryLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UsernameLBL
            // 
            this.UsernameLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.UsernameLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLBL.Location = new System.Drawing.Point(0, 0);
            this.UsernameLBL.Name = "UsernameLBL";
            this.UsernameLBL.Size = new System.Drawing.Size(421, 42);
            this.UsernameLBL.TabIndex = 0;
            this.UsernameLBL.Text = "Username: XXXXXXXXXXXXXXX";
            this.UsernameLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HistoryLog
            // 
            this.HistoryLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistoryLog.Location = new System.Drawing.Point(0, 42);
            this.HistoryLog.Multiline = true;
            this.HistoryLog.Name = "HistoryLog";
            this.HistoryLog.ReadOnly = true;
            this.HistoryLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.HistoryLog.Size = new System.Drawing.Size(421, 402);
            this.HistoryLog.TabIndex = 1;
            // 
            // GameHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 444);
            this.Controls.Add(this.HistoryLog);
            this.Controls.Add(this.UsernameLBL);
            this.Name = "GameHistory";
            this.Text = "GameHistory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UsernameLBL;
        private System.Windows.Forms.TextBox HistoryLog;
    }
}