namespace Kader_System.Domain.DTOs.Response.Setting;

public class StGetSubMainScreenByIdResponse
{
    public int Id { get; set; }
    public string Screen_sub_title_en { get; set; } = string.Empty;
    public string Screen_sub_title_ar { get; set; } = string.Empty;
    public int Screen_cat_id { get; set; }
    public string Url { get; set; } = string.Empty;
    public List<ActionsData> Actions { get; set; } = [];
}
public class ActionsData : SpecificSelectListResponse
{
}