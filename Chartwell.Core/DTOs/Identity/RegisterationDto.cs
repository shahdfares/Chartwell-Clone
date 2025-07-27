﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.Identity
{
    public class RegisterationDto
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "PhoneNumber is Required")]
        [DataType(DataType.Password)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "DisplayName is Required")]
        public string DisplayName { get; set; }
    }
}
