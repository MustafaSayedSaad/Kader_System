namespace Kader_System.Domain.Dtos.Request.Shared;

public class SharCreateServiceRequest
{
    public required string Title { get; set; }
    public required string TitleInEnglish { get; set; }
    public required string Description { get; set; }
    public string? HtmlBody { get; set; }

    [AllowedLetters(FileSettings.SpecialChar), MaxFileLettersCount(FileSettings.Length)]
    public required IFormFile ImagePath { get; set; }
    public int ServicesCategoryyId { get; set; }
}
