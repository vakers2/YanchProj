using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Message
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public DateTime CreationTime { get; set; }

        public User Sender { get; set; }
    }
}
