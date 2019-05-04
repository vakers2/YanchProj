using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class Post
    {
        public int PostId { get; set; }

        public int OwnerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public User Owner { get; set; }
    }
}
