using AutoMapper;
using Business.Dtos.Products;
using Business.Repositories.InterfaceRepo;
using Data.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace ToysSalesWebIU.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductRepository productRepo,IMapper mapper,ICategoryRepository categoryRepo,IWebHostEnvironment webHostEnvironment)
        {
            _productRepo = productRepo;
            _mapper = mapper;
            _categoryRepo = categoryRepo;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var products=await _productRepo.GetAllAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct() 
        {
            ViewBag.Categories = new SelectList
                (
                await _categoryRepo.GetAllAsync(), "Id", "Name"
                );
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO model)
        {
            if (ModelState.IsValid) 
            {
                string imageName = "noimage.png";
                if (model.UploadImage != null)
                {
                    
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");
                    imageName = $"{Guid.NewGuid().ToString()}_{model.UploadImage.FileName}";
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    await model.UploadImage.CopyToAsync(fileStream);
                    fileStream.Close();
                }

                var product = _mapper.Map<Product>(model);
                product.Image = imageName;
                await _productRepo.AddAsync(product);
                TempData["Success"] = "Ürün kaydedildi!!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Ürün kaydedilemedi!!";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product=await _productRepo.GetByIdAsync(id);
            UpdateProductDTO model = new UpdateProductDTO()
            {
                Name = product.Name,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
                UnitStock = product.UnitStock,
                Image = product.Image,
                CategoryId = product.CategoryId,
                Categories = await _categoryRepo.GetAllAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO model)
        {
            if (ModelState.IsValid)
            {
                string imageName = "noimage.png";
                if (model.UploadImage != null)
                {

                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");
                    imageName = $"{Guid.NewGuid().ToString()}_{model.UploadImage.FileName}";
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    await model.UploadImage.CopyToAsync(fileStream);
                    fileStream.Close();
                }

                var product=_mapper.Map<Product>(model);
                product.Image = imageName;
                await _productRepo.UpdateAsync(product);
                TempData["Success"] = "Ürün Güncellendi";
                return RedirectToAction("Index");

            }
            TempData["Error"] = "Ürün Güncellenemedi";
            return View(model);
        }

    }
}
