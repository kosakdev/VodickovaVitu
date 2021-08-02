﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models.Calendar
{
    public class CalendarDetailModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        [Display(Name="Popis")]
        public string Description { get; set; }
        [Display(Name="Datum")]
        public DateTime DateTime { get; set; }
        public string Place { get; set; }
        public Guid EventTypeId { get; set; }
    }
}