using AutoMapper;
using CMS.Dtos;
using CMS.Models;
using CMS.Models.CMSModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace CMS.Controllers.API
{
    public class DevicesController : ApiController
    {
        private readonly CmsContext _cms;

        public DevicesController()
        {
            _cms = new CmsContext();
        }

        // Get /api/devices
        public IEnumerable<DeviceDto> GetDevices(string query = null)
        {
            var devicesQuery = _cms.Devices
                .Include(d => d.AssociatedLocation);

            if (!string.IsNullOrWhiteSpace(query))
                devicesQuery = devicesQuery.Where(m => m.Name.Contains(query));


            return devicesQuery
                .ToList()
                .Select(Mapper.Map<Device, DeviceDto>);
        }

        // Get /api/device/1
        public IHttpActionResult GetDevice(int id)
        {
            var device = _cms.Devices.SingleOrDefault(d => d.DeviceId == id);

            if (device == null)
                return NotFound();

            return Ok(Mapper.Map<Device, DeviceDto>(device));
        }

        // Post /api/device
        [HttpPost]
        [Authorize(Roles = RoleHelper.CanManageDevices)]
        public IHttpActionResult CreateDevice(DeviceDto deviceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var device = Mapper.Map<DeviceDto, Device>(deviceDto);
            _cms.Devices.Add(device);
            _cms.SaveChanges();

            deviceDto.DeviceId = device.DeviceId;

            return Created(new Uri(Request.RequestUri + "/" + device.DeviceId), deviceDto);
        }

        //  Put /api/devices/1
        [HttpPut]
        public IHttpActionResult UpdateDevice(int id, DeviceDto deviceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var deviceInDb = _cms.Devices.SingleOrDefault(d => d.DeviceId == id);

            if (deviceInDb == null)
                return NotFound();

            Mapper.Map(deviceDto, deviceInDb);

            _cms.SaveChanges();
            return Ok();
        }

        //  Delete /api/devices/1
        [HttpDelete]
        [Authorize(Roles = RoleHelper.CanManageDevices)]
        public IHttpActionResult DeleteDevice(int id)
        {
            var deviceInDb = _cms.Devices.SingleOrDefault(d => d.DeviceId == id);

            if (deviceInDb == null)
                return NotFound();

            _cms.Devices.Remove(deviceInDb);
            _cms.SaveChanges();

            return Ok();
        }
    }
}
