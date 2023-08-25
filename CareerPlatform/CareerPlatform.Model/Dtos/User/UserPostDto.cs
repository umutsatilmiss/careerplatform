﻿using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.User
{
    public class UserPostDto:IDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
        public string? CV { get; set; }
    }
}
