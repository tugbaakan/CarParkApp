using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    public class Translation
    {
        public string Culture { get; set; } // "tr-TR"
        public string Name { get; set; } // "Pazartesi"

    }
}
