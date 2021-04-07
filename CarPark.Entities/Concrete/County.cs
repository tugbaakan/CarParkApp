using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    // ilce ilgisi
    public class County : BaseModel
    {
        public string Name { get; set; }
        public string Latitute { get; set; }
        public string Longitute { get; set; }
        public string PostCode { get; set; }


    }
}
