namespace Kader_System.Domain.Dtos.Request.Shared;

public class SharCreatePolicyRequest
{
    public required string Title { get; set; }

    [AllowedLetters(FileSettings.SpecialChar), MaxFileLettersCount(FileSettings.Length)]
    public required IFormFile ImagePath { get; set; }

    [AllowedLetters(FileSettings.SpecialChar), MaxFileLettersCount(FileSettings.Length)]
    public required IFormFile FilePath { get; set; }
}
