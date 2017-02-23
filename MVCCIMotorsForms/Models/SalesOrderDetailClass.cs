using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCIMotorsForms.Models
{
    public class SalesOrderDetailClass
    {
        public ProductClass Product { get; set; }
        public int Quantity { get; set; }

        public SalesOrderDetailClass(Product p) {
            Product.CatagoryId = p.CatagoryId;
            Product.Category = p.ProductCatagory.Catagory;
            Product.Name = p.Name;
            Product.Price = p.Price;
            Product.ProductId = p.ProductId;
            Quantity = 1;

        }
    }
}