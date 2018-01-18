using AutoMapper;
using CMS.Dtos;
using CMS.Models.CMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMS.Controllers.API
{
    [Authorize(Roles = "Admin")]
    public class DevicesController : ApiController
    {
        private CMSContext _cms;

        public DevicesController()
        {
            _cms = new CMSContext();
        }

        // Get /api/devices
        public IEnumerable<DeviceDto> GetDevices()
        {
            return _cms.Devices.ToList().Select(Mapper.Map<Device, DeviceDto>);
        }

        // Get /api/device/1
        public DeviceDto GetDevice(int id)
        {
            var device = _cms.Devices.SingleOrDefault(d => d.DeviceID == id);

            if (device == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Device, DeviceDto>(device);
        }

        // Post /api/device
        [HttpPost]
        public DeviceDto CreateDevice(DeviceDto deviceDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var device = Mapper.Map<DeviceDto, Device>(deviceDto);
            _cms.Devices.Add(device);
            _cms.SaveChanges();

            deviceDto.DeviceID = device.DeviceID;

            return deviceDto;
        }

        //  Put /api/devices/1
        [HttpPut]
        public void UpdateDevice(int id, DeviceDto deviceDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var deviceInDb = _cms.Devices.SingleOrDefault(d => d.DeviceID == id);

            if (deviceInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(deviceDto, deviceInDb);

            _cms.SaveChanges();
        }

        //  Delete /api/devices/1
        [HttpDelete]
        public void DeleteDevice(int id)
        {
            var deviceInDb = _cms.Devices.SingleOrDefault(d => d.DeviceID == id);

            if (deviceInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _cms.Devices.Remove(deviceInDb);
            _cms.SaveChanges();
        }
    }
}
