namespace Kader_System.Domain.DTOs.Response.Shared;

public class SharGetNewsResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public string TitleInEnglish { get; set; } = string.Empty;

    public string TitleMeta { get; set; } = string.Empty;

    public string TitleMetaInEnglish { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public string? HtmlBody { get; set; }

    public string ImagePath { get; set; } = string.Empty;
    public string ImageExtension { get; set; } = string.Empty;
    public string VideoPath { get; set; } = string.Empty;
    public string VideoExtension { get; set; } = string.Empty;

    public string InsertDate { get; set; } = string.Empty;
}
