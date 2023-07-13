using Data.Entities.Concrete;

namespace ToysSalesWebIU.Models
{
    public class CategoryAndProductVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
