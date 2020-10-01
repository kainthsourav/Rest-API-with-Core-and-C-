using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiWithCodeFirstApproch
{
    public class Products
    {
        [Key]
        public int productID { get; set; }
        public string productName { get; set; }
        public string productPrice { get; set; }
    }
}
