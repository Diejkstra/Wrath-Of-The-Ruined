namespace WrathOfTheRuined
{
    partial class LevelUpForm
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
            this.lblLevelUp = new System.Windows.Forms.Label();
            this.buttonMaxHP = new System.Windows.Forms.Button();
            this.buttonStrength = new System.Windows.Forms.Button();
            this.buttonIntellect = new System.Windows.Forms.Button();
            this.buttonAP = new System.Windows.Forms.Button();
            this.buttonMR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLevelUp
            // 
            this.lblLevelUp.AutoSize = true;
            this.lblLevelUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevelUp.Location = new System.Drawing.Point(12, 9);
            this.lblLevelUp.Name = "lblLevelUp";
            this.lblLevelUp.Size = new System.Drawing.Size(114, 29);
            this.lblLevelUp.TabIndex = 0;
            this.lblLevelUp.Text = "Level Up!";
            // 
            // buttonMaxHP
            // 
            this.buttonMaxHP.Location = new System.Drawing.Point(17, 41);
            this.buttonMaxHP.Name = "buttonMaxHP";
            this.buttonMaxHP.Size = new System.Drawing.Size(106, 23);
            this.buttonMaxHP.TabIndex = 1;
            this.buttonMaxHP.Text = "Increase Max HP";
            this.buttonMaxHP.UseVisualStyleBackColor = true;
            this.buttonMaxHP.Click += new System.EventHandler(this.buttonMaxHP_Click);
            // 
            // buttonStrength
            // 
            this.buttonStrength.Location = new System.Drawing.Point(17, 70);
            this.buttonStrength.Name = "buttonStrength";
            this.buttonStrength.Size = new System.Drawing.Size(106, 23);
            this.buttonStrength.TabIndex = 2;
            this.buttonStrength.Text = "Increase Strength";
            this.buttonStrength.UseVisualStyleBackColor = true;
            this.buttonStrength.Click += new System.EventHandler(this.buttonStrength_Click);
            // 
            // buttonIntellect
            // 
            this.buttonIntellect.Location = new System.Drawing.Point(17, 99);
            this.buttonIntellect.Name = "buttonIntellect";
            this.buttonIntellect.Size = new System.Drawing.Size(106, 23);
            this.buttonIntellect.TabIndex = 3;
            this.buttonIntellect.Text = "Increase Intellect";
            this.buttonIntellect.UseVisualStyleBackColor = true;
            this.buttonIntellect.Click += new System.EventHandler(this.buttonIntellect_Click);
            // 
            // buttonAP
            // 
            this.buttonAP.Location = new System.Drawing.Point(17, 128);
            this.buttonAP.Name = "buttonAP";
            this.buttonAP.Size = new System.Drawing.Size(106, 23);
            this.buttonAP.TabIndex = 4;
            this.buttonAP.Text = "Increase AP";
            this.buttonAP.UseVisualStyleBackColor = true;
            this.buttonAP.Click += new System.EventHandler(this.buttonAP_Click);
            // 
            // buttonMR
            // 
            this.buttonMR.Location = new System.Drawing.Point(17, 157);
            this.buttonMR.Name = "buttonMR";
            this.buttonMR.Size = new System.Drawing.Size(106, 23);
            this.buttonMR.TabIndex = 5;
            this.buttonMR.Text = "Increase MR";
            this.buttonMR.UseVisualStyleBackColor = true;
            this.buttonMR.Click += new System.EventHandler(this.buttonMR_Click);
            // 
            // LevelUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(137, 193);
            this.Controls.Add(this.buttonMR);
            this.Controls.Add(this.buttonAP);
            this.Controls.Add(this.buttonIntellect);
            this.Controls.Add(this.buttonStrength);
            this.Controls.Add(this.buttonMaxHP);
            this.Controls.Add(this.lblLevelUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LevelUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LevelUpForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLevelUp;
        private System.Windows.Forms.Button buttonMaxHP;
        private System.Windows.Forms.Button buttonStrength;
        private System.Windows.Forms.Button buttonIntellect;
        private System.Windows.Forms.Button buttonAP;
        private System.Windows.Forms.Button buttonMR;
    }
}