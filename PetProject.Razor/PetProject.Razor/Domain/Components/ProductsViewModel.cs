using Microsoft.AspNetCore.Components;
using PetProject.Razor.Domain.Components.Base;
using PetProject.Razor.Domain.Entitities;
using PetProject.Razor.Domain.Repositories;

namespace PetProject.Razor.Domain.Components
{
    public class ProductsViewModel : BaseViewModel
    {
        private IEnumerable<Product>? _products;

        public IEnumerable<Product>? products
        { 
            get { return _products; } 
            set { _products = value; } 
        }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IProductRepository productRepository { get; set; }

        protected override void OnInitialized()
        {
            products = new List<Product>();

            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            products = await GetProductsAsync(5);

            await base.OnInitializedAsync();
        }

        public void HandleOnClick()
        {
            navigationManager.NavigateTo("/add");
        }

        private async Task<IEnumerable<Product>> GetProductsAsync(int productSize)
        {
            return await productRepository.GetAll();
        }
    }
}
