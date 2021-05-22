using AspNetCore.Identity.MongoDbCore.Models;
using CarPark.Business.Abstract;
using CarPark.Core.Models;
using CarPark.DataAccess.Abstract;
using CarPark.Entities.Concrete;
using CarPark.Models.ViewModels.Personnels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Business.Concrete
{
    public class PersonnelManager : IPersonnelService
    {
        private readonly IPersonnelRepository _personnelRepository;
        private readonly RoleManager<MongoIdentityRole> _roleManager;

        public PersonnelManager(IPersonnelRepository personnelRepository
            , RoleManager<MongoIdentityRole> roleManager )
        {
            _personnelRepository = personnelRepository;
            _roleManager = roleManager;
        }

        public GetManyResult<Personnel> GetPersonnelsHasEmailAddress()
        {
            var personnels = _personnelRepository.FilterBy(x => x.Email != null);
            return personnels;
        }

        public GetManyResult<Personnel> GetAllPersonnels()
        {
            var personnels = _personnelRepository.GetAll();
            return personnels;
        }

        public async Task<GetOneResult<PersonnelMainRole>> GetPersonnelRoles(string id)
        {
            var result = new GetOneResult<PersonnelMainRole>();
            try
            {
                
                var roles = _roleManager.Roles != null ? _roleManager.Roles.ToList() : null;

                var personnel = await _personnelRepository.GetByIdAsync(id, "guid");
                var personnelRoles = personnel != null && personnel.Entity != null && personnel.Entity.Roles != null
                    ? personnel.Entity.Roles.Select(x => new PersonnelRole
                    {
                        Id = x.ToString(),
                        Name = roles.FirstOrDefault(y => y.Id == x).Name
                    }).ToList() : null;

                result.Entity = new PersonnelMainRole { Roles = roles, PersonnelRoleList = personnelRoles };
                result.Success = true;
            }
            catch( Exception ex)
            {
                result.Entity = null;
                result.Success = false;
            }

            return result;
        }

        public async Task<GetOneResult<Personnel>> UpdatePersonnelRoles(string personnelId, string[] personnelRoleList)
        {
            var personnel = await _personnelRepository.GetByIdAsync(personnelId, "guid");
            var roles = personnelRoleList.Select(x => new Guid()).ToList();

            personnel.Entity.Roles = null;
            personnel.Entity.Roles = roles;
            var result = await _personnelRepository.ReplaceOneAsync(personnelId, personnel.Entity, "guid");
            result.Message = $"{personnel.Entity.Name} {personnel.Entity.Surname} adlı personelin rol güncellemesi gerçekleşti.";
            return result;
        }
    }
}
