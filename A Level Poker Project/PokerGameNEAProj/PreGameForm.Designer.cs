namespace PokerGameNEAProj
{
    partial class PreGameForm
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
            this.UsernameLBL = new System.Windows.Forms.Label();
            this.BalanceLBL = new System.Windows.Forms.Label();
            this.GameHistoryBTN = new System.Windows.Forms.Button();
            this.JoinGameBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.UsernameLBL, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BalanceLBL, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.GameHistoryBTN, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.JoinGameBTN, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(605, 318);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // UsernameLBL
            // 
            this.UsernameLBL.AutoSize = true;
            this.UsernameLBL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsernameLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLBL.Location = new System.Drawing.Point(2, 0);
            this.UsernameLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UsernameLBL.Name = "UsernameLBL";
            this.UsernameLBL.Size = new System.Drawing.Size(298, 95);
            this.UsernameLBL.TabIndex = 0;
            this.UsernameLBL.Text = "Username : XXXXXXXXXX";
            this.UsernameLBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BalanceLBL
            // 
            this.BalanceLBL.AutoSize = true;
            this.BalanceLBL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BalanceLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BalanceLBL.Location = new System.Drawing.Point(304, 0);
            this.BalanceLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BalanceLBL.Name = "BalanceLBL";
            this.BalanceLBL.Size = new System.Drawing.Size(299, 95);
            this.BalanceLBL.TabIndex = 1;
            this.BalanceLBL.Text = "Balance : XXXXXX";
            this.BalanceLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GameHistoryBTN
            // 
            this.GameHistoryBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameHistoryBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameHistoryBTN.Location = new System.Drawing.Point(2, 192);
            this.GameHistoryBTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GameHistoryBTN.Name = "GameHistoryBTN";
            this.GameHistoryBTN.Size = new System.Drawing.Size(298, 124);
            this.GameHistoryBTN.TabIndex = 2;
            this.GameHistoryBTN.Text = "Show Game History";
            this.GameHistoryBTN.UseVisualStyleBackColor = true;
            this.GameHistoryBTN.Click += new System.EventHandler(this.GameHistoryBTN_Click);
            // 
            // JoinGameBTN
            // 
            this.JoinGameBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JoinGameBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinGameBTN.Location = new System.Drawing.Point(304, 192);
            this.JoinGameBTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.JoinGameBTN.Name = "JoinGameBTN";
            this.JoinGameBTN.Size = new System.Drawing.Size(299, 124);
            this.JoinGameBTN.TabIndex = 3;
            this.JoinGameBTN.Text = "Join Game";
            this.JoinGameBTN.UseVisualStyleBackColor = true;
            this.JoinGameBTN.Click += new System.EventHandler(this.JoinGameClick);
            // 
            // PreGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 318);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PreGameForm";
            this.Text = "Game Lobby";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label UsernameLBL;
        private System.Windows.Forms.Label BalanceLBL;
        private System.Windows.Forms.Button GameHistoryBTN;
        private System.Windows.Forms.Button JoinGameBTN;
    }
}