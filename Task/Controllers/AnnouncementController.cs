using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
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
        [HttpGet, Route("{id}", Name = "DisplayRoute")]
        [ResponseType(typeof(AnnouncementDTO))]
        public async Task<IHttpActionResult> GetOne(int id)
        {
            Announcement item = _repository.GetOne(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AnnouncementDTO>(item));
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
        [HttpPut, Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChange(int id, Announcement item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != item.Id)
            {
                return BadRequest();
            }
            try
            {
                _repository.Save(item);
            }
            catch (Exception ex)
            {
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
        [HttpGet, Route("similar/{id}")]
        [ResponseType(typeof(List<AnnouncementDTO>))]
        public IHttpActionResult GetSimilar(int id)
        {
            List<Announcement> item = _repository.Similar(id);
  
            return Ok(_mapper.Map<List<AnnouncementDTO>>(item));
        }
    }
}
