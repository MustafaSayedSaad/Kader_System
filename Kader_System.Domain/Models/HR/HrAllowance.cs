﻿namespace Kader_System.Domain.Models.HR;

[Table("Hr_Allowances")]
public class HrAllowance : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public required string Name_ar { get; set; }
    public required string Name_en { get; set; }
}
