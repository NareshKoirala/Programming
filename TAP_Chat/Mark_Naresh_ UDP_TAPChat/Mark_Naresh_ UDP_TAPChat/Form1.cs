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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Mark_Naresh__UDP_TAPChat
{
    public partial class Form1 : Form
    {
        private UPDManager updManager;
        public Form1()
        {
            InitializeComponent();

            updManager = new UPDManager();

            this.Text = "TAP-Chat 1.1";
            UI_addtargetBTN.Text = "Add Target";
            UI_sendBTN.Text = "Send";
            UI_messageLBL.Text = "Chat Text: ";
            UI_targetaddrLBL.Text = "Target Address: ";
            UI_knowaddrLBL.Text = "Known Hosts: ";
            UI_nicknameLBL.Text = "Nickname: ";
            UI_consoleErrorLBL.Text = "";
            UI_deleteKnowIpBTN.Text = "Delete";

            UpdateLSBOXIPs();

            UI_addtargetBTN.Click += UI_addtargetBTN_Click;
            UI_sendBTN.Click += UI_sendBTN_Click;
            UI_deleteKnowIpBTN.Click += UI_deleteKnowIpBTN_Click;


            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Had to put in form load event since it gets mad when Invoke happens
            Task.Run(Recieve);
        }

        /// <summary>
        /// Recieves messages from other users within the same port and shows it to the current user
        /// </summary>
        private async void Recieve()
        {
            //List that will contain all messages recieved
            List<ChatMessageStruc> messages = new List<ChatMessageStruc>();
            while (true)
            {
                //Get the message
                var msg = await updManager.RecieveMessage();

                if(msg == null)
                {
                    Invoke(new Action(() => { UpdateErrorLBL("Invalid JSON recieved"); }));
                    continue;
                }

                messages.Add(msg);

                //Reset the datagrid and update, update known ip's as well
                Invoke(new Action(() => { 
                    UI_messageboxDATAGRID.DataSource = null;
                    UI_messageboxDATAGRID.DataSource = messages.OrderByDescending(x => x.Message).ToList();
                    UI_messageboxDATAGRID.Columns["Message"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    UpdateLSBOXIPs();
                }));
            }
        }

        private void UI_deleteKnowIpBTN_Click(object sender, EventArgs e)
        {
            foreach (var item in UI_knowipLSBOX.SelectedItems)
            {
                var split = item.ToString().Split(':');
                if (split[0].Trim() != updManager._userIP)
                    updManager.UpdateKnownIP(split[0].Trim(), "Deleted", false);
                else
                    UpdateErrorLBL($"IP: {split[0]} - deleteClickBTN - Admin/Main user cant be deleted");
            }

            UpdateLSBOXIPs();
        }

        /// <summary>
        /// Update the ErrorLBL with error message
        /// </summary>
        /// <param name="error"></param>
        public void UpdateErrorLBL(string error) => UI_consoleErrorLBL.Text = error;
             
        private void UI_addtargetBTN_Click(object sender, EventArgs e)
        {
            IPAddress.TryParse(UI_targetedIPTXTBOX.Text.Trim(), out IPAddress ips);
                
            if (string.IsNullOrEmpty("" + ips))
            {
                UpdateErrorLBL($"User : {UI_targetedIPTXTBOX.Text.Trim()} - BTNCLick - Empty/Invalid ip given");
                return;
            }

            updManager.UpdateKnownIP("" + ips, "家务", true);
            UpdateLSBOXIPs();
        }

        /// <summary>
        /// Updates the UI_knownipLSBOX with new known IP Address'
        /// </summary>
        private void UpdateLSBOXIPs()
        {
            UI_knowipLSBOX.Items.Clear();

            foreach (var item in updManager.KnowIPs)
            {
                //if(updManager.KnowIPs.Keys.Select(x => x == "家务"))`

                UI_knowipLSBOX.Items.Add(item.Key + " : " + item.Value);
            }
        }

        private async void UI_sendBTN_Click(object sender, EventArgs e)
        {
            string message = UI_messageTXTBOX.Text.Trim();
            string nickname = UI_nicknameTXTBOX.Text.Trim();

            //Probably wanna try letting localhost through aswell? Have to check with herb
            if(!IPAddress.TryParse(UI_targetedIPTXTBOX.Text.Trim(), out IPAddress ips))
                if(UI_targetedIPTXTBOX.Text.Trim().Length > 0)
                    UpdateErrorLBL($"IP: {UI_targetedIPTXTBOX.Text.Trim()} - sendBTNCLick - Invalid IP given");

            List<string> targetedIP = new List<string>();

            if (string.IsNullOrEmpty(message))
            {
                UpdateErrorLBL($"Message - sendBTNCLick - Empty message given");
                return;
            }

            foreach (var item in UI_knowipLSBOX.SelectedItems)
            {
                targetedIP.Add((string)item);
            }

            if (!string.IsNullOrEmpty("" + ips) && !targetedIP.Contains(ips.ToString()))
                targetedIP.Add("" + ips);


            await updManager.SendMessage(nickname, message, targetedIP);

            UI_targetedIPTXTBOX.Text = string.Empty;
            UI_messageTXTBOX.Text = string.Empty;
            UpdateLSBOXIPs();

        }

    }
}
