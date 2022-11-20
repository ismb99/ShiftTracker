using AutoMapper;
using ShiftTracker.API.Models;
using ShiftTracker.API.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.API.Mapping
{
    public class MappingConfig : Profile

    {
        public MappingConfig()
        {
            CreateMap<Shift, ShiftDTO>().ReverseMap();
            CreateMap<Shift, CreateShiftDTO>().ReverseMap();
            CreateMap<Shift, UpdateShiftDTO>().ReverseMap();
        }
    }
}
