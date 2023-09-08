using Microsoft.EntityFrameworkCore;
using UserCRUDApi.Domain;
using UserCRUDApi.Infractructure.Interfaces;

namespace UserCRUDApi.Infractructure.Repositories;

public class UserRepository : RepositoryBase<User>,IUserRepository
{
    public UserRepository(DataContext dataContext) : base(dataContext )
    { 
    }
}