namespace Mark_Naresh__UDP_TAPChat
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
            this.UI_sendBTN = new System.Windows.Forms.Button();
            this.UI_addtargetBTN = new System.Windows.Forms.Button();
            this.UI_messageLBL = new System.Windows.Forms.Label();
            this.UI_messageTXTBOX = new System.Windows.Forms.TextBox();
            this.UI_targetedIPTXTBOX = new System.Windows.Forms.TextBox();
            this.UI_nicknameTXTBOX = new System.Windows.Forms.TextBox();
            this.UI_messageboxDATAGRID = new System.Windows.Forms.DataGridView();
            this.UI_knowipLSBOX = new System.Windows.Forms.ListBox();
            this.UI_targetaddrLBL = new System.Windows.Forms.Label();
            this.UI_nicknameLBL = new System.Windows.Forms.Label();
            this.UI_knowaddrLBL = new System.Windows.Forms.Label();
            this.UI_consoleErrorLBL = new System.Windows.Forms.Label();
            this.UI_deleteKnowIpBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UI_messageboxDATAGRID)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_sendBTN
            // 
            this.UI_sendBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_sendBTN.Location = new System.Drawing.Point(685, 32);
            this.UI_sendBTN.Name = "UI_sendBTN";
            this.UI_sendBTN.Size = new System.Drawing.Size(103, 23);
            this.UI_sendBTN.TabIndex = 0;
            this.UI_sendBTN.Text = "button1";
            this.UI_sendBTN.UseVisualStyleBackColor = true;
            // 
            // UI_addtargetBTN
            // 
            this.UI_addtargetBTN.Location = new System.Drawing.Point(478, 55);
            this.UI_addtargetBTN.Name = "UI_addtargetBTN";
            this.UI_addtargetBTN.Size = new System.Drawing.Size(85, 23);
            this.UI_addtargetBTN.TabIndex = 1;
            this.UI_addtargetBTN.Text = "button2";
            this.UI_addtargetBTN.UseVisualStyleBackColor = true;
            // 
            // UI_messageLBL
            // 
            this.UI_messageLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_messageLBL.AutoSize = true;
            this.UI_messageLBL.Location = new System.Drawing.Point(12, 6);
            this.UI_messageLBL.Name = "UI_messageLBL";
            this.UI_messageLBL.Size = new System.Drawing.Size(35, 13);
            this.UI_messageLBL.TabIndex = 2;
            this.UI_messageLBL.Text = "label1";
            // 
            // UI_messageTXTBOX
            // 
            this.UI_messageTXTBOX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_messageTXTBOX.Location = new System.Drawing.Point(103, 6);
            this.UI_messageTXTBOX.Name = "UI_messageTXTBOX";
            this.UI_messageTXTBOX.Size = new System.Drawing.Size(685, 20);
            this.UI_messageTXTBOX.TabIndex = 4;
            // 
            // UI_targetedIPTXTBOX
            // 
            this.UI_targetedIPTXTBOX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_targetedIPTXTBOX.Location = new System.Drawing.Point(103, 32);
            this.UI_targetedIPTXTBOX.Name = "UI_targetedIPTXTBOX";
            this.UI_targetedIPTXTBOX.Size = new System.Drawing.Size(576, 20);
            this.UI_targetedIPTXTBOX.TabIndex = 5;
            // 
            // UI_nicknameTXTBOX
            // 
            this.UI_nicknameTXTBOX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_nicknameTXTBOX.Location = new System.Drawing.Point(655, 57);
            this.UI_nicknameTXTBOX.Name = "UI_nicknameTXTBOX";
            this.UI_nicknameTXTBOX.Size = new System.Drawing.Size(133, 20);
            this.UI_nicknameTXTBOX.TabIndex = 6;
            // 
            // UI_messageboxDATAGRID
            // 
            this.UI_messageboxDATAGRID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_messageboxDATAGRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_messageboxDATAGRID.Location = new System.Drawing.Point(197, 84);
            this.UI_messageboxDATAGRID.Name = "UI_messageboxDATAGRID";
            this.UI_messageboxDATAGRID.Size = new System.Drawing.Size(591, 355);
            this.UI_messageboxDATAGRID.TabIndex = 8;
            // 
            // UI_knowipLSBOX
            // 
            this.UI_knowipLSBOX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_knowipLSBOX.FormattingEnabled = true;
            this.UI_knowipLSBOX.Location = new System.Drawing.Point(15, 110);
            this.UI_knowipLSBOX.Name = "UI_knowipLSBOX";
            this.UI_knowipLSBOX.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.UI_knowipLSBOX.Size = new System.Drawing.Size(176, 329);
            this.UI_knowipLSBOX.TabIndex = 9;
            // 
            // UI_targetaddrLBL
            // 
            this.UI_targetaddrLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_targetaddrLBL.AutoSize = true;
            this.UI_targetaddrLBL.Location = new System.Drawing.Point(12, 32);
            this.UI_targetaddrLBL.Name = "UI_targetaddrLBL";
            this.UI_targetaddrLBL.Size = new System.Drawing.Size(35, 13);
            this.UI_targetaddrLBL.TabIndex = 10;
            this.UI_targetaddrLBL.Text = "label1";
            // 
            // UI_nicknameLBL
            // 
            this.UI_nicknameLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_nicknameLBL.AutoSize = true;
            this.UI_nicknameLBL.Location = new System.Drawing.Point(569, 64);
            this.UI_nicknameLBL.Name = "UI_nicknameLBL";
            this.UI_nicknameLBL.Size = new System.Drawing.Size(35, 13);
            this.UI_nicknameLBL.TabIndex = 11;
            this.UI_nicknameLBL.Text = "label1";
            // 
            // UI_knowaddrLBL
            // 
            this.UI_knowaddrLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_knowaddrLBL.AutoSize = true;
            this.UI_knowaddrLBL.Location = new System.Drawing.Point(12, 84);
            this.UI_knowaddrLBL.Name = "UI_knowaddrLBL";
            this.UI_knowaddrLBL.Size = new System.Drawing.Size(35, 13);
            this.UI_knowaddrLBL.TabIndex = 12;
            this.UI_knowaddrLBL.Text = "label1";
            // 
            // UI_consoleErrorLBL
            // 
            this.UI_consoleErrorLBL.AutoSize = true;
            this.UI_consoleErrorLBL.Location = new System.Drawing.Point(12, 60);
            this.UI_consoleErrorLBL.Name = "UI_consoleErrorLBL";
            this.UI_consoleErrorLBL.Size = new System.Drawing.Size(35, 13);
            this.UI_consoleErrorLBL.TabIndex = 13;
            this.UI_consoleErrorLBL.Text = "label1";
            // 
            // UI_deleteKnowIpBTN
            // 
            this.UI_deleteKnowIpBTN.Location = new System.Drawing.Point(103, 81);
            this.UI_deleteKnowIpBTN.Name = "UI_deleteKnowIpBTN";
            this.UI_deleteKnowIpBTN.Size = new System.Drawing.Size(85, 23);
            this.UI_deleteKnowIpBTN.TabIndex = 14;
            this.UI_deleteKnowIpBTN.Text = "button2";
            this.UI_deleteKnowIpBTN.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UI_deleteKnowIpBTN);
            this.Controls.Add(this.UI_consoleErrorLBL);
            this.Controls.Add(this.UI_knowaddrLBL);
            this.Controls.Add(this.UI_nicknameLBL);
            this.Controls.Add(this.UI_targetaddrLBL);
            this.Controls.Add(this.UI_knowipLSBOX);
            this.Controls.Add(this.UI_messageboxDATAGRID);
            this.Controls.Add(this.UI_nicknameTXTBOX);
            this.Controls.Add(this.UI_targetedIPTXTBOX);
            this.Controls.Add(this.UI_messageTXTBOX);
            this.Controls.Add(this.UI_messageLBL);
            this.Controls.Add(this.UI_addtargetBTN);
            this.Controls.Add(this.UI_sendBTN);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.UI_messageboxDATAGRID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UI_sendBTN;
        private System.Windows.Forms.Button UI_addtargetBTN;
        private System.Windows.Forms.Label UI_messageLBL;
        private System.Windows.Forms.TextBox UI_messageTXTBOX;
        private System.Windows.Forms.TextBox UI_targetedIPTXTBOX;
        private System.Windows.Forms.TextBox UI_nicknameTXTBOX;
        private System.Windows.Forms.DataGridView UI_messageboxDATAGRID;
        private System.Windows.Forms.ListBox UI_knowipLSBOX;
        private System.Windows.Forms.Label UI_targetaddrLBL;
        private System.Windows.Forms.Label UI_nicknameLBL;
        private System.Windows.Forms.Label UI_knowaddrLBL;
        private System.Windows.Forms.Label UI_consoleErrorLBL;
        private System.Windows.Forms.Button UI_deleteKnowIpBTN;
    }
}

