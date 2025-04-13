using Practice.Razor.Domain.Entitities;

namespace Practice.Razor.Domain.Repositories
{
    public interface IDealerRepository
    {
        Task Create(Dealer dealer);

        Task<IEnumerable<Dealer>> GetAll();

        Task<Dealer> GetById(Guid id);
    }
}
