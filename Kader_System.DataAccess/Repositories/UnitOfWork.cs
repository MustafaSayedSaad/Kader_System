namespace Kader_System.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly KaderDbContext _context;
    protected readonly IConfiguration _config;

    public IUserRepository Users { get; private set; }
    public IRoleClaimRepository RoleClaims { get; private set; }
    public IRoleRepository Roles { get; private set; }
    public IUserRoleRepository UserRoles { get; private set; }
    public IUserDeviceRepository UserDevices { get; private set; }
    public ISubMainScreenRepository SubMainScreens { get; private set; }
    public ISubMainScreenActionRepository SubMainScreenActions { get; private set; }
    public IMainScreenRepository MainScreens { get; private set; }
    public IMainScreenCategoryRepository MainScreenCategories { get; private set; }

    public UnitOfWork(KaderDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;

        Users = new UserRepository(_context);
        RoleClaims = new RoleClaimRepository(_context);
        UserDevices = new UserDeviceRepository(_context);
        Roles = new RoleRepository(_context);
        UserRoles = new UserRoleRepository(_context);

        SubMainScreens = new SubMainScreenRepository(_context);
        SubMainScreenActions = new SubMainScreenActionRepository(_context);
        MainScreens = new MainScreenRepository(_context);
        MainScreenCategories = new MainScreenCategoryRepository(_context);
    }

    public IDatabaseTransaction BeginTransaction() =>
        new EntityDatabaseTransaction(_context);

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();

    public int Complete() => _context.SaveChanges();
}
