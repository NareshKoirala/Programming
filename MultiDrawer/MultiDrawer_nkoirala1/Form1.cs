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
using ConnectDlg_nkoirala1;
using Newtonsoft;
using MultiDraw2022;
using AbSoc;
using System.Net.Sockets;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace MultiDrawer_nkoirala1
{
    // Main form class for the Multi Drawer application
    public partial class Form1 : Form
    {
        // Flag to toggle between connect and disconnect states
        private bool _connBTN = true;
        // Current thickness of the drawing line
        private int _thickness = 1;
        // Current color of the drawing line
        private Color _color = Color.Red;

        // Instance of AbSoc_dlg for socket communication
        private AbSoc_dlg _absoc;
        // Socket for network communication
        private Socket _socket;
        // Instance of Form2 for logging messages
        private Form2 _log;

        // List to store drawn line segments
        private List<LineSegment> _lines = new List<LineSegment>();
        // Tracks the last mouse position during drawing
        private Point? _lastPoint = null;

        // Graphics object for rendering on the form
        private Graphics gg;

        // Constructor for Form1
        public Form1()
        {
            // Initialize the form's components
            InitializeComponent();

            // Test: Print the length of the string "100" to the console
            Console.WriteLine(100.ToString().Length);

            // Set up the UI elements
            UI();

            // Attach event handlers for UI interactions
            label1.Click += ConnectionDialog; // Handle connect/disconnect
            label2.Click += ColorDialog; // Open color selection dialog
            label3.MouseWheel += ThicknessWheel; // Adjust thickness with mouse wheel
            label8.Click += ClearScreen; // Clear the drawing area

            // Attach mouse event handlers for drawing
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
        }

        // Event handler to clear the drawing area
        private void ClearScreen(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Normal;
        }

        // Event handler for mouse up event to stop drawing
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // Reset the last point to stop drawing
            _lastPoint = null;
        }

        // Event handler for mouse move event to draw lines
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Check if drawing is active (last point exists) and socket is connected
            if (_lastPoint.HasValue && _absoc != null)
            {
                // Create a new line segment from the last point to the current mouse position
                var line = new LineSegment
                {
                    SX = (short)_lastPoint.Value.X, // Start X coordinate
                    SY = (short)_lastPoint.Value.Y, // Start Y coordinate
                    EX = (short)e.Location.X, // End X coordinate
                    EY = (short)e.Location.Y, // End Y coordinate
                    T = (byte)_thickness, // Thickness of the line
                    C = _color // Color of the line
                };

                // Convert the line segment to JSON format
                string json = line.LineSegmentToJSON();

                // Check if JSON serialization was successful
                if (!string.IsNullOrEmpty(json))
                {
                    // Send the JSON data over the socket
                    _absoc.Send(json);
                    // Uncomment to log the sent line segment
                    //LogMessage($"Form1_MouseMove - Sent LineSegment: {json}");
                }
                else
                {
                    // Log an error if JSON serialization failed
                    LogMessage("Form1_MouseMove - Failed to serialize LineSegment to JSON");
                }

                // Update the last point to the current mouse position
                _lastPoint = e.Location;
            }
        }

        // Event handler for mouse down event to start drawing
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // Start drawing if the left mouse button is pressed and socket is connected
            if (e.Button == MouseButtons.Left && _absoc != null)
            {
                // Set the last point to the current mouse position to begin drawing
                _lastPoint = e.Location;
            }
        }

        // Event handler for mouse wheel event to adjust line thickness
        private void ThicknessWheel(object sender, MouseEventArgs e)
        {
            // Increase or decrease thickness based on mouse wheel direction
            _thickness += e.Delta > 0 ? +1 : -1;

            // Clamp thickness between 1 and 100
            _thickness = _thickness > 100 ? 100 : _thickness;
            _thickness = _thickness < 1 ? 1 : _thickness;

            // Update the thickness label on the UI
            label3.Text = $"Thickness: {_thickness}";
        }

        // Event handler to open a color selection dialog
        private void ColorDialog(object sender, EventArgs e)
        {
            // Create and show a color dialog
            using (var dlg = new ColorDialog())
            {
                // Check if the user selected a color
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Validate the selected color (not white)
                    if (dlg.Color != Color.White)
                        _color = dlg.Color; // Update the drawing color
                    else
                        LogMessage($"ColorDialog - Invalid Color Selected: {dlg.Color}");

                    // Log the selected color
                    LogMessage($"ColorDialog - Color Selected: {_color}");
                }
                else
                {
                    // Log if the dialog was cancelled
                    LogMessage("ColorDialog - Dialog Cancelled");
                }
            }

            // Update the color label's foreground color to the selected color
            label2.ForeColor = _color;
        }

        // Method to set up the UI elements of the form
        public void UI()
        {
            // Set the form's title
            this.Text = "Multi Drawer - Naresh Koirala";
            // Set the form's background color to white
            this.BackColor = Color.White;
            // Enable double buffering to reduce flicker
            this.DoubleBuffered = true;

            // Set initial text for UI labels
            label2.Text = "Colour";
            label3.Text = $"Thickness: {_thickness}";
            label8.Text = "Clear Screen";

            // Configure the group box appearance
            groupBox1.Text = "";
            groupBox1.BackColor = Color.DarkGray;

            // Set background color for all labels to white
            label1.BackColor = Color.White;
            label2.BackColor = Color.White;
            label3.BackColor = Color.White;
            label4.BackColor = Color.White;
            label5.BackColor = Color.White;
            label6.BackColor = Color.White;
            label7.BackColor = Color.White;
            label8.BackColor = Color.White;

            // Set the initial foreground color of the color label
            label2.ForeColor = _color;

            // Update the statistics display
            UpdateStats();

            // Start Form2 (log window) in a separate thread
            Task.Run(() =>
            {
                _log = new Form2();
                Application.Run(_log);
            });
        }

        // Method to log messages to Form2
        private void LogMessage(string message)
        {
            // Check if the log form exists and its handle is created
            if (_log != null && _log.IsHandleCreated)
            {
                // Invoke the log method on the UI thread
                _log.Invoke((MethodInvoker)delegate
                {
                    _log.Log(message);
                });
            }
        }

        // Event handler for the connect/disconnect button
        private void ConnectionDialog(object sender, EventArgs e)
        {
            // Check if in connect mode
            if (_connBTN)
            {
                // Open the connection dialog with default IP and port
                using (var dlg = new ConnectDlg("10.132.8.144", 1667))
                {
                    // Show the dialog and check if the user clicked OK
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        // Get the connected socket from the dialog
                        _socket = dlg.ConnectedSocket;

                        // Validate the socket connection
                        if (_socket == null || !_socket.Connected)
                        {
                            LogMessage("ConnectionDialog - Socket Not Connected");
                            return;
                        }

                        // Log successful connection
                        LogMessage("ConnectionDialog - Socket Connected");

                        try
                        {
                            // Initialize the AbSoc_dlg instance for socket communication
                            _absoc = new AbSoc_dlg(_socket, OnDataReceived, OnError);

                            // Log successful AbSoc initialization
                            LogMessage("ConnectionDialog - AbSoc Connected");
                        }
                        catch (ArgumentNullException ex)
                        {
                            // Log any argument null exceptions during AbSoc initialization
                            LogMessage("ConnectionDialog - AbSoc -" + ex.Message);
                        }

                        // Toggle the connect button state to disconnect mode
                        _connBTN = !_connBTN;

                        // Update the UI statistics
                        UpdateStats();
                    }
                    else
                    {
                        // Log if the dialog was cancelled
                        LogMessage("ConnectionDialog - Dialog Cancelled");
                    }
                }
            }
            else
            {
                // Disconnect the socket if in disconnect mode
                SocketDie();
                LogMessage("ConnectionDialog - Socket Disconnected");
            }
        }

        // Callback method to handle received JSON data (line segments)
        private void OnDataReceived(List<string> ls_json)
        {
            // Process each JSON string in the received list
            foreach (var json in ls_json)
            {
                // Create a graphics object for rendering
                gg = this.CreateGraphics();

                try
                {
                    // Deserialize the JSON into a LineSegment object
                    var line = LineSegment.JSONToLineSegment(json);

                    // Check if deserialization was successful
                    if (line != null)
                    {
                        // Render the line segment on the form
                        line.Render(gg);
                        // Update the UI statistics
                        UpdateStats();
                    }
                    else
                    {
                        // Log an error if deserialization failed
                        LogMessage($"OnDataReceived - Failed to deserialize or validate LineSegment: {json}");
                    }
                }
                catch (Exception ex)
                {
                    // Log any errors during JSON processing
                    LogMessage($"Error processing JSON: {ex.Message}");
                }
            }
        }

        // Callback method to handle socket errors
        private void OnError(Exception ex)
        {
            // Log the socket error
            LogMessage($"Socket Error: {ex.Message}");
            // Invoke the SocketDie method on the UI thread to disconnect
            this.Invoke(new Action(() =>
            {
                SocketDie();
            }));
        }

        // Method to update the UI statistics labels
        private void UpdateStats()
        {
            // Check if invocation is required (thread safety)
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateStats));
                return;
            }

            // Update statistics if AbSoc is connected
            if (_absoc != null)
            {
                // Display the number of frames received
                label4.Text = $"Frames RX: {_absoc.FramesReceived}";
                // Display the number of fragmentation events
                label5.Text = $"Frag: {_absoc.FragmentationEvents}";
                // Display the average frames per receive event
                label6.Text = $"Destach AVG: {_absoc.AverageFramesDestacked:F2}";
                // Display the total bytes received
                label7.Text = $"Byte RX: {_absoc.TotalBytesReceived}";

                // Uncomment to log the total bytes received
                //LogMessage(_absoc._totalBytesReceived.ToString());
            }
            else
            {
                // Reset statistics if not connected
                label4.Text = $"Frames RX: {0}";
                label5.Text = $"Frag: {0}";
                label6.Text = $"Destach AVG: {0:F2}";
                label7.Text = $"Byte RX: {0}";
            }

            // Update the connect/disconnect button text
            if (_connBTN) label1.Text = "Connect";
            else label1.Text = "Disconnect";
        }

        /// <summary>
        /// Method to disconnect and clean up the socket connection
        /// </summary>
        public void SocketDie()
        {
            // Ensure the method runs on the UI thread
            if (InvokeRequired) Invoke(new Action(SocketDie));

            try
            {
                // Shut down the socket for both sending and receiving
                _socket?.Shutdown(SocketShutdown.Both);
                // Close the socket
                _socket?.Close();
                // Shut down the AbSoc instance
                _absoc?.SocketDie();
            }
            catch { }

            // Reset the socket and AbSoc instances
            _socket = null;
            _absoc = null;

            // Toggle the connect button state back to connect mode
            _connBTN = !_connBTN;

            // Update the UI statistics
            UpdateStats();
        }
    }
}