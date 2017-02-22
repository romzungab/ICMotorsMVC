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
        [Display(Name = "Staff List")]
        public List<StaffClass> Staffs { get; set; }
        [Display(Name = "Search Key")]
        public string SearchKey { get; set; }
        [Display(Name = "Suburb")]
        public IEnumerable<SelectListItem> SuburbTypes { get; set; }
        [Display(Name = "Employee Type")]
        public IEnumerable<SelectListItem> PersonTypes { get; set; }
    }
}