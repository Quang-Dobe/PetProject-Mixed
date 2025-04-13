using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using PetProject.Razor.Common;
using PetProject.Razor.Domain.Components.Base;
using PetProject.Razor.Domain.Entitities;
using PetProject.Razor.Domain.Repositories;

namespace PetProject.Razor.Domain.Components
{
    public class AddProductViewModel() : BaseViewModel
    {
        public EditContext? EditContext;
        private Product? _product;

        public Product? product
        {
            get => _product;
            set => _product = value;
        }

        public IEnumerable<Dealer>? Dealers { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IDealerRepository dealerRepository { get; set; }

        [Inject]
        public IProductRepository productRepository { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            product = Product.New();
            Dealers = new List<Dealer>();

            EditContext = new(product);
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Dealers = await GetDealersAsync(5);
        }

        public async Task HandleSubmit()
        {
            // Manual call validation | Otherwise we can use OnValidSubmit instead!
            if (product == null || EditContext == null || !EditContext.Validate())
            {
                return;
            }

            await dealerRepository.Create(Dealer.New());
            await productRepository.Create(product);

            product = Product.New();
            navigationManager.NavigateTo("/products");
        }

        private async Task<IEnumerable<Dealer>> GetDealersAsync(int dealerSize)
        {
            await Task.Delay(1000);
            return DataGeneration.GenerateDealers(dealerSize);
        }
    }
}
