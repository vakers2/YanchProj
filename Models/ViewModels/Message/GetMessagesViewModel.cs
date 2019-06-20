using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Message
{
    public class GetMessagesViewModel
    {
        public string Text { get; set; }

        public DateTime CreationTime { get; set; }

        public string UserName { get; set; }
    }
}
