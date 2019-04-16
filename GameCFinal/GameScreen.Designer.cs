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
            this.lblPlayerGold = new System.Windows.Forms.Label();
            this.lblPlayerGBP = new System.Windows.Forms.Label();
            this.TbMain = new System.Windows.Forms.RichTextBox();
            this.ActionBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnContinue = new System.Windows.Forms.Button();
            this.lblLoc = new System.Windows.Forms.Label();
            this.lblXP = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblGBP = new System.Windows.Forms.Label();
            this.listBoxPlayerInventory = new System.Windows.Forms.ListBox();
            this.equipButton = new System.Windows.Forms.Button();
            this.lblEquippedArmor = new System.Windows.Forms.Label();
            this.lblEquippedStaff = new System.Windows.Forms.Label();
            this.lblEquippedSword = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.BtnSaveGame = new System.Windows.Forms.Button();
            this.progressBarXP = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblPlayerGold
            // 
            this.lblPlayerGold.AutoSize = true;
            this.lblPlayerGold.Location = new System.Drawing.Point(107, 32);
            this.lblPlayerGold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayerGold.Name = "lblPlayerGold";
            this.lblPlayerGold.Size = new System.Drawing.Size(68, 13);
            this.lblPlayerGold.TabIndex = 1;
            this.lblPlayerGold.Text = "lblPlayerGold";
            // 
            // lblPlayerGBP
            // 
            this.lblPlayerGBP.AutoSize = true;
            this.lblPlayerGBP.Location = new System.Drawing.Point(107, 45);
            this.lblPlayerGBP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayerGBP.Name = "lblPlayerGBP";
            this.lblPlayerGBP.Size = new System.Drawing.Size(68, 13);
            this.lblPlayerGBP.TabIndex = 2;
            this.lblPlayerGBP.Text = "lblPlayerGBP";
            // 
            // TbMain
            // 
            this.TbMain.Location = new System.Drawing.Point(305, 32);
            this.TbMain.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.ActionBox.Location = new System.Drawing.Point(360, 359);
            this.ActionBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ActionBox.Name = "ActionBox";
            this.ActionBox.Size = new System.Drawing.Size(190, 21);
            this.ActionBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(418, 344);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select Action";
            // 
            // BtnContinue
            // 
            this.BtnContinue.Location = new System.Drawing.Point(453, 304);
            this.BtnContinue.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.lblLoc.Location = new System.Drawing.Point(108, 123);
            this.lblLoc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(35, 13);
            this.lblLoc.TabIndex = 9;
            this.lblLoc.Text = "lblLoc";
            // 
            // lblXP
            // 
            this.lblXP.AutoSize = true;
            this.lblXP.Location = new System.Drawing.Point(77, 18);
            this.lblXP.Name = "lblXP";
            this.lblXP.Size = new System.Drawing.Size(24, 13);
            this.lblXP.TabIndex = 10;
            this.lblXP.Text = "XP:";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(69, 32);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(32, 13);
            this.lblGold.TabIndex = 11;
            this.lblGold.Text = "Gold:";
            // 
            // lblGBP
            // 
            this.lblGBP.AutoSize = true;
            this.lblGBP.Location = new System.Drawing.Point(69, 45);
            this.lblGBP.Name = "lblGBP";
            this.lblGBP.Size = new System.Drawing.Size(32, 13);
            this.lblGBP.TabIndex = 12;
            this.lblGBP.Text = "GBP:";
            // 
            // listBoxPlayerInventory
            // 
            this.listBoxPlayerInventory.BackColor = System.Drawing.SystemColors.Window;
            this.listBoxPlayerInventory.FormattingEnabled = true;
            this.listBoxPlayerInventory.Location = new System.Drawing.Point(18, 155);
            this.listBoxPlayerInventory.Name = "listBoxPlayerInventory";
            this.listBoxPlayerInventory.Size = new System.Drawing.Size(196, 264);
            this.listBoxPlayerInventory.TabIndex = 19;
            this.listBoxPlayerInventory.DataSourceChanged += new System.EventHandler(this.listBoxPlayerInventory_DataSourceChanged);
            // 
            // equipButton
            // 
            this.equipButton.Location = new System.Drawing.Point(18, 422);
            this.equipButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.equipButton.Name = "equipButton";
            this.equipButton.Size = new System.Drawing.Size(95, 23);
            this.equipButton.TabIndex = 20;
            this.equipButton.Text = "Equip Item";
            this.equipButton.UseVisualStyleBackColor = true;
            this.equipButton.Click += new System.EventHandler(this.equipButton_Click);
            // 
            // lblEquippedArmor
            // 
            this.lblEquippedArmor.AutoSize = true;
            this.lblEquippedArmor.Location = new System.Drawing.Point(108, 100);
            this.lblEquippedArmor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEquippedArmor.Name = "lblEquippedArmor";
            this.lblEquippedArmor.Size = new System.Drawing.Size(89, 13);
            this.lblEquippedArmor.TabIndex = 21;
            this.lblEquippedArmor.Text = "lblEquippedArmor";
            // 
            // lblEquippedStaff
            // 
            this.lblEquippedStaff.AutoSize = true;
            this.lblEquippedStaff.Location = new System.Drawing.Point(108, 87);
            this.lblEquippedStaff.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEquippedStaff.Name = "lblEquippedStaff";
            this.lblEquippedStaff.Size = new System.Drawing.Size(84, 13);
            this.lblEquippedStaff.TabIndex = 22;
            this.lblEquippedStaff.Text = "lblEquippedStaff";
            // 
            // lblEquippedSword
            // 
            this.lblEquippedSword.AutoSize = true;
            this.lblEquippedSword.Location = new System.Drawing.Point(108, 74);
            this.lblEquippedSword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEquippedSword.Name = "lblEquippedSword";
            this.lblEquippedSword.Size = new System.Drawing.Size(92, 13);
            this.lblEquippedSword.TabIndex = 23;
            this.lblEquippedSword.Text = "lblEquippedSword";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(14, 72);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(88, 13);
            this.lbl1.TabIndex = 24;
            this.lbl1.Text = "Equipped Sword:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(22, 86);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(80, 13);
            this.lbl2.TabIndex = 25;
            this.lbl2.Text = "Equipped Staff:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(15, 100);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(85, 13);
            this.lbl3.TabIndex = 26;
            this.lbl3.Text = "Equipped Armor:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(51, 123);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 27;
            this.lblLocation.Text = "Location:";
            // 
            // BtnSaveGame
            // 
            this.BtnSaveGame.Location = new System.Drawing.Point(117, 422);
            this.BtnSaveGame.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.BtnSaveGame.Name = "BtnSaveGame";
            this.BtnSaveGame.Size = new System.Drawing.Size(95, 23);
            this.BtnSaveGame.TabIndex = 28;
            this.BtnSaveGame.Text = "Save Game";
            this.BtnSaveGame.UseVisualStyleBackColor = true;
            this.BtnSaveGame.Click += new System.EventHandler(this.BtnSaveGame_Click);
            // 
            // progressBarXP
            // 
            this.progressBarXP.Location = new System.Drawing.Point(110, 18);
            this.progressBarXP.Name = "progressBarXP";
            this.progressBarXP.Size = new System.Drawing.Size(100, 13);
            this.progressBarXP.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarXP.TabIndex = 29;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 474);
            this.Controls.Add(this.progressBarXP);
            this.Controls.Add(this.BtnSaveGame);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lblEquippedSword);
            this.Controls.Add(this.lblEquippedStaff);
            this.Controls.Add(this.lblEquippedArmor);
            this.Controls.Add(this.equipButton);
            this.Controls.Add(this.listBoxPlayerInventory);
            this.Controls.Add(this.lblGBP);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblXP);
            this.Controls.Add(this.lblLoc);
            this.Controls.Add(this.BtnContinue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ActionBox);
            this.Controls.Add(this.TbMain);
            this.Controls.Add(this.lblPlayerGBP);
            this.Controls.Add(this.lblPlayerGold);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "GameScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wrath of the Ruined";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game_FormClosed);
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPlayerGold;
        private System.Windows.Forms.Label lblPlayerGBP;
        private System.Windows.Forms.RichTextBox TbMain;
        private System.Windows.Forms.ComboBox ActionBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnContinue;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.Label lblXP;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblGBP;
        private System.Windows.Forms.ListBox listBoxPlayerInventory;
        private System.Windows.Forms.Button equipButton;
        private System.Windows.Forms.Label lblEquippedArmor;
        private System.Windows.Forms.Label lblEquippedStaff;
        private System.Windows.Forms.Label lblEquippedSword;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button BtnSaveGame;
        private System.Windows.Forms.ProgressBar progressBarXP;
    }
}