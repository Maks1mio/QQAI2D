namespace QQAI2D_WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cropCheckBox = new System.Windows.Forms.CheckBox();
            this.saveCheckBox = new System.Windows.Forms.CheckBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.startButton = new System.Windows.Forms.Button();
            this.picturesCountLabel = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.openDirectoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cropCheckBox
            // 
            this.cropCheckBox.AutoSize = true;
            this.cropCheckBox.Location = new System.Drawing.Point(21, 16);
            this.cropCheckBox.Name = "cropCheckBox";
            this.cropCheckBox.Size = new System.Drawing.Size(126, 17);
            this.cropCheckBox.TabIndex = 1;
            this.cropCheckBox.Text = "Обрезать картинку";
            this.cropCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveCheckBox
            // 
            this.saveCheckBox.AutoSize = true;
            this.saveCheckBox.Location = new System.Drawing.Point(21, 38);
            this.saveCheckBox.Name = "saveCheckBox";
            this.saveCheckBox.Size = new System.Drawing.Size(248, 17);
            this.saveCheckBox.TabIndex = 2;
            this.saveCheckBox.Text = "Сохранять каждую картинку в свою папку";
            this.saveCheckBox.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(21, 60);
            this.textBox.Name = "textBox";
            this.textBox.PlaceholderText = "Количество вариаций на картинку";
            this.textBox.Size = new System.Drawing.Size(223, 21);
            this.textBox.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(21, 85);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(375, 23);
            this.progressBar.TabIndex = 4;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(21, 114);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(90, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "ПРИМЕНИТЬ";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // picturesCountLabel
            // 
            this.picturesCountLabel.AutoSize = true;
            this.picturesCountLabel.Location = new System.Drawing.Point(250, 62);
            this.picturesCountLabel.Name = "picturesCountLabel";
            this.picturesCountLabel.Size = new System.Drawing.Size(0, 13);
            this.picturesCountLabel.TabIndex = 6;
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressLabel.AutoSize = true;
            this.progressLabel.BackColor = System.Drawing.Color.Transparent;
            this.progressLabel.Location = new System.Drawing.Point(29, 90);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(0, 13);
            this.progressLabel.TabIndex = 7;
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openDirectoryButton
            // 
            this.openDirectoryButton.Location = new System.Drawing.Point(118, 114);
            this.openDirectoryButton.Name = "openDirectoryButton";
            this.openDirectoryButton.Size = new System.Drawing.Size(164, 23);
            this.openDirectoryButton.TabIndex = 8;
            this.openDirectoryButton.Text = "ДИРЕКТОРИЯ КАРТИНОК";
            this.openDirectoryButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(421, 149);
            this.Controls.Add(this.openDirectoryButton);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.picturesCountLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.saveCheckBox);
            this.Controls.Add(this.cropCheckBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "QQAI2D";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CheckBox cropCheckBox;
        private CheckBox saveCheckBox;
        private TextBox textBox;
        private ProgressBar progressBar;
        private Button startButton;
        private Label picturesCountLabel;
        private Label progressLabel;
        private Button openDirectoryButton;
    }
}