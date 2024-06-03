﻿namespace EcommerceWeb.Mvc.Models.Authentication
{
    public class RegisterRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? NumberPhone { get; set; }
        public string? Address { get; set; }
    }
}
