namespace Kader_System.Domain.DTOs.Response.Shared;

public class SharGetServicesCategoryWthAllServicesResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<SharGetServiceResponse> Services { get; set; } = new();
}
