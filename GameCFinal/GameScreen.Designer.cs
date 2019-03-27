namespace GameCFinal
{
    partial class GameScreen
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
            this.lblXP = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblGBP = new System.Windows.Forms.Label();
            this.DgQuests = new System.Windows.Forms.DataGridView();
            this.TbMain = new System.Windows.Forms.RichTextBox();
            this.CbChoice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnContinue = new System.Windows.Forms.Button();
            this.lblLoc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgQuests)).BeginInit();
            this.SuspendLayout();
            // 
            // lblXP
            // 
            this.lblXP.AutoSize = true;
            this.lblXP.Location = new System.Drawing.Point(23, 30);
            this.lblXP.Name = "lblXP";
            this.lblXP.Size = new System.Drawing.Size(51, 20);
            this.lblXP.TabIndex = 0;
            this.lblXP.Text = "label1";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(23, 50);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(51, 20);
            this.lblGold.TabIndex = 1;
            this.lblGold.Text = "label1";
            // 
            // lblGBP
            // 
            this.lblGBP.AutoSize = true;
            this.lblGBP.Location = new System.Drawing.Point(23, 70);
            this.lblGBP.Name = "lblGBP";
            this.lblGBP.Size = new System.Drawing.Size(51, 20);
            this.lblGBP.TabIndex = 2;
            this.lblGBP.Text = "label1";
            // 
            // DgQuests
            // 
            this.DgQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgQuests.Location = new System.Drawing.Point(27, 423);
            this.DgQuests.Name = "DgQuests";
            this.DgQuests.RowTemplate.Height = 28;
            this.DgQuests.Size = new System.Drawing.Size(240, 229);
            this.DgQuests.TabIndex = 3;
            // 
            // TbMain
            // 
            this.TbMain.Location = new System.Drawing.Point(376, 50);
            this.TbMain.Name = "TbMain";
            this.TbMain.ReadOnly = true;
            this.TbMain.Size = new System.Drawing.Size(364, 415);
            this.TbMain.TabIndex = 4;
            this.TbMain.Text = "";
            // 
            // CbChoice
            // 
            this.CbChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbChoice.FormattingEnabled = true;
            this.CbChoice.Location = new System.Drawing.Point(457, 549);
            this.CbChoice.Name = "CbChoice";
            this.CbChoice.Size = new System.Drawing.Size(283, 28);
            this.CbChoice.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(637, 526);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select Action";
            // 
            // BtnContinue
            // 
            this.BtnContinue.Location = new System.Drawing.Point(597, 472);
            this.BtnContinue.Name = "BtnContinue";
            this.BtnContinue.Size = new System.Drawing.Size(143, 36);
            this.BtnContinue.TabIndex = 8;
            this.BtnContinue.Text = "Continue";
            this.BtnContinue.UseVisualStyleBackColor = true;
            this.BtnContinue.Click += new System.EventHandler(this.BtnContinue_Click);
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Location = new System.Drawing.Point(457, 608);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(51, 20);
            this.lblLoc.TabIndex = 9;
            this.lblLoc.Text = "label2";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 744);
            this.Controls.Add(this.lblLoc);
            this.Controls.Add(this.BtnContinue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbChoice);
            this.Controls.Add(this.TbMain);
            this.Controls.Add(this.DgQuests);
            this.Controls.Add(this.lblGBP);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblXP);
            this.Name = "GameScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wrath of the Ruined";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game_FormClosed);
            this.Load += new System.EventHandler(this.Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgQuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblXP;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblGBP;
        private System.Windows.Forms.DataGridView DgQuests;
        private System.Windows.Forms.RichTextBox TbMain;
        private System.Windows.Forms.ComboBox CbChoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnContinue;
        private System.Windows.Forms.Label lblLoc;
    }
}