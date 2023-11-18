using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Kader_System.DataAccess.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected KaderDbContext _context;
    internal DbSet<T> dbSet;

    public BaseRepository(KaderDbContext context)
    {
        _context = context;
        dbSet = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id) =>
        (await dbSet.FindAsync(id))!;

    public async Task<IEnumerable<TType>> GetSpecificSelectAsync<TType>(
        Expression<Func<T, bool>> filter,
        Expression<Func<T, TType>> select,
        string includeProperties = null!,
        int? skip = null,
        int? take = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!

        ) where TType : class
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (includeProperties != null)
        {
            query.AsSplitQuery();
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty).IgnoreQueryFilters();
        }

        if (filter != null)
            query = query.Where(filter);
        if (orderBy != null)
            query = orderBy(query);

        if (skip.HasValue)
            query = query.Skip(skip.Value);
        if (take.HasValue)
            query = query.Take(take.Value);

        return await query.Select(select).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>> filter = null!,
        Expression<Func<T, IQueryable<T>>> select = null!,
        Expression<Func<T, T>> selector = null!,
        Func<IQueryable<T>,
        IOrderedQueryable<T>> orderBy = null!,
        Expression<Func<T, bool>> includeFilter = null!,
        string includeProperties = null!,
        int? skip = null,
        int? take = null)
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (includeFilter is not null)
            query = query.Include(includeFilter);

        if (select != null)
            query = (IQueryable<T>)query.Select(select);
        if (filter != null)
            query = query.Where(filter);

        if (includeProperties != null)
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if (take.HasValue)
            query = query.Take(take.Value);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    public IEnumerable<T> GetAll(
        Expression<Func<T, bool>> filter = null!,
        Expression<Func<T, IQueryable<T>>> select = null!,
        Func<IQueryable<T>,
        IOrderedQueryable<T>> orderBy = null!,
        Expression<Func<T, bool>> includeFilter = null!,
        string includeProperties = null!,
        int? skip = null,
        int? take = null)
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (includeFilter is not null)
            query = query.Include(includeFilter);

        if (select != null)
            query = (IQueryable<T>)query.Select(select);
        if (filter != null)
            query = query.Where(filter);

        if (includeProperties != null)
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if (take.HasValue)
            query = query.Take(take.Value);

        if (orderBy != null)
            return orderBy(query).ToList();

        return query.ToList();
    }

    public async Task<bool> ExistAsync(int id) =>
        await dbSet.FindAsync(id) is not null;

    public async Task<bool> ExistAsync(Expression<Func<T, bool>> filter = null!, string includeProperties = null!
      )
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        if (includeProperties != null)
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

        return await query.FirstOrDefaultAsync() is not null;
    }

    public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null!,
        string includeProperties = null!
          , Func<IQueryable<T>,
        IOrderedQueryable<T>> orderBy = null!
        )
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        if (includeProperties != null)
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);
        if (orderBy != null)
            return (await orderBy(query).FirstOrDefaultAsync())!;

        return (await query.FirstOrDefaultAsync())!;
    }

    //public async Task<T> GetLastObjectOrDefaultAsync(IOrderedQueryable<T> orderBy = null!)
    //{
    //    IQueryable<T> query = dbSet.AsNoTracking();

    //    var firstObj = await dbSet.FirstOrDefaultAsync();
    //    if (firstObj is not null &&  dbSet.Count() > 1)
    //    {
    //        if (orderBy != null)
    //            return (await orderBy(query)())!;
    //    }
    //    else if(firstObj is not null && dbSet.Count() == 1)
    //    {
    //        return ((await dbSet.FirstOrDefaultAsync())!);
    //    }
    //    else
    //    {
    //        return null!;
    //    }
    //}

    public async Task<T> AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<T> AddOrUpdate(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
            await dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        await dbSet.AddRangeAsync(entities);
        return entities;
    }

    public T Remove(T entity)
    {
        dbSet.Remove(entity);
        return entity;
    }

    public int Remove2(Expression<Func<T, bool>> filter = null!)
    {
        IQueryable<T> query = dbSet;

        if (filter != null)
            query = query.Where(filter);
        int totalNumbers = query.ExecuteDelete();
        return totalNumbers;
    }

    public T Update(T entity)
    {
        dbSet.Update(entity);
        return entity;
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> filter = null!, string includeProperties = null!)
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);
        if (includeProperties != null)
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

        return await query.CountAsync();
    }

    public int Count(Expression<Func<T, bool>> filter = null!, string includeProperties = null!)
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        if (includeProperties != null)
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

        return query.Count();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null!)
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        return await query.AnyAsync();
    }

    public void Attach(T entity)
    {
        dbSet.Attach(entity);

        //var attached = _context.Attach(entity);
        //attached.State = EntityState.Modified;
        //_context.SaveChangesAsync();
    }
    public void RemoveRange(IEnumerable<T> entities) =>
            dbSet.RemoveRange(entities);

    public void UpdateRange(IEnumerable<T> entities) =>
        dbSet.UpdateRange(entities);

    public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null!, string includeProperties = null!, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!)
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        if (includeProperties != null)
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

        if (orderBy != null)
            return orderBy(query).FirstOrDefault()!;

        return query.FirstOrDefault()!;
    }

    public IEnumerable<T> AddRange(IEnumerable<T> entities)
    {
        dbSet.AddRange(entities);
        return entities;
    }

    public EntityEntry<T> Attached(T entity) =>
        dbSet.Attach(entity);

    public void AttachRange(IEnumerable<T> entities) =>
        dbSet.AttachRange(entities);

    public async Task<T> GetLastObjectOrDefaultAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!)
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (orderBy != null)
            return (await orderBy(query).FirstOrDefaultAsync())!;

        return (await query.FirstOrDefaultAsync())!;
    }
}
