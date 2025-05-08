/*=======================================================================================
* Program: TapChat
* Description: Sends and Recieves messages that are in the same port, Stores the known ip addresses aswell
* Author: Mark Tangon & Naresh
* Course: CMPE2800
* Class: A03
*=======================================================================================
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mark_Naresh__UDP_TAPChat
{
    internal class UPDManager
    {
        private UdpClient _sendClient;
        private readonly int _port = 1666;
        public readonly string _userIP = "localhost"; //Could probably also use localhost here instead?`
        private Dictionary<string, string> _knowIPs = new Dictionary<string, string>();
        private readonly string _defaultNickname = "家务";

        public Dictionary<string,string> KnowIPs => _knowIPs; 

        public UPDManager()
        {
            //_sendClient = new UdpClient();
            _sendClient = new UdpClient(_port); //changed: Placed the 'listening port'
        }

        /// <summary>
        /// Update the known IP's 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="nickname"></param>
        /// <param name="addRemove"></param>
        public void UpdateKnownIP(string ip, string nickname, bool addRemove)
        {
            if (string.IsNullOrEmpty(nickname))
                nickname = _defaultNickname;

            if (addRemove)
            {
                if (!_knowIPs.ContainsKey(ip))
                    _knowIPs.Add(ip, nickname);
                else
                    _knowIPs[ip] = nickname;
            }
            else
                _knowIPs.Remove(ip);

        }

        /// <summary>
        /// Sends the message given by user along with the nickname to the selected/all known IP's in the local port
        /// </summary>
        /// <param name="nickname"></param>
        /// <param name="message"></param>
        /// <param name="targetIP"></param>
        /// <returns></returns>
        public async Task SendMessage(string nickname, string message, List<string> targetIP)
        {
            var chatMessage = new ChatMessageStruc { Nickname = nickname, Message = message };
            string jsonMessage = JsonSerializer.Serialize(chatMessage);
            byte[] data = Encoding.UTF8.GetBytes(jsonMessage);


            await _sendClient.SendAsync(data, data.Length, _userIP, _port);

            if (targetIP.Count == 0) //Check if sending to all targets
            {
                //Iterate through all known IP's
                foreach (string ip in _knowIPs.Keys)
                {
                    await _sendClient.SendAsync(data, data.Length, ip, _port);
                }
            }
            //Else send to selected target/s
            else 
            {
                foreach (string ip in targetIP)
                {
                    if (!_knowIPs.ContainsKey(ip.Split(':')[0].Trim()) && ip.Split(':')[0].Trim() != _userIP)
                        UpdateKnownIP(ip, _defaultNickname, true);

                    await _sendClient.SendAsync(data, data.Length, ip.Split(':')[0].Trim(), _port);
                }
            }
        }

        /// <summary>
        /// Recieves messages from other users that would be in the same port. Updates the known ports as well
        /// </summary>
        /// <returns>ChatMessageStruc</returns>
        public async Task<ChatMessageStruc> RecieveMessage()
        {
            //Get the data from UDP
            UdpReceiveResult result = await _sendClient.ReceiveAsync();

            //Unpack the data and turn it into bytes
            byte[] recievedData = result.Buffer;

            //Take the senders data (IP address and port)
            IPEndPoint endPoint = result.RemoteEndPoint; 

            //Take bytes and convert into utf8 string
            string byteMessage = Encoding.UTF8.GetString(recievedData);

            try
            {
                //Take the utf8 string and convert it into a json and then convert it into the ChatMessageStruc class
                var jsonMessage = JsonSerializer.Deserialize<ChatMessageStruc>(byteMessage);

                //Check if the IP address is of local address
                if(!(endPoint.Address.ToString() == "127.0.0.1"))
                    //Update all known IPs
                    UpdateKnownIP(endPoint.Address.ToString(), jsonMessage.Nickname, true);

                jsonMessage.Message = $"({DateTime.Now}) : {jsonMessage.Message}";

                //Return the JSON message as the class made
                return jsonMessage;
            }
            catch (Exception e)
            {

                Trace.WriteLine(e);
                return null;
            }


        }

    }
}
