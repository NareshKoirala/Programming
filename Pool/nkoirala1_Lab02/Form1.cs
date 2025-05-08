// LAB_02
// Naresh P. Koirala
// Submission Code : 1241_2300_L02
using GDIDrawer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nkoirala1_Lab02
{
    public partial class Form1 : Form
    {
        public const float shotVelo = 40f;
        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        Table _table = null;
        private bool _running;
        private int _numBalls;

        public Form1()
        {
            InitializeComponent();

            button1.Text = $"New Table[{_numBalls}]";
            label2.Text = "Friction: " + Ball.Friction;
            radioButton1.Text = "Radius";
            radioButton2.Text = "Hits";
            radioButton3.Text = "Total Hits";
            groupBox1.Text = "Sort Mode : ";
            _timer.Interval = 35;
            _timer.Enabled = true;
            this.KeyPreview = true;
            radioButton1.Checked = true;
            dataGridView1.DataSource = null;

            // Binding UI events to handlers
            button1.Click += Button1_Click;
            button1.MouseWheel += Button1_MouseWheel;
            label2.MouseWheel += Label2_MouseWheel;
            radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton_CheckedChanged;
            radioButton3.CheckedChanged += RadioButton_CheckedChanged;
            _timer.Tick += _timer_Tick;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void Label2_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                Ball.Friction += 0.001f;
            else
                Ball.Friction -= 0.001f;

            Ball.Friction = Ball.Friction < 0 ? 0 : Ball.Friction;

            label2.Text = $"Friction: {Ball.Friction:f3}";
        }

        private void Button1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                _numBalls++;
            else
                _numBalls--;

            _numBalls = _numBalls < 0 ? 0 : _numBalls; // Ensures non-negative number of balls

            button1.Text = $"New Table[{_numBalls}]";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _table?._CDrawer?.Close(); // Close any existing drawer if present

            _table = new Table();
            _table.MakeTable(900, 600, _numBalls);

            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_table == null) return;

            _table.ShowTable();

            if (!_table.Running)
                UpdateGridView();
        }

        /// <summary>
        /// This method updates the DataGridView with ball statistics for user reference.
        /// </summary>
        public void UpdateGridView()
        {
            if (_table == null) return;

            List<Ball> retrive = _table.balls;

            if (radioButton1.Checked)
            {
                retrive.Sort();
            }
            else if (radioButton2.Checked)
            {
                retrive.Sort(Ball.CompareByHit);
            }
            else
            {
                retrive.Sort(Ball.CompareByTotalHits);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = retrive;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns["BallColor"].Visible = false;
            dataGridView1.Columns["Center"].Visible = false;
            dataGridView1.Columns["Velocity"].Visible = false;

            // Color-coding the Radius column for better visualization
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["Radius"].Style.BackColor = (Color)row.Cells["BallColor"].Value;
            }

            dataGridView1.AutoResizeColumns();
        }
    }
}
