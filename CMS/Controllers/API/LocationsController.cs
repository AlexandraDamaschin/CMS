using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using CMS.Dtos;
using CMS.Models;
using CMS.Models.CMSModel;

namespace CMS.Controllers.API
{
    public class LocationsController : ApiController
    {
        private readonly CmsContext _cms;

        public LocationsController()
        {
            _cms = new CmsContext();
        }

        // Get /api/locations
        public IEnumerable<LocationDto>  GetLocations()
        {
            var locationsQuery = _cms.Locations;

            return locationsQuery
                .ToList()
                .Select(Mapper.Map<Location, LocationDto>);
        }


        // Get /api/location/1
        public IHttpActionResult GetLocation(int id)
        {
            var location = _cms.Locations.SingleOrDefault(m => m.LocationId == id);

            if (location == null)
                return NotFound();

            return Ok(Mapper.Map<Location, LocationDto>(location));
        }

        // Post /api/location
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageLocations)]
        public IHttpActionResult CreateLocation(LocationDto locationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var location = Mapper.Map<LocationDto, Location>(locationDto);
            _cms.Locations.Add(location);
            _cms.SaveChanges();

            locationDto.LocationId = location.LocationId;

            return Created(new Uri(Request.RequestUri + "/" + location.LocationId), locationDto);
        }

        //  Put /api/locations/1
        [HttpPut]
        public IHttpActionResult UpdateLocation(int id, LocationDto locationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var locationInDb = _cms.Locations.SingleOrDefault(m => m.LocationId == id);

            if (locationInDb == null)
                return NotFound();

            Mapper.Map(locationDto, locationInDb);
            _cms.SaveChanges();

            return Ok();
        }

        //  Delete /api/locations/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageLocations)]
        public IHttpActionResult DeleteLocation(int id)
        {
            var locationInDb = _cms.Locations.SingleOrDefault(m => m.LocationId == id);

            if (locationInDb == null)
                return NotFound();

            _cms.Locations.Remove(locationInDb);
            _cms.SaveChanges();

            return Ok();
        }
    }
}
