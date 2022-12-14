using GetIt.Core.Attributes;
using GetIt.Data;
using GetIt.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace GetIt.Application.Products
{
    [Scoped]
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(GetItDbContext db) : base(db)
        {
        }

        public Task<List<Product>> GetRecentlyAddedProducts(int count)
        {
            return Query.OrderByDescending(x => x.CreatedDate).Take(count).ToListAsync();
        }
    }
}
