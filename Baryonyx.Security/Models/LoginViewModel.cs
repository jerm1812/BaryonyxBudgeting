﻿using System.ComponentModel.DataAnnotations;

namespace BaryonyxBudgeting.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter your username"), Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your password"), Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}