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
            CreateMap<Location, LocationDto>();
            CreateMap<LocationDto, Location>();
            CreateMap<Organiser, OrganiserDto>();
            CreateMap<OrganiserDto, Organiser>();
            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();
            CreateMap<EventCategory, EventCategoryDto>();
            CreateMap<EventCategoryDto, EventCategory>();
        }
    }
}