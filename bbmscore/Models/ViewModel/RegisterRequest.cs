﻿namespace bbmscore.Models.ViewModel
{
    public class RegisterRequest
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
