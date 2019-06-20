using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class UserChat
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Chat Chat { get; set; }
    }
}
