using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using baitapvenha.Models;
using baitapvenha.ViewModels;
using baitapvenha.Data;

namespace baitapvenha.Controllers
{
    public class ProductController : Controller
    {
        // 1. DANH SÁCH (INDEX)
        public IActionResult Index()
        {
            var productViewModels = SeedData.Products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Des = p.Description,
                CategoryName = SeedData.Categories.FirstOrDefault(c => c.Id == p.CategoryId)?.Name
            }).ToList();

            return View(productViewModels);
        }

        // 2. THÊM MỚI (CREATE)
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(SeedData.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            model.Id = SeedData.Products.Count > 0 ? SeedData.Products.Max(p => p.Id) + 1 : 1;
            SeedData.Products.Add(model);
            return RedirectToAction("Index");
        }

        // 3. CẬP NHẬT (EDIT)
        public IActionResult Edit(int id)
        {
            var product = SeedData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            // Truyền danh sách Category, chọn sẵn mục cũ của sản phẩm
            ViewBag.CategoryId = new SelectList(SeedData.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, Product model)
        {
            var product = SeedData.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Price = model.Price;
                product.Description = model.Description;
                product.CategoryId = model.CategoryId;
            }
            return RedirectToAction("Index");
        }

        // 4. XÓA (DELETE)
        public IActionResult Delete(int id)
        {
            var product = SeedData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = SeedData.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                SeedData.Products.Remove(product);
            }
            return RedirectToAction("Index");
        }
    }
}