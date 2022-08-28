using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrathamFirst.Data;
using PrathamFirst.Models;
using System.Xml.Linq;

namespace PrathamFirst.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext Context;
        public ProductController(ApplicationDbContext context)
        {
            this.Context = context;
        }

        //private readonly ILogger<HomeController> _logger;
        // GET: HomeController1

        public ActionResult Index()
        {
            List<Product> products = Context.Products.ToList();
            return View(products);
            //var data = Context.Products.ToList();
            //Product obj = new Product();
            //foreach (var row in data)
            //{                
            //    obj.Name = row.Name;
            //    obj.Stock = row.Stock;
            //    obj.Size = row.Size;
            //    obj.Color = row.Color;
            //    obj.Price = row.Price;
            //}
            //var viewModel = new Product()
            //{
            //    Name = Context.Products.First().Name,
            //    Stock = Context.Products.First().Stock,
            //    Size = Context.Products.First().Size,
            //    Color = Context.Products.First().Color,
            //    Price = Context.Products.First().Price
            //};

        }
        public ActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNew(Product prod)
        {
            this.Context.Products.Add(prod);
            this.Context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Update(string id) 
        {
            Product product = Context.Products.Find(id);
            return View(product); 
        }
        [HttpPost]
        public ActionResult Update(Product prod)
        {
            
            Context.Entry(prod).State = EntityState.Modified;
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult NewTemplete()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(string id)
        {
            Product prod = Context.Products.Find(id);
            Context.Entry(prod).State = EntityState.Deleted;
            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
