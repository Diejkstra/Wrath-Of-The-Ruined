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
            this.SuspendLayout();
            // 
            // lblPlayerXP
            // 
            this.lblPlayerXP.AutoSize = true;
            this.lblPlayerXP.Location = new System.Drawing.Point(144, 22);
            this.lblPlayerXP.Name = "lblPlayerXP";
            this.lblPlayerXP.Size = new System.Drawing.Size(80, 17);
            this.lblPlayerXP.TabIndex = 0;
            this.lblPlayerXP.Text = "lblPlayerXP";
            // 
            // lblPlayerGold
            // 
            this.lblPlayerGold.AutoSize = true;
            this.lblPlayerGold.Location = new System.Drawing.Point(143, 39);
            this.lblPlayerGold.Name = "lblPlayerGold";
            this.lblPlayerGold.Size = new System.Drawing.Size(92, 17);
            this.lblPlayerGold.TabIndex = 1;
            this.lblPlayerGold.Text = "lblPlayerGold";
            // 
            // lblPlayerGBP
            // 
            this.lblPlayerGBP.AutoSize = true;
            this.lblPlayerGBP.Location = new System.Drawing.Point(143, 56);
            this.lblPlayerGBP.Name = "lblPlayerGBP";
            this.lblPlayerGBP.Size = new System.Drawing.Size(91, 17);
            this.lblPlayerGBP.TabIndex = 2;
            this.lblPlayerGBP.Text = "lblPlayerGBP";
            // 
            // TbMain
            // 
            this.TbMain.Location = new System.Drawing.Point(407, 39);
            this.TbMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TbMain.Name = "TbMain";
            this.TbMain.ReadOnly = true;
            this.TbMain.Size = new System.Drawing.Size(324, 333);
            this.TbMain.TabIndex = 4;
            this.TbMain.Text = "";
            // 
            // ActionBox
            // 
            this.ActionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ActionBox.FormattingEnabled = true;
            this.ActionBox.Location = new System.Drawing.Point(451, 445);
            this.ActionBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ActionBox.Name = "ActionBox";
            this.ActionBox.Size = new System.Drawing.Size(252, 24);
            this.ActionBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(530, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select Action";
            // 
            // BtnContinue
            // 
            this.BtnContinue.Location = new System.Drawing.Point(604, 385);
            this.BtnContinue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnContinue.Name = "BtnContinue";
            this.BtnContinue.Size = new System.Drawing.Size(127, 28);
            this.BtnContinue.TabIndex = 8;
            this.BtnContinue.Text = "Continue";
            this.BtnContinue.UseVisualStyleBackColor = true;
            this.BtnContinue.Click += new System.EventHandler(this.OutsideTownContinueClick);
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Location = new System.Drawing.Point(144, 152);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(45, 17);
            this.lblLoc.TabIndex = 9;
            this.lblLoc.Text = "lblLoc";
            // 
            // lblXP
            // 
            this.lblXP.AutoSize = true;
            this.lblXP.Location = new System.Drawing.Point(103, 22);
            this.lblXP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXP.Name = "lblXP";
            this.lblXP.Size = new System.Drawing.Size(30, 17);
            this.lblXP.TabIndex = 10;
            this.lblXP.Text = "XP:";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(92, 39);
            this.lblGold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(42, 17);
            this.lblGold.TabIndex = 11;
            this.lblGold.Text = "Gold:";
            // 
            // lblGBP
            // 
            this.lblGBP.AutoSize = true;
            this.lblGBP.Location = new System.Drawing.Point(92, 56);
            this.lblGBP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGBP.Name = "lblGBP";
            this.lblGBP.Size = new System.Drawing.Size(41, 17);
            this.lblGBP.TabIndex = 12;
            this.lblGBP.Text = "GBP:";
            // 
            // listBoxPlayerInventory
            // 
            this.listBoxPlayerInventory.BackColor = System.Drawing.SystemColors.Window;
            this.listBoxPlayerInventory.FormattingEnabled = true;
            this.listBoxPlayerInventory.ItemHeight = 16;
            this.listBoxPlayerInventory.Location = new System.Drawing.Point(24, 190);
            this.listBoxPlayerInventory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxPlayerInventory.Name = "listBoxPlayerInventory";
            this.listBoxPlayerInventory.Size = new System.Drawing.Size(275, 324);
            this.listBoxPlayerInventory.TabIndex = 19;
            this.listBoxPlayerInventory.DataSourceChanged += new System.EventHandler(this.listBoxPlayerInventory_DataSourceChanged);
            // 
            // equipButton
            // 
            this.equipButton.Location = new System.Drawing.Point(173, 521);
            this.equipButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.equipButton.Name = "equipButton";
            this.equipButton.Size = new System.Drawing.Size(127, 28);
            this.equipButton.TabIndex = 20;
            this.equipButton.Text = "Equip Item";
            this.equipButton.UseVisualStyleBackColor = true;
            this.equipButton.Click += new System.EventHandler(this.equipButton_Click);
            // 
            // lblEquippedArmor
            // 
            this.lblEquippedArmor.AutoSize = true;
            this.lblEquippedArmor.Location = new System.Drawing.Point(144, 123);
            this.lblEquippedArmor.Name = "lblEquippedArmor";
            this.lblEquippedArmor.Size = new System.Drawing.Size(120, 17);
            this.lblEquippedArmor.TabIndex = 21;
            this.lblEquippedArmor.Text = "lblEquippedArmor";
            // 
            // lblEquippedStaff
            // 
            this.lblEquippedStaff.AutoSize = true;
            this.lblEquippedStaff.Location = new System.Drawing.Point(144, 107);
            this.lblEquippedStaff.Name = "lblEquippedStaff";
            this.lblEquippedStaff.Size = new System.Drawing.Size(111, 17);
            this.lblEquippedStaff.TabIndex = 22;
            this.lblEquippedStaff.Text = "lblEquippedStaff";
            // 
            // lblEquippedSword
            // 
            this.lblEquippedSword.AutoSize = true;
            this.lblEquippedSword.Location = new System.Drawing.Point(144, 91);
            this.lblEquippedSword.Name = "lblEquippedSword";
            this.lblEquippedSword.Size = new System.Drawing.Size(121, 17);
            this.lblEquippedSword.TabIndex = 23;
            this.lblEquippedSword.Text = "lblEquippedSword";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(19, 89);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(115, 17);
            this.lbl1.TabIndex = 24;
            this.lbl1.Text = "Equipped Sword:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(29, 106);
            this.lbl2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(105, 17);
            this.lbl2.TabIndex = 25;
            this.lbl2.Text = "Equipped Staff:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(20, 123);
            this.lbl3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(114, 17);
            this.lbl3.TabIndex = 26;
            this.lbl3.Text = "Equipped Armor:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(68, 152);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(66, 17);
            this.lblLocation.TabIndex = 27;
            this.lblLocation.Text = "Location:";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 584);
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
            this.Controls.Add(this.lblPlayerXP);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wrath of the Ruined";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game_FormClosed);
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerXP;
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
    }
}