﻿namespace AcademyAPI.Data.Models.Auth;

public class RegisterUser
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
