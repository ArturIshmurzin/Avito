using Avito.DataAccess.Interfaces.Repositories;
using Avito.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Avito.DataAccess.Postgres.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(AvitoContext dbContext) : base(dbContext)
        {
        }
    }
}
