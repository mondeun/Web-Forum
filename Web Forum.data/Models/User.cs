﻿using System;

namespace Web_Forum.data.Models
{
    public sealed class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsModerator { get; set; }
    }
}
