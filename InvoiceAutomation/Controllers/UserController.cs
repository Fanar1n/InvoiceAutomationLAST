using InvoiceAutomation.EF;
using InvoiceAutomation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;

namespace InvoiceAutomation.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        protected readonly DbSet<User> _dbSet;

        public UserController(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
            _dbSet = _db.Set<User>();
        }



        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Authorization()
        {
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> AuthorizationUser([FromBody] User user)
        {
            User userFromDB = null;
            try
            {
                userFromDB = _db.User.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

                if (userFromDB != null)
                {
                    if(userFromDB.Role == "Администратор")
                    {
                        return RedirectToAction("Create", "Invoice");
                    }
                    if (userFromDB.Role == "СМЦ" || userFromDB.Role == "ПДО")
                    {
                        return RedirectToAction("List", "Invoice");
                    }
                    if (userFromDB.Role == "Плановый")
                    {
                        return RedirectToAction("List", "Planovie");
                    }
                    else
                    {
                        return NotFound("Пользователь не найден");
                    }
                }
                else
                {
                    return NotFound("Пользователь не найден");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
