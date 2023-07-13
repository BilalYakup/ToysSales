using Data.Entities.Abstract;
using Data.Entities.Concrete;

namespace ToysSalesWebIU.Models
{
    public class ProductDetailVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitStock { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
