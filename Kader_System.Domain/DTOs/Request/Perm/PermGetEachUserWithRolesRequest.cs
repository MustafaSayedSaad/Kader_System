namespace Kader_System.Domain.Dtos.Request.Perm;

public class PermGetEachUserWithRolesRequest : PaginationRequest
{
    public int? CompanyId{ get; set; }
    public int? DepartmentId { get; set; }
    public int? EmployeeId { get; set; }
    //public string? RoleId { get; set; }
    public string? UserId { get; set; }
    public DateTime? CreationStartDate { get; set; }
    public DateTime? CreationEndDate { get; set; }
    public int? JobId { get; set; }
    public int? SuperVisorId { get; set; }
}
