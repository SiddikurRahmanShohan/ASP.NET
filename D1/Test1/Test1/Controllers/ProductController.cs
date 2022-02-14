using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Models;

namespace Test1.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ActionResult Home()
        {
            Product p = new Product();
            p.Id = 1;
            p.Name = "Product1";
            return View(p);
        }

        public ActionResult List()

        {
            List<Product> products = new List<Product>();
            for (int i = 0; i < 5; i++)
            {
                var p = new Product {
                    Id = i + 1, Name = "Product " + (i+1)
                };
                products.Add(p);
            }
                return View(products);
        }
	}
}