namespace Kader_System.DataAccess.Repositories.Shared;

public class ServicesCategoryRepository : BaseRepository<SharServicesCategory>, IServicesCategoryRepository
{
    public ServicesCategoryRepository(KaderDbContext context) : base(context)
    {
    }
}
