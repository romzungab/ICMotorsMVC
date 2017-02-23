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
        [Display(Name = "Customer List")]
        public List<CustomerClass> Customers { get; set; }
        [Display(Name = "Search Key")]
        public string SearchKey { get; set; }
        [Display(Name = "Suburb")]
        public IEnumerable<SelectListItem> SuburbTypes { get; set; }
        [Display(Name = "Employee Type")]
        public IEnumerable<SelectListItem> PersonTypes { get; set; }

        public CustomerViewClass() { }
        public CustomerViewClass(IEnumerable<SelectListItem> suburbTypes)
        {

            SuburbTypes = suburbTypes;
            
        }

        public CustomerViewClass(Person person, IEnumerable<SelectListItem> suburbTypes) : this(suburbTypes)
        {
            Customers = new List<CustomerClass>();
            var customer = new CustomerClass(person);
            Customers.Add(customer);

        }
    }
}