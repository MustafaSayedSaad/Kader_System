namespace Kader_System.Domain.Dtos.Request.Shared
{
    public class SharEditNewsRequest
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public required string TitleInEnglish { get; set; }

        public required string TitleMeta { get; set; }

        public required string TitleMetaInEnglish { get; set; }
        public required string Description { get; set; }
        public string? HtmlBody { get; set; }

        [AllowedLetters(FileSettings.SpecialChar), MaxFileLettersCount(FileSettings.Length)]
        public IFormFile? Image { get; set; }

        [AllowedLetters(FileSettings.SpecialChar), MaxFileLettersCount(FileSettings.Length)]
        public IFormFile? Video { get; set; }
    }
}
