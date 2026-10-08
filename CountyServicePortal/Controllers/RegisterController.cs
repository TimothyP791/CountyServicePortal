using Microsoft.AspNetCore.Mvc;
using CountyServicePortal.Data;
using CountyServicePortal.Models;
using Microsoft.EntityFrameworkCore;


namespace CountyServicePortal.Controllers
{
    public class RegisterController : Controller
    {

        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Register() // GET: Register/Register
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            var civilian = _context.Civilians.FirstOrDefault(u => u.Username == username);

            // Check if the username already exists in the database
            if (civilian != null)
            {
                ModelState.AddModelError("Username", "Username already exists.");
                return View();
            }
            // Check if password meets the required criteria (e.g., minimum length, complexity)
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError(string.Empty, "Username and password are required.");
                return View();
            }

            if (password.Length < 6)
            {
                ModelState.AddModelError("Password", "Password must be at least 6 characters long.");
                return View();
            }

            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit))
            {
                ModelState.AddModelError("Password", "Password must contain at least one uppercase letter, one lowercase letter, and one digit.");
                return View();
            }

            if (ModelState.IsValid)
            {
                _context.Civilians.Add(new Civilian { Username = username, Password = password });
                _context.SaveChanges();

                return RedirectToAction(nameof(SuccessReg));
            }

            return View();
        }
        public IActionResult SuccessReg() // Success page after registering a new user
        {
            return View();
        }

    }
}
