namespace Kader_System.Domain.Dtos.Request.Shared;

public class SharEditServicesCategoryRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string NameInEnglish { get; set; }
}
