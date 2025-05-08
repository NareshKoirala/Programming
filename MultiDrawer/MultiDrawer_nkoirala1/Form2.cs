// Naresh Pd. Koirala
// Multi_Drawer_A03
// 2025-04-06
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiDrawer_nkoirala1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false;
           
        }

        public void Log(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Log), message);
            }
            listBox1.Items.Add(message);
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
    }
}
