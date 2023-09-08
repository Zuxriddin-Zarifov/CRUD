using Microsoft.EntityFrameworkCore;
using UserCRUDApi.Domain;
using UserCRUDApi.Infractructure.Interfaces;

namespace UserCRUDApi.Infractructure.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseModel
{
    private readonly DbContext _dbContext;

    public RepositoryBase(DbContext context)
    {
        _dbContext = context;
    }

    public DbSet<T> GetSet() =>
        _dbContext.Set<T>();

    public async ValueTask<T?> GetByIdAsync(long id) =>
        GetSet().FirstOrDefault(x => x.Id == id);

    public async ValueTask<T> CreateAsync(T entity)
    {
        var entityResult = GetSet().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entityResult.Entity;
    }

    public async ValueTask<T> DeleteAsync(T entity)
    {
        var entityResult = GetSet().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return entityResult.Entity;
    }

    public async ValueTask<T> UpdateAsync(T entity)
    {
        var entityResult = GetSet().Update(entity);
        await _dbContext.SaveChangesAsync();
        return entityResult.Entity;
    }
}