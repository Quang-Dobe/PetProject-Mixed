using Microsoft.EntityFrameworkCore;
using Practice.Razor.Domain.Entitities;
using Practice.Razor.Domain.Repositories;

namespace Practice.Razor.Persistence.Repositories
{
    public class ProductRepository(IfsDbContext dbContext) : IProductRepository
    {
        public async Task Create(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetById(Guid Id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
