using Microsoft.AspNetCore.Mvc;
using baitapvenha.Models;
using baitapvenha.Data;

namespace baitapvenha.Controllers
{
    public class CategoryController : Controller
    {
        
        public IActionResult Index()
        {
            return View(SeedData.Categories);
        }

    
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            model.Id = SeedData.Categories.Count > 0 ? SeedData.Categories.Max(c => c.Id) + 1 : 1;
            SeedData.Categories.Add(model);
            return RedirectToAction("Index");
        }
    }
}