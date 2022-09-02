using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrathamFirst.Data;
using PrathamFirst.Models;
using PrathamFirst.ViewModel;
using System.Xml.Linq;

namespace PrathamFirst.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext Context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly INotyfService _notyf;
        public ProductController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, INotyfService notyf)
        {
            this.Context = context;
            this.webHostEnvironment = webHostEnvironment;
            _notyf = notyf;
        }
        
        
        //private readonly ILogger<HomeController> _logger;
        // GET: HomeController1

        public ActionResult Index()
        {
            List<Product> products = Context.Products.ToList();
            return View(products);
          
        }
        public ActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNew(ProductVM prod)
        {
            if (ModelState.IsValid)
            {
                
                string FileUrl = Upload(prod);

                var data = new Product
                {
                    Name = prod.Name,
                    Stock = prod.Stock,
                    Color = prod.Color,
                    Size = prod.Size,
                    Price = prod.Price,
                    Image = FileUrl,
                };
                Context.Products.Add(data);
                Context.SaveChanges();
                _notyf.Success("Product Added Successfully!");
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "";

            }
            return View("AddNew");
        }

        private string Upload(ProductVM prod)
        {
            string filename = "";
            if (prod.Image != null) {
                string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                filename = Guid.NewGuid().ToString() + "-" + prod.Image.FileName;
                string filePath = Path.Combine(uploadDir, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    prod.Image.CopyTo(fileStream);
                }
            }
            return filename;
        }

        public ActionResult Update(long id) 
        {
            var product = Context.Products.Find(id);
            return View(product); 
        }
        [HttpPost]
        public ActionResult Update(ProductVM prod)
        {
            var product = Context.Products.Find(prod.Id);

                product.Name = prod.Name;
                product.Stock = prod.Stock;
                product.Color = prod.Color;
                product.Size = prod.Size;
                product.Price = prod.Price;

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
        public ActionResult Delete(long id)
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
