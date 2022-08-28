using Microsoft.AspNetCore.Mvc;
using PrathamFirst.Data;
using PrathamFirst.Models;
using System;
using System.Diagnostics;

namespace PrathamFirst.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext Context { get; }
        public HomeController(ApplicationDbContext _context)
        {
            this.Context = _context;
        }

        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        
        public IActionResult Index()
        {
            return View();  
        }
        
        public IActionResult Privacy()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult StudentDetails(Student st)
        {
            var viewModel = new Student()
            {
                Id = st.Id,
                Name = st.Name,
                Address = st.Address
            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}