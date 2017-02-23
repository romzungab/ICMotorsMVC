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
        [Display(Name = "Product Category")]
        public string Category { get; set; }
        [Display(Name = "Product Price ")]
        public decimal Price { get; set; }
        [Display(Name = "Quantity ")]
        public int Quantity { get; set; }

        public ProductClass() { }
        public ProductClass(Product p)
        {
            CatagoryId = p.CatagoryId;
            Category = p.ProductCatagory.Catagory;
            Name = p.Name;
            Price = p.Price;
            ProductId = p.ProductId;
            Quantity = 1;

        }

    }
}