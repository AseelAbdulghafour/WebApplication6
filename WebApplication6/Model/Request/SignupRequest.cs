﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Model.Request
{
    public class SignupRequest
    { 
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
      
    }
}
