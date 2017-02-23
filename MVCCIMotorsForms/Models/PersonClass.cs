using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCCIMotorsForms.Models
{
    public class PersonClass
    {

        [Display(Name = "ID ")]
        public int PersonId { get; set; }
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name  ")]
        public string LastName { get; set; }
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
         [Display(Name = "SuburbId")]
        public int SuburbId { get; set; }
        [Display(Name = "Person Type Id")]
        public int PersonTypeId { get; set; }


        [Display(Name = "Suburb")]
        public string Suburb { get; set; }
        [Display(Name = "Employee Type")]
        public string EmployeeType { get; set; }
        public PersonClass() { }
        public PersonClass(Person p)
        {

            PersonId = p.PersonId;
            PersonTypeId = p.PersonTypeId;
            FirstName = p.FirstName;
            LastName = p.LastName;
            Address1 = p.Address1;
            Address2 = p.Address2;
            SuburbId = p.SuburbId;
            PhoneNumber = p.PhoneNumber;

        }


    }
}