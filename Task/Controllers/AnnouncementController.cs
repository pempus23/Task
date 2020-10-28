using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Task.Models;
using Task.Models.DTO;
using TaskDAL.Repositpry;

namespace Task.Controllers
{
    [RoutePrefix("api/Announcement")]
    public class AnnouncementController : ApiController
    {
        private readonly IRepository<Announcement> _repository;
        private readonly IMapper _mapper;
        public AnnouncementController()
        {

        }
        public AnnouncementController(IRepository<Announcement> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet, Route("")]
        public IHttpActionResult GetList()
        {
            var announcement = _repository.GetAll();
            return Ok(_mapper.Map<List<AnnouncementDTO>>(announcement));

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost, Route("")]
        [ResponseType(typeof(Announcement))]
        public IHttpActionResult PostInventory(Announcement item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _repository.Add(item);
            }
            catch (Exception ex)
            {
                //must be other actions
                throw;
            }
            return CreatedAtRoute("DisplayRoute", new { id = item.Id }, item);
        }
        [HttpDelete, Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }
    }
}
