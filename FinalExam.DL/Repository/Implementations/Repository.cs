using FinalExam.Core.Models.Base;
using FinalExam.DL.Contexts;
using FinalExam.DL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.DL.Repository.Implementations;

public class Repository<T> : IRepository<T> where T : BaseEntity, new()
{
    readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task<ICollection<T>> GetAllAsync(int count = 0, bool orderAsc = true, params string[] includes)
    {
        IQueryable<T> query = Table.AsNoTracking();

        if (includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        if (count > 0) query = query.Take(count);

        query = orderAsc ? query.OrderBy(e => e.Id) : query.OrderByDescending(e => e.Id);

        return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id, bool isTracking = false, params string[] includes)
    {
        IQueryable<T> query = Table;

        if (!isTracking) query = query.AsNoTracking();

        if (includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task CreateAsync(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow.AddHours(4);
        await Table.AddAsync(entity);
    }

    public void Update(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow.AddHours(4);
        Table.Update(entity);
    }

    public void Delete(T entity)
    {
        Table.Remove(entity);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}
