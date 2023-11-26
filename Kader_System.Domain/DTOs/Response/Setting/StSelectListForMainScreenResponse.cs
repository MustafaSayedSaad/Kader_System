namespace Kader_System.Domain.DTOs.Response.Setting;

public class StSelectListForMainScreenResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Main_id { get; set; } 
    public string? Main_image { get; set; } 
    public string Main_title { get; set; } = string.Empty;
}
