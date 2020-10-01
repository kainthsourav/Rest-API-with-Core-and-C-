using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiWithCodeFirstApproch
{
    public class Products
    {
        [Key]
        public int productID { get; set; }
        [Required,MaxLength(15)]
        public string productName { get; set; }
        [Required]
        public string productPrice { get; set; }
    }
}
