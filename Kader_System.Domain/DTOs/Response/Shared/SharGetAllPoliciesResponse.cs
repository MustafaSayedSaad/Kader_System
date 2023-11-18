namespace Kader_System.Domain.DTOs.Response.Shared;

public class SharGetAllPoliciesResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public string ImageExtension { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string FileExtension { get; set; } = string.Empty;
    public string InsertBy { get; set; } = string.Empty;

}
