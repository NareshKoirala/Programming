//*************************************************************
//Program: Lab02
//Description: Lab02
//Date: nov. 3/2023
//Author: Naresh Koirala
//Course: CMPE1666
//Class: CNT-A01
//**************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab02_nareshk
{
    public partial class Form1 : Form
    {
        Bitmap MainBmp;//global varable
        Bitmap Modified;//global varable
        public Form1()
        {
            InitializeComponent();
            UI_trackBar.Value = 20;
            UI_LabelPrint.Text = (UI_trackBar.Value ).ToString();
            UI_LabelPrint.ForeColor = Color.Blue;
            UI_LabelPrint.Anchor = AnchorStyles.Bottom;
            UI_buttonTransform.Enabled = false;
        }

        //***********************************************************************************
        //Method:  private void button1_Click(object sender, EventArgs e)
        //Purpose: main load button click
        //*******************************************************************************

        private void UI_buttonLoad_Click(object sender, EventArgs e)
        {

            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "JPEG (*.jpg) |*.jpg |PNG (*.png) |*.png |BMP (*.bmp)|*.bmp| ALL Files (*.jpg; *.png; *.bmp)|*.jpg;*.png;*.bmp";
            openFileDialog1.FilterIndex = 3;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    UI_pictureBox.Load(openFileDialog1.FileName);
                    UI_buttonTransform.Enabled = true;
                    MainBmp = new Bitmap(openFileDialog1.FileName);
                    Modified = new Bitmap(openFileDialog1.FileName);
                }
                catch
                {
                    MessageBox.Show("File Did Not load");
                }

            }
        }

        //***********************************************************************************
        //Method:   private void UI_trackBar_ValueChanged(object sender, EventArgs e)
        //Purpose:  track value change
        //*******************************************************************************

        private void UI_trackBar_ValueChanged(object sender, EventArgs e)
        {
            string str = (UI_trackBar.Value).ToString();
            if (UI_radioButTint.Checked)
            {
                if (UI_trackBar.Value < 0)
                    str = "Red: " + ((UI_trackBar.Value) * -1).ToString();

                if (UI_trackBar.Value > 0)
                    str = "Green: " + (UI_trackBar.Value).ToString();
            }

            UI_LabelPrint.Text = str;
        }
        //***********************************************************************************
        //Method:  private void UI_radioButTint_CheckedChanged(object sender, EventArgs e)
        //Purpose: change the label
        //*******************************************************************************

        private void UI_radioButTint_CheckedChanged(object sender, EventArgs e)
        {
            if (!UI_radioButTint.Checked)
            {
                Ui_labelLess.Text = "Less";
                UI_labelMore.Text = "More";

                UI_trackBar.Maximum = 100;
                UI_trackBar.Minimum = 0;
                UI_trackBar.Value = 20;
            }
            else
            {
                Ui_labelLess.Text = "Red";
                UI_labelMore.Text = "Green";

                UI_trackBar.Maximum = 50;
                UI_trackBar.Minimum = -50;
                UI_trackBar.Value = 0;
            }
        }
        //***********************************************************************************
        //Method:  private void UI_buttonRevert_Click(object sender, EventArgs e)
        //Purpose: revert to the main image
        //*******************************************************************************

        private void UI_buttonRevert_Click(object sender, EventArgs e)
        {
            if (UI_pictureBox.Image != null)
            {
                try
                {
                    UI_pictureBox.Load(openFileDialog1.FileName);
                    MainBmp = new Bitmap(openFileDialog1.FileName);
                    Modified = new Bitmap(openFileDialog1.FileName);

                }
                catch
                {
                    MessageBox.Show("File Did Not load");
                }

            }
        }
        //***********************************************************************************
        //Method:  private void UI_buttonTransform_Click(object sender, EventArgs e)
        //Purpose: change the radio
        //*******************************************************************************

        private void UI_buttonTransform_Click(object sender, EventArgs e)
        {
            if (UI_radioButBnW.Checked && UI_pictureBox.Image != null)
                BlackNWhite(Modified, UI_trackBar.Value);

            if (UI_radioButContrast.Checked && UI_pictureBox.Image != null)
                Contrast(Modified, UI_trackBar.Value);

            if (UI_radioButTint.Checked && UI_pictureBox.Image != null)
                tint(Modified, UI_trackBar.Value);

            if(UI_radioButNoise.Checked && UI_pictureBox.Image != null)
                noise(Modified, UI_trackBar.Value);

            UI_pictureBox.Image = Modified;
            UI_progressBar.Value = 0;
        }
        //***********************************************************************************
        //Method:  private void tint(Bitmap image, int value)
        //Purpose: to fliter tint
        //Parameters:Bitmap image, int value
        //*******************************************************************************

        private void tint(Bitmap image, int value)
        {
            Color get;
            UI_progressBar.Value = 0;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    get = image.GetPixel(x, y);

                    double r = get.R;
                    double g = get.G;
                    double b = get.B;

                    if (value < 0)
                        r += (50 - value);

                    if (value > 0)
                        g += (50 + value);

                    miniMax(ref r, ref g, ref b);

                    Modified.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                }
                progressBar();
            }
        }
        //***********************************************************************************
        //Method:  private void Contrast(Bitmap image, int value)
        //Purpose: to fliter contrast
        //Parameters:Bitmap image, int value
        //*******************************************************************************

        private void Contrast(Bitmap image, int value)
        {
            Color get;
            UI_progressBar.Value = 0;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    get = image.GetPixel(x, y);

                    double r = mathContrast(get.R, value);
                    double g = mathContrast(get.G, value);
                    double b = mathContrast(get.B, value);

                    miniMax(ref r,ref g,ref b);

                    Modified.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                }
                progressBar();
            }
        }
        //***********************************************************************************
        //Method:  private void noise(Bitmap image, int value)
        //Purpose: to fliter noise
        //Parameters:Bitmap image, int value
        //*******************************************************************************

        private void noise(Bitmap image, int value)
        {
            Random num = new Random();
            Color get;
            UI_progressBar.Value = 0;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    get = image.GetPixel(x, y);

                    double r = noiseMath(get.R, num, value);
                    double g = noiseMath(get.G, num, value);
                    double b = noiseMath(get.B, num, value);

                    miniMax(ref r, ref g, ref b);

                    Modified.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                }
                progressBar();
            }
        }
        //***********************************************************************************
        //Method:  static private void GetValue(out double valueDouble, string prompt)
        //Purpose: to get the proper int value with the proper range and valid currency
        //Parameters:string prompt - prompt to display to the user
        //Returns: int - value accepted by the method
        //*******************************************************************************

        private double noiseMath(double color, Random num, double scale) { return (color + (num.Next(0, 256) % ((scale + 1) * 20) - scale)); }
        //***********************************************************************************
        //Method:  static private void GetValue(out double valueDouble, string prompt)
        //Purpose: to get the proper int value with the proper range and valid currency
        //Parameters:string prompt - prompt to display to the user
        //Returns: int - value accepted by the method
        //*******************************************************************************

        private void miniMax(ref double red, ref double green, ref double blue)
        {
            red = (red < 255) ? red : 255;
            green = (green < 255) ? green : 255;
            blue = (blue < 255) ? blue : 255;
            red = (red > 0) ? red : 0;
            green = (green > 0) ? green : 0;
            blue = (blue > 0) ? blue : 0;
        }
        //***********************************************************************************
        //Method:  private double mathContrast(double value, double scale)
        //Purpose: math for constrast
        //Parameters:double value, double scale
        //Returns: int - value accepted by the method
        //*******************************************************************************

        private double mathContrast(double value, double scale)
        {
            if (value > 128)
                return (value + (scale / 5.0));

            if (value < 128)
                return (value - (scale / 5.0));

            return value;
        }
        //***********************************************************************************
        //Method:  private void BlackNWhite(Bitmap image, int value)
        //Purpose: to fliter black and white
        //Parameters:Bitmap image, int value
        //*******************************************************************************

        private void BlackNWhite(Bitmap image, int value)
        { 
            Color get;
            UI_progressBar.Value = 0;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    get = image.GetPixel(x, y);

                    int avg = Average(get.R, get.G, get.B);

                    double r = mathBNW(get.R, avg, value / 100.00);
                    double g = mathBNW(get.G, avg, value / 100.00);
                    double b = mathBNW(get.B, avg, value / 100.00);

                    miniMax(ref r, ref g, ref b);

                    Modified.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                }
                progressBar();
            }
        }
        //***********************************************************************************
        //Method:  private void progressBar()
        //Purpose: to increament progress bar
        //*******************************************************************************

        private void progressBar()
        {
            UI_progressBar.Maximum = Modified.Width-200;
            UI_progressBar.Increment(1);
        }
        //***********************************************************************************
        //Method:  private int Average(int r, int g, int b)
        //Purpose: it does the math 
        //Parameters: int r, int g, int b
        //Returns:  returns the solution
        //*******************************************************************************

        private int Average(int r, int g, int b) { return ((r + g + b) / 3); }
        //***********************************************************************************
        //Method:  private double mathBNW(double color, double avg, double scale)
        //Purpose: it does the math 
        //Parameters: double color, double avg, double scale
        //Returns:  returns the solution
        //*******************************************************************************

        private double mathBNW(double color, double avg, double scale) { return (color + ((avg - color) * scale)); }

    }
}
