namespace Kader_System.Domain.DTOs.Response.Shared;

public class SharGetAboutUsResponse
{
    public int Id { get; set; }
    public string WhoAreWe { get; set; } = string.Empty;
    public string WhoAreWeInEnglish { get; set; } = string.Empty;

    public string OurVision { get; set; } = string.Empty;
    public string OurVisionInEnglish { get; set; } = string.Empty;

    public string Details { get; set; } = string.Empty;
    public string DetailsInEnglish { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;
}
