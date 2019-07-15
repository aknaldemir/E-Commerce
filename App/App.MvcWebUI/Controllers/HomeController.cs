using App.MvcWebUI.Entities;
using App.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MvcWebUI.Controllers
{
    
    public class HomeController : Controller
    {
       DataContext context = new DataContext();
        // GET: Home
        public ActionResult Index()
        {

            var products = context.Products
                .Where(i => i.IsHome && i.IsApproved)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Image = i.files,
                    CategoryId = i.CategoryId
                })
                .ToList();

            return View(products);
        }

        public ActionResult Details(int id)
        {
            return View(context.Products
                .FirstOrDefault(i => i.Id == id));
        }

        public ActionResult List(int? id)
        {
            var products = context.Products
               .Where(i => i.IsApproved)
               .Select(i => new ProductModel()
               {
                   Id = i.Id,
                   Name = i.Name.Length > 30 ? i.Name.Substring(0, 27) + "..." : i.Name,
                   Description = i.Description.Length > 30 ? i.Description.Substring(0, 27) + "..." : i.Description,
                   Price = i.Price,
                   Image = i.files, //i.image null ise 1.jpg
                   CategoryId = i.CategoryId
               })
               .AsQueryable();
            if (id != null)
            {
                products = products.Where(i => i.CategoryId == id);
            }


            return View(products.ToList());
        }

        [ChildActionOnly]
        public PartialViewResult CategoryList()
        {
            var Categories = context.Categories
                .ToList();
            return PartialView(Categories);
        }



        public ActionResult AdminIndex()
        {

            return View();
        }


    }
}