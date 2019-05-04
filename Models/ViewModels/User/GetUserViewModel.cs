using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;

namespace Models.ViewModels
{
    public class GetUserViewModel
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public UserStatus Status { get; set; }
    }
}
