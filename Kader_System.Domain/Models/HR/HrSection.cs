﻿namespace Kader_System.Domain.Models.HR;

[Table("Hr_Sections")]
public class HrSection : SelectList
{
    public int Company_id { get; set; }
    [ForeignKey(nameof(Company_id))]
    public HrCompany Company { get; set; } = default!;

    public ICollection<HrSectionDepartment> ListOfDepartments { get; set; } = [];
}
