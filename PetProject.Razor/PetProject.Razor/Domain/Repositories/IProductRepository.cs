using PetProject.Razor.Domain.Entitities;

namespace PetProject.Razor.Domain.Repositories
{
    public interface IProductRepository
    {
        Task Create(Product product);

        Task<IEnumerable<Product>> GetAll();

        Task<Product> GetById(Guid Id);
    }
}
