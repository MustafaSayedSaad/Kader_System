namespace Kader_System.DataAccess.Repositories.Shared;

public class PoliticsRepository : BaseRepository<SharPolitics>, IPoliticsRepository
{
    public PoliticsRepository(KaderDbContext context) : base(context)
    {
    }
}
