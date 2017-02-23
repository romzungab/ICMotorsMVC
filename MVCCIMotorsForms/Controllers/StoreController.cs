using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCIMotorsForms.Models;

namespace MVCCIMotorsForms.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            IC_MotersEntities db = new IC_MotersEntities();
            var productList = db.Products.Select(x => new ProductClass
            {
                ProductId = x.ProductId,
                CatagoryId = x.CatagoryId,
                Price = x.Price,
                Name = x.Name,
                Category = x.ProductCatagory.Catagory
            }).ToList();

            return View(productList);
        }

        public ActionResult AddToMyCart(int productId)
        {
            IC_MotersEntities db = new IC_MotersEntities();
            var product = db.Products.Find(productId);
            ProductClass prodInCart = new ProductClass(product);
            CartClass cart = new CartClass();
            cart.CartItems.Add(prodInCart);
            return RedirectToAction("Index", "MyCart");
        }
    }
}