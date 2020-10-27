﻿using AutoLotDAL.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Task.Models.DTO
{
    public class Announcement : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DataType DataAdded { get; set; }
    }
}
