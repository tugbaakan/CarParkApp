using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static CarPark.User.Models.Test;
using Newtonsoft.Json;
using MongoDB.Bson;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Threading;

namespace CarPark.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly MongoClient client;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
            client = new MongoClient("mongodb+srv://degnekci:Carpark2021@carparkcluster.r2zce.mongodb.net/CarParkDB?retryWrites=true&w=majority");
        }

        public IActionResult Index()
        {

            //localization test
            /* var sayHello_value = _localizer["sayHello"];

            var cultureInfo = CultureInfo.GetCultureInfo("tr-TR");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            var sayHello_value2 = _localizer["sayHello"];*/

            // logging test
            /*  var customer = new Customer
            {

                Id = 1,
                NameSurname = "Tugba Akan",
                Age = 30
            };
            
            _logger.LogError("Customer da bir hata olustu {@customer}", customer);*/

            // mongodb connection test 1
            /* var collection = database.GetCollection<Test>("Test");
            var test = new Test()
            {
                _Id = ObjectId.GenerateNewId(),
                NameSurname = "Tugba Akan",
                Age = 30,
                AddressList= new List<Address>() 
                {
                    new Address(){ Title = "Ev adresi", Description = "Zümrütevler"},
                    new Address(){ Title = "İş adresi", Description = "Kozyatagi"}
                }
            };
            
            collection.InsertOne(test); */

            // mongodb connection test 2
            /* var database = client.GetDatabase("CarParkDB");

            // Dependencies- Nuget - Install Newtonsoft.Json

            var jsonString = System.IO.File.ReadAllText("cities.json");
            var cities = JsonConvert.DeserializeObject<List<City>>(jsonString);

            var citiesCollection = database.GetCollection<CarPark.Entities.Concrete.City>("City"); // city isimli modeller karışmasın diye entities'den gelen modelleri boyle tanimlıycam

            foreach ( var item in cities) 
            {
                var city = new CarPark.Entities.Concrete.City
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = item.Name,
                    Plate = item.Plate,
                    Latitude = item.Latitude,
                    Longitude = item.Longitude,
                    Counties = new List<CarPark.Entities.Concrete.County>() 
                };


                foreach (var item2 in item.Counties)
                {
                    city.Counties.Add(new CarPark.Entities.Concrete.County
                    {
                        Id = ObjectId.GenerateNewId(),
                        Name = item2,
                        Latitute = "",
                        Longitute = "",
                        PostCode = ""
                    } );
                }

                citiesCollection.InsertOne(city);
            } */

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Dashboard()
        {
            return View();
        }

    }
}
