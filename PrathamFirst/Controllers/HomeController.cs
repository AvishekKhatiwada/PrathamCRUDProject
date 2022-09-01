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
        public IActionResult Index()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var data = Context.Users.ToList();
            foreach (var item in data)
            {
                if (item.Email == user.Email && item.Password == user.Password)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Privacy");
                }
            }
            return RedirectToAction("Privacy");
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