namespace PokerGameNEAProj
{
    partial class GameTable
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
            this.ActionBTN = new System.Windows.Forms.Button();
            this.All_InBTN = new System.Windows.Forms.Button();
            this.FoldBTN = new System.Windows.Forms.Button();
            this.MoneySelector = new System.Windows.Forms.TrackBar();
            this.P1C1 = new System.Windows.Forms.Label();
            this.P1C2 = new System.Windows.Forms.Label();
            this.P2C1 = new System.Windows.Forms.Label();
            this.P2C2 = new System.Windows.Forms.Label();
            this.P3C1 = new System.Windows.Forms.Label();
            this.P3C2 = new System.Windows.Forms.Label();
            this.P4C1 = new System.Windows.Forms.Label();
            this.P4C2 = new System.Windows.Forms.Label();
            this.Flop3 = new System.Windows.Forms.Label();
            this.Flop1 = new System.Windows.Forms.Label();
            this.Flop2 = new System.Windows.Forms.Label();
            this.Turn = new System.Windows.Forms.Label();
            this.River = new System.Windows.Forms.Label();
            this.PotLabel = new System.Windows.Forms.Label();
            this.UsernameP1 = new System.Windows.Forms.Label();
            this.UsernameP3 = new System.Windows.Forms.Label();
            this.UsernameP2 = new System.Windows.Forms.Label();
            this.UsernameP4 = new System.Windows.Forms.Label();
            this.BalanceP1 = new System.Windows.Forms.Label();
            this.BalanceP2 = new System.Windows.Forms.Label();
            this.BalanceP3 = new System.Windows.Forms.Label();
            this.BalanceP4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MoneySelector)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.ActionBTN, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.All_InBTN, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.FoldBTN, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 511);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(957, 30);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ActionBTN
            // 
            this.ActionBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionBTN.Enabled = false;
            this.ActionBTN.Location = new System.Drawing.Point(720, 3);
            this.ActionBTN.Name = "ActionBTN";
            this.ActionBTN.Size = new System.Drawing.Size(234, 24);
            this.ActionBTN.TabIndex = 1;
            this.ActionBTN.Text = "Call";
            this.ActionBTN.UseVisualStyleBackColor = true;
            this.ActionBTN.Click += new System.EventHandler(this.ActionBTNClick);
            // 
            // All_InBTN
            // 
            this.All_InBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.All_InBTN.Enabled = false;
            this.All_InBTN.Location = new System.Drawing.Point(481, 3);
            this.All_InBTN.Name = "All_InBTN";
            this.All_InBTN.Size = new System.Drawing.Size(233, 24);
            this.All_InBTN.TabIndex = 0;
            this.All_InBTN.Text = "All-In";
            this.All_InBTN.UseVisualStyleBackColor = true;
            this.All_InBTN.Click += new System.EventHandler(this.AllInBTNClick);
            // 
            // FoldBTN
            // 
            this.FoldBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FoldBTN.Enabled = false;
            this.FoldBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FoldBTN.Location = new System.Drawing.Point(242, 3);
            this.FoldBTN.Name = "FoldBTN";
            this.FoldBTN.Size = new System.Drawing.Size(233, 24);
            this.FoldBTN.TabIndex = 2;
            this.FoldBTN.Text = "Fold";
            this.FoldBTN.UseVisualStyleBackColor = true;
            this.FoldBTN.Click += new System.EventHandler(this.FoldBTNClick);
            // 
            // MoneySelector
            // 
            this.MoneySelector.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MoneySelector.Enabled = false;
            this.MoneySelector.LargeChange = 50;
            this.MoneySelector.Location = new System.Drawing.Point(902, 401);
            this.MoneySelector.Maximum = 500;
            this.MoneySelector.Name = "MoneySelector";
            this.MoneySelector.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.MoneySelector.Size = new System.Drawing.Size(45, 104);
            this.MoneySelector.SmallChange = 10;
            this.MoneySelector.TabIndex = 1;
            this.MoneySelector.ValueChanged += new System.EventHandler(this.SelectorValueChange);
            // 
            // P1C1
            // 
            this.P1C1.Location = new System.Drawing.Point(107, 211);
            this.P1C1.Name = "P1C1";
            this.P1C1.Size = new System.Drawing.Size(20, 32);
            this.P1C1.TabIndex = 3;
            this.P1C1.Text = "10\r\n♣";
            this.P1C1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P1C2
            // 
            this.P1C2.Location = new System.Drawing.Point(134, 210);
            this.P1C2.Name = "P1C2";
            this.P1C2.Size = new System.Drawing.Size(20, 32);
            this.P1C2.TabIndex = 4;
            this.P1C2.Text = "10\r\n♣";
            this.P1C2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P2C1
            // 
            this.P2C1.Location = new System.Drawing.Point(284, 345);
            this.P2C1.Name = "P2C1";
            this.P2C1.Size = new System.Drawing.Size(20, 32);
            this.P2C1.TabIndex = 5;
            this.P2C1.Text = "10\r\n♣";
            this.P2C1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P2C2
            // 
            this.P2C2.Location = new System.Drawing.Point(317, 345);
            this.P2C2.Name = "P2C2";
            this.P2C2.Size = new System.Drawing.Size(20, 32);
            this.P2C2.TabIndex = 6;
            this.P2C2.Text = "10\r\n♣";
            this.P2C2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P3C1
            // 
            this.P3C1.Location = new System.Drawing.Point(600, 345);
            this.P3C1.Name = "P3C1";
            this.P3C1.Size = new System.Drawing.Size(20, 32);
            this.P3C1.TabIndex = 7;
            this.P3C1.Text = "10\r\n♣";
            this.P3C1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P3C2
            // 
            this.P3C2.Location = new System.Drawing.Point(633, 345);
            this.P3C2.Name = "P3C2";
            this.P3C2.Size = new System.Drawing.Size(20, 32);
            this.P3C2.TabIndex = 8;
            this.P3C2.Text = "10\r\n♣";
            this.P3C2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P4C1
            // 
            this.P4C1.Location = new System.Drawing.Point(741, 279);
            this.P4C1.Name = "P4C1";
            this.P4C1.Size = new System.Drawing.Size(27, 40);
            this.P4C1.TabIndex = 9;
            this.P4C1.Text = "10\r\n♣";
            this.P4C1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P4C2
            // 
            this.P4C2.Location = new System.Drawing.Point(774, 279);
            this.P4C2.Name = "P4C2";
            this.P4C2.Size = new System.Drawing.Size(27, 40);
            this.P4C2.TabIndex = 10;
            this.P4C2.Text = "10\r\n♣";
            this.P4C2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Flop3
            // 
            this.Flop3.Location = new System.Drawing.Point(474, 143);
            this.Flop3.Name = "Flop3";
            this.Flop3.Size = new System.Drawing.Size(20, 32);
            this.Flop3.TabIndex = 11;
            this.Flop3.Text = "10\r\n♣";
            this.Flop3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Flop1
            // 
            this.Flop1.Location = new System.Drawing.Point(408, 143);
            this.Flop1.Name = "Flop1";
            this.Flop1.Size = new System.Drawing.Size(20, 32);
            this.Flop1.TabIndex = 11;
            this.Flop1.Text = "10\r\n♣";
            this.Flop1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Flop2
            // 
            this.Flop2.Location = new System.Drawing.Point(408, 106);
            this.Flop2.Name = "Flop2";
            this.Flop2.Size = new System.Drawing.Size(20, 32);
            this.Flop2.TabIndex = 12;
            this.Flop2.Text = "10\r\n♣";
            this.Flop2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Turn
            // 
            this.Turn.Location = new System.Drawing.Point(507, 143);
            this.Turn.Name = "Turn";
            this.Turn.Size = new System.Drawing.Size(20, 32);
            this.Turn.TabIndex = 13;
            this.Turn.Text = "10\r\n♣";
            this.Turn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // River
            // 
            this.River.Location = new System.Drawing.Point(540, 143);
            this.River.Name = "River";
            this.River.Size = new System.Drawing.Size(20, 32);
            this.River.TabIndex = 14;
            this.River.Text = "10\r\n♣";
            this.River.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PotLabel
            // 
            this.PotLabel.Location = new System.Drawing.Point(220, 113);
            this.PotLabel.Name = "PotLabel";
            this.PotLabel.Size = new System.Drawing.Size(93, 32);
            this.PotLabel.TabIndex = 15;
            this.PotLabel.Text = "Pot:\r\nXXX";
            this.PotLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsernameP1
            // 
            this.UsernameP1.Location = new System.Drawing.Point(82, 195);
            this.UsernameP1.Name = "UsernameP1";
            this.UsernameP1.Size = new System.Drawing.Size(126, 13);
            this.UsernameP1.TabIndex = 16;
            this.UsernameP1.Text = "USERNAMEUSERNAM";
            this.UsernameP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsernameP3
            // 
            this.UsernameP3.Location = new System.Drawing.Point(368, 249);
            this.UsernameP3.Name = "UsernameP3";
            this.UsernameP3.Size = new System.Drawing.Size(126, 13);
            this.UsernameP3.TabIndex = 17;
            this.UsernameP3.Text = "USERNAMEUSERNAM";
            this.UsernameP3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsernameP2
            // 
            this.UsernameP2.Location = new System.Drawing.Point(220, 249);
            this.UsernameP2.Name = "UsernameP2";
            this.UsernameP2.Size = new System.Drawing.Size(126, 13);
            this.UsernameP2.TabIndex = 18;
            this.UsernameP2.Text = "USERNAMEUSERNAM";
            this.UsernameP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsernameP4
            // 
            this.UsernameP4.Location = new System.Drawing.Point(507, 197);
            this.UsernameP4.Name = "UsernameP4";
            this.UsernameP4.Size = new System.Drawing.Size(126, 13);
            this.UsernameP4.TabIndex = 19;
            this.UsernameP4.Text = "USERNAMEUSERNAM";
            this.UsernameP4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BalanceP1
            // 
            this.BalanceP1.Location = new System.Drawing.Point(82, 175);
            this.BalanceP1.Name = "BalanceP1";
            this.BalanceP1.Size = new System.Drawing.Size(126, 13);
            this.BalanceP1.TabIndex = 20;
            this.BalanceP1.Text = "BALANCE : XXXXXXXXXXX";
            this.BalanceP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BalanceP2
            // 
            this.BalanceP2.Location = new System.Drawing.Point(220, 230);
            this.BalanceP2.Name = "BalanceP2";
            this.BalanceP2.Size = new System.Drawing.Size(126, 13);
            this.BalanceP2.TabIndex = 21;
            this.BalanceP2.Text = "BALANCE : XXXXXXXXXXX";
            this.BalanceP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BalanceP3
            // 
            this.BalanceP3.Location = new System.Drawing.Point(368, 230);
            this.BalanceP3.Name = "BalanceP3";
            this.BalanceP3.Size = new System.Drawing.Size(126, 13);
            this.BalanceP3.TabIndex = 22;
            this.BalanceP3.Text = "BALANCE : XXXXXXXXXXX";
            this.BalanceP3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BalanceP4
            // 
            this.BalanceP4.Location = new System.Drawing.Point(507, 184);
            this.BalanceP4.Name = "BalanceP4";
            this.BalanceP4.Size = new System.Drawing.Size(126, 13);
            this.BalanceP4.TabIndex = 23;
            this.BalanceP4.Text = "BALANCE : XXXXXXXXXXX";
            this.BalanceP4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PokerGameNEAProj.Properties.Resources.poker_table_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(957, 541);
            this.Controls.Add(this.BalanceP4);
            this.Controls.Add(this.BalanceP3);
            this.Controls.Add(this.BalanceP2);
            this.Controls.Add(this.BalanceP1);
            this.Controls.Add(this.UsernameP4);
            this.Controls.Add(this.UsernameP2);
            this.Controls.Add(this.UsernameP3);
            this.Controls.Add(this.UsernameP1);
            this.Controls.Add(this.PotLabel);
            this.Controls.Add(this.River);
            this.Controls.Add(this.Turn);
            this.Controls.Add(this.Flop2);
            this.Controls.Add(this.Flop1);
            this.Controls.Add(this.Flop3);
            this.Controls.Add(this.P4C2);
            this.Controls.Add(this.P4C1);
            this.Controls.Add(this.P3C2);
            this.Controls.Add(this.P3C1);
            this.Controls.Add(this.P2C2);
            this.Controls.Add(this.P2C1);
            this.Controls.Add(this.P1C2);
            this.Controls.Add(this.P1C1);
            this.Controls.Add(this.MoneySelector);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameTable";
            this.Text = "Table";
            this.Load += new System.EventHandler(this.GameTable_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MoneySelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ActionBTN;
        private System.Windows.Forms.Button All_InBTN;
        private System.Windows.Forms.Button FoldBTN;
        private System.Windows.Forms.TrackBar MoneySelector;
        private System.Windows.Forms.Label P1C1;
        private System.Windows.Forms.Label P1C2;
        private System.Windows.Forms.Label P2C1;
        private System.Windows.Forms.Label P2C2;
        private System.Windows.Forms.Label P3C1;
        private System.Windows.Forms.Label P3C2;
        private System.Windows.Forms.Label P4C1;
        private System.Windows.Forms.Label P4C2;
        private System.Windows.Forms.Label Flop3;
        private System.Windows.Forms.Label Flop1;
        private System.Windows.Forms.Label Flop2;
        private System.Windows.Forms.Label Turn;
        private System.Windows.Forms.Label River;
        private System.Windows.Forms.Label PotLabel;
        private System.Windows.Forms.Label UsernameP1;
        private System.Windows.Forms.Label UsernameP3;
        private System.Windows.Forms.Label UsernameP2;
        private System.Windows.Forms.Label UsernameP4;
        private System.Windows.Forms.Label BalanceP1;
        private System.Windows.Forms.Label BalanceP2;
        private System.Windows.Forms.Label BalanceP3;
        private System.Windows.Forms.Label BalanceP4;
    }
}