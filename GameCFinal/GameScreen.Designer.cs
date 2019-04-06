namespace WrathOfTheRuined
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
            this.lblPlayerXP = new System.Windows.Forms.Label();
            this.lblPlayerGold = new System.Windows.Forms.Label();
            this.lblPlayerGBP = new System.Windows.Forms.Label();
            this.DgQuests = new System.Windows.Forms.DataGridView();
            this.TbMain = new System.Windows.Forms.RichTextBox();
            this.ActionBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnContinue = new System.Windows.Forms.Button();
            this.lblLoc = new System.Windows.Forms.Label();
            this.lblXP = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblGBP = new System.Windows.Forms.Label();
            this.lblSword = new System.Windows.Forms.Label();
            this.lblStaff = new System.Windows.Forms.Label();
            this.lblArmor = new System.Windows.Forms.Label();
            this.lblPlayerSword = new System.Windows.Forms.Label();
            this.lblPlayerStaff = new System.Windows.Forms.Label();
            this.lblPlayerArmor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgQuests)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayerXP
            // 
            this.lblPlayerXP.AutoSize = true;
            this.lblPlayerXP.Location = new System.Drawing.Point(52, 19);
            this.lblPlayerXP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayerXP.Name = "lblPlayerXP";
            this.lblPlayerXP.Size = new System.Drawing.Size(60, 13);
            this.lblPlayerXP.TabIndex = 0;
            this.lblPlayerXP.Text = "lblPlayerXP";
            // 
            // lblPlayerGold
            // 
            this.lblPlayerGold.AutoSize = true;
            this.lblPlayerGold.Location = new System.Drawing.Point(52, 32);
            this.lblPlayerGold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayerGold.Name = "lblPlayerGold";
            this.lblPlayerGold.Size = new System.Drawing.Size(68, 13);
            this.lblPlayerGold.TabIndex = 1;
            this.lblPlayerGold.Text = "lblPlayerGold";
            // 
            // lblPlayerGBP
            // 
            this.lblPlayerGBP.AutoSize = true;
            this.lblPlayerGBP.Location = new System.Drawing.Point(52, 45);
            this.lblPlayerGBP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayerGBP.Name = "lblPlayerGBP";
            this.lblPlayerGBP.Size = new System.Drawing.Size(68, 13);
            this.lblPlayerGBP.TabIndex = 2;
            this.lblPlayerGBP.Text = "lblPlayerGBP";
            // 
            // DgQuests
            // 
            this.DgQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgQuests.Location = new System.Drawing.Point(18, 275);
            this.DgQuests.Margin = new System.Windows.Forms.Padding(2);
            this.DgQuests.Name = "DgQuests";
            this.DgQuests.RowTemplate.Height = 28;
            this.DgQuests.Size = new System.Drawing.Size(160, 149);
            this.DgQuests.TabIndex = 3;
            // 
            // TbMain
            // 
            this.TbMain.Location = new System.Drawing.Point(251, 32);
            this.TbMain.Margin = new System.Windows.Forms.Padding(2);
            this.TbMain.Name = "TbMain";
            this.TbMain.ReadOnly = true;
            this.TbMain.Size = new System.Drawing.Size(244, 271);
            this.TbMain.TabIndex = 4;
            this.TbMain.Text = "";
            // 
            // ActionBox
            // 
            this.ActionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ActionBox.FormattingEnabled = true;
            this.ActionBox.Location = new System.Drawing.Point(305, 357);
            this.ActionBox.Margin = new System.Windows.Forms.Padding(2);
            this.ActionBox.Name = "ActionBox";
            this.ActionBox.Size = new System.Drawing.Size(190, 21);
            this.ActionBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 342);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select Action";
            // 
            // BtnContinue
            // 
            this.BtnContinue.Location = new System.Drawing.Point(398, 307);
            this.BtnContinue.Margin = new System.Windows.Forms.Padding(2);
            this.BtnContinue.Name = "BtnContinue";
            this.BtnContinue.Size = new System.Drawing.Size(95, 23);
            this.BtnContinue.TabIndex = 8;
            this.BtnContinue.Text = "Continue";
            this.BtnContinue.UseVisualStyleBackColor = true;
            this.BtnContinue.Click += new System.EventHandler(this.OutsideTownContinueClick);
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Location = new System.Drawing.Point(305, 395);
            this.lblLoc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(35, 13);
            this.lblLoc.TabIndex = 9;
            this.lblLoc.Text = "lblLoc";
            // 
            // lblXP
            // 
            this.lblXP.AutoSize = true;
            this.lblXP.Location = new System.Drawing.Point(15, 19);
            this.lblXP.Name = "lblXP";
            this.lblXP.Size = new System.Drawing.Size(24, 13);
            this.lblXP.TabIndex = 10;
            this.lblXP.Text = "XP:";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(15, 32);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(32, 13);
            this.lblGold.TabIndex = 11;
            this.lblGold.Text = "Gold:";
            // 
            // lblGBP
            // 
            this.lblGBP.AutoSize = true;
            this.lblGBP.Location = new System.Drawing.Point(15, 45);
            this.lblGBP.Name = "lblGBP";
            this.lblGBP.Size = new System.Drawing.Size(32, 13);
            this.lblGBP.TabIndex = 12;
            this.lblGBP.Text = "GBP:";
            // 
            // lblSword
            // 
            this.lblSword.AutoSize = true;
            this.lblSword.Location = new System.Drawing.Point(15, 69);
            this.lblSword.Name = "lblSword";
            this.lblSword.Size = new System.Drawing.Size(40, 13);
            this.lblSword.TabIndex = 13;
            this.lblSword.Text = "Sword:";
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(15, 82);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(32, 13);
            this.lblStaff.TabIndex = 14;
            this.lblStaff.Text = "Staff:";
            // 
            // lblArmor
            // 
            this.lblArmor.AutoSize = true;
            this.lblArmor.Location = new System.Drawing.Point(15, 95);
            this.lblArmor.Name = "lblArmor";
            this.lblArmor.Size = new System.Drawing.Size(37, 13);
            this.lblArmor.TabIndex = 15;
            this.lblArmor.Text = "Armor:";
            // 
            // lblPlayerSword
            // 
            this.lblPlayerSword.AutoSize = true;
            this.lblPlayerSword.Location = new System.Drawing.Point(52, 69);
            this.lblPlayerSword.Name = "lblPlayerSword";
            this.lblPlayerSword.Size = new System.Drawing.Size(76, 13);
            this.lblPlayerSword.TabIndex = 16;
            this.lblPlayerSword.Text = "lblPlayerSword";
            // 
            // lblPlayerStaff
            // 
            this.lblPlayerStaff.AutoSize = true;
            this.lblPlayerStaff.Location = new System.Drawing.Point(52, 82);
            this.lblPlayerStaff.Name = "lblPlayerStaff";
            this.lblPlayerStaff.Size = new System.Drawing.Size(68, 13);
            this.lblPlayerStaff.TabIndex = 17;
            this.lblPlayerStaff.Text = "lblPlayerStaff";
            // 
            // lblPlayerArmor
            // 
            this.lblPlayerArmor.AutoSize = true;
            this.lblPlayerArmor.Location = new System.Drawing.Point(52, 95);
            this.lblPlayerArmor.Name = "lblPlayerArmor";
            this.lblPlayerArmor.Size = new System.Drawing.Size(73, 13);
            this.lblPlayerArmor.TabIndex = 18;
            this.lblPlayerArmor.Text = "lblPlayerArmor";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 484);
            this.Controls.Add(this.lblPlayerArmor);
            this.Controls.Add(this.lblPlayerStaff);
            this.Controls.Add(this.lblPlayerSword);
            this.Controls.Add(this.lblArmor);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.lblSword);
            this.Controls.Add(this.lblGBP);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblXP);
            this.Controls.Add(this.lblLoc);
            this.Controls.Add(this.BtnContinue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ActionBox);
            this.Controls.Add(this.TbMain);
            this.Controls.Add(this.DgQuests);
            this.Controls.Add(this.lblPlayerGBP);
            this.Controls.Add(this.lblPlayerGold);
            this.Controls.Add(this.lblPlayerXP);
            this.Margin = new System.Windows.Forms.Padding(2);
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

        private System.Windows.Forms.Label lblPlayerXP;
        private System.Windows.Forms.Label lblPlayerGold;
        private System.Windows.Forms.Label lblPlayerGBP;
        private System.Windows.Forms.DataGridView DgQuests;
        private System.Windows.Forms.RichTextBox TbMain;
        private System.Windows.Forms.ComboBox ActionBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnContinue;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.Label lblXP;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblGBP;
        private System.Windows.Forms.Label lblSword;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.Label lblArmor;
        private System.Windows.Forms.Label lblPlayerSword;
        private System.Windows.Forms.Label lblPlayerStaff;
        private System.Windows.Forms.Label lblPlayerArmor;
    }
}