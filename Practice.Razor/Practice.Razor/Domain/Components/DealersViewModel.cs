using Practice.Razor.Domain.Components.Base;
using Practice.Razor.Domain.Entitities;

namespace Practice.Razor.Domain.Components
{
    public class DealersViewModel : BaseViewModel
    {
        private IEnumerable<Dealer>? _dealers;

        public IEnumerable<Dealer>? dealers
        {
            get { return _dealers; }
            set { _dealers = value; }
        }

        protected override void OnInitialized()
        {
            dealers = new List<Dealer>();

            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            dealers = await GetDealersAsync(5);

            await base.OnInitializedAsync();
        }

        private async Task<IEnumerable<Dealer>> GetDealersAsync(int dealerSize)
        {
            var dealers = new List<Dealer>();
            var random = new Random();

            for (int i = 0; i < dealerSize; i++)
            {
                var dealer = Dealer.New();
                dealer.Name = $"Dealer No.{i + 1}";

                dealers.Add(dealer);
            }

            await Task.Delay(1000);

            return dealers;
        }
    }
}
