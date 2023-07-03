using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demeter.Application.Requests;
using Demeter.Domain.FoodDomain;

namespace Demeter.Application.Mappings
{
    public class MealMappings: Profile
    {
        public MealMappings()
        {
            CreateMap<Meal, MealDTO>()
                .ForMember(dest => dest.DateRegistered, opt => opt.MapFrom(src => src.DateRegistered.ToString("MM-dd-yyyy")))
                .ForMember(dest => dest.Foods, opt => opt.MapFrom(src => src.Foods));

            CreateMap<MealDTO, Meal>()
                .ForMember(dest => dest.DateRegistered, opt => opt.MapFrom(src => DateTime.Parse(src.DateRegistered)))
                .ForMember(dest => dest.Foods, opt => opt.MapFrom(src => src.Foods));
        }
    }
}
