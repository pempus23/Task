using AutoMapper;
using System.Web.Http;
using Task.Models;
using TaskDAL.Repositpry;

namespace Task.Controllers
{
    [RoutePrefix("api/Ann")]
    public class HomeController : ApiController
    {
        private readonly IRepository<Announcement> _repository;
        private readonly IMapper _mapper;
        public HomeController(IRepository<Announcement> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
