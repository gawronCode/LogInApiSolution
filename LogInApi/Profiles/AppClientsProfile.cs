using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LogInApi.Dtos;
using LogInApi.Models;

namespace LogInApi.Profiles
{
    public class AppClientsProfile : Profile
    {
        public AppClientsProfile()
        {
            CreateMap<AppClient, AppClientReadDto>();
        }
    }
}
