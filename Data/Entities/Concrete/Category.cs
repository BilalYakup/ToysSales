using Data.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Concrete
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string? Image { get; set; }

        [NotMapped]
        public IFormFile UploadImage { get; set; }
        public List<Product> Products { get; set; }
    }
}
