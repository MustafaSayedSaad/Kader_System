namespace Kader_System.Domain.Dtos.Request.Setting;

public class StGetAllFiltrationsForSubMainScreenRequest : PaginationRequest
{
    [DefaultValue(false)]
    public bool IsDeleted { get; set; }
}
