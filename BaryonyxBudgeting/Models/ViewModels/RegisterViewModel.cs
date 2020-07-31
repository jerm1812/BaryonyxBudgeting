﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BaryonyxBudgeting.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter a username"), Display(Name = "Username"), MaxLength(30)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your email address"), Display(Name = "Email"), EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password"), Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password"), Display(Name = "Confirm Password"), DataType(DataType.Password), Compare("Password", ErrorMessage = "Your passwords do not match")]
        public string ConfirmPassword { get; set; }

        public DateTime RegisterDate { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}