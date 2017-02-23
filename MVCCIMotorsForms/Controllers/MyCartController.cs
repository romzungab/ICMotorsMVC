using MVCCIMotorsForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCIMotorsForms.Controllers
{
    public class MyCartController : Controller
    {
        // GET: MyCart
        public ActionResult Index(CartClass cart)
        {
            return View(cart);
        }
    }
}