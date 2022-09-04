using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrathamFirst.Data;
using PrathamFirst.Migrations;
using PrathamFirst.Models;
using System;
using System.Diagnostics;

namespace PrathamFirst.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext Context { get; }
        private readonly INotyfService _notyf;
        public HomeController(ApplicationDbContext _context, INotyfService notyf)
        {
            this.Context = _context;
            _notyf = notyf;
        }
        public IActionResult Index()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Login(string email,string password)
        {
            var UserDetail = Context.Users.FirstOrDefault(u => u.Email == email);

            if (UserDetail is null)
            {
                return Redirect("https://localhost:7206");
            }
            else {
                if (BCrypt.Net.BCrypt.Verify(password, UserDetail.Password))
                {
                    _notyf.Success("Login Successful");
                    return RedirectToAction("Index");
                }
                else {
                    return Redirect("https://localhost:7206");
                }
            }
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