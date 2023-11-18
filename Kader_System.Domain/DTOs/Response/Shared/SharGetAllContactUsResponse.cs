namespace Kader_System.Domain.DTOs.Response.Shared;

public class SharGetAllContactUsResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
}
