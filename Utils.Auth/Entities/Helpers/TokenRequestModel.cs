﻿using System.ComponentModel.DataAnnotations;

namespace Utils.Auth.Entities.Helpers
{
    public class TokenRequestModel
    {
        [Required, MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
    }
}
