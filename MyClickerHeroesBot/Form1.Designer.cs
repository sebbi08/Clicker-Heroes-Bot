namespace MyClickerHeroesBot
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ClickableCount = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.GetClickablesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(54, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Running";
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
            this.startButton.BackColor = System.Drawing.Color.Red;
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Location = new System.Drawing.Point(57, 82);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // GetClickablesButton
            // 
            this.GetClickablesButton.BackColor = System.Drawing.Color.Red;
            this.GetClickablesButton.Enabled = false;
            this.GetClickablesButton.Location = new System.Drawing.Point(57, 120);
            this.GetClickablesButton.Name = "GetClickablesButton";
            this.GetClickablesButton.Size = new System.Drawing.Size(75, 23);
            this.GetClickablesButton.TabIndex = 7;
            this.GetClickablesButton.Text = "GetClickables";
            this.GetClickablesButton.UseVisualStyleBackColor = false;
            this.GetClickablesButton.Click += new System.EventHandler(this.GetClickables_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 170);
            this.Controls.Add(this.GetClickablesButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.ClickableCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ClickableCount;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button GetClickablesButton;
    }
}

