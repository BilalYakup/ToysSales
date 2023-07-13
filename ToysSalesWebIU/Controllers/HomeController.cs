using Business.Repositories.InterfaceRepo;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToysSalesWebIU.Models;

namespace ToysSalesWebIU.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IProductRepository _productRepo;

        public HomeController(ILogger<HomeController> logger,ICategoryRepository categoryRepo,IProductRepository productRepo)
        {
            _logger = logger;
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
        }

        public async Task<IActionResult> Index()
        {
            CategoryAndProductVM viewModel= new CategoryAndProductVM();
            viewModel.Categories= await _categoryRepo.GetAllAsync();
            viewModel.Products=await _productRepo.GetAllAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> ProductDetail(int id)
        {
            var product=await _productRepo.GetByIdAsync(id);
            var category=await _categoryRepo.GetByIdAsync(product.CategoryId);

            ProductDetailVM model = new ProductDetailVM()
            {
                Name = product.Name,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
                UnitStock = product.UnitStock,
                Image = product.Image,
                CreatedDate = product.CreatedDate,
                Status = product.Status,
                CategoryName = category.Name,
                Products=await _productRepo.GetAllAsync(),
            };

            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}