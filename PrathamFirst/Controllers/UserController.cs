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
        public UserController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            Context = context;
            this.webHostEnvironment = webHostEnvironment;
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
        public IActionResult Landing()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            /*var data = new User
            {
                Name=user.Name,
                Email=user.Email,
                Address=user.Address,
                Gender=user.Gender,
                Password=user.Gender
            };*/
            Context.Users.Add(user);
            Context.SaveChanges();

            return RedirectToAction("Landing");
        }
    }
}
