namespace NareshK_LAB03
{
    partial class Form2
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
            this.UI_Ok = new System.Windows.Forms.Button();
            this.UI_Cancel = new System.Windows.Forms.Button();
            this.UI_radioEasy = new System.Windows.Forms.RadioButton();
            this.UI_radioMedium = new System.Windows.Forms.RadioButton();
            this.UI_radioHard = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.UI_groupBox = new System.Windows.Forms.GroupBox();
            this.UI_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_Ok
            // 
            this.UI_Ok.Location = new System.Drawing.Point(17, 185);
            this.UI_Ok.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UI_Ok.Name = "UI_Ok";
            this.UI_Ok.Size = new System.Drawing.Size(80, 28);
            this.UI_Ok.TabIndex = 1;
            this.UI_Ok.Text = "OK";
            this.UI_Ok.UseVisualStyleBackColor = true;
            this.UI_Ok.Click += new System.EventHandler(this.UI_Ok_Click);
            // 
            // UI_Cancel
            // 
            this.UI_Cancel.Location = new System.Drawing.Point(123, 185);
            this.UI_Cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UI_Cancel.Name = "UI_Cancel";
            this.UI_Cancel.Size = new System.Drawing.Size(80, 28);
            this.UI_Cancel.TabIndex = 2;
            this.UI_Cancel.Text = "Cancel";
            this.UI_Cancel.UseVisualStyleBackColor = true;
            this.UI_Cancel.Click += new System.EventHandler(this.UI_Cancel_Click);
            // 
            // UI_radioEasy
            // 
            this.UI_radioEasy.AutoSize = true;
            this.UI_radioEasy.Location = new System.Drawing.Point(4, 28);
            this.UI_radioEasy.Margin = new System.Windows.Forms.Padding(2);
            this.UI_radioEasy.Name = "UI_radioEasy";
            this.UI_radioEasy.Size = new System.Drawing.Size(48, 17);
            this.UI_radioEasy.TabIndex = 0;
            this.UI_radioEasy.TabStop = true;
            this.UI_radioEasy.Text = "Easy";
            this.UI_radioEasy.UseVisualStyleBackColor = true;
            // 
            // UI_radioMedium
            // 
            this.UI_radioMedium.AutoSize = true;
            this.UI_radioMedium.Location = new System.Drawing.Point(4, 56);
            this.UI_radioMedium.Margin = new System.Windows.Forms.Padding(2);
            this.UI_radioMedium.Name = "UI_radioMedium";
            this.UI_radioMedium.Size = new System.Drawing.Size(62, 17);
            this.UI_radioMedium.TabIndex = 1;
            this.UI_radioMedium.TabStop = true;
            this.UI_radioMedium.Text = "Medium";
            this.UI_radioMedium.UseVisualStyleBackColor = true;
            // 
            // UI_radioHard
            // 
            this.UI_radioHard.AutoSize = true;
            this.UI_radioHard.Location = new System.Drawing.Point(4, 85);
            this.UI_radioHard.Margin = new System.Windows.Forms.Padding(2);
            this.UI_radioHard.Name = "UI_radioHard";
            this.UI_radioHard.Size = new System.Drawing.Size(48, 17);
            this.UI_radioHard.TabIndex = 2;
            this.UI_radioHard.TabStop = true;
            this.UI_radioHard.Text = "Hard";
            this.UI_radioHard.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // UI_groupBox
            // 
            this.UI_groupBox.Controls.Add(this.label1);
            this.UI_groupBox.Controls.Add(this.UI_radioHard);
            this.UI_groupBox.Controls.Add(this.UI_radioMedium);
            this.UI_groupBox.Controls.Add(this.UI_radioEasy);
            this.UI_groupBox.Location = new System.Drawing.Point(32, 30);
            this.UI_groupBox.Margin = new System.Windows.Forms.Padding(2);
            this.UI_groupBox.Name = "UI_groupBox";
            this.UI_groupBox.Padding = new System.Windows.Forms.Padding(2);
            this.UI_groupBox.Size = new System.Drawing.Size(155, 131);
            this.UI_groupBox.TabIndex = 0;
            this.UI_groupBox.TabStop = false;
            this.UI_groupBox.Text = "Difficulty";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 254);
            this.Controls.Add(this.UI_Cancel);
            this.Controls.Add(this.UI_Ok);
            this.Controls.Add(this.UI_groupBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(252, 293);
            this.MinimumSize = new System.Drawing.Size(252, 293);
            this.Name = "Form2";
            this.Text = "Select Difficulty";
            this.UI_groupBox.ResumeLayout(false);
            this.UI_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button UI_Ok;
        private System.Windows.Forms.Button UI_Cancel;
        private System.Windows.Forms.RadioButton UI_radioEasy;
        private System.Windows.Forms.RadioButton UI_radioMedium;
        private System.Windows.Forms.RadioButton UI_radioHard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox UI_groupBox;
    }
}