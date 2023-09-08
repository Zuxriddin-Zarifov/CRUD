using Microsoft.EntityFrameworkCore;
using UserCRUDApi.Domain;

namespace UserCRUDApi.Infractructure.Interfaces;

public interface IRepositoryBase<T> where T : BaseModel
{
    DbSet<T> GetSet();
    ValueTask<T?> GetByIdAsync(int id);
    ValueTask<T> CreateAsync(T entity);
    ValueTask<T> DeleteAsync(T entity);
    ValueTask<T> UpdateAsync(T entity);
}