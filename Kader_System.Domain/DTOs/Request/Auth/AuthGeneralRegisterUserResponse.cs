﻿namespace Kader_System.Domain.Dtos.Response.Auth;

public class AuthGeneralRegisterUserResponse
{
    public string Id { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; } 
}
