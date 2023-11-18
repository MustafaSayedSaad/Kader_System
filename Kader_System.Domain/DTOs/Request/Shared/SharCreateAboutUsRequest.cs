namespace Kader_System.Domain.Dtos.Request.Shared;

public class SharCreateAboutUsRequest
{
    [Required]
    public string WhoAreWe { get; set; } = string.Empty;
    [Required]
    public string WhoAreWeInEnglish { get; set; } = string.Empty;

    [Required]
    public string OurVision { get; set; } = string.Empty;
    [Required]
    public string OurVisionInEnglish { get; set; } = string.Empty;

    [Required]
    public string Details { get; set; } = string.Empty;
    [Required]
    public string DetailsInEnglish { get; set; } = string.Empty;

    [AllowedLetters(FileSettings.SpecialChar), MaxFileLettersCount(FileSettings.Length)]
    public IFormFile? ImagePath { get; set; }
}
