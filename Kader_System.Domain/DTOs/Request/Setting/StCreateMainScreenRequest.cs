﻿namespace Kader_System.Domain.Dtos.Request.Setting;

public class StCreateMainScreenRequest
{
    [Display(Name = Annotations.NameInEnglish), Required(ErrorMessage = Annotations.FieldIsRequired)]
    public string Screen_main_title_en { get; set; } = string.Empty;

    [Display(Name = Annotations.NameInArabic), Required(ErrorMessage = Annotations.FieldIsRequired)]
    public string Screen_main_title_ar { get; set; } = string.Empty;

    public int Screen_main_id { get; set; }
}