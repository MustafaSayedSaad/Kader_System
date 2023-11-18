namespace Kader_System.DataAccess.Repositories.Shared;

public class AboutUsRepository : BaseRepository<SharAboutUs>, IAboutUsRepository
{
    public AboutUsRepository(KaderDbContext context) : base(context)
    {
    }
}
