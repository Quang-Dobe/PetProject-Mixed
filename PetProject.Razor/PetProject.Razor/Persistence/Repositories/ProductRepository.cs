using Microsoft.EntityFrameworkCore;
using PetProject.Razor.Domain.Entitities;
using PetProject.Razor.Domain.Repositories;

namespace PetProject.Razor.Persistence.Repositories
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
