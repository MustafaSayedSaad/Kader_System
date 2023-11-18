namespace Kader_System.Domain.Models.Shared;

[Table("Shar_ServicesCategories")]
public class SharServicesCategory : BaseEntity
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string NameInEnglish { get; set; } = string.Empty;

    public ICollection<SharService> Services { get; set; } = new HashSet<SharService>();
}
