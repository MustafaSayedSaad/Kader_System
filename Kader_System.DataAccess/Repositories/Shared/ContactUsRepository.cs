namespace Kader_System.DataAccess.Repositories.Shared;

public class ContactUsRepository : BaseRepository<SharContactUs>, IContactUsRepository
{
    public ContactUsRepository(KaderDbContext context) : base(context)
    {
    }
}
