﻿namespace Kader_System.Domain.Models.Shared;

[Table("Shar_ContactUs")]
public class SharContactUs : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
}
