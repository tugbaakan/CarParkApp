using CarPark.Core.Settings;
using CarPark.DataAccess.Abstract;
using CarPark.DataAccess.Context;
using CarPark.DataAccess.Repository;
using CarPark.Entities.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.DataAccess.Concrete
{
    public class PersonnelRepository : MongoRepositoryBase<Personnel>, IPersonnelRepository
    {
        private readonly MongoDBContext _context;
        private readonly IMongoCollection<Personnel> _collection; 
        public PersonnelRepository(IOptions<MongoSettings> settings) : base(settings)
        {
            _context = new MongoDBContext(settings);
            _collection = _context.GetCollection<Personnel>();
        }
    }
}
