using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCIMotorsForms.Models
{
    public class ProductClass
    {
        [Display(Name = "Product ID ")]
        public int ProductId { get; set; }
        [Display(Name = "Product Name ")]
        public string Name { get; set; }
        [Display(Name = "Product Category Id ")]
        public int CatagoryId { get; set; }
        [Display(Name = "Product Price ")]
        public decimal Price { get; set; }
    }
}