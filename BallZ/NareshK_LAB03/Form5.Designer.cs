namespace NareshK_LAB03
{
    partial class Form5
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
            this.Name = new System.Windows.Forms.Label();
            this.UI_textBox = new System.Windows.Forms.TextBox();
            this.UI_ok = new System.Windows.Forms.Button();
            this.UI_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(12, 44);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(44, 16);
            this.Name.TabIndex = 0;
            this.Name.Text = "Name";
            // 
            // UI_textBox
            // 
            this.UI_textBox.Location = new System.Drawing.Point(62, 41);
            this.UI_textBox.Name = "UI_textBox";
            this.UI_textBox.Size = new System.Drawing.Size(307, 22);
            this.UI_textBox.TabIndex = 1;
            this.UI_textBox.TextChanged += new System.EventHandler(this.UI_textBox_TextChanged);
            // 
            // UI_ok
            // 
            this.UI_ok.Location = new System.Drawing.Point(62, 99);
            this.UI_ok.Name = "UI_ok";
            this.UI_ok.Size = new System.Drawing.Size(119, 30);
            this.UI_ok.TabIndex = 2;
            this.UI_ok.Text = "Ok";
            this.UI_ok.UseVisualStyleBackColor = true;
            this.UI_ok.Click += new System.EventHandler(this.UI_ok_Click);
            // 
            // UI_cancel
            // 
            this.UI_cancel.Location = new System.Drawing.Point(250, 99);
            this.UI_cancel.Name = "UI_cancel";
            this.UI_cancel.Size = new System.Drawing.Size(119, 30);
            this.UI_cancel.TabIndex = 3;
            this.UI_cancel.Text = "Cancel";
            this.UI_cancel.UseVisualStyleBackColor = true;
            this.UI_cancel.Click += new System.EventHandler(this.UI_cancel_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 165);
            this.Controls.Add(this.UI_cancel);
            this.Controls.Add(this.UI_ok);
            this.Controls.Add(this.UI_textBox);
            this.Controls.Add(this.Name);
            //this.Name = "Form5";
            this.Text = "High Score";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.TextBox UI_textBox;
        private System.Windows.Forms.Button UI_ok;
        private System.Windows.Forms.Button UI_cancel;
    }
}