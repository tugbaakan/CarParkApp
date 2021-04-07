using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User.Models
{
    public class City
    {

        public string Name {get; set;}
        public string Plate { get; set; }
        public string Latitude {get; set;}
        public string Longitude { get; set; }
        public string[] Counties { get; set; }


    }
}
