﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CMS.Dtos;

namespace CMS.Models.CMSModel
{
    [Table("Location")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }
        public float LAT { get; set; }
        public float LONG { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Event> events { get; set; }
        public virtual ICollection<Device> devices { get; set; }
    }
}