using System;
using System.Collections.Generic;
using System.Data.Entity;
using CMS.Dtos;
using CMS.Models.CMSModel;
using System.Linq;
using System.Web.Http;
using AutoMapper;

namespace CMS.Controllers.API
{
    public class EventsController : ApiController
    {
        private readonly CmsContext _cms;

        public EventsController()
        {
            _cms = new CmsContext();
        }

        //        //  Get /api/myEvents
        //        //  Endpoint for device to get events for it's location
        //        [HttpGet]
        //        [Route("api/myEvents")]
        //        public IHttpActionResult GetEventsByLocation()
        //        {
        //            IEnumerable<Event> eventsQuery = new CMS.Controllers.EventsController().GetEventList();
        //            var data = AutoMapper.Mapper.Map<List<EventDto>>(eventsQuery);
        //            return Ok(data);
        //        }


        // Get /api/evnts
        public IHttpActionResult GetEvents()
        {
            var eventsQuery = _cms.Events
                .Include(d => d.AssociatedEventCategory)
                .Include(d => d.AssociatedLocation)
                .Include(d => d.AssociatedOrganiser);

            var evntDtos = eventsQuery
                .ToList()
                .Select(Mapper.Map<Event, EventDto>);

            return Ok(evntDtos);
        }

        // Get /api/evnt/1
        public IHttpActionResult GetEvent(int id)
        {
            var evnt = _cms.Events.SingleOrDefault(d => d.EventId == id);

            if (evnt == null)
                return NotFound();

            return Ok(Mapper.Map<Event, EventDto>(evnt));
        }

        // Post /api/evnt
        [HttpPost]
        public IHttpActionResult CreateEvent(EventDto eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var evnt = Mapper.Map<EventDto, Event>(eventDto);
            _cms.Events.Add(evnt);
            _cms.SaveChanges();

            eventDto.EventId = evnt.EventId;

            return Created(new Uri(Request.RequestUri + "/" + evnt.EventId), eventDto);
        }

        //  Put /api/evnts/1
        [HttpPut]
        public IHttpActionResult UpdateEvent(int id, EventDto eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var evntInDb = _cms.Events.SingleOrDefault(d => d.EventId == id);

            if (evntInDb == null)
                return NotFound();

            Mapper.Map(eventDto, evntInDb);
            _cms.SaveChanges();

            return Ok();
        }

        //  Delete /api/evnts/1
        [HttpDelete]
        public IHttpActionResult DeleteEvent(int id)
        {
            var evntInDb = _cms.Events.SingleOrDefault(d => d.EventId == id);

            if (evntInDb == null)
                return NotFound();

            _cms.Events.Remove(evntInDb);
            _cms.SaveChanges();

            return Ok();
        }
    }
}