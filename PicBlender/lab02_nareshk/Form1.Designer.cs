namespace lab02_nareshk
{
    partial class Form1
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
            this.UI_pictureBox = new System.Windows.Forms.PictureBox();
            this.UI_progressBar = new System.Windows.Forms.ProgressBar();
            this.UI_buttonLoad = new System.Windows.Forms.Button();
            this.UI_groupBoxType = new System.Windows.Forms.GroupBox();
            this.UI_radioButNoise = new System.Windows.Forms.RadioButton();
            this.UI_radioButTint = new System.Windows.Forms.RadioButton();
            this.UI_radioButBnW = new System.Windows.Forms.RadioButton();
            this.UI_radioButContrast = new System.Windows.Forms.RadioButton();
            this.UI_trackBar = new System.Windows.Forms.TrackBar();
            this.Ui_labelLess = new System.Windows.Forms.Label();
            this.UI_LabelPrint = new System.Windows.Forms.Label();
            this.UI_labelMore = new System.Windows.Forms.Label();
            this.UI_buttonTransform = new System.Windows.Forms.Button();
            this.UI_buttonRevert = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.UI_pictureBox)).BeginInit();
            this.UI_groupBoxType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_pictureBox
            // 
            this.UI_pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UI_pictureBox.Location = new System.Drawing.Point(19, 14);
            this.UI_pictureBox.Name = "UI_pictureBox";
            this.UI_pictureBox.Size = new System.Drawing.Size(759, 329);
            this.UI_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UI_pictureBox.TabIndex = 0;
            this.UI_pictureBox.TabStop = false;
            // 
            // UI_progressBar
            // 
            this.UI_progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_progressBar.Location = new System.Drawing.Point(11, 349);
            this.UI_progressBar.Name = "UI_progressBar";
            this.UI_progressBar.Size = new System.Drawing.Size(777, 12);
            this.UI_progressBar.Step = 20;
            this.UI_progressBar.TabIndex = 1;
            // 
            // UI_buttonLoad
            // 
            this.UI_buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_buttonLoad.Location = new System.Drawing.Point(19, 386);
            this.UI_buttonLoad.Name = "UI_buttonLoad";
            this.UI_buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.UI_buttonLoad.TabIndex = 2;
            this.UI_buttonLoad.Text = "Load Picture";
            this.UI_buttonLoad.UseVisualStyleBackColor = true;
            this.UI_buttonLoad.Click += new System.EventHandler(this.UI_buttonLoad_Click);
            // 
            // UI_groupBoxType
            // 
            this.UI_groupBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_groupBoxType.Controls.Add(this.UI_radioButNoise);
            this.UI_groupBoxType.Controls.Add(this.UI_radioButTint);
            this.UI_groupBoxType.Controls.Add(this.UI_radioButBnW);
            this.UI_groupBoxType.Controls.Add(this.UI_radioButContrast);
            this.UI_groupBoxType.Location = new System.Drawing.Point(131, 367);
            this.UI_groupBoxType.Name = "UI_groupBoxType";
            this.UI_groupBoxType.Size = new System.Drawing.Size(186, 78);
            this.UI_groupBoxType.TabIndex = 3;
            this.UI_groupBoxType.TabStop = false;
            this.UI_groupBoxType.Text = "Modification Type";
            // 
            // UI_radioButNoise
            // 
            this.UI_radioButNoise.AutoSize = true;
            this.UI_radioButNoise.Location = new System.Drawing.Point(95, 55);
            this.UI_radioButNoise.Name = "UI_radioButNoise";
            this.UI_radioButNoise.Size = new System.Drawing.Size(52, 17);
            this.UI_radioButNoise.TabIndex = 3;
            this.UI_radioButNoise.TabStop = true;
            this.UI_radioButNoise.Text = "Noise";
            this.UI_radioButNoise.UseVisualStyleBackColor = true;
            // 
            // UI_radioButTint
            // 
            this.UI_radioButTint.AutoSize = true;
            this.UI_radioButTint.Location = new System.Drawing.Point(95, 31);
            this.UI_radioButTint.Name = "UI_radioButTint";
            this.UI_radioButTint.Size = new System.Drawing.Size(43, 17);
            this.UI_radioButTint.TabIndex = 2;
            this.UI_radioButTint.TabStop = true;
            this.UI_radioButTint.Text = "Tint";
            this.UI_radioButTint.UseVisualStyleBackColor = true;
            this.UI_radioButTint.CheckedChanged += new System.EventHandler(this.UI_radioButTint_CheckedChanged);
            // 
            // UI_radioButBnW
            // 
            this.UI_radioButBnW.AutoSize = true;
            this.UI_radioButBnW.Checked = true;
            this.UI_radioButBnW.Location = new System.Drawing.Point(6, 54);
            this.UI_radioButBnW.Name = "UI_radioButBnW";
            this.UI_radioButBnW.Size = new System.Drawing.Size(86, 17);
            this.UI_radioButBnW.TabIndex = 1;
            this.UI_radioButBnW.TabStop = true;
            this.UI_radioButBnW.Text = "Black & White";
            this.UI_radioButBnW.UseVisualStyleBackColor = true;
            // 
            // UI_radioButContrast
            // 
            this.UI_radioButContrast.AutoSize = true;
            this.UI_radioButContrast.Location = new System.Drawing.Point(6, 31);
            this.UI_radioButContrast.Name = "UI_radioButContrast";
            this.UI_radioButContrast.Size = new System.Drawing.Size(64, 17);
            this.UI_radioButContrast.TabIndex = 0;
            this.UI_radioButContrast.TabStop = true;
            this.UI_radioButContrast.Text = "Contrast";
            this.UI_radioButContrast.UseVisualStyleBackColor = true;
            // 
            // UI_trackBar
            // 
            this.UI_trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_trackBar.LargeChange = 1;
            this.UI_trackBar.Location = new System.Drawing.Point(366, 367);
            this.UI_trackBar.Maximum = 100;
            this.UI_trackBar.Name = "UI_trackBar";
            this.UI_trackBar.Size = new System.Drawing.Size(290, 45);
            this.UI_trackBar.TabIndex = 4;
            this.UI_trackBar.TickFrequency = 5;
            this.UI_trackBar.Value = 5;
            this.UI_trackBar.ValueChanged += new System.EventHandler(this.UI_trackBar_ValueChanged);
            // 
            // Ui_labelLess
            // 
            this.Ui_labelLess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Ui_labelLess.AutoSize = true;
            this.Ui_labelLess.Location = new System.Drawing.Point(363, 415);
            this.Ui_labelLess.Name = "Ui_labelLess";
            this.Ui_labelLess.Size = new System.Drawing.Size(29, 13);
            this.Ui_labelLess.TabIndex = 5;
            this.Ui_labelLess.Text = "Less";
            // 
            // UI_LabelPrint
            // 
            this.UI_LabelPrint.AutoSize = true;
            this.UI_LabelPrint.Location = new System.Drawing.Point(501, 402);
            this.UI_LabelPrint.Name = "UI_LabelPrint";
            this.UI_LabelPrint.Size = new System.Drawing.Size(0, 13);
            this.UI_LabelPrint.TabIndex = 6;
            // 
            // UI_labelMore
            // 
            this.UI_labelMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_labelMore.AutoSize = true;
            this.UI_labelMore.Location = new System.Drawing.Point(621, 415);
            this.UI_labelMore.Name = "UI_labelMore";
            this.UI_labelMore.Size = new System.Drawing.Size(31, 13);
            this.UI_labelMore.TabIndex = 7;
            this.UI_labelMore.Text = "More";
            // 
            // UI_buttonTransform
            // 
            this.UI_buttonTransform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_buttonTransform.Location = new System.Drawing.Point(703, 386);
            this.UI_buttonTransform.Name = "UI_buttonTransform";
            this.UI_buttonTransform.Size = new System.Drawing.Size(75, 23);
            this.UI_buttonTransform.TabIndex = 8;
            this.UI_buttonTransform.Text = "Transform";
            this.UI_buttonTransform.UseVisualStyleBackColor = true;
            this.UI_buttonTransform.Click += new System.EventHandler(this.UI_buttonTransform_Click);
            // 
            // UI_buttonRevert
            // 
            this.UI_buttonRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_buttonRevert.Location = new System.Drawing.Point(19, 415);
            this.UI_buttonRevert.Name = "UI_buttonRevert";
            this.UI_buttonRevert.Size = new System.Drawing.Size(75, 23);
            this.UI_buttonRevert.TabIndex = 9;
            this.UI_buttonRevert.Text = "Revert!";
            this.UI_buttonRevert.UseVisualStyleBackColor = true;
            this.UI_buttonRevert.Click += new System.EventHandler(this.UI_buttonRevert_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UI_buttonRevert);
            this.Controls.Add(this.UI_buttonTransform);
            this.Controls.Add(this.UI_labelMore);
            this.Controls.Add(this.UI_LabelPrint);
            this.Controls.Add(this.Ui_labelLess);
            this.Controls.Add(this.UI_trackBar);
            this.Controls.Add(this.UI_groupBoxType);
            this.Controls.Add(this.UI_buttonLoad);
            this.Controls.Add(this.UI_progressBar);
            this.Controls.Add(this.UI_pictureBox);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "PicBlender";
            ((System.ComponentModel.ISupportInitialize)(this.UI_pictureBox)).EndInit();
            this.UI_groupBoxType.ResumeLayout(false);
            this.UI_groupBoxType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox UI_pictureBox;
        private System.Windows.Forms.ProgressBar UI_progressBar;
        private System.Windows.Forms.Button UI_buttonLoad;
        private System.Windows.Forms.GroupBox UI_groupBoxType;
        private System.Windows.Forms.RadioButton UI_radioButNoise;
        private System.Windows.Forms.RadioButton UI_radioButTint;
        private System.Windows.Forms.RadioButton UI_radioButBnW;
        private System.Windows.Forms.RadioButton UI_radioButContrast;
        private System.Windows.Forms.TrackBar UI_trackBar;
        private System.Windows.Forms.Label Ui_labelLess;
        private System.Windows.Forms.Label UI_LabelPrint;
        private System.Windows.Forms.Label UI_labelMore;
        private System.Windows.Forms.Button UI_buttonTransform;
        private System.Windows.Forms.Button UI_buttonRevert;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

