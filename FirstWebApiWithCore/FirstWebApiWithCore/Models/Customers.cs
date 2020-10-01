using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FirstWebApiWithCore.Models
{
    public class Customers
    {
        [Required]
        public int customerID { get; set; }
        [Required,StringLength(15)]
        public string customerName { get; set; }
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$",ErrorMessage ="Email Format Not Valid")]
        public string customerEmail { get; set; }
        public string customePhone { get; set; }

    }
}
