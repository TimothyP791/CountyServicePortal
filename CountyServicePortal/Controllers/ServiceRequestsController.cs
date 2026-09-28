using Microsoft.AspNetCore.Mvc;
using CountyServicePortal.Data;
using CountyServicePortal.Models;



namespace CountyServicePortal.Controllers
{
    public class ServiceRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServiceRequest request)
        {
            if (ModelState.IsValid)
            {
                request.DateSubmitted = DateTime.Now;
                request.Status = "Submitted";

                _context.ServiceRequests.Add(request);
                _context.SaveChanges();

                return RedirectToAction(nameof(Success));
            }

            return View(request);
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
