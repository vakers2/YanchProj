﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;

namespace Models.ViewModels
{
    public class UpdateUserStatusViewModel
    {
        public string UserId { get; set; }

        public UserStatus Status { get; set; }
    }
}
