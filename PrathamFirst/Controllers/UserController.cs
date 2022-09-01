using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using PrathamFirst.Data;
using PrathamFirst.Models;
using PrathamFirst.ViewModel;

namespace PrathamFirst.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext Context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly INotyfService _notyf;
        public UserController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, INotyfService notyf)
        {
            Context = context;
            this.webHostEnvironment = webHostEnvironment;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Landing()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            string HashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var data = new User
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                Gender = user.Gender,
                Password = HashedPassword
            };
            Context.Users.Add(data);
            Context.SaveChanges();
            return RedirectToAction("Landing");
        }
    }
}
