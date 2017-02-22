using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCIMotorsForms.Models;
namespace MVCCIMotorsForms.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            IC_MotersEntities db = new IC_MotersEntities();
            var customerList = db.People.Where(x => x.PersonTypeId == 4)
                                     .Select(x => new CustomerClass
                                     {
                                         PersonId = x.PersonId,
                                         FirstName = x.FirstName,
                                         LastName = x.LastName,
                                         Address1 = x.Address1,
                                         SuburbId = x.SuburbId,
                                         Suburb = x.SuburbType.Suburb,
                                         Address2 = x.Address2,
                                         PhoneNumber = x.PhoneNumber,
                                         PersonType = x.PersonType.PersonType1
                                     })
                                     .ToList();
            return View(customerList);
        }
        private IEnumerable<SelectListItem> GetSuburbs()
        {
            IC_MotersEntities db = new IC_MotersEntities();
            var suburbs = db.SuburbTypes
                            .Select(x=> new SelectListItem
                                        {
                                            Value = x.SuburbId.ToString(),
                                            Text =x.Suburb
                                        }
                                    );

            return new SelectList(suburbs, "Value", "Text");
        }
        public ActionResult EditCustomer(int customerId)
        {
            CustomerViewClass customerToEdit;
            IC_MotersEntities db = new IC_MotersEntities();
                   
            if (customerId != 0)
            {
                customerToEdit = new CustomerViewClass(db.People.Find(customerId), GetSuburbs());
            }
            else {
                customerToEdit = new CustomerViewClass(GetSuburbs());
            }
            return View(customerToEdit);
        }
        

        [HttpPost]
        public ActionResult EditCustomer(CustomerViewClass customerData)
        {
            IC_MotersEntities db = new IC_MotersEntities();
            if (customerData.Customer.PersonId != 0)
            {
                var newCustomer = db.People.Find(customerData.Customer.PersonId);

                newCustomer.PersonId = customerData.Customer.PersonId;
                newCustomer.FirstName = customerData.Customer.FirstName.Trim();
                newCustomer.LastName = customerData.Customer.LastName.Trim();
                newCustomer.Address1 = customerData.Customer.Address1.Trim();
                newCustomer.Address2 = customerData.Customer.Address2.Trim();
                newCustomer.PhoneNumber = customerData.Customer.PhoneNumber.Trim();
                newCustomer.SuburbId = customerData.Customer.SuburbId;
            }
            else {
                Person newCustomer = new Person();
                newCustomer.FirstName = customerData.Customer.FirstName.Trim();
                newCustomer.LastName = customerData.Customer.LastName.Trim();
                newCustomer.Address1 = customerData.Customer.Address1.Trim();
                newCustomer.Address2 = customerData.Customer.Address2.Trim();
                newCustomer.PhoneNumber = customerData.Customer.PhoneNumber.Trim();
                newCustomer.PersonTypeId = 4;
                newCustomer.SuburbId = customerData.Customer.SuburbId;
                db.People.Add(newCustomer);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");
         }
    }
}