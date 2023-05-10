namespace MessangerApp
{
    partial class Messenger
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
            this.DisplayBox = new System.Windows.Forms.TextBox();
            this.InputField = new System.Windows.Forms.TextBox();
            this.SendBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.DisplayBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.InputField, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SendBTN, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(391, 518);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DisplayBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.DisplayBox, 2);
            this.DisplayBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayBox.Location = new System.Drawing.Point(3, 3);
            this.DisplayBox.Multiline = true;
            this.DisplayBox.Name = "DisplayBox";
            this.DisplayBox.ReadOnly = true;
            this.DisplayBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DisplayBox.Size = new System.Drawing.Size(385, 460);
            this.DisplayBox.TabIndex = 0;
            // 
            // InputField
            // 
            this.InputField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputField.Location = new System.Drawing.Point(3, 481);
            this.InputField.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.InputField.Name = "InputField";
            this.InputField.Size = new System.Drawing.Size(326, 20);
            this.InputField.TabIndex = 1;
            // 
            // SendBTN
            // 
            this.SendBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SendBTN.Location = new System.Drawing.Point(335, 469);
            this.SendBTN.Name = "SendBTN";
            this.SendBTN.Size = new System.Drawing.Size(53, 46);
            this.SendBTN.TabIndex = 2;
            this.SendBTN.Text = "-->";
            this.SendBTN.UseVisualStyleBackColor = true;
            this.SendBTN.Click += new System.EventHandler(this.SendBTN_Click);
            // 
            // Messenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 518);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Messenger";
            this.Text = "Messenger";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox DisplayBox;
        private System.Windows.Forms.TextBox InputField;
        private System.Windows.Forms.Button SendBTN;
    }
}