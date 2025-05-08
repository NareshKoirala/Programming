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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mark_Naresh__UDP_TAPChat
{
    internal class ChatMessageStruc
    {
        public string Nickname { get; set; }
        public string Message { get; set; }
    }
}
