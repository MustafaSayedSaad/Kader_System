namespace Kader_System.Domain.Dtos.Request.Shared;

public class SharEditServiceRequest
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string TitleInEnglish { get; set; }
    public required string Description { get; set; }

    [AllowedLetters(FileSettings.SpecialChar), MaxFileLettersCount(FileSettings.Length)]
    public IFormFile? ImagePath { get; set; }
    public int ServicesCategoryyId { get; set; }
}
