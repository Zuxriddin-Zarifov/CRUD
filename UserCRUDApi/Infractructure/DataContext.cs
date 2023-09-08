using Microsoft.EntityFrameworkCore;
using UserCRUDApi.Domain;

namespace UserCRUDApi.Infractructure;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
        
    }
}