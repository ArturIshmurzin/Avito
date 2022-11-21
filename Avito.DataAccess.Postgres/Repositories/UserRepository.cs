using Avito.DataAccess.Interfaces.Repositories;
using Avito.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Avito.DataAccess.Postgres.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AvitoContext dbContext) : base(dbContext)
        {
        }
    }
}
