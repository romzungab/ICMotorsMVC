using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCCIMotorsForms.Models
{
    public class StaffViewClass
    {
        [Display(Name = "Staff")]
        public StaffClass Staff { get; set; }
        [Display(Name = "Suburb")]
        public IEnumerable<SelectListItem>  SuburbTypes { get; set; }
        [Display(Name = "Employee Type")]
        public IEnumerable<SelectListItem> PersonTypes { get; set; }
      
        public int SelectedSuburb { get; set; }
        public int SelectedType { get; set; }
        public StaffViewClass() { }
        public StaffViewClass(IEnumerable<SelectListItem> suburbTypes, IEnumerable<SelectListItem> staffTypes) {

            SuburbTypes = suburbTypes;
            PersonTypes = staffTypes;
        }
        public StaffViewClass(Person staff, IEnumerable<SelectListItem> suburbTypes, IEnumerable<SelectListItem> staffTypes):this(suburbTypes, staffTypes)
        {
            Staff =new StaffClass(staff);
          
        }
    }
}