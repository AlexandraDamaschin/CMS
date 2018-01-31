using CMS.Dtos;
using CMS.Models.CMSModel;
using System.Collections.Generic;
using System.Web.Http;

namespace CMS.Controllers.API
{
    public class EventsController : ApiController
    {
        [HttpGet]
        [Route("api/events")]
        public IHttpActionResult GetEvents()
        {
            IEnumerable<Event> eventsQuery = new CMS.Controllers.EventsController().GetEventList();
            var data = AutoMapper.Mapper.Map<List<EventDto>>(eventsQuery);
            return Ok(data);
        }
    }
}
