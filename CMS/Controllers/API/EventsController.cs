using System;
using System.Collections.Generic;
using System.Data.Entity;
using CMS.Dtos;
using CMS.Models.CMSModel;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using CMS.Models;

namespace CMS.Controllers.API
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EventsController : ApiController
    {
        private readonly CmsContext _cms;

        public EventsController()
        {
            _cms = new CmsContext();
        }

        //  Get /api/myEvents/1
        //  Endpoint for device to get events for it's location
        [HttpGet]
        [Route("api/myEvents/{id}")]
        public IHttpActionResult GetEventsByLocation(int id)
        {
            var eventsQuery = new Controllers.EventsController().GetLocationEventList(id);
            var data = Mapper.Map<List<EventDto>>(eventsQuery);
            return Ok(data);
        }

        // Get /api/eventCategories
        public IEnumerable<EventDto> GetEvents(string query = null)
        {
            var eventsQuery = _cms.Events
                .Include(m => m.AssociatedEventCategory)
                .Include(m => m.AssociatedLocation)
                .Include(m => m.AssociatedOrganiser)
                .Where(m => m.Priority > 0);

            if (!string.IsNullOrWhiteSpace(query))
                eventsQuery = eventsQuery.Where(m => m.Name.Contains(query));

            return eventsQuery
                .ToList()
                .Select(Mapper.Map<Event, EventDto>);
        }


        // Get /api/event/1
        public IHttpActionResult GetEvent(int id)
        {
            var evnt = _cms.Events.SingleOrDefault(d => d.EventId == id);

            if (evnt == null)
                return NotFound();

            return Ok(Mapper.Map<Event, EventDto>(evnt));
        }

        // Post /api/event
        [HttpPost]
        [Authorize(Roles = RoleHelper.CanManageEvents)]
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

        //  Put /api/events/1
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

        //  Delete /api/events/1
        [HttpDelete]
        [Authorize(Roles = RoleHelper.CanManageEvents)]
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