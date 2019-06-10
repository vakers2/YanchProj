using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class Post
    {
        [Key]
        public string PostId { get; set; }

        public string OwnerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public User Owner { get; set; }
    }
}
