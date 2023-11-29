namespace Kader_System.Domain.Dtos.Request.Auth;

public class AuthLoginUserRequest
{
    [Display(Name = Annotations.UserNameOrEmail), Required(ErrorMessage = Annotations.FieldIsRequired)]
    public string UserNameOrEmail { get; set; } = string.Empty;

    [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
    [Display(Name = Annotations.Password), Required(ErrorMessage = Annotations.FieldIsRequired)]
    public string Password { get; set; } = string.Empty;

    [Display(Name = Annotations.RememberMe)]
    public bool RememberMe { get; set; }

    public string? DeviceId { get; set; }
}
