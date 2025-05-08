using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB01_nkoirala1
{
    public partial class Form1 : Form
    {
        private int currentThresVal = 1;
        Action<string> error;
        Bitmap mainImage;
        Bitmap originalImage;
        ImageReducer image; 
        private Thread reductionThread;

        public Form1()
        {
            InitializeComponent();

            this.BackColor = Color.LightGray;
            _pictureBOX.BackColor = Color.White;

            _pictureBOX.SizeMode = PictureBoxSizeMode.Zoom;
            _reduceBTN.Enabled = false;

            this.Text = "ImagePress";
            _thresLBL.Text = "Threshold Value:";
            _reduceBTN.Text = "Reduce";
            _resetImage.Text = "Reset Image";
            _consoleLBL.Text = "";
            _thresValueLBL.Text = currentThresVal.ToString();

            error = (msg) => _consoleLBL.Text = msg;

            this.AllowDrop = true;

            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;
            _reduceBTN.Click += _reduceBTN_Click;
            _resetImage.Click += _resetImage_Click;
            _thresValueLBL.MouseWheel += _thresValueLBL_MouseWheel;

        }

        private void _resetImage_Click(object sender, EventArgs e)
        {
            if (image == null || mainImage == null || originalImage == null) return;

            mainImage = new Bitmap(originalImage);
            _pictureBOX.Image = mainImage;
            image = new ImageReducer(mainImage, error);

            _consoleLBL.Text = "Reseted Image";
        }

        private void _thresValueLBL_MouseWheel(object sender, MouseEventArgs e)
        {
            currentThresVal += e.Delta < 0 ? -1 : 1;

            if (currentThresVal < 1)
                currentThresVal = 1;
            else if (currentThresVal > 256)
                currentThresVal = 256;

            _thresValueLBL.Text = currentThresVal.ToString();
        }

        private void _reduceBTN_Click(object sender, EventArgs e)
        {
            if (image == null || mainImage == null) return;

            _reduceBTN.Enabled = false;
            _pictureBOX.Enabled = false; 
            _consoleLBL.Text = "Reducing colors...";

            reductionThread = new Thread(() => ReduceImageThread(currentThresVal));
            reductionThread.Start();
        }
        private void ReduceImageThread(int threshold)
        {
            try
            {
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                Bitmap reducedImage = image.ReduceImage(threshold);

                stopwatch.Stop();
                long elapsedMs = stopwatch.ElapsedMilliseconds;

                Invoke((Action)(() =>
                {
                    _pictureBOX.Image = reducedImage;
                    mainImage = reducedImage;
                    image = new ImageReducer(mainImage, error);
                    _consoleLBL.Text = $"Success - Reduced to {image.BuildColourTable().Count} colors! Took {elapsedMs} ms";
                    _reduceBTN.Enabled = true;
                    _pictureBOX.Enabled = true;
                }));
            }
            catch (Exception ex)
            {
                Invoke((Action)(() =>
                {
                    error($"Error during reduction: {ex.Message}");
                    _reduceBTN.Enabled = true;
                    _pictureBOX.Enabled = true;
                }));
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0 && System.IO.File.Exists(files[0]))
            {
                try
                {
                    mainImage = new Bitmap(files[0]);
                    _pictureBOX.Image = mainImage;
                    originalImage = new Bitmap(mainImage);

                    image = new ImageReducer(mainImage, error);

                    _consoleLBL.Text = "Success file - " + files[0] + $" - There are {image.BuildColourTable().Count} colors in the image!";

                    _reduceBTN.Enabled = true;
                }
                catch
                {
                    _consoleLBL.Text = "Invalid Image Format";
                    _pictureBOX.Image = null;
                    _reduceBTN.Enabled = false;
                }
            }
            else
                _consoleLBL.Text = "File doesn't exist";
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }
    }
}
