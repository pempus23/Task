using AutoMapper;
using Task.Models;
using Task.Models.DTO;

namespace Task.Infrastructure
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Announcement, AnnouncementDTO>();
        }
    }
}