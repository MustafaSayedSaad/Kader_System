using Kader_System.Domain.Interfaces.Setting;

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



    INewsRepository News { get; }
    IServiceRepository Services { get; }
    IServicesCategoryRepository ServicesCategories { get; }
    IPoliticsRepository Politics { get; }
    IContactUsRepository ContactUs { get; }
    IAboutUsRepository AboutUs { get; }

    Task<int> CompleteAsync();
}
