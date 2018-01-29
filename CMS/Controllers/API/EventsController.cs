using AutoMapper;
using CMS.Models.CMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMS.Controllers.API
{
    public class EventsController : ApiController
    {
        private CmsContext _cms;

        public EventsController()
        {
            _cms = new CmsContext();
        }
        [HttpGet]
        //using route I can specify what URL i want to use for the api end point
        [Route("api/events")]
        public IHttpActionResult GetDevices()
        {
            //since there are two controllers of the same name, I need to prefix the controller with the namespace to target the correct one.
            IEnumerable<Event> eventsQuery = new CMS.Controllers.EventsController().GetEventList();
            var data = AutoMapper.Mapper.Map<List<DeviceDto>>(eventsQuery);
            return Ok(data);
        }
        // Get /api/event/1
        public IHttpActionResult GetEvent(int id)
        {
            var device = _cms.Devices.SingleOrDefault(d => d.DeviceId == id);

            if (device == null)
                return NotFound();

            return Ok(Mapper.Map<Device, DeviceDto>(device));
        }

        // Post /api/device
        [HttpPost]
        public IHttpActionResult CreateEvent(DeviceDto deviceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Event = Mapper.Map<DeviceDto, Device>(deviceDto);
            _cms.Devices.Add(device);
            _cms.SaveChanges();

            deviceDto.DeviceId = device.DeviceId;

            return Created(new Uri(Request.RequestUri + "/" + device.DeviceId), deviceDto);
        }

        //  Put /api/events/1
        [HttpPut]
        public IHttpActionResult UpdateEvent(int id, DeviceDto deviceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var eventInDb = _cms.Devices.SingleOrDefault(d => d.DeviceId == id);

            if (eventInDb == null)
                return NotFound();

            Mapper.Map(deviceDto, eventInDb);

            _cms.SaveChanges();

            return Ok();
        }

        //  Delete /api/devices/1
        [HttpDelete]
        public IHttpActionResult DeleteEvent(int id)
        {
            var eventInDb = _cms.Devices.SingleOrDefault(d => d.DeviceId == id);

            if (eventInDb == null)
                return NotFound();

            _cms.Events.Remove(eventInDb);
            _cms.SaveChanges();

            return Ok();
        }
    }
}
