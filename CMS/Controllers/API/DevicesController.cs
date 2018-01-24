using AutoMapper;
using CMS.Dtos;
using CMS.Models.CMSModel;
using System;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using System.Collections.Generic;
using CMS.Controllers;

namespace CMS.Controllers.API
{

    public class DevicesController : ApiController
    {
        private CmsContext _cms;

        public DevicesController()
        {
            _cms = new CmsContext();
        }

        [HttpGet]
        //using route I can specify what URL i want to use for the api end point
        [Route("api/devices")]
        public IHttpActionResult GetDevices()
        {   
            //since there are two controllers of the same name, I need to prefix the controller with the namespace to target the correct one.
            IEnumerable<Device> devicesQuery = new CMS.Controllers.DevicesController().GetDeviceList();
            var data = AutoMapper.Mapper.Map<List<DeviceDto>>(devicesQuery);
            return Ok(data);
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
