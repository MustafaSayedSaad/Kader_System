namespace Kader_System.Domain.Models.Shared;

[Table("Shar_AboutUs")]
public class SharAboutUs : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string WhoAreWe { get; set; } = string.Empty;
    public string WhoAreWeInEnglish { get; set; } = string.Empty;

    public string OurVision { get; set; } =string.Empty;
    public string OurVisionInEnglish { get; set; } = string.Empty;

    public string Details { get; set; } = string.Empty;
    public string DetailsInEnglish { get; set; } = string.Empty;

    public string? ImageName { get; set; }
    public string? ImageExtension { get; set; }

}
