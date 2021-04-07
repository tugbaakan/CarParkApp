using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    public class BaseModel
    {
        // dependecies - manage nuget packages - install mongodb.driver
        [BsonId]
        public ObjectId Id { get; set; }

    }
}
