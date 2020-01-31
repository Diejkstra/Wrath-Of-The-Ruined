namespace WrathOfTheRuined
{
    partial class UseItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UseItemForm));
            this.listBoxPlayerInv = new System.Windows.Forms.ListBox();
            this.buttonUseItem = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxPlayerInv
            // 
            this.listBoxPlayerInv.FormattingEnabled = true;
            this.listBoxPlayerInv.ItemHeight = 16;
            this.listBoxPlayerInv.Items.AddRange(new object[] {
            "Item1 - Price",
            "Item2 - Price",
            "Item3 - Price"});
            this.listBoxPlayerInv.Location = new System.Drawing.Point(16, 15);
            this.listBoxPlayerInv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxPlayerInv.Name = "listBoxPlayerInv";
            this.listBoxPlayerInv.Size = new System.Drawing.Size(284, 260);
            this.listBoxPlayerInv.TabIndex = 9;
            // 
            // buttonUseItem
            // 
            this.buttonUseItem.Location = new System.Drawing.Point(16, 283);
            this.buttonUseItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUseItem.Name = "buttonUseItem";
            this.buttonUseItem.Size = new System.Drawing.Size(285, 28);
            this.buttonUseItem.TabIndex = 11;
            this.buttonUseItem.Text = "Use Item";
            this.buttonUseItem.UseVisualStyleBackColor = true;
            this.buttonUseItem.Click += new System.EventHandler(this.buttonUseItem_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(16, 319);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(285, 28);
            this.buttonExit.TabIndex = 12;
            this.buttonExit.Text = "Go Back";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // UseItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 358);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonUseItem);
            this.Controls.Add(this.listBoxPlayerInv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UseItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UseItemForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPlayerInv;
        private System.Windows.Forms.Button buttonUseItem;
        private System.Windows.Forms.Button buttonExit;
    }
}