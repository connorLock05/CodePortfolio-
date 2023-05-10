namespace PokerGameNEAProj
{
    partial class Connection
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
            this.HostBTN = new System.Windows.Forms.Button();
            this.ConnectBTN = new System.Windows.Forms.Button();
            this.IPtextField = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.HostBTN, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ConnectBTN, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.IPtextField, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(637, 307);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // HostBTN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.HostBTN, 3);
            this.HostBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HostBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostBTN.Location = new System.Drawing.Point(3, 207);
            this.HostBTN.Name = "HostBTN";
            this.HostBTN.Size = new System.Drawing.Size(631, 97);
            this.HostBTN.TabIndex = 0;
            this.HostBTN.Text = "Host Game";
            this.HostBTN.UseVisualStyleBackColor = true;
            this.HostBTN.Click += new System.EventHandler(this.HostGameBTNClick);
            // 
            // ConnectBTN
            // 
            this.ConnectBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConnectBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectBTN.Location = new System.Drawing.Point(427, 105);
            this.ConnectBTN.Name = "ConnectBTN";
            this.ConnectBTN.Size = new System.Drawing.Size(207, 31);
            this.ConnectBTN.TabIndex = 1;
            this.ConnectBTN.Text = "Connect";
            this.ConnectBTN.UseVisualStyleBackColor = true;
            this.ConnectBTN.Click += new System.EventHandler(this.ConnectBTNClick);
            // 
            // IPtextField
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.IPtextField, 2);
            this.IPtextField.Dock = System.Windows.Forms.DockStyle.Top;
            this.IPtextField.Location = new System.Drawing.Point(3, 105);
            this.IPtextField.Name = "IPtextField";
            this.IPtextField.Size = new System.Drawing.Size(418, 22);
            this.IPtextField.TabIndex = 2;
            this.IPtextField.Text = "Enter IP Here";
            this.IPtextField.Enter += new System.EventHandler(this.IPTextFieldEnter);
            this.IPtextField.Leave += new System.EventHandler(this.IPTextFieldLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 307);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Connect To Server";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button HostBTN;
        private System.Windows.Forms.Button ConnectBTN;
        private System.Windows.Forms.TextBox IPtextField;
    }
}

