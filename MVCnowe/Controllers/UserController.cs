using Microsoft.AspNetCore.Mvc;
using MVCnowe.Data;
using MVCnowe.Models;

namespace MVCnowe.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        //get
        public IActionResult Create()
        {

            return View();
        }
        //post
        [HttpPost] //co to robi
        [ValidateAntiForgeryToken] //co to robi
        public IActionResult Create(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Created item";

                return RedirectToAction("Index");
            }
            return View(obj);
            return View(obj);
        }
             

    }
}

