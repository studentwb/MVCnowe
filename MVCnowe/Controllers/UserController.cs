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
            IEnumerable<User> objUserList = _db.Users;
            return View(objUserList);
        }
        //get
        public IActionResult CreateUser()
        {

            return View();
        }
        //post
        [HttpPost] //co to robi
        [ValidateAntiForgeryToken] //co to robi
        public IActionResult CreateUser(User obj)
        {

            if (ModelState.IsValid)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Created user";

                return RedirectToAction("Index");
            }
            return View(obj);
           
        }
             

    }
}

