namespace MyClickerHeroesBot.Forms
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.MessageLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ClickableCount = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.CurentLevelLabel = new System.Windows.Forms.Label();
            this.CurentLevel = new System.Windows.Forms.Label();
            this.ClickabelBox = new System.Windows.Forms.CheckBox();
            this.DreadKnightLevelLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ClickabelMaxLevelUpAndDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ClickabelMaxLevelUpAndDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.BackColor = System.Drawing.SystemColors.Control;
            this.MessageLabel.ForeColor = System.Drawing.Color.Lime;
            this.MessageLabel.Location = new System.Drawing.Point(36, 24);
            this.MessageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(68, 13);
            this.MessageLabel.TabIndex = 1;
            this.MessageLabel.Text = "Game Found";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(11, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Clickables Found : ";
            // 
            // ClickableCount
            // 
            this.ClickableCount.AutoSize = true;
            this.ClickableCount.BackColor = System.Drawing.SystemColors.Control;
            this.ClickableCount.Location = new System.Drawing.Point(102, 47);
            this.ClickableCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ClickableCount.Name = "ClickableCount";
            this.ClickableCount.Size = new System.Drawing.Size(13, 13);
            this.ClickableCount.TabIndex = 4;
            this.ClickableCount.Text = "0";
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.Control;
            this.startButton.ForeColor = System.Drawing.Color.Red;
            this.startButton.Location = new System.Drawing.Point(208, 14);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            // 
            // CurentLevelLabel
            // 
            this.CurentLevelLabel.AutoSize = true;
            this.CurentLevelLabel.Location = new System.Drawing.Point(401, 24);
            this.CurentLevelLabel.Name = "CurentLevelLabel";
            this.CurentLevelLabel.Size = new System.Drawing.Size(73, 13);
            this.CurentLevelLabel.TabIndex = 8;
            this.CurentLevelLabel.Text = "CurentLevel : ";
            // 
            // CurentLevel
            // 
            this.CurentLevel.AutoSize = true;
            this.CurentLevel.Location = new System.Drawing.Point(470, 24);
            this.CurentLevel.Name = "CurentLevel";
            this.CurentLevel.Size = new System.Drawing.Size(13, 13);
            this.CurentLevel.TabIndex = 9;
            this.CurentLevel.Text = "0";
            // 
            // ClickabelBox
            // 
            this.ClickabelBox.AutoSize = true;
            this.ClickabelBox.Location = new System.Drawing.Point(208, 47);
            this.ClickabelBox.Name = "ClickabelBox";
            this.ClickabelBox.Size = new System.Drawing.Size(94, 17);
            this.ClickabelBox.TabIndex = 10;
            this.ClickabelBox.Text = "Get Clickabels";
            this.ClickabelBox.UseVisualStyleBackColor = true;
            // 
            // DreadKnightLevelLabel
            // 
            this.DreadKnightLevelLabel.AutoSize = true;
            this.DreadKnightLevelLabel.Location = new System.Drawing.Point(470, 48);
            this.DreadKnightLevelLabel.Name = "DreadKnightLevelLabel";
            this.DreadKnightLevelLabel.Size = new System.Drawing.Size(13, 13);
            this.DreadKnightLevelLabel.TabIndex = 12;
            this.DreadKnightLevelLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Dread Knight Level : ";
            // 
            // ClickabelMaxLevelUpAndDown
            // 
            this.ClickabelMaxLevelUpAndDown.Location = new System.Drawing.Point(256, 70);
            this.ClickabelMaxLevelUpAndDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.ClickabelMaxLevelUpAndDown.Name = "ClickabelMaxLevelUpAndDown";
            this.ClickabelMaxLevelUpAndDown.Size = new System.Drawing.Size(46, 20);
            this.ClickabelMaxLevelUpAndDown.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Clickable Max Level";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 116);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClickabelMaxLevelUpAndDown);
            this.Controls.Add(this.DreadKnightLevelLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ClickabelBox);
            this.Controls.Add(this.CurentLevel);
            this.Controls.Add(this.CurentLevelLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.ClickableCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MessageLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Clicker Heroes Bot";
            ((System.ComponentModel.ISupportInitialize)(this.ClickabelMaxLevelUpAndDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ClickableCount;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label CurentLevelLabel;
        private System.Windows.Forms.Label CurentLevel;
        private System.Windows.Forms.CheckBox ClickabelBox;
        private System.Windows.Forms.Label DreadKnightLevelLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ClickabelMaxLevelUpAndDown;
        private System.Windows.Forms.Label label1;
    }
}

