using AutoMapper;
using CMS.Dtos;
using CMS.Models.CMSModel;
using System;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;


namespace CMS.Controllers.API
{

    public class DevicesController : ApiController
    {
        private CMSContext _cms;

        public DevicesController()
        {
            _cms = new CMSContext();
        }

        // Get /api/devices
        public IHttpActionResult GetDevices()
        {
            var devicesQuery = _cms.Devices
                .Include(d => d.associatedLocation);

            var deviceDtos = devicesQuery
                .ToList()
                .Select(Mapper.Map<Device, DeviceDto>);

            return Ok(deviceDtos);



            //return Ok(_cms.Devices.ToList().Select(Mapper.Map<Device, DeviceDto>));
        }

        // Get /api/device/1
        public IHttpActionResult GetDevice(int id)
        {
            var device = _cms.Devices.SingleOrDefault(d => d.DeviceID == id);

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

            deviceDto.DeviceID = device.DeviceID;

            return Created(new Uri(Request.RequestUri + "/" + device.DeviceID), deviceDto);
        }

        //  Put /api/devices/1
        [HttpPut]
        public IHttpActionResult UpdateDevice(int id, DeviceDto deviceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var deviceInDb = _cms.Devices.SingleOrDefault(d => d.DeviceID == id);

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
            var deviceInDb = _cms.Devices.SingleOrDefault(d => d.DeviceID == id);

            if (deviceInDb == null)
                return NotFound();

            _cms.Devices.Remove(deviceInDb);
            _cms.SaveChanges();

            return Ok();
        }
    }
}
