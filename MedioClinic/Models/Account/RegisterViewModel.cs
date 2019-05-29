﻿using System.ComponentModel.DataAnnotations;

namespace MedioClinic.Models.Account
{
    public class RegisterViewModel : IViewModel
    {
        [Required]
        [Display(Name = "general.firstname")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "general.lastname")]
        public string LastName { get; set; }

        public EmailViewModel EmailViewModel { get; set; }

        public PasswordConfirmationViewModel PasswordConfirmationViewModel { get; set; }
    }
}