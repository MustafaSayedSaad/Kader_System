namespace Kader_System.Domain.Models.Setting;

[Table("St_MainScreenCategories")]
public class StMainScreenCategory : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Screen_main_title_en { get; set; } = string.Empty;
    public string Screen_main_title_ar { get; set; } = string.Empty;
    public string? Screen_main_image { get; set; }
    public string? ImageExtension { get; set; }
}
