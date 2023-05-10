namespace MessangerApp
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
            this.UsernameField = new System.Windows.Forms.TextBox();
            this.IPField = new System.Windows.Forms.TextBox();
            this.HostBTN = new System.Windows.Forms.Button();
            this.JoinBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.UsernameField, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.IPField, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.HostBTN, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.JoinBTN, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(523, 289);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // UsernameField
            // 
            this.UsernameField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsernameField.Location = new System.Drawing.Point(3, 60);
            this.UsernameField.Margin = new System.Windows.Forms.Padding(3, 60, 3, 3);
            this.UsernameField.Name = "UsernameField";
            this.UsernameField.Size = new System.Drawing.Size(255, 20);
            this.UsernameField.TabIndex = 0;
            this.UsernameField.Text = "Username";
            this.UsernameField.Enter += new System.EventHandler(this.UsernameField_Enter);
            this.UsernameField.Leave += new System.EventHandler(this.UsernameField_Leave);
            // 
            // IPField
            // 
            this.IPField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IPField.Location = new System.Drawing.Point(264, 60);
            this.IPField.Margin = new System.Windows.Forms.Padding(3, 60, 3, 3);
            this.IPField.Name = "IPField";
            this.IPField.Size = new System.Drawing.Size(256, 20);
            this.IPField.TabIndex = 1;
            this.IPField.Text = "IP Address";
            this.IPField.Enter += new System.EventHandler(this.IPField_Enter);
            this.IPField.Leave += new System.EventHandler(this.IPField_Leave);
            // 
            // HostBTN
            // 
            this.HostBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HostBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostBTN.Location = new System.Drawing.Point(3, 147);
            this.HostBTN.Name = "HostBTN";
            this.HostBTN.Size = new System.Drawing.Size(255, 139);
            this.HostBTN.TabIndex = 2;
            this.HostBTN.Text = "Host";
            this.HostBTN.UseVisualStyleBackColor = true;
            this.HostBTN.Click += new System.EventHandler(this.HostBTN_Click);
            // 
            // JoinBTN
            // 
            this.JoinBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JoinBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinBTN.Location = new System.Drawing.Point(264, 147);
            this.JoinBTN.Name = "JoinBTN";
            this.JoinBTN.Size = new System.Drawing.Size(256, 139);
            this.JoinBTN.TabIndex = 3;
            this.JoinBTN.Text = "Join";
            this.JoinBTN.UseVisualStyleBackColor = true;
            this.JoinBTN.Click += new System.EventHandler(this.JoinBTN_Click);
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 289);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Connection";
            this.Text = "Connect To Host";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox UsernameField;
        private System.Windows.Forms.TextBox IPField;
        private System.Windows.Forms.Button HostBTN;
        private System.Windows.Forms.Button JoinBTN;
    }
}

