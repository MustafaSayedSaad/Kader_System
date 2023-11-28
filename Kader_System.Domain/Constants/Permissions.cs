namespace Kader_System.Domain.Constants;

public static class Permissions
{
    public static List<GetPermissionsWithActions> GeneratePermissionsList(string module)
    {
        if (module == "Auth")
            return
            [
                new()
                {
                    ClaimValue = $"Permissions.{module}.View",
                    ActionId = (int)ActionsEnums.View
                }
            ];

        else
            return
            [
                new()
                {
                    ClaimValue = $"Permissions.{module}.View",
                    ActionId = (int)ActionsEnums.View
                },
                new()
                {
                    ClaimValue = $"Permissions.{module}.Ptint",
                    ActionId = (int)ActionsEnums.Ptint
                },
                new()
                {
                    ClaimValue = $"Permissions.{module}.Edit",
                    ActionId = (int)ActionsEnums.Edit
                },
                new()
                {
                    ClaimValue = $"Permissions.{module}.Delete",
                    ActionId = (int)ActionsEnums.Delete
                },
                new()
                {
                    ClaimValue = $"Permissions.{module}.ForceDelete",
                    ActionId = (int)ActionsEnums.ForceDelete
                }
            ];
    }

    public static List<GetPermissionsWithActions> GenerateAllPermissions()
    {
        List<GetPermissionsWithActions> allPermissions = [];

        var modules = Enum.GetValues(typeof(PermissionsModulesEnums));

        foreach (var module in modules)
            allPermissions.AddRange(GeneratePermissionsList(module.ToString()!));

        return allPermissions;
    }

    public static class Auth
    {
        public const string View = "Permissions.Auth.View";
    }


    public static class Companies
    {
        public const string View = "Permissions.Companies.View";
        public const string Ptint = "Permissions.Companies.Ptint";
        public const string Create = "Permissions.Companies.Create";
        public const string Edit = "Permissions.Companies.Edit";
        public const string Delete = "Permissions.Companies.Delete";
        public const string ForceDelete = "Permissions.Companies.ForceDelete";
    }
}