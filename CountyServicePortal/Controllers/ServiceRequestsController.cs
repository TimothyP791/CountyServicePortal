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

        public IActionResult Index() 
        {
            var requests = _context.ServiceRequests
                                    .OrderByDescending(r => r.DateSubmitted)
                                    .ToList();
            return View(requests);
        }

        public IActionResult Details(int id) //creates a details view for a specific service request based on its ID
        {
            var request = _context.ServiceRequests
                                    .FirstOrDefault(r => r.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
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

        public IActionResult UpdateStatus(int id)
        {
            var request = _context.ServiceRequests
                                    .FirstOrDefault(r => r.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            var request = _context.ServiceRequests
                                  .FirstOrDefault(r => r.RequestId == id);

            if (request == null)
            {
                return NotFound();
            }

            request.Status = status;

            _context.SaveChanges();

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
