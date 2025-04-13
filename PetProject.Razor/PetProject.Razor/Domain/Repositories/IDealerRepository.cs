using PetProject.Razor.Domain.Entitities;

namespace PetProject.Razor.Domain.Repositories
{
    public interface IDealerRepository
    {
        Task Create(Dealer dealer);

        Task<IEnumerable<Dealer>> GetAll();

        Task<Dealer> GetById(Guid id);
    }
}
