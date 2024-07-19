﻿using System.ComponentModel.DataAnnotations;

namespace MusicLibraryApp.Models.AccountPage
{
    public class loginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}