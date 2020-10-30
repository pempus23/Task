using AutoLotDAL.Models.Base;
using System;

namespace Task.Models.DTO
{
    public class AnnouncementDTO : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
