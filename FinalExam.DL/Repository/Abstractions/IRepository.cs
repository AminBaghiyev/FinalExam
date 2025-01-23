using FinalExam.Core.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.DL.Repository.Abstractions;

public interface IRepository<T> where T : BaseEntity, new()
{
    DbSet<T> Table { get; }
    Task<ICollection<T>> GetAllAsync(int count = 0, bool orderAsc = true, params string[] includes);
    Task<T?> GetByIdAsync(int id, bool isTracking = false, params string[] includes);
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<int> SaveChangesAsync();
}
