namespace WrathOfTheRuined
{
    partial class NewCharacterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCharacterForm));
            this.lblName = new System.Windows.Forms.Label();
            this.lblMaxHP = new System.Windows.Forms.Label();
            this.lblStrength = new System.Windows.Forms.Label();
            this.lblIntellect = new System.Windows.Forms.Label();
            this.lblAP = new System.Windows.Forms.Label();
            this.lblMR = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.numMaxHP = new System.Windows.Forms.NumericUpDown();
            this.numStrength = new System.Windows.Forms.NumericUpDown();
            this.numIntellect = new System.Windows.Forms.NumericUpDown();
            this.numAP = new System.Windows.Forms.NumericUpDown();
            this.numMR = new System.Windows.Forms.NumericUpDown();
            this.lblSPR = new System.Windows.Forms.Label();
            this.lblSP = new System.Windows.Forms.Label();
            this.buttonDone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIntellect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMR)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(24, 18);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(87, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Enter Name:";
            // 
            // lblMaxHP
            // 
            this.lblMaxHP.AutoSize = true;
            this.lblMaxHP.Location = new System.Drawing.Point(48, 49);
            this.lblMaxHP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxHP.Name = "lblMaxHP";
            this.lblMaxHP.Size = new System.Drawing.Size(60, 17);
            this.lblMaxHP.TabIndex = 1;
            this.lblMaxHP.Text = "Max HP:";
            // 
            // lblStrength
            // 
            this.lblStrength.AutoSize = true;
            this.lblStrength.Location = new System.Drawing.Point(45, 81);
            this.lblStrength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStrength.Name = "lblStrength";
            this.lblStrength.Size = new System.Drawing.Size(66, 17);
            this.lblStrength.TabIndex = 2;
            this.lblStrength.Text = "Strength:";
            // 
            // lblIntellect
            // 
            this.lblIntellect.AutoSize = true;
            this.lblIntellect.Location = new System.Drawing.Point(49, 113);
            this.lblIntellect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIntellect.Name = "lblIntellect";
            this.lblIntellect.Size = new System.Drawing.Size(60, 17);
            this.lblIntellect.TabIndex = 3;
            this.lblIntellect.Text = "Intellect:";
            // 
            // lblAP
            // 
            this.lblAP.AutoSize = true;
            this.lblAP.Location = new System.Drawing.Point(20, 145);
            this.lblAP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAP.Name = "lblAP";
            this.lblAP.Size = new System.Drawing.Size(93, 17);
            this.lblAP.TabIndex = 4;
            this.lblAP.Text = "Armor Points:";
            // 
            // lblMR
            // 
            this.lblMR.AutoSize = true;
            this.lblMR.Location = new System.Drawing.Point(17, 177);
            this.lblMR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMR.Name = "lblMR";
            this.lblMR.Size = new System.Drawing.Size(92, 17);
            this.lblMR.TabIndex = 5;
            this.lblMR.Text = "Magic Resist:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(120, 15);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameTextBox.MaxLength = 20;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(159, 22);
            this.nameTextBox.TabIndex = 6;
            // 
            // numMaxHP
            // 
            this.numMaxHP.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numMaxHP.Location = new System.Drawing.Point(120, 47);
            this.numMaxHP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numMaxHP.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMaxHP.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxHP.Name = "numMaxHP";
            this.numMaxHP.ReadOnly = true;
            this.numMaxHP.Size = new System.Drawing.Size(160, 22);
            this.numMaxHP.TabIndex = 7;
            this.numMaxHP.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numMaxHP.ValueChanged += new System.EventHandler(this.numMaxHP_ValueChanged);
            // 
            // numStrength
            // 
            this.numStrength.Location = new System.Drawing.Point(120, 79);
            this.numStrength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numStrength.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numStrength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStrength.Name = "numStrength";
            this.numStrength.ReadOnly = true;
            this.numStrength.Size = new System.Drawing.Size(160, 22);
            this.numStrength.TabIndex = 8;
            this.numStrength.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numStrength.ValueChanged += new System.EventHandler(this.numStrength_ValueChanged);
            // 
            // numIntellect
            // 
            this.numIntellect.Location = new System.Drawing.Point(120, 111);
            this.numIntellect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numIntellect.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numIntellect.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numIntellect.Name = "numIntellect";
            this.numIntellect.ReadOnly = true;
            this.numIntellect.Size = new System.Drawing.Size(160, 22);
            this.numIntellect.TabIndex = 9;
            this.numIntellect.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numIntellect.ValueChanged += new System.EventHandler(this.numIntellect_ValueChanged);
            // 
            // numAP
            // 
            this.numAP.Location = new System.Drawing.Point(120, 143);
            this.numAP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numAP.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numAP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAP.Name = "numAP";
            this.numAP.ReadOnly = true;
            this.numAP.Size = new System.Drawing.Size(160, 22);
            this.numAP.TabIndex = 10;
            this.numAP.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numAP.ValueChanged += new System.EventHandler(this.numAP_ValueChanged);
            // 
            // numMR
            // 
            this.numMR.Location = new System.Drawing.Point(120, 175);
            this.numMR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numMR.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numMR.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMR.Name = "numMR";
            this.numMR.ReadOnly = true;
            this.numMR.Size = new System.Drawing.Size(160, 22);
            this.numMR.TabIndex = 11;
            this.numMR.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMR.ValueChanged += new System.EventHandler(this.numMR_ValueChanged);
            // 
            // lblSPR
            // 
            this.lblSPR.AutoSize = true;
            this.lblSPR.Location = new System.Drawing.Point(315, 95);
            this.lblSPR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSPR.Name = "lblSPR";
            this.lblSPR.Size = new System.Drawing.Size(151, 17);
            this.lblSPR.TabIndex = 12;
            this.lblSPR.Text = "Stat Points Remaining:";
            // 
            // lblSP
            // 
            this.lblSP.AutoSize = true;
            this.lblSP.Location = new System.Drawing.Point(385, 111);
            this.lblSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSP.Name = "lblSP";
            this.lblSP.Size = new System.Drawing.Size(16, 17);
            this.lblSP.TabIndex = 13;
            this.lblSP.Text = "0";
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(120, 210);
            this.buttonDone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(160, 28);
            this.buttonDone.TabIndex = 14;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // NewCharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 258);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.lblSP);
            this.Controls.Add(this.lblSPR);
            this.Controls.Add(this.numMR);
            this.Controls.Add(this.numAP);
            this.Controls.Add(this.numIntellect);
            this.Controls.Add(this.numStrength);
            this.Controls.Add(this.numMaxHP);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.lblMR);
            this.Controls.Add(this.lblAP);
            this.Controls.Add(this.lblIntellect);
            this.Controls.Add(this.lblStrength);
            this.Controls.Add(this.lblMaxHP);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NewCharacterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewCharacter";
            ((System.ComponentModel.ISupportInitialize)(this.numMaxHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIntellect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMaxHP;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.Label lblIntellect;
        private System.Windows.Forms.Label lblAP;
        private System.Windows.Forms.Label lblMR;
        private System.Windows.Forms.Label lblSPR;
        private System.Windows.Forms.Label lblSP;
        public System.Windows.Forms.TextBox nameTextBox;
        public System.Windows.Forms.NumericUpDown numMaxHP;
        public System.Windows.Forms.NumericUpDown numStrength;
        public System.Windows.Forms.NumericUpDown numIntellect;
        public System.Windows.Forms.NumericUpDown numAP;
        public System.Windows.Forms.NumericUpDown numMR;
        private System.Windows.Forms.Button buttonDone;
    }
}