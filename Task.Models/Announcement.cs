using AutoLotDAL.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class Announcement : EntityBase
    {
        [StringLength(30)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        public DateTime DataAdded { get; set; }
    }
}
