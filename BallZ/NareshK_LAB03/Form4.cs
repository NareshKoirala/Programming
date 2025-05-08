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
    public partial class Form4 : Form
    {
        UI_MainForm mainForm = new UI_MainForm();

        public int trackValue 
        {
            set { trackBar1.Value = value; }
        }

        

        public Form4()
        {
            InitializeComponent();
            trackBar1.Value = 100;
            label2.Text = trackBar1.Value.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
            mainForm.Scoreanima(trackBar1.Value);
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
