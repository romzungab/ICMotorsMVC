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
        public ActionResult Index(string searchKey=null)
        {
            IC_MotersEntities db = new IC_MotersEntities();
            var viewModel = new CustomerViewClass();
            if (searchKey == null)
            {
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
                                             PersonTypeId = x.PersonTypeId
                                         })
                                         .ToList();

                viewModel.Customers = customerList;
            }
            else {
                var customerList = db.People.Where(x => x.PersonTypeId == 4)
                                            .Where(x=> x.Address1.Contains(searchKey) ||
                                                    x.Address2.Contains(searchKey) ||
                                                    x.FirstName.Contains(searchKey)||
                                                    x.LastName.Contains(searchKey)||
                                                    x.SuburbType.Suburb.Contains(searchKey)||
                                                    x.PersonType.PersonType1.Contains(searchKey)||
                                                    x.PhoneNumber.Contains(searchKey))
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
                                             PersonTypeId = x.PersonTypeId
                                         })
                                         .ToList();
                viewModel.Customers = customerList;
            }
           
            viewModel.SuburbTypes = GetSuburbs();
            return View(viewModel);
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
            if (customerData.Customers[0].PersonId != 0)
            {
                var newCustomer = db.People.Find(customerData.Customers[0].PersonId);

                newCustomer.PersonId = customerData.Customers[0].PersonId;
                newCustomer.FirstName = customerData.Customers[0].FirstName.Trim();
                newCustomer.LastName = customerData.Customers[0].LastName.Trim();
                newCustomer.Address1 = customerData.Customers[0].Address1.Trim();
                newCustomer.Address2 = customerData.Customers[0].Address2.Trim();
                newCustomer.PhoneNumber = customerData.Customers[0].PhoneNumber.Trim();
                newCustomer.SuburbId = customerData.Customers[0].SuburbId;
            }
            else {
                Person newCustomer = new Person();
                newCustomer.FirstName = customerData.Customers[0].FirstName.Trim();
                newCustomer.LastName = customerData.Customers[0].LastName.Trim();
                newCustomer.Address1 = customerData.Customers[0].Address1.Trim();
                newCustomer.Address2 = customerData.Customers[0].Address2.Trim();
                newCustomer.PhoneNumber = customerData.Customers[0].PhoneNumber.Trim();
                newCustomer.PersonTypeId = 4;
                newCustomer.SuburbId = customerData.Customers[0].SuburbId;
                db.People.Add(newCustomer);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");
         }
    }
}