namespace Kader_System.Domain.DTOs.Response.Shared;

public class SharGetServiceResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string TitleInEnglish { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public string? HtmlBody { get; set; }
    public int ServicesCategoryId { get; set; }
    public string InsertDate { get; set; } = string.Empty;
}
