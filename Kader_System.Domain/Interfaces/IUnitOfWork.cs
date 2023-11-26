namespace Kader_System.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IDatabaseTransaction BeginTransaction();

    IUserRepository Users { get; }
    IUserDeviceRepository UserDevices { get; }
    IRoleRepository Roles { get; }
    IUserRoleRepository UserRoles { get; }
    ISubMainScreenRepository SubMainScreens { get; }
    ISubMainScreenActionRepository SubMainScreenActions { get; }
    IMainScreenRepository MainScreens { get; }
    IMainScreenCategoryRepository MainScreenCategories { get; }

    Task<int> CompleteAsync();
}
