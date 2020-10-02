using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithCodeFirstApproch.Models
{
    public class MovieV2
    {
        public int movieId { get; set; }
        public string movieName { get; set; }
        public string movieDescription { get; set; }
        public string Type { get; set; }
    }
}
