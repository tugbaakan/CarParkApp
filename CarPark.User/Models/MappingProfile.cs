using AutoMapper;
using CarPark.Entities.Concrete;
using CarPark.Models.ViewModels.Personnels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Personnel, PersonnelProfileInfo>().ReverseMap();

        }
    }
}
