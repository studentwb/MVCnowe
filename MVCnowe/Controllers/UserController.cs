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
            CountUsers();
            return View(objUserList);
        }
        //get
        public IActionResult CreateUser()
        {
             return View();
        }
        //post
        [HttpPost] 
        [ValidateAntiForgeryToken] 
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
        public IActionResult EditUser(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var UserFromDb = _db.Users.Find(id);

            if(UserFromDb == null)
            {
                return NotFound();
            }
            return View(UserFromDb);
        }
        
        [HttpPost] 
        [ValidateAntiForgeryToken] 
        public IActionResult EditUser(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Edited item";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult DeleteUser(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var UserFromDb = _db.Users.Find(id);

            if (UserFromDb == null)
            {
                return NotFound();
            }
            return View(UserFromDb);
        }
        //post
        [HttpPost] 
        [ValidateAntiForgeryToken] 
        public IActionResult DeleteUserPost(int? id)
        {
            var obj = _db.Users.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Users.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Deleted item";
            return RedirectToAction("Index");

        }


        public IActionResult CountUsers()
        {
            int Counter = 0;
            var count = _db.Users.Count();
            Counter = count;
            TempData["counter"] = Counter;
         
            return RedirectToAction("Index");
        }


    }
}

