using Practice.Razor.Domain.Entitities;
using static Practice.Razor.Domain.Constants.App;

namespace Practice.Razor.Common
{
    public static class DataGeneration
    {
        public static IEnumerable<Dealer> Dealers = new List<Dealer>()
        {
            Dealer.New()
        };

        public static IEnumerable<Product> Products = new List<Product>()
        {
            Product.New(Dealers.First().Id),
            Product.New(Dealers.First().Id),
            Product.New(Dealers.First().Id),
            Product.New(Dealers.First().Id),
            Product.New(Dealers.First().Id),
        };

        public static IEnumerable<Dealer> GenerateDealers(int dealerSize)
        {
            var dealers = new List<Dealer>();
            var random = new Random();

            for (int i = 0; i < dealerSize; i++)
            {
                var dealer = Dealer.New();
                dealer.Name = $"Dealer No.{i + 1}";

                dealers.Add(dealer);
            }

            return dealers;
        }

        public static IEnumerable<Product> GenerateProducts(int productSize)
        {
            var products = new List<Product>();
            var random = new Random();
            var statuses = Enum.GetValues(typeof(ProductStatus));

            for (int i = 0; i < productSize; i++)
            {
                var product = Product.New();
                product.Name = $"Product {i + 1}";
                product.Description = $"Description for product {i + 1}";
                product.Price = random.Next(10, 500);
                product.CreatedAt = DateTime.Now.AddDays(-random.Next(1, 100));
                product.DealerId = Guid.NewGuid();
                product.Status = i % 3 == 0 ? true : false;

                products.Add(product);
            }

            return products;
        }
    }
}
