using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    public class Personnel : BaseModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
        public PersonnelContact PersonnelContact { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDate {get; set;} = DateTime.Now;

        public DateTime? UpdatedDate {get; set;}


    }
}
