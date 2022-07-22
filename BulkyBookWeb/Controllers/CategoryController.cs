using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Catogories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name.Equals(obj.DisplayOrder.ToString()))
            {
                ModelState.AddModelError("name", "Name and DisplayOrder can not be same.");
            }
            if (ModelState.IsValid)
            {
                _db.Catogories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
            else
                return View(obj);
        }



        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }

            var category = _db.Catogories.Find(id);
            if (category == null) { return NotFound(); }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name.Equals(obj.DisplayOrder.ToString()))
            {
                ModelState.AddModelError("name", "Name and DisplayOrder can not be same.");
            }
            if (ModelState.IsValid)
            {
                _db.Catogories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated successfully";
                return RedirectToAction("Index");
            }
            else
                return View(obj);
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }

            var category = _db.Catogories.Find(id);
            if (category == null) { return NotFound(); }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }

            var category = _db.Catogories.Find(id);
            if (category == null) { return NotFound(); }

            _db.Catogories.Remove(category);
            _db.SaveChanges();

            TempData["success"]="Category Deleted successfully";   
            return RedirectToAction("Index");
        }


    }
}
