namespace Kader_System.Domain.Dtos.Request.Setting;

public class StCreateMainScreenRequest
{
    [Required]
    public string Screen_main_title_en { get; set; } = string.Empty;
    [Required]
    public string Screen_main_title_ar { get; set; } = string.Empty;

    [AllowedLetters(FileSettings.SpecialChar), MaxFileLettersCount(FileSettings.Length)]
    public IFormFile? Screen_main_image { get; set; }
}
