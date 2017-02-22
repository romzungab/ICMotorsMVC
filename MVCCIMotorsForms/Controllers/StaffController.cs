using MVCCIMotorsForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCIMotorsForms.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            IC_MotersEntities db = new IC_MotersEntities();
            var stafflist = db.People.Where(x => x.PersonTypeId != 4)
                                     .Select(x => new StaffClass
                                     {
                                         PersonId = x.PersonId,
                                         FirstName = x.FirstName,
                                         LastName = x.LastName,
                                         Address1 = x.Address1,
                                         Address2 = x.Address2,
                                         SuburbId = x.SuburbId,
                                         Suburb = x.SuburbType.Suburb,
                                         PersonType = x.PersonType.PersonType1,                                       
                                         Salary = x.Salary,
                                         PhoneNumber = x.PhoneNumber
                                     })
                                     .ToList();
            return View(stafflist);
        }
        private IEnumerable<SelectListItem> GetSuburbs()
        {
            IC_MotersEntities db = new IC_MotersEntities();
            var suburbs = db.SuburbTypes
                            .Select(x => new SelectListItem
                            {
                                Value = x.SuburbId.ToString(),
                                Text = x.Suburb
                            }
                                    );

            return new SelectList(suburbs, "Value", "Text");
        }
        private IEnumerable<SelectListItem> GetStaffTypes()
        {
            IC_MotersEntities db = new IC_MotersEntities();
            var staffTypes = db.PersonTypes
                                    .Where(x=>x.PersonTypeId!=4)
                                    .Select(x => new SelectListItem
                                        {
                                            Value = x.PersonTypeId.ToString(),
                                            Text = x.PersonType1
                                        }
                                    );

            return new SelectList(staffTypes, "Value", "Text");
        }

        public ActionResult EditStaffMember(int staffId)
        {
            IC_MotersEntities db = new IC_MotersEntities();
            StaffViewClass staffToEdit;
           
            if (staffId != 0)
            {
                staffToEdit = new StaffViewClass(db.People.Find(staffId), GetSuburbs(), GetStaffTypes());
            }
            else
            {
                staffToEdit = new StaffViewClass(GetSuburbs(), GetStaffTypes());
            }

            return View(staffToEdit);
        }

        [HttpPost]
        public ActionResult EditStaffMember(StaffViewClass staffData)
        {
            IC_MotersEntities db = new IC_MotersEntities();
            var newStaff = db.People.Find(staffData.Staff.PersonId);

            newStaff.PersonId = staffData.Staff.PersonId;
            newStaff.FirstName = staffData.Staff.FirstName.Trim();
            newStaff.LastName = staffData.Staff.LastName.Trim();
            newStaff.Address1 = staffData.Staff.Address1.Trim();
            newStaff.Address2 = staffData.Staff.Address2.Trim();
            newStaff.PhoneNumber = staffData.Staff.PhoneNumber.Trim();
            newStaff.SuburbId = staffData.Staff.SuburbId;
            newStaff.Salary = staffData.Staff.Salary;
            newStaff.PersonTypeId = staffData.Staff.PersonTypeId;
            db.SaveChanges();
            return RedirectToAction("Index", "Staff");
        }
    }
}