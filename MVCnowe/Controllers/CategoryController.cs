﻿using Microsoft.AspNetCore.Mvc;
using MVCnowe.Data;
using MVCnowe.Models;

namespace MVCnowe.Controllers
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
            IEnumerable<Category> objCategoryList=_db.Categories;
            return View(objCategoryList);
        }
        //get
        public IActionResult CreateCategory()
        {
           
            return View();
        }
        //post
        [HttpPost] //co to robi
        [ValidateAntiForgeryToken] //co to robi
        public IActionResult CreateCategory(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Created item";

                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //get
        public IActionResult EditCategory(int? id)
        {

            if(id==null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            
            
            return View(categoryFromDb);
        }
        //post
        [HttpPost] //co to robi
        [ValidateAntiForgeryToken] //co to robi
        public IActionResult EditCategory(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Edited item";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult DeleteCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);
            
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //post
        [HttpPost] //co to robi
        [ValidateAntiForgeryToken] //co to robi
        public IActionResult DeleteCategoryPost(int? id)
        {
            var obj = _db.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Deleted item";
            return RedirectToAction("Index");

        }
        public IActionResult CountDisplayOrders()
        {
            var obj = _db.Categories.ToList();
            int counter = 0;
            foreach (var order in obj)
            {
                counter = counter + order.DisplayOrder;
            }
            TempData["count"] = counter.ToString();
            return RedirectToAction("Index");
        }

    }
}
