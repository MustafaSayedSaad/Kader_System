﻿namespace Kader_System.Domain.Models.Setting;

[Table("St_SubMainScreens")]
public class StSubMainScreen : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Screen_sub_title_en { get; set; } = string.Empty;
    public string Screen_sub_title_ar { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

    public int Screen_main_id { get; set; }
    [ForeignKey(nameof(Screen_main_id))]
    public StMainScreen MainScreen { get; set; } = default!;

    public ICollection<StSubMainScreenAction> ListOfActions { get; set; } = [];
}
