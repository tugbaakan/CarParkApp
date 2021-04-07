﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    public class Reservation : BaseModel
    {
        public string ImagePath { get; set; }
        public string Plate { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Decimal Price { get; set; }
        public bool IsExist { get; set; }
        public bool IsPayment { get; set; }        
        public ReservationDetail ReservationDetail { get; set; }


    }
}
