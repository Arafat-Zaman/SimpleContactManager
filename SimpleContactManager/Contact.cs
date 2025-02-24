﻿using System;

namespace SimpleContactManager
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}, {Email}, {Phone}";
        }
    }
}
