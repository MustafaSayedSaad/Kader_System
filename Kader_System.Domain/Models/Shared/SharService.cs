namespace Kader_System.Domain.Models.Shared;

[Table("Shar_Services")]
public class SharService : BaseEntity
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string TitleInEnglish { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public string ImageName { get; set; } = string.Empty;
    public string ImageExtension { get; set; } = string.Empty;

    public string? HtmlBody { get; set; }

    public int ServicesCategoryyId { get; set; }
    [ForeignKey(nameof(ServicesCategoryyId))]
    public SharServicesCategory ServicesCategory { get; set; } = default!;
}
