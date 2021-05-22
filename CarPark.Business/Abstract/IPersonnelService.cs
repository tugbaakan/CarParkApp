using CarPark.Core.Models;
using CarPark.Entities.Concrete;
using CarPark.Models.ViewModels.Personnels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Business.Abstract
{
    public interface IPersonnelService
    {
        GetManyResult<Personnel> GetPersonnelsHasEmailAddress();
        GetManyResult<Personnel> GetAllPersonnels();
        Task<GetOneResult<PersonnelMainRole>> GetPersonnelRoles(string id);
        Task<GetOneResult<Personnel>> UpdatePersonnelRoles(string personnelId, string[] personnelRoleList);
        
    }
}
