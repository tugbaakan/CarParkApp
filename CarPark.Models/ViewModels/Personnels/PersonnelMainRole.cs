using AspNetCore.Identity.MongoDbCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Models.ViewModels.Personnels
{
    public class PersonnelMainRole
    {
        public List<MongoIdentityRole> Roles { get; set;}
        public List<PersonnelRole> PersonnelRoleList { get; set; }
    }

    public class PersonnelRole
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

}
