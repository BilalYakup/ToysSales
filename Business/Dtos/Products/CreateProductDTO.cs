using Business.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Products
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage ="lütfen alanı doldurunuz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "lütfen alanı doldurunuz")]
        public string Description { get; set; }

        [Required(ErrorMessage = "lütfen alanı doldurunuz")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "lütfen alanı doldurunuz")]
        public int UnitStock { get; set; }

        public string? Image { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg" })]
        public IFormFile UploadImage { get; set; }


        [Required(ErrorMessage = "Lütfen bir kategori seçiniz!!")]
        public int CategoryId { get; set; }
    }
}
