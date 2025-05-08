namespace nkoirala1_LAB01
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
            this._lblDropDrag = new System.Windows.Forms.Label();
            this._lblScrollNum = new System.Windows.Forms.Label();
            this._btnSolve = new System.Windows.Forms.Button();
            this._lbStatus = new System.Windows.Forms.ListBox();
            this._btnColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblDropDrag
            // 
            this._lblDropDrag.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._lblDropDrag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblDropDrag.Location = new System.Drawing.Point(12, 9);
            this._lblDropDrag.Name = "_lblDropDrag";
            this._lblDropDrag.Size = new System.Drawing.Size(131, 60);
            this._lblDropDrag.TabIndex = 0;
            this._lblDropDrag.Text = "label1";
            this._lblDropDrag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblScrollNum
            // 
            this._lblScrollNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblScrollNum.Location = new System.Drawing.Point(315, 28);
            this._lblScrollNum.Name = "_lblScrollNum";
            this._lblScrollNum.Size = new System.Drawing.Size(81, 23);
            this._lblScrollNum.TabIndex = 1;
            this._lblScrollNum.Text = "label1";
            // 
            // _btnSolve
            // 
            this._btnSolve.Location = new System.Drawing.Point(166, 9);
            this._btnSolve.Name = "_btnSolve";
            this._btnSolve.Size = new System.Drawing.Size(128, 60);
            this._btnSolve.TabIndex = 2;
            this._btnSolve.Text = "button1";
            this._btnSolve.UseVisualStyleBackColor = true;
            // 
            // _lbStatus
            // 
            this._lbStatus.FormattingEnabled = true;
            this._lbStatus.ItemHeight = 16;
            this._lbStatus.Location = new System.Drawing.Point(9, 99);
            this._lbStatus.Name = "_lbStatus";
            this._lbStatus.Size = new System.Drawing.Size(667, 212);
            this._lbStatus.TabIndex = 3;
            // 
            // _btnColor
            // 
            this._btnColor.Location = new System.Drawing.Point(418, 28);
            this._btnColor.Name = "_btnColor";
            this._btnColor.Size = new System.Drawing.Size(89, 23);
            this._btnColor.TabIndex = 4;
            this._btnColor.Text = "button1";
            this._btnColor.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 333);
            this.Controls.Add(this._btnColor);
            this.Controls.Add(this._lbStatus);
            this.Controls.Add(this._btnSolve);
            this.Controls.Add(this._lblScrollNum);
            this.Controls.Add(this._lblDropDrag);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _lblDropDrag;
        private System.Windows.Forms.Label _lblScrollNum;
        private System.Windows.Forms.Button _btnSolve;
        private System.Windows.Forms.ListBox _lbStatus;
        private System.Windows.Forms.Button _btnColor;
    }
}

