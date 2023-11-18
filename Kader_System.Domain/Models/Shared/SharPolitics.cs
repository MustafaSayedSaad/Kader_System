namespace Kader_System.Domain.Models.Shared;

[Table("Shar_Politics")]
public class SharPolitics : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ImageName { get; set; } = string.Empty;
    public string ImageExtension { get; set; } = string.Empty;

    public string FileName { get; set; } = string.Empty;
    public string FileExtension { get; set; } = string.Empty;
}
