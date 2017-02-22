using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCCIMotorsForms.Models
{
    public class CustomerViewClass
    {
        public CustomerClass Customer { get; set; }
        [Display(Name = "Suburb")]
        public IEnumerable<SelectListItem> SuburbTypes { get; set; }
        public int SelectedSuburb { get; set; }
        public CustomerViewClass() { }
        public CustomerViewClass(Person customer)
        {
            Customer = new CustomerClass(customer);
        }
        public CustomerViewClass(Person customer, IEnumerable<SelectListItem> suburbType):this(suburbType)
        {
            Customer = new CustomerClass(customer);
        }

        public CustomerViewClass(IEnumerable<SelectListItem> suburbType)
        {
            SuburbTypes = suburbType;
        }
    }
}