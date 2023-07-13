﻿using AutoMapper;
using Business.Dtos.Categories;
using Business.Repositories.InterfaceRepo;
using Data.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ToysSalesWebIU.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryController(ICategoryRepository categoryRepo,IMapper mapper,IWebHostEnvironment webHostEnvironment)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult CreateCategory() => View();

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (await _categoryRepo.AnyCategoryName(model.Name))
                {
                    TempData["Warning"] = "Bu kategori ismi zaten var.";
                    return View(model);
                }

                string imageName = "noimage.png";
                if (model.UploadImage != null)
                {

                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/categories");
                    imageName = $"{Guid.NewGuid().ToString()}_{model.UploadImage.FileName}";
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    await model.UploadImage.CopyToAsync(fileStream);
                    fileStream.Close();
                }

                var category = _mapper.Map<Category>(model);
                category.Image = imageName;
                await _categoryRepo.AddAsync(category);
                TempData["Success"] = "Kategori oluşturuldu!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Kategori oluşturulamadı!!";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            if (id > 0)
            {
                var category = await _categoryRepo.GetByIdAsync(id);
                if (category != null)
                {
                    var model = _mapper.Map<UpdateCategoryDTO>(category);
                    return View(model);
                }
                TempData["Error"] = "Kategori bulunamadı!!";
                return View();
            }
            TempData["Error"] = "Hatalı işlem!!";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (await _categoryRepo.AnyCategoryName(model.Name))
                {
                    TempData["Warning"] = "Bu kategori adı zaten kullanılıyor!!";
                    return View(model);
                }

                string imageName = "noimage.png";
                if (model.UploadImage != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/categories");
                    imageName = $"{Guid.NewGuid().ToString()}_{model.UploadImage.FileName}";
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    await model.UploadImage.CopyToAsync(fileStream);
                    fileStream.Close();

                }

                var category = _mapper.Map<Category>(model);
                category.Image = imageName;
                await _categoryRepo.UpdateAsync(category);
                TempData["Success"] = "Kategori güncellendi!!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Kategori güncellenemedi!!";
            return View(model);
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id > 0)
            {
                var category = await _categoryRepo.GetByIdAsync(id);
                if (category != null)
                {
                    await _categoryRepo.DeleteAsync(category);
                    TempData["Success"] = "Kategori silindi!!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Success"] = "Kategori bulunamadı!!";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["Warning"] = "Hatalı işlem!!";
            }
            return RedirectToAction("Index");


        }
    }
}
