namespace WrathOfTheRuined
{
    partial class StoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreForm));
            this.lblGold = new System.Windows.Forms.Label();
            this.lblPlayerGold = new System.Windows.Forms.Label();
            this.lblGBP = new System.Windows.Forms.Label();
            this.lblPlayerGBP = new System.Windows.Forms.Label();
            this.listBoxStoreInv = new System.Windows.Forms.ListBox();
            this.sellButton = new System.Windows.Forms.Button();
            this.lblPlayerInv = new System.Windows.Forms.Label();
            this.lblStore = new System.Windows.Forms.Label();
            this.listBoxPlayerInv = new System.Windows.Forms.ListBox();
            this.buyButton = new System.Windows.Forms.Button();
            this.leaveButton = new System.Windows.Forms.Button();
            this.lblPlayerValue = new System.Windows.Forms.Label();
            this.lblStoreValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(48, 23);
            this.lblGold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(52, 17);
            this.lblGold.TabIndex = 0;
            this.lblGold.Text = "lblGold";
            // 
            // lblPlayerGold
            // 
            this.lblPlayerGold.AutoSize = true;
            this.lblPlayerGold.Location = new System.Drawing.Point(108, 23);
            this.lblPlayerGold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayerGold.Name = "lblPlayerGold";
            this.lblPlayerGold.Size = new System.Drawing.Size(92, 17);
            this.lblPlayerGold.TabIndex = 1;
            this.lblPlayerGold.Text = "lblPlayerGold";
            // 
            // lblGBP
            // 
            this.lblGBP.AutoSize = true;
            this.lblGBP.Location = new System.Drawing.Point(48, 39);
            this.lblGBP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGBP.Name = "lblGBP";
            this.lblGBP.Size = new System.Drawing.Size(51, 17);
            this.lblGBP.TabIndex = 2;
            this.lblGBP.Text = "lblGBP";
            // 
            // lblPlayerGBP
            // 
            this.lblPlayerGBP.AutoSize = true;
            this.lblPlayerGBP.Location = new System.Drawing.Point(108, 39);
            this.lblPlayerGBP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayerGBP.Name = "lblPlayerGBP";
            this.lblPlayerGBP.Size = new System.Drawing.Size(91, 17);
            this.lblPlayerGBP.TabIndex = 3;
            this.lblPlayerGBP.Text = "lblPlayerGBP";
            // 
            // listBoxStoreInv
            // 
            this.listBoxStoreInv.FormattingEnabled = true;
            this.listBoxStoreInv.ItemHeight = 16;
            this.listBoxStoreInv.Items.AddRange(new object[] {
            "Item1 - Price",
            "Item2 - Price",
            "Item3 - Price"});
            this.listBoxStoreInv.Location = new System.Drawing.Point(372, 36);
            this.listBoxStoreInv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxStoreInv.Name = "listBoxStoreInv";
            this.listBoxStoreInv.Size = new System.Drawing.Size(284, 324);
            this.listBoxStoreInv.TabIndex = 4;
            // 
            // sellButton
            // 
            this.sellButton.Location = new System.Drawing.Point(52, 368);
            this.sellButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sellButton.Name = "sellButton";
            this.sellButton.Size = new System.Drawing.Size(285, 28);
            this.sellButton.TabIndex = 5;
            this.sellButton.Text = "Sell";
            this.sellButton.UseVisualStyleBackColor = true;
            // 
            // lblPlayerInv
            // 
            this.lblPlayerInv.AutoSize = true;
            this.lblPlayerInv.Location = new System.Drawing.Point(160, 80);
            this.lblPlayerInv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayerInv.Name = "lblPlayerInv";
            this.lblPlayerInv.Size = new System.Drawing.Size(66, 17);
            this.lblPlayerInv.TabIndex = 6;
            this.lblPlayerInv.Text = "Inventory";
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Location = new System.Drawing.Point(464, 16);
            this.lblStore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(104, 17);
            this.lblStore.TabIndex = 7;
            this.lblStore.Text = "Store Inventory";
            // 
            // listBoxPlayerInv
            // 
            this.listBoxPlayerInv.FormattingEnabled = true;
            this.listBoxPlayerInv.ItemHeight = 16;
            this.listBoxPlayerInv.Items.AddRange(new object[] {
            "Item1 - Price",
            "Item2 - Price",
            "Item3 - Price"});
            this.listBoxPlayerInv.Location = new System.Drawing.Point(52, 100);
            this.listBoxPlayerInv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxPlayerInv.Name = "listBoxPlayerInv";
            this.listBoxPlayerInv.Size = new System.Drawing.Size(284, 260);
            this.listBoxPlayerInv.TabIndex = 8;
            // 
            // buyButton
            // 
            this.buyButton.Location = new System.Drawing.Point(372, 368);
            this.buyButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(285, 28);
            this.buyButton.TabIndex = 9;
            this.buyButton.Text = "Purchase";
            this.buyButton.UseVisualStyleBackColor = true;
            // 
            // leaveButton
            // 
            this.leaveButton.Location = new System.Drawing.Point(207, 444);
            this.leaveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.leaveButton.Name = "leaveButton";
            this.leaveButton.Size = new System.Drawing.Size(285, 28);
            this.leaveButton.TabIndex = 10;
            this.leaveButton.Text = "Leave";
            this.leaveButton.UseVisualStyleBackColor = true;
            this.leaveButton.Click += new System.EventHandler(this.leaveButton_Click);
            // 
            // lblPlayerValue
            // 
            this.lblPlayerValue.AutoSize = true;
            this.lblPlayerValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerValue.Location = new System.Drawing.Point(48, 400);
            this.lblPlayerValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayerValue.Name = "lblPlayerValue";
            this.lblPlayerValue.Size = new System.Drawing.Size(104, 24);
            this.lblPlayerValue.TabIndex = 11;
            this.lblPlayerValue.Text = "Item Value:";
            // 
            // lblStoreValue
            // 
            this.lblStoreValue.AutoSize = true;
            this.lblStoreValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreValue.Location = new System.Drawing.Point(368, 400);
            this.lblStoreValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStoreValue.Name = "lblStoreValue";
            this.lblStoreValue.Size = new System.Drawing.Size(104, 24);
            this.lblStoreValue.TabIndex = 12;
            this.lblStoreValue.Text = "Item Value:";
            // 
            // StoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 487);
            this.Controls.Add(this.lblStoreValue);
            this.Controls.Add(this.lblPlayerValue);
            this.Controls.Add(this.leaveButton);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.listBoxPlayerInv);
            this.Controls.Add(this.lblStore);
            this.Controls.Add(this.lblPlayerInv);
            this.Controls.Add(this.sellButton);
            this.Controls.Add(this.listBoxStoreInv);
            this.Controls.Add(this.lblPlayerGBP);
            this.Controls.Add(this.lblGBP);
            this.Controls.Add(this.lblPlayerGold);
            this.Controls.Add(this.lblGold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Store";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblPlayerGold;
        private System.Windows.Forms.Label lblGBP;
        private System.Windows.Forms.Label lblPlayerGBP;
        private System.Windows.Forms.ListBox listBoxStoreInv;
        private System.Windows.Forms.Button sellButton;
        private System.Windows.Forms.Label lblPlayerInv;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.ListBox listBoxPlayerInv;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.Button leaveButton;
        private System.Windows.Forms.Label lblPlayerValue;
        private System.Windows.Forms.Label lblStoreValue;
    }
}