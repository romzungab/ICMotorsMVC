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
                                         PersonTypeId = x.PersonTypeId,                                      
                                         Salary = x.Salary,
                                         PhoneNumber = x.PhoneNumber,
                                         EmployeeType = x.PersonType.PersonType1,
                                         Suburb = x.SuburbType.Suburb
                                     })
                                     .ToList();
            
            var viewModel = new StaffViewClass();
            viewModel.Staffs = stafflist;
            viewModel.SuburbTypes = GetSuburbs();
            viewModel.PersonTypes = GetStaffTypes();
            
            return View(viewModel);
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
            if (staffData.Staffs[0].PersonId != 0)
            {
                var newStaff = db.People.Find(staffData.Staffs[0].PersonId);

                newStaff.PersonId = staffData.Staffs[0].PersonId;
                newStaff.FirstName = staffData.Staffs[0].FirstName.Trim();
                newStaff.LastName = staffData.Staffs[0].LastName.Trim();
                newStaff.Address1 = staffData.Staffs[0].Address1.Trim();
                newStaff.Address2 = staffData.Staffs[0].Address2.Trim();
                newStaff.PhoneNumber = staffData.Staffs[0].PhoneNumber.Trim();
                newStaff.SuburbId = staffData.Staffs[0].SuburbId;
                newStaff.Salary = staffData.Staffs[0].Salary;
                newStaff.PersonTypeId = staffData.Staffs[0].PersonTypeId;
                
            }
            else
            {
                Person newStaff = new Person();
                newStaff.FirstName = staffData.Staffs[0].FirstName.Trim();
                newStaff.LastName = staffData.Staffs[0].LastName.Trim();
                newStaff.Address1 = staffData.Staffs[0].Address1.Trim();
                newStaff.Address2 = staffData.Staffs[0].Address2.Trim();
                newStaff.PhoneNumber = staffData.Staffs[0].PhoneNumber.Trim();
                newStaff.SuburbId = staffData.Staffs[0].SuburbId;
                newStaff.Salary = staffData.Staffs[0].Salary;
                newStaff.PersonTypeId = staffData.Staffs[0].PersonTypeId;
                db.People.Add(newStaff);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Staff");
        }
    }
}