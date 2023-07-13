using AutoMapper;
using Business.Dtos.Categories;
using Business.Dtos.Products;
using Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>();

            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>();


            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>();

            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>();
        }
    }
}
