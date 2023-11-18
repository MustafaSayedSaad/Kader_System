﻿namespace Kader_System.Domain.Dtos.Request.Shared;

public class SharCreateContactUsRequest
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Description { get; set; }
    public required string Mobile { get; set; }
}
