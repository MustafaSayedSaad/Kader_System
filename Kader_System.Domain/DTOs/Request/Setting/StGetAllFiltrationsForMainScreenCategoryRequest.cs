namespace Kader_System.Domain.Dtos.Request.Setting;

public class StGetAllFiltrationsForMainScreenCategoryRequest : PaginationRequest
{
    [DefaultValue(false)]
    public bool IsDeleted { get; set; }
}
