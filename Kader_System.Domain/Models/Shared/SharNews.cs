namespace Kader_System.Domain.Models.Shared;

[Table("Shar_News")]
public class SharNews : BaseEntity
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string TitleInEnglish { get; set; } = string.Empty;

    public string TitleMeta { get; set; } = string.Empty;
    public string? HtmlBody { get; set; } 

    public string TitleMetaInEnglish { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string? ImageName { get; set; }
    public string? ImageExtension { get; set; }

    public string? VideoName { get; set; }
    public string? VideoExtension { get; set; }

}
