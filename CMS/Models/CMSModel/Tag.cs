using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS.Models.CMSModel
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Event> AssociatedEvents { get; set; }
    }
}