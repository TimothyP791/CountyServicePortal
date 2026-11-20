using CountyServicePortal.Models;
using CountyServicePortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CountyServicePortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccountDetails()
        {
            var username = HttpContext.Session.GetString("username");
            var isCivilian = HttpContext.Session.GetString("isCivilian");
            var isEmployee = HttpContext.Session.GetString("isEmployee");

            if (isCivilian == "true")
            {
                var civilian = _context.Civilians
                    .FirstOrDefault(u => u.Username == username);

                if (civilian == null)
                    return NotFound("Civilian account not found.");

                var accountDetails = new AccountDetails
                {
                    UserID = civilian.UserId,
                    Username = civilian.Username,
                    AccountCreatedAt = civilian.CreatedAt,
                    RequestsMade = civilian.RequestsMade
                };

                return View(accountDetails);
            }

            if (isEmployee == "true")
            {
                var employee = _context.Employees
                    .FirstOrDefault(u => u.Username == username);

                if (employee == null)
                    return NotFound("Employee account not found.");

                var accountDetails = new AccountDetails
                {
                    UserID = employee.EmployeeId,
                    Username = employee.Username,
                    AccountCreatedAt = employee.CreatedAt,
                    RequestsMade = employee.RequestsMade,
                    RequestsAltered = employee.RequestsAltered
                };

                return View(accountDetails);
            }

            return Unauthorized();

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
