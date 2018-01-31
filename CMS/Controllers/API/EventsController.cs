using AutoMapper;
using CMS.Dtos;
using CMS.Models.CMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [Route("api/events")]
        public IHttpActionResult GetEvents()
        {
            IEnumerable<Event> eventsQuery = new CMS.Controllers.EventsController().GetEventList();
            var data = AutoMapper.Mapper.Map<List<EventDto>>(eventsQuery);
            return Ok(data);
        }
        // Get /api/event/1
        public IHttpActionResult GetEvent(int id)
        {
            var Event = _cms.Events.SingleOrDefault(e => e.EventId == id);

            if (Event == null)
                return NotFound();

            return Ok(Mapper.Map<Event, EventDto>(Event));
        }

        // Post /api/event
        [HttpPost]
        public IHttpActionResult CreateEvent(EventDto eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Event = Mapper.Map<EventDto, Event>(eventDto);
            _cms.Events.Add(Event);
            _cms.SaveChanges();

            eventDto.EventId = Event.EventId;

            return Created(new Uri(Request.RequestUri + "/" + Event.EventId), eventDto);
        }

        //  Put /api/events/1
        [HttpPut]
        public IHttpActionResult UpdateEvent(int id, EventDto eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var eventInDb = _cms.Events.SingleOrDefault(e => e.EventId == id);

            if (eventInDb == null)
                return NotFound();

            Mapper.Map(eventDto, eventInDb);

            _cms.SaveChanges();

            return Ok();
        }

        //  Delete /api/events/1
        [HttpDelete]
        public IHttpActionResult DeleteEvent(int id)
        {
            var eventInDb = _cms.Events.SingleOrDefault(e => e.EventId == id);

            if (eventInDb == null)
                return NotFound();

            _cms.Events.Remove(eventInDb);
            _cms.SaveChanges();

            return Ok();
        }
    }
}
