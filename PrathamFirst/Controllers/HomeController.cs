﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
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
        public IActionResult Login(User user)
        {
            var data = Context.Users.ToList();
            
            foreach (var item in data)
            {
                if (item.Email == user.Email)
                {
                    bool verified = BCrypt.Net.BCrypt.Verify(user.Password, item.Password);
                    if (verified == true)
                    {
                        _notyf.Success("Log In Successful!");
                        return RedirectToAction("Index");
                    }
                    else {
                        RedirectToAction("Wrong");
                    }
                }
                else
                {
                    return RedirectToAction("Wrong");
                }
            }
            return RedirectToAction("Wrong");
        }
        public IActionResult Wrong() {
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