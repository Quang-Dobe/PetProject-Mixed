using Microsoft.EntityFrameworkCore;
using PetProject.Razor.Domain.Entitities;
using PetProject.Razor.Domain.Repositories;

namespace PetProject.Razor.Persistence.Repositories
{
    public class DealerRepository(IfsDbContext dbContext) : IDealerRepository
    {
        public async Task Create(Dealer dealer)
        {
            await dbContext.Dealers.AddAsync(dealer);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Dealer>> GetAll()
        {
            return await dbContext.Dealers.ToListAsync();
        }

        public async Task<Dealer> GetById(Guid id)
        {
            return await dbContext.Dealers.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
