using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NareshK_LAB03
{
    public partial class Form2 : Form
    {
        int level = 0;
        public int mainLevel 
        {
            get { return level; }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void UI_Ok_Click(object sender, EventArgs e)
        {
            if (UI_radioEasy.Checked)
                level = 3;
            else if (UI_radioMedium.Checked)
                level = 4;
            else if (UI_radioHard.Checked) 
                level = 5;

            DialogResult = DialogResult.OK;
        }

        private void UI_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
