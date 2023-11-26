namespace Kader_System.Domain.Dtos.Request.Setting;

public class StCreateSubMainScreenRequest
{
    [Display(Name = Annotations.NameInEnglish), Required(ErrorMessage = Annotations.FieldIsRequired)]
    public string Screen_sub_title_en { get; set; } = string.Empty;

    [Display(Name = Annotations.NameInArabic), Required(ErrorMessage = Annotations.FieldIsRequired)]
    public string Screen_sub_title_ar { get; set; } = string.Empty;
    public int Screen_main_id { get; set; }
    public string Url { get; set; } = string.Empty;
    public List<int> Actions { get; set; } = [];
}
