using CarPark.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Models.ViewModels.Personnels
{
    public class PersonnelProfileInfo
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string CityName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string ReceiveNotification { get; set; }
        public string ReceiveMessage { get; set; }
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}
