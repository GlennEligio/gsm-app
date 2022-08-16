using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    class Message
    { 
        public string Sender { get; set; }
        public string Content { get; set; }

        public Message(string sender, string content) { this.Sender = sender; this.Content = content; }

        override
        public string ToString()
        {
            return this.Sender + ": " + this.Content;
        }
    }
}
