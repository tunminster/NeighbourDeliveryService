using AutoMapper;
using NeighbourDelivery.Core.Dtos;
using NeighbourDelivery.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbourDelivery.Core.MapperConfig
{
    public class NdContextProfile : Profile
    {
        public NdContextProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
