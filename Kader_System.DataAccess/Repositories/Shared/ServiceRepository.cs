namespace Kader_System.DataAccess.Repositories.Shared;

public class ServiceRepository : BaseRepository<SharService>, IServiceRepository
{
    public ServiceRepository(KaderDbContext context) : base(context)
    {
    }
}
