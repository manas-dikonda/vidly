using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customers, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customers>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movies, MovieDto>();
            Mapper.CreateMap<MovieDto, Movies>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
        }
    }
}