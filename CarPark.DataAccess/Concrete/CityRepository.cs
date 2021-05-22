using CarPark.Core.Settings;
using CarPark.DataAccess.Abstract;
using CarPark.DataAccess.Repository;
using CarPark.Entities.Concrete;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.DataAccess.Concrete
{
    public class CityRepository : MongoRepositoryBase<City>, ICityRepository
    {
        public CityRepository(IOptions<MongoSettings> settings) : base(settings)
        {
        }
    }
}
