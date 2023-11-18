namespace Kader_System.DataAccess.Repositories.Shared;

public class NewsRepository : BaseRepository<SharNews>, INewsRepository
{
    public NewsRepository(KaderDbContext context) : base(context)
    {
    }
}
