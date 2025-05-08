namespace NareshK_LAB03
{
    partial class Form3
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
            this.UI_label = new System.Windows.Forms.Label();
            this.UI_labelScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_label
            // 
            this.UI_label.AutoSize = true;
            this.UI_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_label.Location = new System.Drawing.Point(31, 38);
            this.UI_label.Name = "UI_label";
            this.UI_label.Size = new System.Drawing.Size(96, 29);
            this.UI_label.TabIndex = 0;
            this.UI_label.Text = "Score: ";
            // 
            // UI_labelScore
            // 
            this.UI_labelScore.AutoSize = true;
            this.UI_labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_labelScore.Location = new System.Drawing.Point(167, 38);
            this.UI_labelScore.Name = "UI_labelScore";
            this.UI_labelScore.Size = new System.Drawing.Size(97, 29);
            this.UI_labelScore.TabIndex = 1;
            this.UI_labelScore.Text = "000000";
            this.UI_labelScore.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 121);
            this.Controls.Add(this.UI_labelScore);
            this.Controls.Add(this.UI_label);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(365, 168);
            this.MinimumSize = new System.Drawing.Size(365, 168);
            this.Name = "Form3";
            this.Text = "Score";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UI_label;
        private System.Windows.Forms.Label UI_labelScore;
    }
}