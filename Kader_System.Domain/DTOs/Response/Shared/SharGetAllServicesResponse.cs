namespace Kader_System.Domain.DTOs.Response.Shared;

public class SharGetAllServicesResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public string ImageExtension { get; set; } = string.Empty;
    public int ServicesCategoryId { get; set; }
    public string? HtmlBody { get; set; }
    public string InsertBy { get; set; } = string.Empty;

}
