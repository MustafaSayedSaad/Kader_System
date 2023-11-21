namespace Kader_System.Domain.Models.Setting;

[Table("St_MainScreens")]
public class StMainScreen : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Screen_cat_title_en { get; set; } = string.Empty;
    public string Screen_cat_title_ar { get; set; } = string.Empty;

    public int Screen_main_id { get; set; }
    [ForeignKey(nameof(Screen_main_id))]
    public StMainScreenCategory MainScreenCategory { get; set; } = default!;
}
