namespace LAB01_nkoirala1
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
            this._pictureBOX = new System.Windows.Forms.PictureBox();
            this._reduceBTN = new System.Windows.Forms.Button();
            this._thresLBL = new System.Windows.Forms.Label();
            this._consoleLBL = new System.Windows.Forms.Label();
            this._thresValueLBL = new System.Windows.Forms.Label();
            this._resetImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBOX)).BeginInit();
            this.SuspendLayout();
            // 
            // _pictureBOX
            // 
            this._pictureBOX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pictureBOX.Location = new System.Drawing.Point(12, 39);
            this._pictureBOX.Name = "_pictureBOX";
            this._pictureBOX.Size = new System.Drawing.Size(776, 399);
            this._pictureBOX.TabIndex = 0;
            this._pictureBOX.TabStop = false;
            // 
            // _reduceBTN
            // 
            this._reduceBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._reduceBTN.Location = new System.Drawing.Point(713, 10);
            this._reduceBTN.Name = "_reduceBTN";
            this._reduceBTN.Size = new System.Drawing.Size(75, 23);
            this._reduceBTN.TabIndex = 1;
            this._reduceBTN.Text = "button1";
            this._reduceBTN.UseVisualStyleBackColor = true;
            // 
            // _thresLBL
            // 
            this._thresLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._thresLBL.AutoSize = true;
            this._thresLBL.Location = new System.Drawing.Point(507, 14);
            this._thresLBL.Name = "_thresLBL";
            this._thresLBL.Size = new System.Drawing.Size(35, 13);
            this._thresLBL.TabIndex = 2;
            this._thresLBL.Text = "label1";
            // 
            // _consoleLBL
            // 
            this._consoleLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._consoleLBL.AutoSize = true;
            this._consoleLBL.Location = new System.Drawing.Point(12, 441);
            this._consoleLBL.Name = "_consoleLBL";
            this._consoleLBL.Size = new System.Drawing.Size(35, 13);
            this._consoleLBL.TabIndex = 3;
            this._consoleLBL.Text = "label2";
            // 
            // _thresValueLBL
            // 
            this._thresValueLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._thresValueLBL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._thresValueLBL.Location = new System.Drawing.Point(607, 9);
            this._thresValueLBL.Name = "_thresValueLBL";
            this._thresValueLBL.Size = new System.Drawing.Size(100, 23);
            this._thresValueLBL.TabIndex = 4;
            this._thresValueLBL.Text = "label3";
            this._thresValueLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _resetImage
            // 
            this._resetImage.Location = new System.Drawing.Point(12, 10);
            this._resetImage.Name = "_resetImage";
            this._resetImage.Size = new System.Drawing.Size(107, 23);
            this._resetImage.TabIndex = 5;
            this._resetImage.Text = "button1";
            this._resetImage.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 459);
            this.Controls.Add(this._resetImage);
            this.Controls.Add(this._thresValueLBL);
            this.Controls.Add(this._consoleLBL);
            this.Controls.Add(this._thresLBL);
            this.Controls.Add(this._reduceBTN);
            this.Controls.Add(this._pictureBOX);
            this.MinimumSize = new System.Drawing.Size(816, 498);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._pictureBOX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _pictureBOX;
        private System.Windows.Forms.Button _reduceBTN;
        private System.Windows.Forms.Label _thresLBL;
        private System.Windows.Forms.Label _consoleLBL;
        private System.Windows.Forms.Label _thresValueLBL;
        private System.Windows.Forms.Button _resetImage;
    }
}

