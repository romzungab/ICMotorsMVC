using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCCIMotorsForms.Models
{
    public class CustomerClass : PersonClass
    {
        public CustomerClass() { }
        public CustomerClass(Person p):base(p) {
         
        }
    }
}