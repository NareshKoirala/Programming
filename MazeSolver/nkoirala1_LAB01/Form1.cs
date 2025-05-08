// LAB_01
// Naresh P. Koirala
// Submission Code : 1241_2300_L01
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using GDIDrawer;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace nkoirala1_LAB01
{
    public partial class Form1 : Form
    {
        private enum CellState 
        {
            Open,
            Wall,
            Visited
        }
        private const int scale = 10; //Scale for the cDrawer

        private CellState[,] maze; // 2D array for maze representation
        private CDrawer drawer = null; // CDrawer object
        private Point start, end; // Start and end points of the maze
        private Color solutionColor = Color.Blue; // Color of the solution path
        private int speed = 10; // Speed for solving, in milliseconds
        private int steps = 0; // Number of steps taken to solve

        private Thread solveThread = null; // Thread for solving
        private bool solving = false; // Bool to track if solve is running

        public Form1()
        {
            InitializeComponent();

            // Property 
            _lblDropDrag.Text = "Drop Mazes Here!";
            _btnSolve.Text = "Solve";
            _btnColor.Text = "Solve Color";
            _btnColor.BackColor = solutionColor;
            _lblScrollNum.Text = $"{speed}";
            _lblDropDrag.AllowDrop = true;
            _btnSolve.Enabled = false;

            // Form Events
            _btnColor.Click += _btnColor_Click;
            _lblScrollNum.MouseWheel += _lblScrollNum_MouseWheel;
            _lblDropDrag.DragEnter += _lblDropDrag_DragEnter;
            _lblDropDrag.DragDrop += _lblDropDrag_DragDrop;
            _btnSolve.Click += _btnSolve_Click;

        }

        /// <summary>
        /// Adds valid neighbors of the current point to the exploration list.
        /// </summary>
        /// <param name="current">The current point being processed.</param>
        /// <param name="pointsToExplore">The list to which valid neighbors will be added.</param>
        private void AddValidNeighbors(Point current, List<Point> pointsToExplore)
        {
            Point[] directions = { new Point(0, 1), new Point(1, 0), new Point(0, -1), new Point(-1, 0) };

            foreach (Point dir in directions)
            {
                Point neighbor = new Point(current.X + dir.X, current.Y + dir.Y);

                // Check if the neighbor is within the maze bounds and is an open cell
                if (neighbor.X >= 0 && neighbor.X < maze.GetLength(0) && neighbor.Y >= 0 && neighbor.Y < maze.GetLength(1) && maze[neighbor.X, neighbor.Y] == CellState.Open)
                {
                    pointsToExplore.Add(neighbor);  // Add to the list (simulates enqueue)
                }
            }
        }

        /// <summary>
        /// Solves the maze using a list as a queue, updates UI with progress, and handles visualization delays.
        /// </summary>
        private void Solve()
        {
            steps = 0;

            List<Point> pointsToExplore = new List<Point>(); // List simulating a queue
            pointsToExplore.Add(start); // Add start point to the list

            while (pointsToExplore.Count > 0 && solving)
            {
                Point current = pointsToExplore[0];  // Get the first point (simulates dequeue)
                pointsToExplore.RemoveAt(0);         // Remove the first point

                // Check if the current point is already visited or is a wall
                if (maze[current.X, current.Y] == CellState.Visited || maze[current.X, current.Y] == CellState.Wall)
                {
                    continue;
                }

                // Check if we've reached the end
                if (current == end)
                {
                    _lbStatus.Invoke((Action)(() => _lbStatus.Items.Add("Solve: Success - Maze solved! Steps - " + steps)));
                    solving = false;
                    Invoke((Action)(() => _btnSolve.Enabled = false));
                    _btnSolve.Invoke((Action)(() => _btnSolve.Text = "Solve"));
                    return;
                }

                // Add a delay for visualization purposes
                Thread.Sleep(speed);

                // Mark the current point as visited and color the solution path
                if (current != start && current != end)
                {
                    drawer.SetBBScaledPixel(current.X, current.Y, solutionColor);
                    maze[current.X, current.Y] = CellState.Visited;
                }

                drawer.Render();  // Update the drawer

                // Enqueue (add to the list) neighbors of the current point
                AddValidNeighbors(current, pointsToExplore);

                steps++;
            }

            if (solving)
            {
                _lbStatus.Invoke((Action)(() => _lbStatus.Items.Add("Solve: Failed - No solution found.")));
            }

            _btnSolve.Invoke((Action)(() => _btnSolve.Text = "Solve"));
            solving = false;
        }

        /// <summary>
        /// Solves the maze using a separate thread, updating the UI with progress and status.
        /// </summary>
        private void SolveWithThreading()
        {
            steps = 0;
            List<Point> pointsToExplore = new List<Point>();
            pointsToExplore.Add(start);

            while (pointsToExplore.Count > 0 && solving)
            {
                Point current = pointsToExplore[0];
                pointsToExplore.RemoveAt(0);

                if (maze[current.X, current.Y] == CellState.Visited || maze[current.X, current.Y] == CellState.Wall)
                {
                    continue;
                }

                if (current == end)
                {
                    Invoke((Action)(() => _lbStatus.Items.Add("SolveWithThreading: Success - Maze solved! Steps - " +steps)));
                    solving = false;
                    Invoke((Action)(() => _btnSolve.Enabled = false));
                    Invoke((Action)(() => _btnSolve.Text = "Solve"));
                    return;
                }

                if (speed > 0) Thread.Sleep(speed);

                if (current != start && current != end)
                {
                    Invoke((Action)(() => drawer.SetBBScaledPixel(current.X, current.Y, solutionColor)));
                    maze[current.X, current.Y] = CellState.Visited;
                }

                Invoke((Action)(() => drawer.Render()));
                AddValidNeighbors(current, pointsToExplore);

                steps++;
            }

            if (solving)
            {
                Invoke((Action)(() => _lbStatus.Items.Add("SolveWithThreading: Failed - No solution found.")));
            }

            Invoke((Action)(() => _btnSolve.Text = "Solve"));
            solveThread = null;
            solving = false;
        }

        private void _btnSolve_Click(object sender, EventArgs e)
        {
            if (!solving)
            {
                solving = true;
                _btnSolve.Text = "Cancel"; // Change button to Cancel

                // Calculate maze area
                int mazeArea = maze.GetLength(0) * maze.GetLength(1);

                // Check if we need to use a threaded solver
                if (mazeArea > 4000 || speed > 4)
                {
                    _lbStatus.Items.Add("_btnSolve_Click: Using - Solving the maze with the thread.");
                    // Start threaded solver
                    solveThread = new Thread(() => SolveWithThreading());
                    solveThread.Start();
                }
                else
                {
                    _lbStatus.Items.Add("_btnSolve_Click: Using - Solving the maze without the thread.");
                    // Directly solve the maze without threading
                    Solve();
                }
            }
            else
            {
                solving = false; // Cancel the solving thread
                solveThread = null;
                _lbStatus.Items.Add("Maze Solve:Cancel - Please load another maze to start again");
                _btnSolve.Enabled = false;
                _btnSolve.Text = "Solve";
            }
        }

        /// <summary>
        /// Loads a maze from a bitmap file, initializes the CDrawer, and sets start/end points.
        /// </summary>
        /// <param name="_filename">Path to the maze bitmap file.</param>
        private void LoadMaze(string _filename)
        {
            try
            {
                int startEndChecker = 0;
                Bitmap bmp = new Bitmap(_filename);

                if (bmp.Width > 190 || bmp.Height > 100)
                    throw new Exception("Bitmap size exceeds displayable area");

                maze = new CellState[bmp.Width, bmp.Height];

                drawer = new CDrawer(bmp.Width * scale, bmp.Height * scale);
                drawer.Scale = scale;
                drawer.ContinuousUpdate = false;
                drawer.Position = new Point(this.Location.X + this.Width, this.Location.Y);


                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        Color pixelColor = bmp.GetPixel(x, y);
                        if (pixelColor == Color.FromArgb(0, 255, 0))
                        {
                            maze[x, y] = CellState.Open;
                            start = new Point(x, y);
                            startEndChecker++;
                        }
                        else if (pixelColor == Color.FromArgb(255, 0, 0))
                        {
                            maze[x, y] = CellState.Open;
                            end = new Point(x, y);
                            startEndChecker++;
                        }
                        else if (pixelColor == Color.FromArgb(0, 0, 0))
                        {
                            maze[x, y] = CellState.Wall;
                        }
                        else
                        {
                            maze[x, y] = CellState.Open;
                        }

                        if(startEndChecker > 2)
                            throw new Exception("Multiple Start and End.");

                        drawer.SetBBScaledPixel(x, y, pixelColor);
                    }
                }
            
                drawer.Render();
                Text = $"Maze Loaded: {_filename}";
                _lbStatus.Items.Add($"LoadMaze: Success - {_filename} loaded.");
                _btnSolve.Enabled = true; 

            }
            catch (Exception ex)
            {
                _lbStatus.Items.Add($"LoadMaze:Error - {ex.Message}");
            }
        }

        /// <summary>
        /// Validating the file name and invoking the name
        /// </summary>
        private void _lblDropDrag_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (files.Length != 1)
            {
                _lbStatus.Items.Add("_lblDropDrag_DragDrop:DragDrop - File couldn't be loaded - (Dont push multiple img)");
                return;
            }


            if (solveThread != null && solving)
            {
                _lbStatus.Items.Add($"LoadMaze:Error - Solving a Maze right now - Wait.");
                return;
            }
            else if (drawer != null)
                drawer.Close();

            _lbStatus.Items.Add("Load: Maze Loaded: " +Path.GetFileName(files[0]));

            Invoke(new Action(() => LoadMaze(files[0])));
        }

        /// <summary>
        /// Effect for Drag Drop Effect
        /// </summary>
        private void _lblDropDrag_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        /// <summary>
        /// UI update with speed and get valid thread sleep speed
        /// </summary>
        private void _lblScrollNum_MouseWheel(object sender, MouseEventArgs e)
        {
            speed += e.Delta > 0 ? 1 : -1;

            speed = speed < 0 ? 0 : speed;

            _lblScrollNum.Text = $"{speed}";
        }

        /// <summary>
        /// Get the color for the solve color
        /// </summary>
        private void _btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = solutionColor;

            if (dlg.ShowDialog() == DialogResult.OK && dlg.Color != Color.White && dlg.Color != Color.Green && dlg.Color != Color.Red && dlg.Color != Color.Black) {
                solutionColor = dlg.Color;
            }

            _btnColor.BackColor = solutionColor;
        }
    }
}
