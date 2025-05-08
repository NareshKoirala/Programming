// Naresh Pd. Koirala
// Multi_Drawer_A03
// 2025-04-06
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AbSoc
{
    // Class to manage asynchronous socket communication with JSON data handling
    public class AbSoc_dlg
    {
        // Private readonly socket instance for network communication
        private readonly Socket _socket;

        // Callback to handle received data as a list of strings (JSON messages)
        private readonly Action<List<string>> _dataCallback;
        // Callback to handle errors by passing exceptions
        private readonly Action<Exception> _errorCallback;

        // Thread-safe queue for messages to be sent
        private readonly ConcurrentQueue<string> _sendQueue = new ConcurrentQueue<string>();
        // Thread-safe queue for received JSON messages
        private readonly ConcurrentQueue<string> _receiveQueue = new ConcurrentQueue<string>();

        // Counter for total bytes received over the socket
        private int _totalBytesReceived = 0;
        // Counter for total frames (complete JSON messages) received
        private int _framesReceived = 0;
        // Counter for fragmentation events (incomplete JSON messages)
        private int _fragmentationEvents = 0;
        // Counter for total receive events (socket receive calls)
        private int _totalReceiveEvents = 0;

        // Method to convert a numeric string into a human-readable format with SI prefixes
        private string si_unit(string value)
        {
            // List of SI prefixes in ascending order: deca, hecto, kilo, mega, giga, tera, peta, exa
            List<string> list = new List<string>() { "da", "h", "k", "M", "G", "T", "P", "E" };
            // Parse the input string into a double to handle large numbers
            double.TryParse(value, out double v);

            // Return "0" if the value is zero or parsing fails
            if (v == 0) return "0"; // Handle zero or invalid input

            // Find the appropriate SI prefix by comparing the magnitude
            // Calculate the exponent (order of magnitude) of the number
            int exponent = (int)Math.Floor(Math.Log10(v)); // Get the order of magnitude
            int prefixIndex = -1; // Index for selecting the SI prefix
            string prefix = ""; // The SI prefix to be used
            double divisor = 1; // Divisor to scale the value

            // Map the exponent to the correct SI prefix and divisor
            if (exponent >= 18) { prefixIndex = 7; divisor = Math.Pow(10.24, 18); } // E (exa)
            else if (exponent >= 15) { prefixIndex = 6; divisor = Math.Pow(10.24, 15); } // P (peta)
            else if (exponent >= 12) { prefixIndex = 5; divisor = Math.Pow(10.24, 12); } // T (tera)
            else if (exponent >= 9) { prefixIndex = 4; divisor = Math.Pow(10.24, 9); } // G (giga)
            else if (exponent >= 6) { prefixIndex = 3; divisor = Math.Pow(10.24, 6); } // M (mega)
            else if (exponent >= 3) { prefixIndex = 2; divisor = Math.Pow(10.24, 3); } // k (kilo)
            else if (exponent >= 2) { prefixIndex = 1; divisor = Math.Pow(10.24, 2); } // h (hecto)
            else if (exponent >= 1) { prefixIndex = 0; divisor = Math.Pow(10.24, 1); } // da (deca)
            else return v.ToString(); // No prefix needed for small numbers

            // Assign the selected prefix from the list
            prefix = list[prefixIndex];
            // Scale the value by dividing by the divisor
            double scaledValue = v / divisor;

            // Format the scaled value with 2 decimal places and append the prefix
            return $"{scaledValue:F2} {prefix}";
        }

        // Property to get total bytes received, formatted with SI units
        public string TotalBytesReceived => si_unit(_totalBytesReceived.ToString()) /*_totalBytesReceived.ToString()*/;
        // Property to get total frames received, formatted with SI units
        public string FramesReceived => si_unit(_framesReceived.ToString());
        // Property to get total fragmentation events as a string
        public string FragmentationEvents => _fragmentationEvents.ToString();
        // Property to calculate and return the average frames per receive event, formatted to 2 decimal places
        public string AverageFramesDestacked => $"{(_totalReceiveEvents > 0 ? (double)_framesReceived / _totalReceiveEvents : 0):f2}";

        // Flag to control the running state of the socket threads
        private bool _isRunnig = true;

        /// <summary>
        /// Constructor for AbSoc_dlg class to initialize the socket and start background threads
        /// </summary>
        /// <param name="connectedSocket">The connected socket for communication</param>
        /// <param name="dataCallback">Callback to handle received JSON data</param>
        /// <param name="errorCallback">Callback to handle errors</param>
        /// <exception cref="ArgumentNullException">Thrown if any parameter is null</exception>
        public AbSoc_dlg(Socket connectedSocket, Action<List<string>> dataCallback, Action<Exception> errorCallback)
        {
            // Assign the socket and callback delegates
            _socket = connectedSocket;
            _dataCallback = dataCallback;
            _errorCallback = errorCallback;

            // Start background threads for receiving, sending, and processing data
            new Thread(ReceiveThread) { IsBackground = true }.Start();
            new Thread(SendThread) { IsBackground = true }.Start();
            new Thread(ProcessThread) { IsBackground = true }.Start();
        }

        /// <summary>
        /// Thread method to handle receiving data from the socket
        /// </summary>
        private void ReceiveThread()
        {
            // Buffer to store incoming data (1 KB)
            byte[] buffer = new byte[1024];
            // String to accumulate received data
            string data = "";

            // Continue running while the socket is active
            while (_isRunnig)
            {
                try
                {
                    // Receive data from the socket into the buffer
                    int bytesRecieved = _socket.Receive(buffer);
                    // Increment the total receive events counter
                    _totalReceiveEvents++;

                    // Check if the connection was closed (0 bytes received)
                    if (bytesRecieved == 0)
                    {
                        // Notify the error callback about disconnection
                        _errorCallback(new Exception("Server Disconnected"));
                        // Shut down the socket
                        SocketDie();
                    }
                    else
                    {
                        // Add the number of bytes received to the total
                        _totalBytesReceived += bytesRecieved;

                        // Convert the received bytes to a UTF-8 string and append to the data
                        data += Encoding.UTF8.GetString(buffer, 0, bytesRecieved);

                        // Sanity check: ensure the data doesn't exceed 1025 characters
                        if (data.Length > 1025)
                        {
                            // Notify the error callback if the buffer limit is exceeded
                            _errorCallback(new Exception("Receive buffer exceeded 1025 characters."));
                            return;
                        }

                        // Process the received data to extract JSON items
                        data = ProcessJSONItems(data);

                        // Increment fragmentation events if there's remaining unprocessed data
                        if (data.Length != 0)
                            _fragmentationEvents++;
                    }
                }
                catch (SocketException e)
                {
                    // Handle socket exceptions and notify the error callback if still running
                    if (_isRunnig) _errorCallback(e);
                    // Shut down the socket
                    SocketDie();
                }
                catch (Exception e)
                {
                    // Handle other exceptions and notify the error callback if still running
                    if (_isRunnig) _errorCallback(e);
                    // Shut down the socket
                    SocketDie();
                }
                // Yield the thread to avoid excessive CPU usage
                Thread.Sleep(0);
            }
        }

        /// <summary>
        /// Method to process received data and extract complete JSON items
        /// </summary>
        /// <param name="_content">The raw data received from the socket</param>
        /// <returns>The remaining unprocessed data</returns>
        public string ProcessJSONItems(string _content)
        {
            // Counter to track nested braces in JSON
            int _braceCount = 0;
            // Index to mark the start of a JSON item
            int _start = 0;

            // Iterate through each character in the content
            for (int index = 0; index < _content.Length; index++)
            {
                char c = _content[index];

                // Increment brace count for opening braces
                if (c == '{') _braceCount++;
                // Decrement brace count for closing braces
                else if (c == '}') _braceCount--;

                // Check if a complete JSON item is found (brace count is 0 and closing brace is encountered)
                if (_braceCount == 0 && c == '}')
                {
                    // Extract the JSON string from the start index to the current index
                    string json = _content.Substring(_start, index - _start + 1);
                    // Add the JSON string to the receive queue
                    _receiveQueue.Enqueue(json);
                    // Increment the frames received counter
                    _framesReceived++;
                    // Update the start index for the next JSON item
                    _start = index + 1;
                }
            }
            // Remove processed data from the content if any JSON items were found
            if (_start > 0)
            {
                _content = _content.Remove(0, _start);
            }
            // Return the remaining unprocessed data
            return _content;
        }

        /// <summary>
        /// Thread method to handle sending data over the socket
        /// </summary>
        private void SendThread()
        {
            // Continue running while the socket is active
            while (_isRunnig)
            {
                // Attempt to dequeue a message from the send queue
                if (_sendQueue.TryDequeue(out string json))
                {
                    try
                    {
                        // Convert the JSON string to UTF-8 bytes
                        byte[] data = Encoding.UTF8.GetBytes(json);
                        // Send the data over the socket
                        _socket.Send(data, data.Length, SocketFlags.None);
                    }
                    catch (SocketException e)
                    {
                        // Handle socket exceptions and notify the error callback if still running
                        if (_isRunnig) _errorCallback(e);
                        // Shut down the socket
                        SocketDie();
                    }
                    catch (Exception e)
                    {
                        // Handle other exceptions and notify the error callback if still running
                        if (_isRunnig) _errorCallback(e);
                        // Shut down the socket
                        SocketDie();
                    }
                }
                // Yield the thread to avoid excessive CPU usage
                Thread.Sleep(0);
            }
        }

        /// <summary>
        /// Thread method to process received JSON messages and invoke the data callback
        /// </summary>
        private void ProcessThread()
        {
            // Continue running while the socket is active
            while (_isRunnig)
            {
                // List to store dequeued JSON messages
                List<string> ls_json = new List<string>();

                // Dequeue all available JSON messages from the receive queue
                while (_receiveQueue.TryDequeue(out string json))
                {
                    ls_json.Add(json);
                }

                // Invoke the data callback with the list of JSON messages
                _dataCallback(ls_json);

                // Yield the thread to avoid excessive CPU usage
                Thread.Sleep(0);
            }
        }

        /// <summary>
        /// Method to send a message over the socket by adding it to the send queue
        /// </summary>
        /// <param name="msg">The message to send</param>
        /// <exception cref="InvalidOperationException">Thrown if the socket is not running</exception>
        public void Send(string msg)
        {
            // Check if the socket is running before sending
            if (!_isRunnig) throw new InvalidOperationException("Socket is not Runnig");
            // Add the message to the send queue
            _sendQueue.Enqueue(msg);
        }

        /// <summary>
        /// Method to shut down and close the socket
        /// </summary>
        public void SocketDie()
        {
            // Set the running flag to false to stop all threads
            _isRunnig = false;

            try
            {
                // Attempt to shut down the socket for both sending and receiving
                _socket.Shutdown(SocketShutdown.Both);
                // Close the socket
                _socket.Close();
            }
            catch (Exception e)
            {
                // Notify the error callback if an exception occurs during shutdown
                _errorCallback(e);
            }
        }
    }
}