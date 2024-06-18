using FireSafetyManager.Data;
using FireSafetyManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FireSafetyManager.Controllers
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
            var onDutyCountEmployees = _context.Employees.Count(e => e.IsOnDuty);
            var offDutyCountEmployees = _context.Employees.Count(e => !e.IsOnDuty);

            ViewBag.onDutyCountEmployees = onDutyCountEmployees;
            ViewBag.offDutyCountEmployees = offDutyCountEmployees;



            var onDutyCountVehicles = _context.Vehicles.Count(e => e.IsOnDuty);
            var offDutyCountVehicles = _context.Vehicles.Count(e => !e.IsOnDuty);

            ViewBag.onDutyCountVehicles = onDutyCountVehicles;
            ViewBag.offDutyCountVehicles = offDutyCountVehicles;

            var viewModel = new
            {
                OnDutyCountEmployees = onDutyCountEmployees,
                OffDutyCountEmployees = offDutyCountEmployees,
                OnDutyCountVehicles = onDutyCountVehicles,
                OffDutyCountVehicles = offDutyCountVehicles
            };

            return View(viewModel);
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
