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
    public class OrganisersController : ApiController
    {
        private CmsContext _cms;

        public OrganisersController()
        {
            _cms = new CmsContext();
        }


        // Get /api/organisers
        public IEnumerable<OrganiserDto> GetOrganisers()
        {
            var organisersQuery = _cms.Organisers;
            return organisersQuery
                .ToList()
                .Select(Mapper.Map<Organiser, OrganiserDto>);
        }


        // Get /api/organiser/1
        public IHttpActionResult GetOrganiser(int id)
        {
            var organiser = _cms.Organisers.SingleOrDefault(m => m.OrganiserId == id);
            if (organiser == null)
                return NotFound();

            return Ok(Mapper.Map<Organiser, OrganiserDto>(organiser));
        }

        // Post /api/organiser
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageOrganisers)]
        public IHttpActionResult CreateOrganiser(OrganiserDto organiserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var organiser = Mapper.Map<OrganiserDto, Organiser>(organiserDto);
            _cms.Organisers.Add(organiser);
            _cms.SaveChanges();

            organiserDto.OrganiserId = organiser.OrganiserId;

            return Created(new Uri(Request.RequestUri + "/" + organiser.OrganiserId), organiserDto);
        }

        //  Put /api/organisers/1
        [HttpPut]
        public IHttpActionResult UpdateOrganiser(int id, OrganiserDto organiserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var organiserInDb = _cms.Organisers.SingleOrDefault(m => m.OrganiserId == id);

            if (organiserInDb == null)
                return NotFound();

            Mapper.Map(organiserDto, organiserInDb);
            _cms.SaveChanges();

            return Ok();
        }

        //  Delete /api/organisers/1
        [HttpDelete]
        public IHttpActionResult DeleteOrganiser(int id)
        {
            var organiserInDb = _cms.Organisers.SingleOrDefault(m => m.OrganiserId == id);

            if (organiserInDb == null)
                return NotFound();

            _cms.Organisers.Remove(organiserInDb);
            _cms.SaveChanges();

            return Ok();
        }
    }
}