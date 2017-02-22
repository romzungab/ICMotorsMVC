using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCCIMotorsForms.Models
{
    public class StaffClass:PersonClass
    {
               
        [Display(Name = "Salary")]
        public Nullable<decimal> Salary { get; set; }
        

              
        
    }
}