using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demeter.Application.Requests;
using Demeter.Domain.FoodDomain;

namespace Demeter.Application.Mappings
{
    public class FoodMappings : Profile
    {
        public FoodMappings()
        {
            CreateMap<Food, FoodDTO>().ReverseMap();
        }
    }
}
