using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Post
{
    public class GetPostViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public string Owner { get; set; }
    }
}
