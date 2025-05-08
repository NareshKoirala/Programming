namespace NareshK_LAB03
{
    partial class UI_MainForm
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
            this.components = new System.ComponentModel.Container();
            this.UI_checkBoxScore = new System.Windows.Forms.CheckBox();
            this.UI_checkBoxAnima = new System.Windows.Forms.CheckBox();
            this.UI_buttonMainPlay = new System.Windows.Forms.Button();
            this.UI_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UI_checkBoxScore
            // 
            this.UI_checkBoxScore.AutoSize = true;
            this.UI_checkBoxScore.Location = new System.Drawing.Point(19, 18);
            this.UI_checkBoxScore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UI_checkBoxScore.Name = "UI_checkBoxScore";
            this.UI_checkBoxScore.Size = new System.Drawing.Size(84, 17);
            this.UI_checkBoxScore.TabIndex = 0;
            this.UI_checkBoxScore.Text = "Show Score";
            this.UI_checkBoxScore.UseVisualStyleBackColor = true;
            // 
            // UI_checkBoxAnima
            // 
            this.UI_checkBoxAnima.AutoSize = true;
            this.UI_checkBoxAnima.Location = new System.Drawing.Point(19, 48);
            this.UI_checkBoxAnima.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UI_checkBoxAnima.Name = "UI_checkBoxAnima";
            this.UI_checkBoxAnima.Size = new System.Drawing.Size(136, 17);
            this.UI_checkBoxAnima.TabIndex = 1;
            this.UI_checkBoxAnima.Text = "Show Animation Speed";
            this.UI_checkBoxAnima.UseVisualStyleBackColor = true;
            // 
            // UI_buttonMainPlay
            // 
            this.UI_buttonMainPlay.Location = new System.Drawing.Point(64, 76);
            this.UI_buttonMainPlay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UI_buttonMainPlay.Name = "UI_buttonMainPlay";
            this.UI_buttonMainPlay.Size = new System.Drawing.Size(142, 31);
            this.UI_buttonMainPlay.TabIndex = 2;
            this.UI_buttonMainPlay.Text = "Play";
            this.UI_buttonMainPlay.UseVisualStyleBackColor = true;
            this.UI_buttonMainPlay.Click += new System.EventHandler(this.UI_buttonMainPlay_Click);
            // 
            // UI_timer
            // 
            this.UI_timer.Tick += new System.EventHandler(this.UI_timer_Tick);
            // 
            // UI_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 123);
            this.Controls.Add(this.UI_buttonMainPlay);
            this.Controls.Add(this.UI_checkBoxAnima);
            this.Controls.Add(this.UI_checkBoxScore);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(276, 162);
            this.MinimumSize = new System.Drawing.Size(276, 162);
            this.Name = "UI_MainForm";
            this.Text = "CMPE 1666 LAB03_BallZ";
            this.Load += new System.EventHandler(this.UI_MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox UI_checkBoxScore;
        private System.Windows.Forms.CheckBox UI_checkBoxAnima;
        private System.Windows.Forms.Button UI_buttonMainPlay;
        private System.Windows.Forms.Timer UI_timer;
    }
}

