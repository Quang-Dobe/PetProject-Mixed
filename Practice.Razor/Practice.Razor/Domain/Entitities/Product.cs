using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Practice.Razor.Domain.Constants.App;

namespace Practice.Razor.Domain.Entitities
{
    public class Product
    {
        public Guid Id { get; } = Guid.NewGuid();

        [Required(AllowEmptyStrings = false, ErrorMessage = "No name? Anonymous? Hacker? Crazy!!!")]
        public required string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "No description? Hell no!")]
        public required string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "No price? So no one can buy it!!!")]
        [Range(1, int.MaxValue, ErrorMessage = "Is it free, same as free fire bro?")]
        public required decimal Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "No created date? How does it happen bro?")]
        public required DateTime CreatedAt { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "No dealer? No one wanna buy it?")]
        public required Guid DealerId { get; set; }

        public Dealer? Dealer { get; set; }

        public required bool Status { get; set; }

        public static Product New() => new Product()
        {
            Name = String.Empty,
            Description = String.Empty,
            Price = decimal.Zero,
            CreatedAt = DateTime.Today,
            DealerId = Guid.Empty,
            Status = true,
        };

        public static Product New(Guid? dealerId) => new Product()
        {
            Name = String.Empty,
            Description = String.Empty,
            Price = decimal.Zero,
            CreatedAt = DateTime.Today,
            DealerId = dealerId ?? Guid.Empty,
            Status = true,
        };
    }
}
