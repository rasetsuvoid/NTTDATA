using Application.Common.Dtos.Coordinates;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mapper
{
    public class CoordinatesDtoMapper : Profile
    {
        public CoordinatesDtoMapper()
        {
            CreateMap<CoordinatesRequestDto, Coordinates>()
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));

            CreateMap<Coordinates, CoordinatesRequestDto>().ReverseMap();

        }
    }
}