namespace Dafny15Puzzle
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
            this.ChooseImageBox = new System.Windows.Forms.GroupBox();
            this.ChooseImageButton = new System.Windows.Forms.Button();
            this.textboxImagePath = new System.Windows.Forms.TextBox();
            this.PuzzleBox = new System.Windows.Forms.GroupBox();
            this.StatusBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TurnCounterLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SteuerungsBox = new System.Windows.Forms.GroupBox();
            this.RestartButton = new System.Windows.Forms.Button();
            this.ChooseImageBox.SuspendLayout();
            this.StatusBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SteuerungsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChooseImageBox
            // 
            this.ChooseImageBox.Controls.Add(this.ChooseImageButton);
            this.ChooseImageBox.Controls.Add(this.textboxImagePath);
            this.ChooseImageBox.Location = new System.Drawing.Point(12, 12);
            this.ChooseImageBox.Name = "ChooseImageBox";
            this.ChooseImageBox.Size = new System.Drawing.Size(794, 100);
            this.ChooseImageBox.TabIndex = 0;
            this.ChooseImageBox.TabStop = false;
            this.ChooseImageBox.Text = "Choose Image";
            // 
            // ChooseImageButton
            // 
            this.ChooseImageButton.Location = new System.Drawing.Point(682, 44);
            this.ChooseImageButton.Name = "ChooseImageButton";
            this.ChooseImageButton.Size = new System.Drawing.Size(106, 23);
            this.ChooseImageButton.TabIndex = 1;
            this.ChooseImageButton.Text = "...";
            this.ChooseImageButton.UseVisualStyleBackColor = true;
            this.ChooseImageButton.Click += new System.EventHandler(this.buttonImageBrowse_Click);
            // 
            // textboxImagePath
            // 
            this.textboxImagePath.Location = new System.Drawing.Point(6, 47);
            this.textboxImagePath.Name = "textboxImagePath";
            this.textboxImagePath.Size = new System.Drawing.Size(647, 20);
            this.textboxImagePath.TabIndex = 0;
            // 
            // PuzzleBox
            // 
            this.PuzzleBox.Location = new System.Drawing.Point(13, 136);
            this.PuzzleBox.Name = "PuzzleBox";
            this.PuzzleBox.Size = new System.Drawing.Size(444, 444);
            this.PuzzleBox.TabIndex = 1;
            this.PuzzleBox.TabStop = false;
            this.PuzzleBox.Text = "Puzzle";
            // 
            // StatusBox
            // 
            this.StatusBox.Controls.Add(this.groupBox2);
            this.StatusBox.Controls.Add(this.groupBox1);
            this.StatusBox.Controls.Add(this.labelStatus);
            this.StatusBox.Location = new System.Drawing.Point(527, 150);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(279, 122);
            this.StatusBox.TabIndex = 2;
            this.StatusBox.TabStop = false;
            this.StatusBox.Text = "Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TurnCounterLabel);
            this.groupBox2.Location = new System.Drawing.Point(180, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(76, 55);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Spielzüge";
            // 
            // TurnCounterLabel
            // 
            this.TurnCounterLabel.AutoSize = true;
            this.TurnCounterLabel.Location = new System.Drawing.Point(17, 25);
            this.TurnCounterLabel.Name = "TurnCounterLabel";
            this.TurnCounterLabel.Size = new System.Drawing.Size(13, 13);
            this.TurnCounterLabel.TabIndex = 2;
            this.TurnCounterLabel.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(30, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(80, 40);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spiel-Zeit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(114, 96);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(24, 13);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "Idle";
            // 
            // SteuerungsBox
            // 
            this.SteuerungsBox.Controls.Add(this.RestartButton);
            this.SteuerungsBox.Location = new System.Drawing.Point(527, 446);
            this.SteuerungsBox.Name = "SteuerungsBox";
            this.SteuerungsBox.Size = new System.Drawing.Size(279, 107);
            this.SteuerungsBox.TabIndex = 3;
            this.SteuerungsBox.TabStop = false;
            this.SteuerungsBox.Text = "Steuerung";
            // 
            // RestartButton
            // 
            this.RestartButton.Location = new System.Drawing.Point(6, 19);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(105, 27);
            this.RestartButton.TabIndex = 0;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.restart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 594);
            this.Controls.Add(this.SteuerungsBox);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.PuzzleBox);
            this.Controls.Add(this.ChooseImageBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "15er Puzzle";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ChooseImageBox.ResumeLayout(false);
            this.ChooseImageBox.PerformLayout();
            this.StatusBox.ResumeLayout(false);
            this.StatusBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.SteuerungsBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ChooseImageBox;
        private System.Windows.Forms.Button ChooseImageButton;
        private System.Windows.Forms.TextBox textboxImagePath;
        private System.Windows.Forms.GroupBox PuzzleBox;
        private System.Windows.Forms.GroupBox StatusBox;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.GroupBox SteuerungsBox;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label TurnCounterLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}

