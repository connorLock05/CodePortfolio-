namespace PokerGameNEAProj
{
    partial class LoginRegister
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PlayerCountNUD = new System.Windows.Forms.NumericUpDown();
            this.InfoLine5 = new System.Windows.Forms.Label();
            this.InfoLine4 = new System.Windows.Forms.Label();
            this.InfoLine3 = new System.Windows.Forms.Label();
            this.InfoLine2 = new System.Windows.Forms.Label();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.FnameLBL = new System.Windows.Forms.Label();
            this.SnameLBL = new System.Windows.Forms.Label();
            this.EmailLBL = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.InfoLine1 = new System.Windows.Forms.Label();
            this.SubmitBTN = new System.Windows.Forms.Button();
            this.ShowPassCheck = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PlayersNUDLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCountNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.registerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.LoginLoad);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.registerToolStripMenuItem.Text = "Register";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.RegisterLoad);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.PlayerCountNUD, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.InfoLine5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.InfoLine4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.InfoLine3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.InfoLine2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.FirstNameTextBox, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.SurnameTextBox, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.EmailTextBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.FnameLBL, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.SnameLBL, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.EmailLBL, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.PasswordTextBox, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.UsernameTextBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.InfoLine1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.SubmitBTN, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.ShowPassCheck, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.button1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.PlayersNUDLabel, 2, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 422);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // PlayerCountNUD
            // 
            this.PlayerCountNUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerCountNUD.Location = new System.Drawing.Point(603, 297);
            this.PlayerCountNUD.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.PlayerCountNUD.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.PlayerCountNUD.Name = "PlayerCountNUD";
            this.PlayerCountNUD.Size = new System.Drawing.Size(194, 22);
            this.PlayerCountNUD.TabIndex = 10;
            this.PlayerCountNUD.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.PlayerCountNUD.Visible = false;
            // 
            // InfoLine5
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.InfoLine5, 2);
            this.InfoLine5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoLine5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLine5.Location = new System.Drawing.Point(203, 168);
            this.InfoLine5.Name = "InfoLine5";
            this.InfoLine5.Size = new System.Drawing.Size(394, 42);
            this.InfoLine5.TabIndex = 14;
            this.InfoLine5.Text = "Both Uppercase and Lowercase Characters";
            this.InfoLine5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoLine4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.InfoLine4, 2);
            this.InfoLine4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoLine4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLine4.Location = new System.Drawing.Point(203, 126);
            this.InfoLine4.Name = "InfoLine4";
            this.InfoLine4.Size = new System.Drawing.Size(394, 42);
            this.InfoLine4.TabIndex = 13;
            this.InfoLine4.Text = "Both Uppercase and Lowercase Characters";
            this.InfoLine4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoLine3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.InfoLine3, 2);
            this.InfoLine3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoLine3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLine3.Location = new System.Drawing.Point(203, 84);
            this.InfoLine3.Name = "InfoLine3";
            this.InfoLine3.Size = new System.Drawing.Size(394, 42);
            this.InfoLine3.TabIndex = 12;
            this.InfoLine3.Text = "Both Uppercase and Lowercase Characters";
            this.InfoLine3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoLine2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.InfoLine2, 2);
            this.InfoLine2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLine2.Location = new System.Drawing.Point(203, 42);
            this.InfoLine2.Name = "InfoLine2";
            this.InfoLine2.Size = new System.Drawing.Size(394, 42);
            this.InfoLine2.TabIndex = 11;
            this.InfoLine2.Text = "Both Uppercase and Lowercase Characters";
            this.InfoLine2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.FirstNameTextBox.Location = new System.Drawing.Point(3, 255);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(194, 22);
            this.FirstNameTextBox.TabIndex = 3;
            // 
            // SurnameTextBox
            // 
            this.SurnameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.SurnameTextBox.Location = new System.Drawing.Point(603, 255);
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.Size = new System.Drawing.Size(194, 22);
            this.SurnameTextBox.TabIndex = 5;
            // 
            // EmailTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.EmailTextBox, 2);
            this.EmailTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.EmailTextBox.Location = new System.Drawing.Point(203, 255);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(394, 22);
            this.EmailTextBox.TabIndex = 4;
            this.EmailTextBox.Enter += new System.EventHandler(this.EmailEnter);
            // 
            // FnameLBL
            // 
            this.FnameLBL.AutoSize = true;
            this.FnameLBL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FnameLBL.Location = new System.Drawing.Point(3, 236);
            this.FnameLBL.Name = "FnameLBL";
            this.FnameLBL.Size = new System.Drawing.Size(194, 16);
            this.FnameLBL.TabIndex = 6;
            this.FnameLBL.Text = "First Name";
            this.FnameLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SnameLBL
            // 
            this.SnameLBL.AutoSize = true;
            this.SnameLBL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SnameLBL.Location = new System.Drawing.Point(603, 236);
            this.SnameLBL.Name = "SnameLBL";
            this.SnameLBL.Size = new System.Drawing.Size(194, 16);
            this.SnameLBL.TabIndex = 5;
            this.SnameLBL.Text = "Surname";
            this.SnameLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmailLBL
            // 
            this.EmailLBL.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.EmailLBL, 2);
            this.EmailLBL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EmailLBL.Location = new System.Drawing.Point(203, 236);
            this.EmailLBL.Name = "EmailLBL";
            this.EmailLBL.Size = new System.Drawing.Size(394, 16);
            this.EmailLBL.TabIndex = 4;
            this.EmailLBL.Text = "Email";
            this.EmailLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.PasswordTextBox.Location = new System.Drawing.Point(603, 129);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(194, 22);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.Enter += new System.EventHandler(this.PasswordEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(603, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(3, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.UsernameTextBox.Location = new System.Drawing.Point(3, 129);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(194, 22);
            this.UsernameTextBox.TabIndex = 1;
            this.UsernameTextBox.Enter += new System.EventHandler(this.UsernameEnter);
            // 
            // InfoLine1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.InfoLine1, 2);
            this.InfoLine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLine1.Location = new System.Drawing.Point(203, 0);
            this.InfoLine1.Name = "InfoLine1";
            this.InfoLine1.Size = new System.Drawing.Size(394, 42);
            this.InfoLine1.TabIndex = 10;
            this.InfoLine1.Text = "Both Uppercase and Lowercase Characters";
            this.InfoLine1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SubmitBTN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.SubmitBTN, 4);
            this.SubmitBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubmitBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitBTN.Location = new System.Drawing.Point(3, 339);
            this.SubmitBTN.Name = "SubmitBTN";
            this.SubmitBTN.Size = new System.Drawing.Size(794, 36);
            this.SubmitBTN.TabIndex = 6;
            this.SubmitBTN.Text = "Register";
            this.SubmitBTN.UseVisualStyleBackColor = true;
            this.SubmitBTN.Click += new System.EventHandler(this.SubmitBTNClick);
            // 
            // ShowPassCheck
            // 
            this.ShowPassCheck.AutoSize = true;
            this.ShowPassCheck.Dock = System.Windows.Forms.DockStyle.Right;
            this.ShowPassCheck.Location = new System.Drawing.Point(672, 171);
            this.ShowPassCheck.Name = "ShowPassCheck";
            this.ShowPassCheck.Size = new System.Drawing.Size(125, 36);
            this.ShowPassCheck.TabIndex = 15;
            this.ShowPassCheck.Text = "Show Password";
            this.ShowPassCheck.UseVisualStyleBackColor = true;
            this.ShowPassCheck.CheckedChanged += new System.EventHandler(this.ShowPassChanged);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(603, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 36);
            this.button1.TabIndex = 16;
            this.button1.Text = "Back To Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BackToConnect);
            // 
            // PlayersNUDLabel
            // 
            this.PlayersNUDLabel.AutoSize = true;
            this.PlayersNUDLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlayersNUDLabel.Location = new System.Drawing.Point(403, 294);
            this.PlayersNUDLabel.Name = "PlayersNUDLabel";
            this.PlayersNUDLabel.Size = new System.Drawing.Size(194, 16);
            this.PlayersNUDLabel.TabIndex = 17;
            this.PlayersNUDLabel.Text = "Number Of Players:";
            this.PlayersNUDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PlayersNUDLabel.Visible = false;
            // 
            // LoginRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LoginRegister";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.LoginRegister_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCountNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.TextBox SurnameTextBox;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label FnameLBL;
        private System.Windows.Forms.Label SnameLBL;
        private System.Windows.Forms.Label EmailLBL;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label InfoLine5;
        private System.Windows.Forms.Label InfoLine4;
        private System.Windows.Forms.Label InfoLine3;
        private System.Windows.Forms.Label InfoLine2;
        private System.Windows.Forms.Label InfoLine1;
        private System.Windows.Forms.Button SubmitBTN;
        private System.Windows.Forms.CheckBox ShowPassCheck;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown PlayerCountNUD;
        private System.Windows.Forms.Label PlayersNUDLabel;
    }
}