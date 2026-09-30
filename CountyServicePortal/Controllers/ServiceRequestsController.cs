using Microsoft.AspNetCore.Mvc;
using CountyServicePortal.Data;
using CountyServicePortal.Models;
using Microsoft.EntityFrameworkCore;



namespace CountyServicePortal.Controllers
{
    public class ServiceRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create() // GET: ServiceRequests/Create
        {
            return View();
        }

        public IActionResult Index() //
        {
            var requests = _context.ServiceRequests
                                    .OrderByDescending(r => r.DateSubmitted)
                                    .ToList();
            return View(requests);
        }

        [HttpPost]
        public IActionResult Create(ServiceRequest request) //creates a new service request and saves it to the database
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
        public IActionResult Success() // Success page after submitting a service request
        {
            return View();
        }
    }
}
