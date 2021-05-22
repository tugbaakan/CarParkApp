using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    [CollectionName("Personnel")]
    public class Personnel : MongoIdentityUser
    {
        public PersonnelContact PersonnelContact { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public short Status { get; set; } = 1;
        public DateTime CreatedDate {get; set;} = DateTime.Now;
        public DateTime? UpdatedDate {get; set;}
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool ReceiveNotification { get; set; }
        public bool ReceiveMessage { get; set; }
        public string ImageUrl { get; set; }
        public string CityName { get; set; }

    }
}
