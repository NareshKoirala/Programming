namespace MolarMassCalculator_JT_Naresh_2800
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
            this.UI_DataGridView = new System.Windows.Forms.DataGridView();
            this.UI_Btn_SortByName = new System.Windows.Forms.Button();
            this.UI_Btn_SingleChar = new System.Windows.Forms.Button();
            this.UI_Btn_SortByAtomicNum = new System.Windows.Forms.Button();
            this.UI_Lbl_ChemForm = new System.Windows.Forms.Label();
            this.UI_TB_ChemFormula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._searchTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UI_Lbl_MolarMass = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UI_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_DataGridView
            // 
            this.UI_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_DataGridView.Location = new System.Drawing.Point(12, 12);
            this.UI_DataGridView.Name = "UI_DataGridView";
            this.UI_DataGridView.Size = new System.Drawing.Size(581, 335);
            this.UI_DataGridView.TabIndex = 0;
            // 
            // UI_Btn_SortByName
            // 
            this.UI_Btn_SortByName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Btn_SortByName.Location = new System.Drawing.Point(599, 12);
            this.UI_Btn_SortByName.Name = "UI_Btn_SortByName";
            this.UI_Btn_SortByName.Size = new System.Drawing.Size(189, 26);
            this.UI_Btn_SortByName.TabIndex = 1;
            this.UI_Btn_SortByName.Text = "Sort by Name";
            this.UI_Btn_SortByName.UseVisualStyleBackColor = true;
            this.UI_Btn_SortByName.Click += new System.EventHandler(this.UI_Btn_SortByName_Click);
            // 
            // UI_Btn_SingleChar
            // 
            this.UI_Btn_SingleChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Btn_SingleChar.Location = new System.Drawing.Point(599, 44);
            this.UI_Btn_SingleChar.Name = "UI_Btn_SingleChar";
            this.UI_Btn_SingleChar.Size = new System.Drawing.Size(189, 28);
            this.UI_Btn_SingleChar.TabIndex = 2;
            this.UI_Btn_SingleChar.Text = "Single Character Symbols";
            this.UI_Btn_SingleChar.UseVisualStyleBackColor = true;
            this.UI_Btn_SingleChar.Click += new System.EventHandler(this.UI_Btn_SingleChar_Click);
            // 
            // UI_Btn_SortByAtomicNum
            // 
            this.UI_Btn_SortByAtomicNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Btn_SortByAtomicNum.Location = new System.Drawing.Point(599, 78);
            this.UI_Btn_SortByAtomicNum.Name = "UI_Btn_SortByAtomicNum";
            this.UI_Btn_SortByAtomicNum.Size = new System.Drawing.Size(189, 26);
            this.UI_Btn_SortByAtomicNum.TabIndex = 3;
            this.UI_Btn_SortByAtomicNum.Text = "Sort by Atomic #";
            this.UI_Btn_SortByAtomicNum.UseVisualStyleBackColor = true;
            this.UI_Btn_SortByAtomicNum.Click += new System.EventHandler(this.UI_Btn_SortByAtomicNum_Click);
            // 
            // UI_Lbl_ChemForm
            // 
            this.UI_Lbl_ChemForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_Lbl_ChemForm.AutoSize = true;
            this.UI_Lbl_ChemForm.Location = new System.Drawing.Point(12, 353);
            this.UI_Lbl_ChemForm.Name = "UI_Lbl_ChemForm";
            this.UI_Lbl_ChemForm.Size = new System.Drawing.Size(90, 13);
            this.UI_Lbl_ChemForm.TabIndex = 4;
            this.UI_Lbl_ChemForm.Text = "Chemical Formula";
            // 
            // UI_TB_ChemFormula
            // 
            this.UI_TB_ChemFormula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_TB_ChemFormula.Location = new System.Drawing.Point(108, 350);
            this.UI_TB_ChemFormula.Name = "UI_TB_ChemFormula";
            this.UI_TB_ChemFormula.Size = new System.Drawing.Size(314, 20);
            this.UI_TB_ChemFormula.TabIndex = 5;
            this.UI_TB_ChemFormula.Text = " ";
            this.UI_TB_ChemFormula.TextChanged += new System.EventHandler(this.UI_TB_ChemFormula_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Approx. MolarMass: ";
            // 
            // _searchTextBox
            // 
            this._searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._searchTextBox.Location = new System.Drawing.Point(612, 158);
            this._searchTextBox.Name = "_searchTextBox";
            this._searchTextBox.Size = new System.Drawing.Size(176, 20);
            this._searchTextBox.TabIndex = 8;
            this._searchTextBox.Text = " ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(609, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Search:";
            // 
            // UI_Lbl_MolarMass
            // 
            this.UI_Lbl_MolarMass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_Lbl_MolarMass.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UI_Lbl_MolarMass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UI_Lbl_MolarMass.ForeColor = System.Drawing.Color.Lime;
            this.UI_Lbl_MolarMass.Location = new System.Drawing.Point(624, 353);
            this.UI_Lbl_MolarMass.Name = "UI_Lbl_MolarMass";
            this.UI_Lbl_MolarMass.Size = new System.Drawing.Size(164, 23);
            this.UI_Lbl_MolarMass.TabIndex = 10;
            this.UI_Lbl_MolarMass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 377);
            this.Controls.Add(this.UI_Lbl_MolarMass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._searchTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UI_TB_ChemFormula);
            this.Controls.Add(this.UI_Lbl_ChemForm);
            this.Controls.Add(this.UI_Btn_SortByAtomicNum);
            this.Controls.Add(this.UI_Btn_SingleChar);
            this.Controls.Add(this.UI_Btn_SortByName);
            this.Controls.Add(this.UI_DataGridView);
            this.MaximumSize = new System.Drawing.Size(1200, 900);
            this.MinimumSize = new System.Drawing.Size(816, 416);
            this.Name = "Form1";
            this.Text = "MMC";
            ((System.ComponentModel.ISupportInitialize)(this.UI_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView UI_DataGridView;
        private System.Windows.Forms.Button UI_Btn_SortByName;
        private System.Windows.Forms.Button UI_Btn_SingleChar;
        private System.Windows.Forms.Button UI_Btn_SortByAtomicNum;
        private System.Windows.Forms.Label UI_Lbl_ChemForm;
        private System.Windows.Forms.TextBox UI_TB_ChemFormula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _searchTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label UI_Lbl_MolarMass;
    }
}

