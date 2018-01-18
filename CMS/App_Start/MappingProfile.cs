using AutoMapper;
using CMS.Dtos;
using CMS.Models.CMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Device, DeviceDto>();
            CreateMap<DeviceDto, Device>();
        }
    }
}