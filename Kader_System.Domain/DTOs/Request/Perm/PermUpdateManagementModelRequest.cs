namespace Kader_System.Domain.Dtos.Request.Perm;

public class PermUpdateManagementModelRequest 
{
    public string RoleId { get; set; } = string.Empty;
    public List<CheckBox> ListOfCheckBoxes { get; set; } = new();
}
