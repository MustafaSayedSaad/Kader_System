namespace Kader_System.Domain.Constants;

public static class Permissions
{
    public static List<string> GeneratePermissionsList(string module)
    {
        if (module == "Auth")
            return
            [
                $"Permissions.{module}.All"
            ];

        else
            return
            [
                $"Permissions.{module}.All",
                $"Permissions.{module}.Ptint",
                $"Permissions.{module}.Create",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete",
                $"Permissions.{module}.ForceDelete"
            ];
    }

    public static List<string> GenerateAllPermissions()
    {
        var allPermissions = new List<string>();

        var modules = Enum.GetValues(typeof(PermissionsModulesEnums));

        foreach (var module in modules)
            allPermissions.AddRange(GeneratePermissionsList(module.ToString()!));

        return allPermissions;
    }

    public static class Auth
    {
        public const string All = "Permissions.Auth.All";
    }


    public static class Companies
    {
        public const string All = "Permissions.Companies.All";
        public const string Ptint = "Permissions.Companies.Ptint";
        public const string Create = "Permissions.Companies.Create";
        public const string Edit = "Permissions.Companies.Edit";
        public const string Delete = "Permissions.Companies.Delete";
        public const string ForceDelete = "Permissions.Companies.ForceDelete";
    }
}