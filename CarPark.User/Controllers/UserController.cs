using CarPark.Core.Repository.Abstract;
using CarPark.Entities.Concrete;
using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{
    public class UserController : Controller
    {

        private readonly IStringLocalizer<UserController> _localizer;
        private readonly IRepository<Personnel> _personnelRepository;

        public UserController(IStringLocalizer<UserController> localizer
            , IRepository<Personnel> personnelRepository
        )
        {
            _localizer = localizer;
            _personnelRepository = personnelRepository;
        }
        public IActionResult Index()
        {
            var nameSurnameValue = _localizer["nameSurname"];
            return View();
        }

        public IActionResult Create()
        {

            /*var result = _personnelRepository.InsertOne(new Personnel
            {
                UserName = "akantugba",
                Password = "1234",
                Email = "akan.tugba@gmail.com"
            });

            var result2 = _personnelRepository.InsertOneAsync(new Personnel
            {
                UserName = "akantugba2",
                Password = "123422",
                Email = "akan.tugba2@gmail.com"
            }); */

            /*  var result3 = _personnelRepository.InsertMany(new List<Personnel> 
              {
                  new Personnel{
                      UserName = "akantugba3",
                      Password = "12343",
                      Email = "akan.tugba3@gmail.com"
                  },
                  new Personnel{
                      UserName = "akantugba4",
                      Password = "12344",
                      Email = "akan.tugba4@gmail.com"
                  },
                  new Personnel{
                      UserName = "akantugba5",
                      Password = "12345",
                      Email = "akan.tugba5@gmail.com"
                  }
              }); */

            
            var result4 = _personnelRepository.AsQuerable();
            var result5 = _personnelRepository.DeleteOne(x => x.Email.Contains("akan.tugba4@gmail.com"));
            var result6 = _personnelRepository.GetById("606c27e9a234aff3cd44a54b");
            result6.Entity.UserName = "akantugba6";
            result6.Entity.Password = "12346";
            result6.Entity.Email = "akan.tugba6@gmail.com";
            var result7 = _personnelRepository.ReplaceOne( result6.Entity.Id.ToString(), result6.Entity );

            return View();

        }
        
        [HttpPost]
        public IActionResult Create(UserCreateRequestModel request)
        {

            return View(request);
        
        }
    }
}
