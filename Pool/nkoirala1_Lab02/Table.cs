// LAB_02
// Naresh P. Koirala
// Submission Code : 1241_2300_L02
using GDIDrawer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace nkoirala1_Lab02
{
    internal class Table
    {
        public CDrawer _CDrawer { get; private set; }
        List<Ball> _balls = new List<Ball>();
        Vector2 _positionMouse;
        Ball _cueBall = null;
        public List<Ball> balls => new List<Ball>(_balls);
        public bool Running => _balls.Exists(ball => ball.Velocity != Vector2.Zero);

        public Table() { }
        /// <summary>
        /// Initializes the table by setting up the drawing canvas, creating the balls,
        /// and attaching mouse event handlers for user interaction.
        /// </summary>
        /// <param name="width">The width of the table (drawing area).</param>
        /// <param name="height">The height of the table (drawing area).</param>
        /// <param name="noBalls">The number of balls to be placed on the table.</param>
        public void MakeTable(int width, int height, int noBalls)
        {
            //_CDrawer?.Close();  // Ensure any existing drawer is closed before creating a new one

            _CDrawer = new CDrawer(width, height, false, true)
            {
                BBColour = Color.LightGreen // Sets the background color to light green
            };

            MakeBalls(noBalls);

            // Attach mouse events for user interaction
            _CDrawer.MouseMoveScaled += _CDrawer_MouseMoveScaled;
            _CDrawer.MouseLeftClickScaled += _CDrawer_MouseLeftClickScaled;

            ShowTable();
        }

        /// <summary>
        /// Creates the specified number of balls for the table, ensuring that no balls overlap.
        /// The cue ball is created first and added to the collection.
        /// </summary>
        /// <param name="noBalls">The number of additional balls to create besides the cue ball.</param>
        public void MakeBalls(int noBalls)
        {
            _balls.Clear();

            // Create the cue ball and ensure it is added to the collection first
            _cueBall = new Ball(_CDrawer);
            _balls.Add(_cueBall);

            for (int i = 0; i < noBalls; i++)
            {
                Ball newBall;
                bool overLap = false;

                do
                {
                    newBall = new Ball(_CDrawer, RandColor.GetColor());
                    overLap = _balls.Exists(p => p.Equals(newBall)); // Check for overlapping balls
                }
                while (overLap);

                _balls.Add(newBall);
            }
        }

        /// <summary>
        /// Displays the table by clearing the drawing canvas and moving each ball. 
        /// If the simulation is not running, it draws an aiming line from the cue ball
        /// to the current mouse position.
        /// </summary>
        public void ShowTable()
        {
            if (_CDrawer == null)
                return;

            _CDrawer.Clear();

            foreach (Ball b in _balls)
            {
                b.Move(_CDrawer, _balls);
                b.Show(_CDrawer);
            }

            // Draw an aiming line from the cue ball to the mouse position if not running
            if (!Running)
            {
                _CDrawer.AddLine((int)_cueBall.Center.X, (int)_cueBall.Center.Y, (int)_positionMouse.X, (int)_positionMouse.Y, Color.Yellow, 2);
            }
            _CDrawer.Render();
        }

        private void _CDrawer_MouseLeftClickScaled(Point pos, CDrawer dr)
        {
            if (Running) return;

            // Reset hit counts before shooting
            balls.ForEach(b => b.ResetHits());

            // Calculate direction vector for cue ball shot
            Vector2 direction = Vector2.Normalize(_positionMouse - _cueBall.Center) * 40f;
            _cueBall.SetVelocity(direction);
        }

        private void _CDrawer_MouseMoveScaled(Point pos, CDrawer dr)
        {
            _positionMouse = new Vector2(pos.X, pos.Y);

            // Only show table with aim line if simulation is not running
            if (!Running)
            {
                ShowTable();
            }
        }
    }
}
