using Practice.Razor.Domain.Entitities;

namespace Practice.Razor.Domain.Repositories
{
    public interface IProductRepository
    {
        Task Create(Product product);

        Task<IEnumerable<Product>> GetAll();

        Task<Product> GetById(Guid Id);
    }
}
