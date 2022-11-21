using Avito.DataAccess.Interfaces.Repositories;
using Avito.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Avito.DataAccess.Postgres.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AvitoContext dbContext) : base(dbContext)
        {
        }
    }
}
