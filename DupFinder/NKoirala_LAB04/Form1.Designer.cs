namespace NKoirala_LAB04
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
            this.UI_labelDropDown = new System.Windows.Forms.Label();
            this.UI_ListBox = new System.Windows.Forms.ListBox();
            this.UI_buttonDup = new System.Windows.Forms.Button();
            this.UI_buttonRest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UI_labelDropDown
            // 
            this.UI_labelDropDown.AllowDrop = true;
            this.UI_labelDropDown.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.UI_labelDropDown.Location = new System.Drawing.Point(924, 18);
            this.UI_labelDropDown.Name = "UI_labelDropDown";
            this.UI_labelDropDown.Size = new System.Drawing.Size(163, 96);
            this.UI_labelDropDown.TabIndex = 0;
            this.UI_labelDropDown.Text = "Drop Down Menu";
            this.UI_labelDropDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UI_labelDropDown.DragDrop += new System.Windows.Forms.DragEventHandler(this.UI_labelDropDown_DragDrop);
            this.UI_labelDropDown.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            // 
            // UI_ListBox
            // 
            this.UI_ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_ListBox.FormattingEnabled = true;
            this.UI_ListBox.ItemHeight = 15;
            this.UI_ListBox.Location = new System.Drawing.Point(12, 18);
            this.UI_ListBox.Name = "UI_ListBox";
            this.UI_ListBox.ScrollAlwaysVisible = true;
            this.UI_ListBox.Size = new System.Drawing.Size(909, 409);
            this.UI_ListBox.TabIndex = 1;
            // 
            // UI_buttonDup
            // 
            this.UI_buttonDup.Location = new System.Drawing.Point(927, 375);
            this.UI_buttonDup.Name = "UI_buttonDup";
            this.UI_buttonDup.Size = new System.Drawing.Size(160, 23);
            this.UI_buttonDup.TabIndex = 2;
            this.UI_buttonDup.Text = "Find Duplicates";
            this.UI_buttonDup.UseVisualStyleBackColor = true;
            this.UI_buttonDup.Click += new System.EventHandler(this.UI_buttonDup_Click);
            // 
            // UI_buttonRest
            // 
            this.UI_buttonRest.Location = new System.Drawing.Point(927, 404);
            this.UI_buttonRest.Name = "UI_buttonRest";
            this.UI_buttonRest.Size = new System.Drawing.Size(160, 23);
            this.UI_buttonRest.TabIndex = 3;
            this.UI_buttonRest.Text = "Resolve Duplicates";
            this.UI_buttonRest.UseVisualStyleBackColor = true;
            this.UI_buttonRest.Click += new System.EventHandler(this.UI_buttonRest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 450);
            this.Controls.Add(this.UI_buttonRest);
            this.Controls.Add(this.UI_buttonDup);
            this.Controls.Add(this.UI_ListBox);
            this.Controls.Add(this.UI_labelDropDown);
            this.Name = "Form1";
            this.Text = "DupFinder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label UI_labelDropDown;
        private System.Windows.Forms.ListBox UI_ListBox;
        private System.Windows.Forms.Button UI_buttonDup;
        private System.Windows.Forms.Button UI_buttonRest;
    }
}

