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
    public partial class Form5 : Form
    {
        public string name 
        {
            get
            {
                return UI_textBox.Text;
            }
        }
        public Form5()
        {
            InitializeComponent();
        }

        private void UI_textBox_TextChanged(object sender, EventArgs e)
        {
            if (UI_textBox.Text != "")
            {
                UI_ok.Enabled = true;
            }
            else
            {
                UI_ok.Enabled = false;
            }
        }

        private void UI_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void UI_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            UI_ok.Enabled = false;
        }
    }
}
