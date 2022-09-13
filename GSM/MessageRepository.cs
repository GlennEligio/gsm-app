using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSM.ADO.NETModels;

namespace GSM
{
    class MessageRepository
    {
        private ezeEntities context;
        private static MessageRepository instance = null;

        private MessageRepository()
        {
            context = new ezeEntities();
        }

        public static MessageRepository getInstance()
        {
            if(instance == null)
            {
                instance = new MessageRepository();
            }
            return instance;
        }

        public List<Message> getMessages()
        {
            List<Message> messages = context.Messages.ToList();
            return messages;
        }

        public List<Message> getMessagesOrderByDateReceivedDescending()
        {
            List<Message> messages = context.Messages.OrderByDescending(m => m.DateReceived).ToList();
            return messages;
        }

        public void addMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
        }
    }
}
