using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Chat
    {
        public string Id { get; set; }

        public List<UserChat> UserChats { get; set; }

        public List<Message> Messages { get; set; }
    }
}
