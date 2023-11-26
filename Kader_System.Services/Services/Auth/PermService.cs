namespace Kader_System.Services.Services.Auth;

public class PermService(UserManager<ApplicationUser> userManager,
                   IStringLocalizer<SharedResource> sharLocalizer, ILogger<AuthService> logger,
                   RoleManager<ApplicationRole> roleManager, IUnitOfWork unitOfWork, IHttpContextAccessor accessor) : IPermService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
    private readonly ILogger<AuthService> _logger = logger;
    private readonly IStringLocalizer<SharedResource> _sharLocalizer = sharLocalizer;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IHttpContextAccessor _accessor = accessor;

    #region Roles

    public async Task<Response<IEnumerable<SelectListForUserResponse>>> GetAllRolesAsync()
    {
        var result =
                await _unitOfWork.Roles.GetSpecificSelectAsync(null!,
                select: x => new SelectListForUserResponse
                {
                    Id = x.Id,
                    Name = x.Name!
                }, orderBy: x =>
                  x.OrderByDescending(x => x.Id));

        if (!result.Any())
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<IEnumerable<SelectListForUserResponse>>()
            {
                Data = new List<SelectListForUserResponse>(),
                Error = resultMsg,
                Msg = resultMsg
            };
        }
        return new Response<IEnumerable<SelectListForUserResponse>>()
        {
            //Msg = _sharLocalizer[Localization.Displayed],
            Data = result,
            Check = true
        };
    }

    public async Task<Response<PermCreateRoleRequest>> CreateRoleAsync(PermCreateRoleRequest model)
    {
        string err = _sharLocalizer[Localization.Error];

        if (await _roleManager.RoleExistsAsync(model.Name.ToLower()))
            return new Response<PermCreateRoleRequest>()
            {
                Data = model,
                Error = err,
                Msg = string.Format(_sharLocalizer[Localization.IsExist],
                _sharLocalizer[Localization.Role], $"({model.Name})"),
                Check = false
            };
        var role = new ApplicationRole()
        {
            Name = model.Name
        };
        role.InsertBy = role.UpdateBy = GetUserId();
        role.InsertDate = role.UpdateDate = new DateTime().NowEg();

        var result = await _roleManager.CreateAsync(role);
        if (result.Succeeded)
            return new Response<PermCreateRoleRequest>()
            {
                Msg = _sharLocalizer[Localization.Done],
                Check = true,
                Data = model,
            };
        return new Response<PermCreateRoleRequest>()
        {
            Error = result.Errors.Select(x => x.Description).First(),
            Msg = err
        };
    }

    public async Task<Response<SelectListForUserRequest>> UpdateRoleAsync(string id, SelectListForUserRequest model)
    {
        var role = await _roleManager.FindByIdAsync(id);

        if (role is null || id != model.Id)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.Role], $"({id})");



            return new Response<SelectListForUserRequest>()
            {
                Data = new SelectListForUserRequest(),
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        string err = _sharLocalizer[Localization.Error];

        role.Name = model.Name;
        role.UpdateBy = GetUserId();
        role.UpdateDate = new DateTime().NowEg();

        var idResult = await _roleManager.UpdateAsync(role);

        return new Response<SelectListForUserRequest>()
        {
            Check = idResult.Succeeded,
            Data = new SelectListForUserRequest(),
            Msg = idResult.Succeeded ? _sharLocalizer[Localization.Updated] : _sharLocalizer[err]
        };
    }

    public async Task<Response<string>> DeleteRoleByIdAsync(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);

        if (role == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.Role], $"({id})");

            return new Response<string>()
            {
                Data = string.Empty,
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        var allUsersInRole = await _userManager.GetUsersInRoleAsync(role.Name!);

        if (allUsersInRole.Any())
        {
            string resultMsg = _sharLocalizer[Localization.CannotDeletedThisRole];

            return new Response<string>()
            {
                Data = string.Empty,
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        string err = _sharLocalizer[Localization.Error];

        var roleClaims = _roleManager.GetClaimsAsync(role).Result;

        if (roleClaims.Any())
        {
            if (roleClaims.Count > 1)
                roleClaims.ToList().ForEach(async claim => await _roleManager.RemoveClaimAsync(role, claim));
            else
                await _roleManager.RemoveClaimAsync(role, roleClaims.First());
        }

        var obj = await _roleManager.DeleteAsync(role);

        bool result = obj.Succeeded;

        if (!result)
            return new Response<string>()
            {
                Check = false,
                Data = id,
                Error = err,
                Msg = err
            };
        return new Response<string>()
        {
            Check = true,
            Data = id,
            Msg = _sharLocalizer[Localization.Deleted]
        };
    }

    #endregion

    #region Spicial to roles of user

    public async Task<Response<PermGetAllUsersRolesResponse>> GetEachUserWithHisRolesAsync(PermGetEachUserWithRolesRequest model)
    {
        Expression<Func<ApplicationUser, bool>> filter = x => x.IsActive && !x.IsDeleted
        &&
        (model.UserId == null || x.Id == model.UserId)
        &&
        (model.CreationStartDate == null || x.InsertDate!.Value.Date >= model.CreationStartDate.Value.Date)
        &&
        (model.CreationEndDate == null || x.InsertDate!.Value.Date <= model.CreationEndDate.Value.Date);

        var result = new PermGetAllUsersRolesResponse
        {
            TotalRecords = await _unitOfWork.Users.CountAsync(filter),
            Data = _userManager.Users.Where(filter)
            .ToList()
            .Skip((model.PageNumber - 1) * model.PageSize)
            .Take(model.PageSize)
            .Select(user => new PermGetAllUsersRoles
            {
                Id = user.Id,
                UserName = user.UserName!,
                Email = user.Email!,
                Roles = _userManager.GetRolesAsync(user).Result.ToList()
            })
            .ToList()
        };

        //var t2 = result.Data.Skip((model.PageNumber - 1) * model.PageSize).ToList();

        return new Response<PermGetAllUsersRolesResponse>()
        {
            Data = result,
            Check = true
        };
    }

    public async Task<Response<PermGetManagementModelResponse>> ManageUserRolesAsync(string userId)
    {

        var user = await _userManager.FindByIdAsync(userId);
        var roles = _roleManager.Roles.Where(x => x.Id != "fab4fac1-c546-41de-aebc-a14da68957ab1").ToList();

        var result = new PermGetManagementModelResponse
        {
            UserId = user!.Id,
            UserName = user.UserName!,
            ListOfCheckBoxes = roles.Select(role => new CheckBox
            {
                DisplayValue = role.Name!,
                IsSelected = _userManager.IsInRoleAsync(user, role.Name!).Result
            }).ToList()
        };

        if (result is null)
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<PermGetManagementModelResponse>()
            {
                Data = new PermGetManagementModelResponse(),
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        return new Response<PermGetManagementModelResponse>()
        {
            Data = result,
            Check = true
        };
    }

    public async Task<Response<PermGetManagementModelResponse>> UpdateUserRolesAsync(PermGetManagementModelResponse model)
    {

        var user = await _userManager.FindByIdAsync(model.UserId);
        var userRoles = await _userManager.GetRolesAsync(user!);

        await _userManager.RemoveFromRolesAsync(user!, userRoles);
        await _userManager.AddToRolesAsync(user!, model.ListOfCheckBoxes.Where(x => x.IsSelected).Select(y => y.DisplayValue));

        return new Response<PermGetManagementModelResponse>()
        {
            Data = model,
            Msg = _sharLocalizer[Localization.Updated],
            Check = true
        };

    }

    #endregion

    #region Spicial to permissions(Claims) of role

    public async Task<Response<IEnumerable<string>>> GetAllPermissionsByCategoryNameAsync(List<string> permissionsCategoryNames)
    {

        var allPermissions = new List<string>();

        foreach (var module in permissionsCategoryNames)
            await Task.Run(() => allPermissions.AddRange(Permissions.GeneratePermissionsList(module.ToString()!)));

        if (!allPermissions.Any())
        {
            string resultMsg = _sharLocalizer[Localization.NotFoundData];

            return new Response<IEnumerable<string>>()
            {
                Data = new List<string>(),
                Error = resultMsg,
                Msg = resultMsg
            };
        }
        return new Response<IEnumerable<string>>()
        {
            Data = allPermissions,
            Check = true
        };
    }

    public async Task<Response<PermGetRolesPermissionsResponse>> ManageRolePermissionsAsync(string roleId)
    {

        var role = await _roleManager.FindByIdAsync(roleId);

        if (role == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.Role], roleId);
            return new Response<PermGetRolesPermissionsResponse>()
            {
                Data = new PermGetRolesPermissionsResponse(),
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        var roleClaims = _roleManager.GetClaimsAsync(role).Result.Select(c => c.Value).ToList();
        var allClaims = Permissions.GenerateAllPermissions(); // It is meant all endpoints
        var allPermissions = allClaims.Select(p => new CheckBox
        {
            DisplayValue = p
        }).ToList();

        foreach (var permission in allPermissions)
            if (roleClaims.Any(c => c == permission.DisplayValue))
                permission.IsSelected = true;

        var result = new PermGetRolesPermissionsResponse
        {
            RoleId = roleId,
            RoleName = role.Name!,
            ListOfCheckBoxes = allPermissions
        };

        return new Response<PermGetRolesPermissionsResponse>()
        {
            Data = result,
            Check = true
        };
    }

    public async Task<Response<PermUpdateManagementModelRequest>> UpdateRolePermissionsAsync(PermUpdateManagementModelRequest model)
    {

        var role = await _roleManager.FindByIdAsync(model.RoleId);

        if (role == null)
        {
            string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
                _sharLocalizer[Localization.Role], model.RoleId);

            return new Response<PermUpdateManagementModelRequest>()
            {
                Data = new PermUpdateManagementModelRequest(),
                Error = resultMsg,
                Msg = resultMsg
            };
        }

        var roleClaims = await _roleManager.GetClaimsAsync(role);//true

        var falseValues = model.ListOfCheckBoxes.Where(y => !y.IsSelected).Select(x => x.DisplayValue).ToList();

        var claims = roleClaims.Where(x => falseValues.Contains(x.Value)).ToList();

        if (claims.Any())
        {
            foreach (var claim in claims)
                await _roleManager.RemoveClaimAsync(role, claim);
        }

        var selectedClaims = model.ListOfCheckBoxes.Where(c => c.IsSelected).ToList();

        if (selectedClaims.Any())
        {
            foreach (var claim in selectedClaims)
                await _roleManager.AddClaimAsync(role, new Claim(RolesClaims.Permission, claim.DisplayValue));
        }
        return new Response<PermUpdateManagementModelRequest>()
        {
            Data = model,
            Check = true,
            Msg = _sharLocalizer[Localization.Updated]
        };
    }

    #endregion

    private string GetUserId() =>
        _accessor!.HttpContext == null ? string.Empty : _accessor!.HttpContext!.User.GetUserId();

    private async Task<ApplicationUser> GetUserByUserId(string userId) =>
    await _unitOfWork.Users.GetFirstOrDefaultAsync(x => x.Id == userId,
        includeProperties: "Employee");
}
