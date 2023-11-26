namespace Kader_System.Domain.Dtos.Request.Setting;

public class StGetAllFiltrationsForMainScreenRequest : PaginationRequest
{
    [DefaultValue(false)]
    public bool IsDeleted { get; set; }
}
