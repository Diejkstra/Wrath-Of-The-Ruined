namespace WrathOfTheRuined
{
    partial class ChangeStanceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeStanceForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Defensive = new System.Windows.Forms.Button();
            this.Neutral = new System.Windows.Forms.Button();
            this.Aggressive = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(419, 93);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change Stance:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.Defensive, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Neutral, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Aggressive, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 40);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(413, 50);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // Defensive
            // 
            this.Defensive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Defensive.Location = new System.Drawing.Point(23, 10);
            this.Defensive.Name = "Defensive";
            this.Defensive.Size = new System.Drawing.Size(90, 30);
            this.Defensive.TabIndex = 0;
            this.Defensive.Text = "Defensive";
            this.Defensive.UseVisualStyleBackColor = true;
            this.Defensive.Click += new System.EventHandler(this.Defensive_Click);
            // 
            // Neutral
            // 
            this.Neutral.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Neutral.Location = new System.Drawing.Point(160, 10);
            this.Neutral.Name = "Neutral";
            this.Neutral.Size = new System.Drawing.Size(90, 30);
            this.Neutral.TabIndex = 1;
            this.Neutral.Text = "Neutral";
            this.Neutral.UseVisualStyleBackColor = true;
            this.Neutral.Click += new System.EventHandler(this.Neutral_Click);
            // 
            // Aggressive
            // 
            this.Aggressive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Aggressive.Location = new System.Drawing.Point(298, 10);
            this.Aggressive.Name = "Aggressive";
            this.Aggressive.Size = new System.Drawing.Size(90, 30);
            this.Aggressive.TabIndex = 2;
            this.Aggressive.Text = "Aggressive";
            this.Aggressive.UseVisualStyleBackColor = true;
            this.Aggressive.Click += new System.EventHandler(this.Aggressive_Click);
            // 
            // ChangeStanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 161);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChangeStanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeStanceForm";
            this.Load += new System.EventHandler(this.ChangeStanceForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Defensive;
        private System.Windows.Forms.Button Neutral;
        private System.Windows.Forms.Button Aggressive;
    }
}