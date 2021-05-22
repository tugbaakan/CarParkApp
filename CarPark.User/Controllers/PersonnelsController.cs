using AutoMapper;
using CarPark.Business.Abstract;
using CarPark.Entities.Concrete;
using CarPark.Models.ViewModels.Personnels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{

    public class PersonnelsController : Controller
    {
        private readonly IPersonnelService _personnelManager;
        private readonly ICityService _cityManager;
        private readonly UserManager<Personnel> _userManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public PersonnelsController(IPersonnelService personnelManager, ICityService cityManager
            , UserManager<Personnel> userManager, IMapper mapper, IWebHostEnvironment env)
        {
            _personnelManager = personnelManager;
            _cityManager = cityManager;
            _userManager = userManager;
            _mapper = mapper;
            _env = env;
        }

        public IActionResult GetPersonnelsHasEmailAddress()
        {
            var result = _personnelManager.GetPersonnelsHasEmailAddress();

            return View(result.Result);
        }

        public async Task<IActionResult> Settings()
        {
            var user = await _userManager.GetUserAsync(User);
            user.ImageUrl = $"/Media/Personnels/{user.ImageUrl}";
            var personnelInfo = _mapper.Map<PersonnelProfileInfo>(user);
            var cities = await _cityManager.GetAllCitiesAsync();
            personnelInfo.Cities = cities.Result;

            return View(personnelInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(PersonnelProfileInfo personnelInfo)
        {
            var user = _userManager.GetUserAsync(User).Result;
            string imgUrl = "";
            if (personnelInfo.Image != null && personnelInfo.Image.Length > 0)
            {
                var path = Path.Combine(_env.WebRootPath, "Media/Personnels/");
                var fileName = Guid.NewGuid().ToString() + "_" + personnelInfo.Image.FileName;

                var filePath = Path.Combine(path, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    personnelInfo.Image.CopyTo(fileStream);
                    imgUrl = fileName;
                }
            }
            else
            {
                imgUrl = user.ImageUrl;
            }
            personnelInfo.Username = user.UserName;
            personnelInfo.Email = user.Email;
            personnelInfo.ImageUrl = imgUrl;

            var personnel = _mapper.Map(personnelInfo, user);
            var updated = await _userManager.UpdateAsync(personnel);
            if (updated.Succeeded)
                return Json(new { message = "Başarılı", success = true, personnel = personnel });
            else
                return Json(new { message = "Başarısız", success = false, personnel = personnel });
        }

        [Authorize(Roles = "admin")]
        public IActionResult List()
        {

            var result = _personnelManager.GetAllPersonnels();
            return View(result.Result);
        }

        [Authorize(Roles = "admin")]
        [Route("getroles/{id}")]
        public async Task<IActionResult> GetRoles(string id)
        {
            return Json(await _personnelManager.GetPersonnelRoles(id));
        }
        [Authorize(Roles = "admin")]
        [Route("update/personnel/roles")]
        public async Task<IActionResult> UpdatePersonnelRoles(string personnelId, string[] personnelRoleList )
        {
            return Json(await _personnelManager.UpdatePersonnelRoles(personnelId, personnelRoleList));
        }

    }
}