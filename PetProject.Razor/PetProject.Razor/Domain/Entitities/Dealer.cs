using System.ComponentModel.DataAnnotations;

namespace PetProject.Razor.Domain.Entitities
{
    public class Dealer
    {
        public Guid Id { get; } = Guid.NewGuid();

        public required string Name { get; set; }

        public required string Email { get; set; }

        public IList<Product>? Products { get; set; }

        public static Dealer New() => new Dealer()
        {
            Name = "Quang",
            Email = "quang.tran@ifinancial.systems",
            Products = new List<Product>()
        };
    }
}
