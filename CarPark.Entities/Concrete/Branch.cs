using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    public class Branch : BaseModel
    {
        public string Name { get; set; }
        public string[] PhoneNumbers { get; set; }
        public Address Address {get;set;}
        public ICollection<Personnel> Personnels { get; set; }
        public string WebSite { get; set; }
        public string[] EmailAddresses { get; set; }
        public ICollection<WorkingDay> WorkingDays { get; set; }
        public ICollection<FloorInformation> Floors { get; set; }


    }
}
