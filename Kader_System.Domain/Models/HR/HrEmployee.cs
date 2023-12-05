namespace Kader_System.Domain.Models.HR;

[Table("Hr_Employees")]
public class HrEmployee : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public required string Employee_name_ar { get; set; }
    public required string Employee_name_en { get; set; }
    public required string Father_name_ar { get; set; }
    public required string Father_name_en { get; set; }
    public required string Grand_father_name_ar { get; set; }
    public required string Grand_father_name_en { get; set; }
    public required string Family_name_ar { get; set; }
    public required string Family_name_en { get; set; }
    public required string Address { get; set; }
    public required string Fixed_salary { get; set; }
    public required DateOnly Hiring_date { get; set; }
    public required DateOnly Immediately_date { get; set; }
    public required double Total_salary { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Children_number { get; set; }

}
