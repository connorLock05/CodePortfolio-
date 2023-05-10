namespace PokerGameNEAProj
{
    partial class HostingForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CloseGameBTN = new System.Windows.Forms.Button();
            this.ConnectedPlayersLBL = new System.Windows.Forms.Label();
            this.GameLog = new System.Windows.Forms.TextBox();
            this.StartGameBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BuyInNUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ExportBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuyInNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.CloseGameBTN, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ConnectedPlayersLBL, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.GameLog, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.StartGameBTN, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ExportBTN, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66665F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66665F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66665F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00003F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00003F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(477, 373);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // CloseGameBTN
            // 
            this.CloseGameBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CloseGameBTN.Enabled = false;
            this.CloseGameBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseGameBTN.Location = new System.Drawing.Point(160, 64);
            this.CloseGameBTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CloseGameBTN.Name = "CloseGameBTN";
            this.CloseGameBTN.Size = new System.Drawing.Size(155, 58);
            this.CloseGameBTN.TabIndex = 1;
            this.CloseGameBTN.Text = "Close Game";
            this.CloseGameBTN.UseVisualStyleBackColor = true;
            this.CloseGameBTN.Click += new System.EventHandler(this.CloseGameBTN_Click);
            // 
            // ConnectedPlayersLBL
            // 
            this.ConnectedPlayersLBL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConnectedPlayersLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectedPlayersLBL.Location = new System.Drawing.Point(2, 0);
            this.ConnectedPlayersLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ConnectedPlayersLBL.Name = "ConnectedPlayersLBL";
            this.tableLayoutPanel1.SetRowSpan(this.ConnectedPlayersLBL, 3);
            this.ConnectedPlayersLBL.Size = new System.Drawing.Size(154, 186);
            this.ConnectedPlayersLBL.TabIndex = 1;
            this.ConnectedPlayersLBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GameLog
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.GameLog, 2);
            this.GameLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameLog.Location = new System.Drawing.Point(2, 188);
            this.GameLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GameLog.Multiline = true;
            this.GameLog.Name = "GameLog";
            this.GameLog.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.GameLog, 2);
            this.GameLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GameLog.Size = new System.Drawing.Size(313, 183);
            this.GameLog.TabIndex = 2;
            // 
            // StartGameBTN
            // 
            this.StartGameBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartGameBTN.Enabled = false;
            this.StartGameBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGameBTN.Location = new System.Drawing.Point(160, 2);
            this.StartGameBTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StartGameBTN.Name = "StartGameBTN";
            this.StartGameBTN.Size = new System.Drawing.Size(155, 58);
            this.StartGameBTN.TabIndex = 6;
            this.StartGameBTN.Text = "Start Game";
            this.StartGameBTN.UseVisualStyleBackColor = true;
            this.StartGameBTN.Click += new System.EventHandler(this.StartGameBTN_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.BuyInNUD, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(160, 126);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 57);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // BuyInNUD
            // 
            this.BuyInNUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuyInNUD.Location = new System.Drawing.Point(2, 30);
            this.BuyInNUD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BuyInNUD.Name = "BuyInNUD";
            this.BuyInNUD.Size = new System.Drawing.Size(146, 20);
            this.BuyInNUD.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "Buy In Fee:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ExportBTN
            // 
            this.ExportBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExportBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportBTN.Location = new System.Drawing.Point(319, 2);
            this.ExportBTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExportBTN.Name = "ExportBTN";
            this.tableLayoutPanel1.SetRowSpan(this.ExportBTN, 5);
            this.ExportBTN.Size = new System.Drawing.Size(156, 369);
            this.ExportBTN.TabIndex = 7;
            this.ExportBTN.Text = "Export Card Data";
            this.ExportBTN.UseVisualStyleBackColor = true;
            this.ExportBTN.Click += new System.EventHandler(this.ExportBTN_Click);
            // 
            // HostingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 373);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HostingForm";
            this.Text = "Server Host";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BuyInNUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label ConnectedPlayersLBL;
        private System.Windows.Forms.TextBox GameLog;
        private System.Windows.Forms.Button StartGameBTN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown BuyInNUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CloseGameBTN;
        private System.Windows.Forms.Button ExportBTN;
    }
}